using System;
using System.Windows.Forms;
using BookTrack.Classi;
using BookTrack.Management_Class;

namespace BookTrack.Forms
{
    public partial class AggiuntaLibro : Form
    {
        public bool LibroInserito = false;
        public AggiuntaLibro()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            //associa l'azione di btnAggiungi al metodo click di btnAggiungi
            this.btnAggiungi.Click += btnAggiungi_Click;
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            int anno;
            if (!Validazione.ValidaAnno(txtAnno.Text, out anno))
            {
                MessageBox.Show("Anno non valido.");
                return;
            }

            double prezzo;
            if (!Validazione.ValidaPrezzo(txtCosto.Text, out prezzo))
            {
                MessageBox.Show("Prezzo non valido.");
                return;
            }

            int id = GestoreLibri.GeneraIDUnivoco();
            Libro nuovoLibro = new Libro(id, txtTitolo.Text, txtAutore.Text, txtGenere.Text, anno, true, prezzo);

            if (GestoreLibri.AggiungiLibro(nuovoLibro))
            {
                MessageBox.Show("Libro aggiunto.");
                LibroInserito = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Libro già presente.");
            }
        }
    }
}
