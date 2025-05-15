using System;
using System.Drawing;
using System.Windows.Forms;
using BookTrack.Classi;
using BookTrack.Management_Class;

namespace BookTrack.Forms
{
    public partial class InfoLibroForm : Form
    {
        private Libro libro;
        private Cliente cliente;
        private TextBox txtFirma;
        private Form Prestito;

        public InfoLibroForm(Libro libro, Cliente utente)
        {
            InitializeComponent();
            this.libro = libro;
            this.cliente = utente;

            MostraInfoLibro();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void MostraInfoLibro()
        {
            lblTitolotext.Text = libro.Titolo;
            lblautoretext.Text = libro.Autore;
            lblGenereText.Text = libro.Genere;
            lblAnnoText.Text = libro.Anno.ToString();
            //scrive "Sì" se il libro è disponibile, altrimenti "No"
            lblDisponibileText.Text = libro.Disponibile ? "Sì" : "No";
            lblPrezzoText.Text = libro.Prezzo.ToString("0.00") + " €";
        }

        private void btnPrestito_Click(object sender, EventArgs e)
        {
            if (!libro.Disponibile)
            {
                MessageBox.Show("Questo libro non è disponibile.");
                return;
            }

            Prestito = new Form();
            Prestito.Text = "Dettagli Prestito";
            Prestito.Size = new Size(350, 250);
            Prestito.StartPosition = FormStartPosition.CenterParent;
            Prestito.FormBorderStyle = FormBorderStyle.FixedDialog;
            Prestito.MaximizeBox = false;
            Prestito.MinimizeBox = false;

            Label lblData = new Label();
            lblData.Text = "Data prestito: " + DateTime.Now.ToString("dd/MM/yyyy");
            lblData.Location = new Point(20, 20);
            lblData.AutoSize = true;

            Label lblFirma = new Label();
            lblFirma.Text = "Firma digitale:";
            lblFirma.Location = new Point(20, 60);
            lblFirma.AutoSize = true;

            txtFirma = new TextBox();
            txtFirma.Location = new Point(120, 57);
            txtFirma.Width = 180;

            Button btnConferma = new Button();
            btnConferma.Text = "Conferma Prestito";
            btnConferma.Location = new Point(20, 110);
            btnConferma.Width = 130;
            btnConferma.Click += btnConferma_Click;

            Button btnAnnulla = new Button();
            btnAnnulla.Text = "Annulla";
            btnAnnulla.Location = new Point(170, 110);
            btnAnnulla.Width = 130;
            btnAnnulla.Click += btnAnnulla_Click;

            Prestito.Controls.Add(lblData);
            Prestito.Controls.Add(lblFirma);
            Prestito.Controls.Add(txtFirma);
            Prestito.Controls.Add(btnConferma);
            Prestito.Controls.Add(btnAnnulla);

            Prestito.ShowDialog();
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirma.Text))
            {
                MessageBox.Show("Inserisci la firma.");
                return;
            }

            DateTime dataInizio = DateTime.Now;
            DateTime dataFine = dataInizio.AddMonths(1);
            int idPrestito = GestorePrestiti.GeneraIDPrestito();

            Prestito nuovoPrestito = new Prestito(idPrestito, libro.ID, cliente.ID, dataInizio, dataFine);
            GestorePrestiti.AggiungiPrestito(nuovoPrestito);

            libro.Disponibile = false;
            GestoreLibri.AggiornaLibro(libro);

            MessageBox.Show(
                "Prestito confermato.\n\n" +
                "Titolo: " + libro.Titolo + "\n" +
                "Data: " + dataInizio.ToString("dd/MM/yyyy") + "\n" +
                "Restituzione: " + dataFine.ToString("dd/MM/yyyy") + "\n" +
                "Firma: " + txtFirma.Text
            );

            Prestito.Close();
            this.Close();
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            Prestito.Close();
        }
    }
}
