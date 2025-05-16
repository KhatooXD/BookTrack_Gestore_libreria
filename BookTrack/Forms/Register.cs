using System;
using System.Windows.Forms;
using BookTrack.Classi;
using BookTrack.Forms;
using BookTrack.Management_Class;

namespace BookTrack
{
    public partial class Register : Form
    {
        #region costruttore della form
        public Register()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; //la form non può essere ingrandita 
        }
        #endregion

        #region bottone per registrarsi
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //controlla se l'email inserita è valida
                if (!Validazione.ValidaEmail(txtEmail.Text))
                {
                    MessageBox.Show("Email non valida.");
                    return;
                }

                //controlla se la password rispetta i criteri
                if (!Validazione.ValidaPassword(txtPassword.Text))
                {
                    MessageBox.Show("Password non valida.");
                    return;
                }

                //controlla se il numero di telefono è corretto
                if (!Validazione.ValidaTelefono(txtTelefono.Text))
                {
                    MessageBox.Show("Telefono non valido.");
                    return;
                }

                //genera un ID univoco per il nuovo utente
                int nuovoID = GestoreUtenti.GeneraIDUnivoco(); 

                //crea un nuovo oggetto Cliente con i dati inseriti
                Cliente nuovoCliente = new Cliente(nuovoID, txtNome.Text, txtCognome.Text, txtEmail.Text, txtTelefono.Text, txtPassword.Text);

                //aggiunge il cliente al file utenti
                bool aggiunto = GestoreUtenti.AggiungiUtente(nuovoCliente); 

                if (aggiunto)
                {
                    MessageBox.Show("Registrazione completata.");

                    MenuForm menu = new MenuForm(nuovoCliente);
                    //associa l'evento di chiusura della MenuForm al metodo Menu_FormClosed
                    menu.FormClosed += Menu_FormClosed;
                    this.Hide(); //nasconde la finestra della form register
                    menu.Show(); //mostra la form del menu principale
                }
                else
                {
                    MessageBox.Show("Email o telefono già esistenti."); 
                }
            }
            catch
            {
                MessageBox.Show("Errore durante la registrazione."); 
            }
        }
        #endregion

        #region chiusura della form dopo chiusura menu
        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close(); //chiude anche la Register quando viene chiuso il menu
        }
        #endregion

        #region bottone per tornare alla form del login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close(); //chiude la form Register e torna alla Login
        }
        #endregion
    }
}
