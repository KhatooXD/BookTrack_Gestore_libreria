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
        private Cliente cliente;
        private ComboBox cmbTitoliRimozione;
        private Form Rimuovi;

        public MenuForm(Cliente utente)
        {
            InitializeComponent();
            cliente = utente;
            //associa la chiusura della form al metodo di chiusura della form 
            this.FormClosing += MenuForm_FormClosing;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }

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
            // Nasconde tutte le altre form aperte tranne quella corrente
            foreach (Form formAperta in Application.OpenForms)
            {
                if (formAperta != this)
                {
                    formAperta.Hide();
                }
            }
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult risultato = MessageBox.Show("Uscire?", "Conferma", MessageBoxButtons.YesNo);
            if (risultato == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnVisualizzaLibriDisponibili_Click(object sender, EventArgs e)
        {
            LibriForm libriForm = new LibriForm(cliente);
            libriForm.Show();
        }

        private void btnStoricoPrestiti_Click(object sender, EventArgs e)
        {
            List<Prestito> tuttiIPrestiti = GestorePrestiti.CaricaPrestiti();
            bool verificaPrestiti = false;

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
            storicoForm.ShowDialog();
        }

        private void btnRimuovi_Click(object sender, EventArgs e)
        {
            List<Libro> tuttiILibri = GestoreLibri.CaricaLibri();

            if (tuttiILibri.Count == 0)
            {
                MessageBox.Show("Nessun libro da rimuovere.");
                return;
            }

            Rimuovi = new Form();
            Rimuovi.Text = "Rimuovi Libro";
            Rimuovi.Size = new Size(400, 180);
            Rimuovi.StartPosition = FormStartPosition.CenterParent;
            Rimuovi.FormBorderStyle = FormBorderStyle.FixedDialog;
            Rimuovi.MaximizeBox = false;
            Rimuovi.MinimizeBox = false;

            Label lblTitolo = new Label();
            lblTitolo.Text = "Nome libro:";
            lblTitolo.Location = new Point(20, 20);
            lblTitolo.AutoSize = true;

            cmbTitoliRimozione = new ComboBox();
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

            Button btnElimina = new Button();
            btnElimina.Text = "Elimina";
            btnElimina.Location = new Point(120, 60);
            btnElimina.Width = 100;
            //associa il click del pulsante Elimina al metodo btnElimina_Click
            btnElimina.Click += btnElimina_Click;
            //aggiunge alla form Rimuovi i controlli: etichetta, combobox e pulsante
            Rimuovi.Controls.Add(lblTitolo);
            Rimuovi.Controls.Add(cmbTitoliRimozione);
            Rimuovi.Controls.Add(btnElimina);
            //mostra la finestra di dialogo per la rimozione del libro
            Rimuovi.ShowDialog();
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            string titoloSelezionato = cmbTitoliRimozione.SelectedItem as string;

            if (string.IsNullOrEmpty(titoloSelezionato))
            {
                MessageBox.Show("Seleziona un libro.");
                return;
            }

            //mostra una finestra di conferma chiedendo se eliminare il libro selezionato
            DialogResult conferma = MessageBox.Show("Vuoi eliminare \"" + titoloSelezionato + "\"?", "Conferma", MessageBoxButtons.YesNo);


            if (conferma != DialogResult.Yes)
            {
                return;
            }

            List<Libro> tuttiILibri = GestoreLibri.CaricaLibri();
            Libro libroDaRimuovere = null;

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
                tuttiILibri.Remove(libroDaRimuovere);
                GestoreLibri.SalvaLibri(tuttiILibri);
                MessageBox.Show("Libro \"" + titoloSelezionato + "\" rimosso.");
                Rimuovi.Close();
            }
        }

        private void btnRicerca_Click(object sender, EventArgs e)
        {
            List<Libro> tuttiILibri = GestoreLibri.CaricaLibri();
            List<Libro> libriDisponibili = new List<Libro>();

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
            ricerca.ShowDialog();
        }
    }
}
