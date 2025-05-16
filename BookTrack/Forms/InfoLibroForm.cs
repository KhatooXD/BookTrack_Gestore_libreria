using System;
using System.Drawing;
using System.Windows.Forms;
using BookTrack.Classi;
using BookTrack.Management_Class;

namespace BookTrack.Forms
{
    public partial class InfoLibroForm : Form
    {
        #region dichiarazione variabili private
        private Libro libro;
        private Cliente cliente;
        private TextBox txtFirma;
        private Form Prestito;
        #endregion

        #region costruttore della form
        public InfoLibroForm(Libro libro, Cliente utente)
        {
            InitializeComponent();
            this.libro = libro;
            this.cliente = utente;

            MostraInfoLibro(); //visualizza le informazioni del libro
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }
        #endregion

        #region metodo che mostra le info del libro
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
        #endregion

        #region bottone per il fare un prestito sul libro scelto
        private void btnPrestito_Click(object sender, EventArgs e)
        {
            if (!libro.Disponibile)
            {
                MessageBox.Show("Questo libro non è disponibile.");
                return;
            }

            //crea una nuova finestra per inserire i dati del prestito
            Prestito = new Form();
            Prestito.Text = "Dettagli Prestito";
            Prestito.Size = new Size(350, 250);
            Prestito.StartPosition = FormStartPosition.CenterParent;
            Prestito.FormBorderStyle = FormBorderStyle.FixedDialog;
            Prestito.MaximizeBox = false;
            Prestito.MinimizeBox = false;

            Label lblData = new Label(); //creazione della label lblData
            lblData.Text = "Data prestito: " + DateTime.Now.ToString("dd/MM/yyyy"); //imposta come testo la data attuale
            lblData.Location = new Point(20, 20);
            lblData.AutoSize = true;

            Label lblFirma = new Label(); //creazione della label lblFirm
            lblFirma.Text = "Firma digitale:";
            lblFirma.Location = new Point(20, 60);
            lblFirma.AutoSize = true;

            txtFirma = new TextBox(); //creazione della textbox txtfirma
            txtFirma.Location = new Point(120, 57);
            txtFirma.Width = 180;

            Button btnConferma = new Button(); //creazione del bottone btnconferma
            btnConferma.Text = "Conferma Prestito";
            btnConferma.Location = new Point(20, 110);
            btnConferma.Width = 130;
            btnConferma.Click += btnConferma_Click;

            Button btnAnnulla = new Button(); //creazione del bottone btnAnnulla
            btnAnnulla.Text = "Annulla";
            btnAnnulla.Location = new Point(170, 110);
            btnAnnulla.Width = 130;
            btnAnnulla.Click += btnAnnulla_Click;

            //aggiunge i controlli alla form Prestito
            Prestito.Controls.Add(lblData);
            Prestito.Controls.Add(lblFirma);
            Prestito.Controls.Add(txtFirma);
            Prestito.Controls.Add(btnConferma);
            Prestito.Controls.Add(btnAnnulla);

            Prestito.ShowDialog(); //mostra la finestra del prestito
        }
        #endregion

        #region bottone per confermare il prestito
        private void btnConferma_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirma.Text))
            {
                MessageBox.Show("Inserisci la firma.");
                return;
            }

            DateTime dataInizio = DateTime.Now;
            DateTime dataFine = dataInizio.AddMonths(1); //scadenza dopo un mese
            int idPrestito = GestorePrestiti.GeneraIDPrestito(); //genera ID univoco

            //crea un nuovo oggetto Prestito
            Prestito nuovoPrestito = new Prestito(idPrestito, libro.ID, cliente.ID, dataInizio, dataFine);
            //salva il prestito
            GestorePrestiti.AggiungiPrestito(nuovoPrestito); 

            libro.Disponibile = false;
            //aggiorna la disponibilità del libro
            GestoreLibri.AggiornaLibro(libro); 

            //mostra i dettagli del prestito all'utente
            MessageBox.Show(
                "Prestito confermato.\n\n" +
                "Titolo: " + libro.Titolo + "\n" +
                "Data: " + dataInizio.ToString("dd/MM/yyyy") + "\n" +
                "Restituzione: " + dataFine.ToString("dd/MM/yyyy") + "\n" +
                "Firma: " + txtFirma.Text
            );

            //chiude la finestra del prestito
            Prestito.Close();
            //chiude la form InfoLibro
            this.Close(); 
        }
        #endregion

        #region bottone per annullare
        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            Prestito.Close(); //chiude la finestra del prestito
        }
        #endregion
    }
}
