using System;
using System.Windows.Forms;
using OctagonHelpdesk.Helpers;
using OctagonHelpdesk.Models;

namespace OctagonHelpdesk
{
    public partial class LoginFrm : Form
    {
        public UserModel CurrentUser { get; set; }
        private bool submitted = false;

        public LoginFrm()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string inputuser = txbuser.Text.Trim();
            string inputpassword = txbpassword.Text.Trim();

            if (string.IsNullOrEmpty(inputuser) || string.IsNullOrEmpty(inputpassword))
            {
                MessageBox.Show("Credenciales vacías. Por favor, complete todos los campos.", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //try
                //{
                    // Verificar las credenciales utilizando AuthenticationService
                    if (AuthenticationService.ValidateCredentials(inputuser, inputpassword))
                    {
                        CurrentUser = AuthenticationService.GetCurrentUser(inputuser);
                        this.DialogResult = DialogResult.OK;
                        submitted = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Credenciales inválidas. Por favor, inténtelo de nuevo.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                //}
                //catch (InvalidOperationException ex)
                //{
                //    MessageBox.Show(ex.Message, "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

            }
        }

        private void txbuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
               txbpassword.Focus();
            }
        }

        private void txbpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnlogin_Click(sender, e);
            }
           
        }

        private void cbPassVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPassVisible.Checked)
            {
                txbpassword.PasswordChar = '\0';
            }
            else
            {
                txbpassword.PasswordChar = '*';

            }
        }
    }
}
