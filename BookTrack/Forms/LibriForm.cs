using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BookTrack.Classi;
using BookTrack.Management_Class;

namespace BookTrack.Forms
{
    public partial class LibriForm : Form
    {
        private Cliente cliente;
        private AggiuntaLibro Aggiunta;
        private InfoLibroForm InfoLibro;

        public LibriForm(Cliente utente)
        {
            InitializeComponent();
            cliente = utente;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            //collega l'azione di cambio selezione della ListView al metodo lvListaLibri_SelectedIndexChanged
            this.lvListaLibri.SelectedIndexChanged += lvListaLibri_SelectedIndexChanged;

        }

        private void LibriForm_Load(object sender, EventArgs e)
        {
            if (cliente.Email == "BTAdmin@gmail.com")
            {
                btnAggiungiLibroLista.Visible = true;
            }
            else
            {
                btnAggiungiLibroLista.Visible = false;
            }

            CaricaLibriInListView();
        }

        private void CaricaLibriInListView()
        {
            lvListaLibri.Items.Clear();

            List<Libro> libri = GestoreLibri.CaricaLibri();

            foreach (Libro libro in libri)
            {
                ListViewItem item = new ListViewItem(libro.Titolo);
                item.SubItems.Add(libro.Autore);
                item.SubItems.Add(libro.Genere);
                item.SubItems.Add(libro.Anno.ToString());
                item.SubItems.Add(libro.Disponibile ? "Sì" : "No");
                item.SubItems.Add(libro.Prezzo.ToString("0.00") + " €");
                item.Tag = libro;
                lvListaLibri.Items.Add(item);
            }
        }

        private void btnAggiungiLibroLista_Click(object sender, EventArgs e)
        {
            //se la form Aggiunta non esiste oppure è stata chiusa, la crea e la mostra
            if (Aggiunta == null || Aggiunta.IsDisposed)
            {
                Aggiunta = new AggiuntaLibro();
                //associa la chiusura della form di Aggiunta al metodo AggiuntaLibroForm_Chiusa
                Aggiunta.FormClosed += AggiuntaLibroForm_Chiusa;
                Aggiunta.Show();
            }
            else
            {
                Aggiunta.Focus();
            }
        }

        private void AggiuntaLibroForm_Chiusa(object sender, FormClosedEventArgs e)
        {
            if (Aggiunta.LibroInserito)
            {
                CaricaLibriInListView();
            }
            Aggiunta = null;
        }

        private void lvListaLibri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvListaLibri.SelectedItems.Count == 0)
            {
                return;
            }
              
            ListViewItem selezionato = lvListaLibri.SelectedItems[0];
            Libro libro = (Libro)selezionato.Tag;

            if (InfoLibro == null || InfoLibro.IsDisposed)
            {
                InfoLibro = new InfoLibroForm(libro, cliente);
                //associa la chiusura della form dell'informazione del libro al metodo InfoLibroForm_Chiusa
                InfoLibro.FormClosed += InfoLibroForm_Chiusa;
                //mostra la form dell'info libro
                InfoLibro.Show();
            }
            else
            {
                InfoLibro.Focus();
            }
        }

        private void InfoLibroForm_Chiusa(object sender, FormClosedEventArgs e)
        {
            InfoLibro = null;
            CaricaLibriInListView();
        }
    }
}
