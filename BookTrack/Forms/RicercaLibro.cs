using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BookTrack.Classi;

namespace BookTrack.Forms
{
    public partial class RicercaLibro : Form
    {
        private List<Libro> libri;
        private Cliente cliente;

        private ComboBox cmbLibri;
        private Label lblTitolo;
        private Label lblAutore;
        private Label lblGenere;
        private Label lblAnno;
        private Label lblDisponibile;
        private Label lblPrezzo;
        private Button btnVaiLibreria;

        public RicercaLibro(List<Libro> listaLibri, Cliente clienteUtente)
        {
            InitializeComponent();

            if (listaLibri != null)
            {
                libri = listaLibri;
            }
            else
            {
                libri = new List<Libro>();
            }

            cliente = clienteUtente;

            CreaControlli();

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }

        private void CreaControlli()
        {
            cmbLibri = new ComboBox();
            cmbLibri.Location = new Point(20, 20);
            cmbLibri.Width = 340;
            cmbLibri.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (Libro libro in libri)
            {
                cmbLibri.Items.Add(libro.Titolo);
            }

            if (cmbLibri.Items.Count > 0)
            {
                cmbLibri.SelectedIndex = 0;
            }
            //collega l'evento di cambio selezione della ComboBox al metodo CmbLibri_SelectedIndexChange
            cmbLibri.SelectedIndexChanged += CmbLibri_SelectedIndexChanged;
            Controls.Add(cmbLibri);

            int y = 60;
            lblTitolo = CreaLabel("Titolo: ", y); y += 25;
            lblAutore = CreaLabel("Autore: ", y); y += 25;
            lblGenere = CreaLabel("Genere: ", y); y += 25;
            lblAnno = CreaLabel("Anno: ", y); y += 25;
            lblDisponibile = CreaLabel("Disponibile: ", y); y += 25;
            lblPrezzo = CreaLabel("Prezzo: ", y); y += 35;

            btnVaiLibreria = new Button();
            btnVaiLibreria.Text = "Vai alla libreria";
            btnVaiLibreria.Location = new Point(20, y);
            btnVaiLibreria.Width = 140;
            //collega il click del pulsante btnVaiLibreria al metodo BtnVaiLibreria_Click
            btnVaiLibreria.Click += BtnVaiLibreria_Click;
            Controls.Add(btnVaiLibreria);

            if (cmbLibri.Items.Count > 0)
            {
                Aggiorna(0);
            }
            else
            {
                lblTitolo.Text = "(Nessun libro disponibile)";
            }
        }

        private Label CreaLabel(string testo, int posY)
        {
            Label lbl = new Label();
            lbl.Text = testo;
            lbl.Location = new Point(20, posY);
            lbl.AutoSize = true;
            Controls.Add(lbl);
            return lbl;
        }

        private void CmbLibri_SelectedIndexChanged(object sender, EventArgs e)
        {
            Aggiorna(cmbLibri.SelectedIndex);
        }

        private void Aggiorna(int index)
        {
            if (index < 0 || index >= libri.Count)
            {
                return;
            }

            Libro libro = libri[index];

            lblTitolo.Text = "Titolo: " + libro.Titolo;
            lblAutore.Text = "Autore: " + libro.Autore;
            lblGenere.Text = "Genere: " + libro.Genere;
            lblAnno.Text = "Anno: " + libro.Anno.ToString();
            //imposta il testo della label indicando se il libro è disponibile o no
            lblDisponibile.Text = "Disponibile: " + (libro.Disponibile ? "Sì" : "No");
            lblPrezzo.Text = "Prezzo: " + libro.Prezzo.ToString("0.00") + " €";
        }

        private void BtnVaiLibreria_Click(object sender, EventArgs e)
        {
            this.Close();
            LibriForm formLibri = new LibriForm(cliente);
            formLibri.Show();
        }
    }
}
