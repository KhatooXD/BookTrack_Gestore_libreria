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
        private Cliente cliente;
        private  ListView lvStorico;
        private  Button btnRestituisci;

        public StoricoPrestitiForm(Cliente cliente)
        {
            this.cliente = cliente;

            Text = $"Storico Prestiti di {cliente.Nome}";
            Size = new Size(600, 450);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            lvStorico = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Dock = DockStyle.Top,
                Height = 350
            };
            lvStorico.Columns.Add("Titolo", 200);
            lvStorico.Columns.Add("Data Prestito", 100);
            lvStorico.Columns.Add("Data Fine", 100);
            lvStorico.Columns.Add("Giorni Rimasti", 100);
            Controls.Add(lvStorico);

            btnRestituisci = new Button
            {
                Text = "Restituisci Libro Selezionato",
                Dock = DockStyle.Bottom,
                Height = 40,
                Enabled = false
            };

            //collega il click del pulsante btnRestituisci al metodo BtnRestituisci_Click
            btnRestituisci.Click += BtnRestituisci_Click;
            Controls.Add(btnRestituisci);

            //collega la selezione della listview al metodo lvStorico_SelectedIndexChanged
            lvStorico.SelectedIndexChanged += lvStorico_SelectedIndexChanged;

            CaricaPrestiti();
        }

        private void lvStorico_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRestituisci.Enabled = lvStorico.SelectedItems.Count > 0;
        }

        private void CaricaPrestiti()
        {
            lvStorico.Items.Clear();

            List<Prestito> tuttiPrestiti = GestorePrestiti.CaricaPrestiti();
            List<Prestito> prestiti = new List<Prestito>();
            foreach (Prestito Prestito in tuttiPrestiti)
            {
                if (Prestito.IDCliente == cliente.ID)
                {
                    prestiti.Add(Prestito);
                }
            }

            List<Libro> libri = GestoreLibri.CaricaLibri();

            foreach (Prestito prestito in prestiti)
            {
                Libro libro = null;
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
                    continue;
                }

                int giorniRimasti = (prestito.DataFine - DateTime.Now).Days;
                if (giorniRimasti < 0)
                {
                    giorniRimasti = 0;
                }

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
                Close();
            }
        }

        private void BtnRestituisci_Click(object sender, EventArgs e)
        {
            if (lvStorico.SelectedItems.Count == 0)
            {
                return;
            }

            ListViewItem selezionato = lvStorico.SelectedItems[0];
            Prestito prestito = (Prestito)selezionato.Tag;

            //crea una messagebox dove ti chiede se vuoi restituire il libro (schiacci si se acconsenti, viceversa se non vuoi)
            DialogResult conferma = MessageBox.Show($"Restituire \"{selezionato.Text}\"?","Conferma",MessageBoxButtons.YesNo);

            if (conferma != DialogResult.Yes)
            {
                return;
            }

            List<Prestito> tuttiPrestiti = GestorePrestiti.CaricaPrestiti();
            List<Prestito> nuoviPrestiti = new List<Prestito>();
            foreach (Prestito prestiti in tuttiPrestiti)
            {
                if (prestiti.ID != prestiti.ID)
                {
                    nuoviPrestiti.Add(prestiti);
                }
            }
            GestorePrestiti.SalvaPrestiti(nuoviPrestiti);

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
    }
}
