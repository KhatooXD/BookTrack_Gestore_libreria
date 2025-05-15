using System;
using System.Windows.Forms;
using BookTrack.Classi;
using BookTrack.Forms;
using BookTrack.Management_Class;

namespace BookTrack
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validazione.ValidaEmail(txtEmail.Text))
                {
                    MessageBox.Show("Email non valida.");
                    return;
                }

                if (!Validazione.ValidaPassword(txtPassword.Text))
                {
                    MessageBox.Show("Password non valida.");
                    return;
                }

                if (!Validazione.ValidaTelefono(txtTelefono.Text))
                {
                    MessageBox.Show("Telefono non valido.");
                    return;
                }

                int nuovoID = GestoreUtenti.GeneraIDUnivoco();

                Cliente nuovoCliente = new Cliente(nuovoID, txtNome.Text, txtCognome.Text, txtEmail.Text, txtTelefono.Text, txtPassword.Text);

                bool aggiunto = GestoreUtenti.AggiungiUtente(nuovoCliente);

                if (aggiunto)
                {
                    MessageBox.Show("Registrazione completata.");

                    MenuForm menu = new MenuForm(nuovoCliente);
                    //associa l'evento di chiusura della MenuForm al metodo Menu_FormClosed
                    menu.FormClosed += Menu_FormClosed;
                    //nasconde la finestra della form register
                    this.Hide();
                    //mostra la form del menu principale
                    menu.Show();
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

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
