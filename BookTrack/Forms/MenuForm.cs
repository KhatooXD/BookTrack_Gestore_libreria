using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BookTrack.Classi;
using BookTrack.Management_Class;

namespace BookTrack.Forms
{
    public partial class MenuForm : Form
    {
        #region dichiarazione variabili private
        private Cliente cliente;
        private ComboBox cmbTitoliRimozione;
        private Form Rimuovi;
        #endregion

        #region costruttore della form
        public MenuForm(Cliente utente)
        {
            InitializeComponent();
            cliente = utente;
            //associa la chiusura della form al metodo di chiusura della form 
            this.FormClosing += MenuForm_FormClosing;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }
        #endregion

        #region metodo per loaddare la form
        private void MenuForm_Load(object sender, EventArgs e)
        {
            btnRimuovi.Visible = false;
            lblAdmin.Visible = false;

            //controlla se l'email è dell'admin, se si abilitiamo il bottone e la label
            if (cliente.Email == "BTAdmin@gmail.com")
            {
                btnRimuovi.Visible = true;
                lblAdmin.Visible = true;
            }

            //nasconde tutte le altre form aperte tranne quella corrente
            foreach (Form formAperta in Application.OpenForms)
            {
                if (formAperta != this)
                {
                    formAperta.Hide();
                }
            }
        }
        #endregion

        #region metodo per gestire la chiusura form
        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //messaggio di conferma per l'utente
            DialogResult risultato = MessageBox.Show("Uscire?", "Conferma", MessageBoxButtons.YesNo);
            if (risultato == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show(); //riapre la form di login
            }
            else
            {
                e.Cancel = true; //annulla la chiusura della form
            }
        }
        #endregion

        #region bottone per visualizzare i libri disponibili (apre la listview della libreria)
        private void btnVisualizzaLibriDisponibili_Click(object sender, EventArgs e)
        {
            LibriForm libriForm = new LibriForm(cliente);
            libriForm.Show(); //mostra la form dei libri
        }
        #endregion

        #region bottone per aprire lo storico dei libri dell'utente
        private void btnStoricoPrestiti_Click(object sender, EventArgs e)
        {
            List<Prestito> tuttiIPrestiti = GestorePrestiti.CaricaPrestiti();
            bool verificaPrestiti = false;

            //verifica se il cliente ha almeno un prestito
            foreach (Prestito prestito in tuttiIPrestiti)
            {
                if (prestito.IDCliente == cliente.ID)
                {
                    verificaPrestiti = true;
                    break;
                }
            }

            if (!verificaPrestiti)
            {
                MessageBox.Show("Nessun prestito.");
                return;
            }

            StoricoPrestitiForm storicoForm = new StoricoPrestitiForm(cliente);
            storicoForm.ShowDialog(); //mostra la finestra dello storico
        }
        #endregion

        #region bottone per rimuovere un libro (solo l'admin può farlo)
        private void btnRimuovi_Click(object sender, EventArgs e)
        {
            List<Libro> tuttiILibri = GestoreLibri.CaricaLibri();

            if (tuttiILibri.Count == 0)
            {
                MessageBox.Show("Nessun libro da rimuovere.");
                return;
            }

            //creazione della form per la rimozione
            Rimuovi = new Form(); 
            Rimuovi.Text = "Rimuovi Libro"; //testo della form
            Rimuovi.Size = new Size(400, 180); //grandezze della form
            Rimuovi.StartPosition = FormStartPosition.CenterParent; //posizione della form all'apertura
            Rimuovi.FormBorderStyle = FormBorderStyle.FixedDialog;
            Rimuovi.MaximizeBox = false; //non si può aumentare la grandezza della form
            Rimuovi.MinimizeBox = false; //non si può diminuire la grandezza della form

            Label lblTitolo = new Label(); //creazione della label lbltitolo
            lblTitolo.Text = "Nome libro:";
            lblTitolo.Location = new Point(20, 20);
            lblTitolo.AutoSize = true;

            cmbTitoliRimozione = new ComboBox(); //creazione della combobox cmbTitoliRimozione
            cmbTitoliRimozione.Location = new Point(120, 18);
            cmbTitoliRimozione.Width = 240;
            cmbTitoliRimozione.DropDownStyle = ComboBoxStyle.DropDownList;

            
            foreach (Libro libro in tuttiILibri)
            {
                cmbTitoliRimozione.Items.Add(libro.Titolo);
            }

            if (cmbTitoliRimozione.Items.Count > 0)
            {
                cmbTitoliRimozione.SelectedIndex = 0;
            }

            Button btnElimina = new Button(); //creazione bottone btnElimina
            btnElimina.Text = "Elimina";
            btnElimina.Location = new Point(120, 60);
            btnElimina.Width = 100;
            //associa il click del pulsante Elimina al metodo btnElimina_Click
            btnElimina.Click += btnElimina_Click;

            //aggiunge alla form i controlli
            Rimuovi.Controls.Add(lblTitolo);
            Rimuovi.Controls.Add(cmbTitoliRimozione);
            Rimuovi.Controls.Add(btnElimina);
            Rimuovi.ShowDialog(); //mostra la finestra di dialogo
        }
        #endregion

        #region botone per eliminare il libro selezionato evento
        private void btnElimina_Click(object sender, EventArgs e)
        {
            //ottiene il titolo selezionato nella ComboBox
            object selezione = cmbTitoliRimozione.SelectedItem;

            //se la selezione è nulla ritorna con il messaggio "seleziona un libro"
            if (selezione == null || string.IsNullOrWhiteSpace(selezione.ToString()))
            {
                MessageBox.Show("Seleziona un libro.");
                return;
            }

            string titoloSelezionato = selezione.ToString();

            //mostra una finestra di conferma all'utente
            DialogResult conferma = MessageBox.Show("Vuoi eliminare \"" + titoloSelezionato + "\"?", "Conferma", MessageBoxButtons.YesNo);

            if (conferma != DialogResult.Yes)
            {
                return;
            }

            List<Libro> tuttiILibri = GestoreLibri.CaricaLibri();
            Libro libroDaRimuovere = null;

            //cerca il libro da rimuovere
            foreach (Libro libro in tuttiILibri)
            {
                if (libro.Titolo == titoloSelezionato)
                {
                    libroDaRimuovere = libro;
                    break;
                }
            }

            if (libroDaRimuovere != null)
            {
                tuttiILibri.Remove(libroDaRimuovere); //rimuove il libro dalla lista
                GestoreLibri.SalvaLibri(tuttiILibri); //salva la nuova lista aggiornata
                MessageBox.Show("Libro \"" + titoloSelezionato + "\" rimosso.");
                Rimuovi.Close();
            }
        }
        #endregion

        #region bottone per la ricerca del libro tramite nome
        private void btnRicerca_Click(object sender, EventArgs e)
        {
            List<Libro> tuttiILibri = GestoreLibri.CaricaLibri();
            List<Libro> libriDisponibili = new List<Libro>();

            //mette solo i libri disponibili
            foreach (Libro libro in tuttiILibri)
            {
                if (libro.Disponibile)
                {
                    libriDisponibili.Add(libro);
                }
            }

            if (libriDisponibili.Count == 0)
            {
                MessageBox.Show("Nessun libro disponibile.");
                return;
            }

            RicercaLibro ricerca = new RicercaLibro(libriDisponibili, cliente);
            ricerca.ShowDialog(); //mostra la finestra di ricerca
        }
        #endregion
    }
}
