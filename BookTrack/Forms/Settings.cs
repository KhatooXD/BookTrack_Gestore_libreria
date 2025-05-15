using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookTrack.Classi;
using BookTrack.Management_Class;

namespace BookTrack.Forms
{
    public partial class Settings : Form
    {
        private Cliente clienteAttuale;
        public Settings(Cliente cliente)
        {

            InitializeComponent();
            clienteAttuale = cliente;

        }

        private void Settings_Load(object sender, EventArgs e)
        {
            // Carica i dati dell'utente corrente e visualizzali
            
            if (clienteAttuale != null)
            {
                txtNomeinfo.Text = clienteAttuale.Nome;
                txtCognomeInfo.Text = clienteAttuale.Cognome;
                txtEmailinfo.Text = clienteAttuale.Email;
                txtnumtelinfo.Text = clienteAttuale.Telefono;
                txtNomeinfo.Enabled = false;
                txtCognomeInfo.Enabled = false;
                txtEmailinfo.Enabled = false;
                txtnumtelinfo.Enabled = false;
                txtNomeinfo.Enabled = false;


                // Impedire la modifica dei campi (rendili readonly)
                txtNomeinfo.ReadOnly = true;
                txtCognomeInfo.ReadOnly = true;
                txtEmailinfo.ReadOnly = true;
                txtnumtelinfo.ReadOnly = true;

            }
            else
            {
                MessageBox.Show("Utente non trovato.");
                this.Close();
            }
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.Close(); // Chiudi la finestra delle impostazioni
        }
    }
}
