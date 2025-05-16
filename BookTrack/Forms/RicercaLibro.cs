using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BookTrack.Classi;

namespace BookTrack.Forms
{
    public partial class RicercaLibro : Form
    {
        #region  dichiarazione variabili private
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
        #endregion

        #region costruttore della form
        public RicercaLibro(List<Libro> listaLibri, Cliente clienteUtente)
        {
            InitializeComponent();

            if (listaLibri != null)
            {
                //assegna la lista dei libri se non è nulla
                libri = listaLibri; 
            }
            else
            {
                //altrimenti crea una lista vuota
                libri = new List<Libro>(); 
            }

            cliente = clienteUtente;

            CreaControlli(); 

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }
        #endregion

        #region metodo per creare tutti i controlli della form
        private void CreaControlli()
        {
            cmbLibri = new ComboBox(); //creo una nuova combobox chiamata cmbLibri
            cmbLibri.Location = new Point(20, 20); //indico dove è situata la combobox nella form
            cmbLibri.Width = 340; //larghezza della combobox
            cmbLibri.DropDownStyle = ComboBoxStyle.DropDownList;

            //foreach per aggiungere i titoli dei libri alla comboBox
            foreach (Libro libro in libri)
            {
                
                cmbLibri.Items.Add(libro.Titolo); 
            }

            if (cmbLibri.Items.Count > 0)
            {
                //se ci sono elementi, seleziona il primo
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
                Aggiorna(0); //aggiorna le info del primo libro
            }
            else
            {
                lblTitolo.Text = "(Nessun libro disponibile)";
            }
        }
        #endregion

        #region metodo per creare in modo dinamico le label
        private Label CreaLabel(string testo, int posY)
        {
            Label lblDinamica = new Label(); //creo una nuova label
            lblDinamica.Text = testo;
            lblDinamica.Location = new Point(20, posY); 
            lblDinamica.AutoSize = true; 
            Controls.Add(lblDinamica); //aggiungo i controlli alla label
            return lblDinamica; 
        }
        #endregion

        #region metodo per cambio selezione ComboBox
        private void CmbLibri_SelectedIndexChanged(object sender, EventArgs e)
        {
            Aggiorna(cmbLibri.SelectedIndex); //aggiorna le info del libro selezionato
        }
        #endregion

        #region metodo per aggiornare le info dei libri selezionati
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
        #endregion

        #region bottone per andare direttamente alla listview della libreria
        private void BtnVaiLibreria_Click(object sender, EventArgs e)
        {
            this.Close(); //chiude la form della RicercaLibro
            LibriForm formLibri = new LibriForm(cliente); //apre la form principale dei libri
            formLibri.Show();
        }
        #endregion
    }
}
