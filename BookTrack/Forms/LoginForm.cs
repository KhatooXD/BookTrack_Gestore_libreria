using System;
using System.Windows.Forms;
using BookTrack.Classi;
using BookTrack.Management_Class;

namespace BookTrack.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cliente utenteLoggato = GestoreUtenti.PrendiUtenteDalleCredenziali(txtEmail.Text, txtPassword.Text);

            if (utenteLoggato != null)
            {
                MessageBox.Show("Login effettuato con successo!");
                txtEmail.Text = "";
                txtPassword.Text = "";

                this.Hide();
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

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register reg = new Register();
            reg.FormClosed += Register_FormClosed;
            reg.Show();
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
