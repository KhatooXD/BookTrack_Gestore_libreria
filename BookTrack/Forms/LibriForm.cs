using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BookTrack.Classi;
using BookTrack.Management_Class;

namespace BookTrack.Forms
{
    public partial class LibriForm : Form
    {
        #region dichiarazione variabili private
        private Cliente cliente;
        private AggiuntaLibro Aggiunta;
        private InfoLibroForm InfoLibro;
        #endregion

        #region costruttore della form
        public LibriForm(Cliente utente)
        {
            InitializeComponent();
            cliente = utente;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            //collega l'azione di cambio selezione della ListView al metodo lvListaLibri_SelectedIndexChanged
            this.lvListaLibri.SelectedIndexChanged += lvListaLibri_SelectedIndexChanged;
        }
        #endregion

        #region metodo per loaddare la LibriForm
        private void LibriForm_Load(object sender, EventArgs e)
        {
            if (cliente.Email == "BTAdmin@gmail.com")
            {
                btnAggiungiLibroLista.Visible = true; //mostra il bottone solo se è admin
            }
            else
            {
                btnAggiungiLibroLista.Visible = false;
            }

            CaricaLibriInListView(); //carica tutti i libri nella ListView
        }
        #endregion

        #region metodo per caricare i libri nella ListView
        private void CaricaLibriInListView()
        {
            //svuota la lista prima del caricamento
            lvListaLibri.Items.Clear();

            //carica i libri dal file
            List<Libro> libri = GestoreLibri.CaricaLibri(); 

            foreach (Libro libro in libri)
            {
                ListViewItem item = new ListViewItem(libro.Titolo);
                item.SubItems.Add(libro.Autore);
                item.SubItems.Add(libro.Genere);
                item.SubItems.Add(libro.Anno.ToString());
                item.SubItems.Add(libro.Disponibile ? "Sì" : "No");
                item.SubItems.Add(libro.Prezzo.ToString("0.00") + " €");
                item.Tag = libro; //salva l'oggetto libro nel tag dell'item
                lvListaLibri.Items.Add(item);
            }
        }
        #endregion

        #region bottone Aggiungi Libro
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
                Aggiunta.Focus(); //porta in primo piano la finestra se già aperta
            }
        }
        #endregion

        #region metodo per gestire la chiusura della form AggiuntaLibro
        private void AggiuntaLibroForm_Chiusa(object sender, FormClosedEventArgs e)
        {
            if (Aggiunta.LibroInserito)
            {
                CaricaLibriInListView(); //aggiorna la lista se è stato inserito un nuovo libro
            }
            Aggiunta = null;
        }
        #endregion

        #region metodo per gestire selezione libro nella ListView
        private void lvListaLibri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvListaLibri.SelectedItems.Count == 0)
            {
                return; 
            }

            ListViewItem selezionato = lvListaLibri.SelectedItems[0];
            Libro libro = (Libro)selezionato.Tag;

            //se la form non esiste o è stata chiusa, la crea e la mostra
            if (InfoLibro == null || InfoLibro.IsDisposed)
            {
                InfoLibro = new InfoLibroForm(libro, cliente);
                //associa la chiusura della form dell'informazione del libro al metodo InfoLibroForm_Chiusa
                InfoLibro.FormClosed += InfoLibroForm_Chiusa;
                InfoLibro.Show();
            }
            else
            {
                InfoLibro.Focus(); //porta in primo piano la finestra se già aperta
            }
        }
        #endregion

        #region metodo per gestire la chiusura  della form di InfoLibro 
        private void InfoLibroForm_Chiusa(object sender, FormClosedEventArgs e)
        {
            InfoLibro = null;
            CaricaLibriInListView(); 
        }
        #endregion
    }
}
