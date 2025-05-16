using System;
using System.Windows.Forms;
using BookTrack.Classi;
using BookTrack.Management_Class;

namespace BookTrack.Forms
{
    public partial class AggiuntaLibro : Form
    {
        #region variabile di tipo bool e pubblica per confermare l'inserimento
        public bool LibroInserito = false;
        #endregion

        #region costruttore della form
        public AggiuntaLibro()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            //associa l'azione di btnAggiungi al metodo click di btnAggiungi
            this.btnAggiungi.Click += btnAggiungi_Click;
        }
        #endregion

        #region bottone per aggiungere il libro
        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            int anno;

            //valida l'anno e lo converte in intero
            if (!Validazione.ValidaAnno(txtAnno.Text, out anno))
            {
                MessageBox.Show("Anno non valido.");
                return;
            }

            double prezzo;

            //valida il prezzo e lo converte in double
            if (!Validazione.ValidaPrezzo(txtCosto.Text, out prezzo))
            {
                MessageBox.Show("Prezzo non valido.");
                return;
            }

            //genera ID univoco per il libro
            int id = GestoreLibri.GeneraIDUnivoco(); 

            //crea il nuovo oggetto libro con i dati inseriti
            Libro nuovoLibro = new Libro(id, txtTitolo.Text, txtAutore.Text, txtGenere.Text, anno, true, prezzo);

            //aggiunge il libro e mostra messaggio di conferma o errore
            if (GestoreLibri.AggiungiLibro(nuovoLibro))
            {
                MessageBox.Show("Libro aggiunto.");
                LibroInserito = true; //indica che un libro è stato effettivamente inserito
                this.Close(); //chiude la form
            }
            else
            {
                MessageBox.Show("Libro già presente.");
            }
        }
        #endregion
    }
}
