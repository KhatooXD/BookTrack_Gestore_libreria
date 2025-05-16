using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using BookTrack.Classi;
using BookTrack.Management_Class;

namespace BookTrack.Forms
{
    public partial class StoricoPrestitiForm : Form
    {
        #region dichiarazione variabili private
        private Cliente cliente; //variabile che gestisce il cliente nella form degli storici
        private ListView lvStorico; //creazione di una listview per gli storici dei prestiti
        private Button btnRestituisci; //creazione di un bottone con la funzione di restituire il libro in prestito
        #endregion

        #region costruttore della form 
        public StoricoPrestitiForm(Cliente cliente)
        {
            this.cliente = cliente;

            Text = $"Storico Prestiti di {cliente.Nome}"; //testo della form
            Size = new Size(600, 450); //misura della form
            StartPosition = FormStartPosition.CenterParent; //posizione di partenza quando viene avviata
            FormBorderStyle = FormBorderStyle.FixedDialog; //stile bordo della form
            MaximizeBox = false; //la form non può essere ingrandita

            //creazione della listview
            lvStorico = new ListView
            {
                View = View.Details, //tipo di visualizzazione: details
                FullRowSelect = true, //imposto a true  la selezione riga intera
                GridLines = true, //imposto a true le linee della griglia
                Dock = DockStyle.Top, //dock style a top
                Height = 350 //altezza della listview di 350
            };
            lvStorico.Columns.Add("Titolo", 200);
            lvStorico.Columns.Add("Data Prestito", 100);
            lvStorico.Columns.Add("Data Fine", 100);
            lvStorico.Columns.Add("Giorni Rimasti", 100);
            Controls.Add(lvStorico); //aggiunge i controlli alla listview dello storico dei libri

            //creazione del bottone per restituire il libro in prestito
            btnRestituisci = new Button
            {
                Text = "Restituisci Libro Selezionato",
                Dock = DockStyle.Bottom,
                Height = 40,
                Enabled = false //disabilita il bottone
            };

            //collega il click del pulsante btnRestituisci al metodo BtnRestituisci_Click
            btnRestituisci.Click += BtnRestituisci_Click;
            Controls.Add(btnRestituisci);

            //collega la selezione della listview al metodo lvStorico_SelectedIndexChanged
            lvStorico.SelectedIndexChanged += lvStorico_SelectedIndexChanged;

            CaricaPrestiti();
        }
        #endregion

        #region metodo per gestire la scelta col cursore sulla listview
        private void lvStorico_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRestituisci.Enabled = lvStorico.SelectedItems.Count > 0;
        }
        #endregion

        #region metodo per caricare i prestiti nella listview
        private void CaricaPrestiti()
        {
            //svuota la listview prima di caricare i dati
            lvStorico.Items.Clear();

            //carica tutti i prestiti dal file
            List<Prestito> tuttiPrestiti = GestorePrestiti.CaricaPrestiti();
            //crea una lista filtrata dei prestiti del cliente attuale
            List<Prestito> prestiti = new List<Prestito>();
            foreach (Prestito Prestito in tuttiPrestiti)
            {
                if (Prestito.IDCliente == cliente.ID)
                {
                    prestiti.Add(Prestito); //aggiunge alla lista solo i prestiti fatti dal cliente loggato
                }
            }

            //carica tutti i libri dal file
            List<Libro> libri = GestoreLibri.CaricaLibri();

            foreach (Prestito prestito in prestiti)
            {
                Libro libro = null;

                //cerca il libro associato al prestito tramite l'ID
                foreach (Libro book in libri)
                {
                    if (book.ID == prestito.IDLibro)
                    {
                        libro = book;
                        break;
                    }
                }

                if (libro == null)
                {
                    continue; //se il libro non viene trovato, salta al prossimo prestito
                }

                //calcola i giorni rimasti alla scadenza del prestito
                int giorniRimasti = (prestito.DataFine - DateTime.Now).Days;
                if (giorniRimasti < 0)
                {
                    giorniRimasti = 0;
                }

                //aggiunge i dettagli del prestito alla listview
                ListViewItem item = new ListViewItem(libro.Titolo);
                item.SubItems.Add(prestito.DataInizio.ToShortDateString());
                item.SubItems.Add(prestito.DataFine.ToShortDateString());
                item.SubItems.Add(giorniRimasti.ToString());
                item.Tag = prestito;

                lvStorico.Items.Add(item);
            }

            if (lvStorico.Items.Count == 0)
            {
                MessageBox.Show("Nessun prestito trovato.", "Vuoto"); 
                Close(); //chiude la form
            }
        }
        #endregion

        #region bottone per restituire il libro preso in prestito
        private void BtnRestituisci_Click(object sender, EventArgs e)
        {
            if (lvStorico.SelectedItems.Count == 0)
            {
                return; //se non c'è nessun elemento selezionato, esce dal metodo
            }

            //prende l'elemento selezionato
            ListViewItem selezionato = lvStorico.SelectedItems[0];
            //recupera l'oggetto Prestito associato all'elemento
            Prestito prestito = (Prestito)selezionato.Tag;

            //crea una messagebox dove ti chiede se vuoi restituire il libro (schiacci si se acconsenti, viceversa se non vuoi)
            DialogResult conferma = MessageBox.Show($"Restituire \"{selezionato.Text}\"?", "Conferma", MessageBoxButtons.YesNo);

            if (conferma != DialogResult.Yes)
            {
                return; 
            }

            //carica tutti i prestiti dal file
            List<Prestito> tuttiPrestiti = GestorePrestiti.CaricaPrestiti();
            List<Prestito> nuoviPrestiti = new List<Prestito>();

            foreach (Prestito prestiti in tuttiPrestiti)
            {
                //controlla se il prestito è diverso da quello da rimuovere
                if (prestiti.ID != prestito.ID)
                {
                    nuoviPrestiti.Add(prestiti);
                }
            }
            //salva i nuovi prestiti aggiornati (senza quello restituito)
            GestorePrestiti.SalvaPrestiti(nuoviPrestiti);
            //carica tutti i libri
            List<Libro> libri = GestoreLibri.CaricaLibri();
            foreach (Libro libro in libri)
            {
                if (libro.ID == prestito.IDLibro)
                {
                    libro.Disponibile = true;
                    GestoreLibri.AggiornaLibro(libro);
                    break;
                }
            }

            CaricaPrestiti(); 
            MessageBox.Show("Libro restituito."); 
        }
        #endregion
    }
}
