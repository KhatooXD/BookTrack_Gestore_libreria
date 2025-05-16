using System;
using System.Windows.Forms;
using BookTrack.Classi;
using BookTrack.Management_Class;

namespace BookTrack.Forms
{
    public partial class LoginForm : Form
    {
        #region costruttore della form
        public LoginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }
        #endregion

        #region bottone per il login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //verifica le credenziali e restituisce l'utente se esiste
            Cliente utenteLoggato = GestoreUtenti.PrendiUtenteDalleCredenziali(txtEmail.Text, txtPassword.Text);

            if (utenteLoggato != null)
            {
                MessageBox.Show("Login effettuato con successo!");

                //ripulisce i campi
                txtEmail.Text = "";
                txtPassword.Text = "";

                this.Hide(); //nasconde la login
                MenuForm menu = new MenuForm(utenteLoggato);

                //associa la chiusura della MenuForm al metodo Menu_FormClosed
                menu.FormClosed += Menu_FormClosed;

                //mostra la finestra del menu principale
                menu.Show();
            }
            else
            {
                MessageBox.Show("Credenziali non valide.");
            }
        }
        #endregion

        #region metodo per gestire la chiusura del menu form
        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close(); //chiude anche la login se si chiude il menu
        }
        #endregion

        #region bottone per passare alla registrazione dell'account
        private void btnRegister_Click(object sender, EventArgs e)
        {
            //nasconde la login
            this.Hide(); 
            Register reg = new Register();

            //associa la chiusura della form di registrazione al metodo Register_FormClosed
            reg.FormClosed += Register_FormClosed;
            reg.Show(); //mostra la form di registrazione
        }
        #endregion

        #region metodo che gestisce la chiusura della form register 
        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show(); //riapre la login dopo la chiusura della register
        }
        #endregion
    }
}
