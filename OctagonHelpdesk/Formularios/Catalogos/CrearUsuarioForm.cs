using OctagonHelpdesk.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OctagonHelpdesk.Models;
using OctagonHelpdesk.Models.Enum;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace OctagonHelpdesk.Formularios
{
    public partial class CrearUsuarioForm : Form
    {

        public event Action<UserModel> UsuarioCreated;
        public UserModel usuario = new UserModel();
        public UserModel currentUser { get; set; }

        //Primer Constructor para cuando se crea un Usuario
        public CrearUsuarioForm(UsuarioDao usuarioService, UserModel currentUser)
        {
            InitializeComponent();
            SharedLoad(currentUser);
            InitializeFormWithoutUserData(usuarioService);

        }

        //Segundo Constructor, cuando se selecciona un Usuario del DataGridView
        public CrearUsuarioForm(UserModel usuarioSelected, UserModel currentUser)//Se envia la info del User Seleccionado
        {
            InitializeComponent();
            SharedLoad(currentUser);
            if (usuarioSelected != null)
            {
                InitializeFormWithUserData(usuarioSelected);
            }


        }

        //Tercer Constructor, para visualizar el perfil propio
        public CrearUsuarioForm(UserModel currentUser)
        {
            InitializeComponent();
            SharedLoad(currentUser);
            usuario = currentUser;
            InitializeFormWithUserData(currentUser);
            DeshabilitarControlesAlVerPerfil();
            Text = "Perfil de Usuario";
            lblTitulo.Text = "Mi Perfil";

        }
        private void CrearUsuarioForm_Load_1(object sender, EventArgs e)
        {


        }

        //Elementos Esenciales del Form
        public void SharedLoad(UserModel currentUser)
        {
            LoadCDepartamento();
            gbDatosGenerales.Visible = true;
            gbUserLog.Visible = false;
            this.currentUser = currentUser;
            pnlActivity.Visible = false;
        }
        //Inicializar el formulario para ver perfil

        //Inicializar el formulario cuando es para crear un nuevo usuario
        private void InitializeFormWithoutUserData(UsuarioDao usuarioDao)
        {
            btnActividad.Visible = false;
            usuario.IDUser = usuarioDao.AutogeneradorID();
            cbActiveState.Enabled = false;
            cbActiveState.Visible = false;
            usuario.ActiveStateU = true;

        }

        //Inicializar el formulario cuando se tiene informacion de un usuario
        private void InitializeFormWithUserData(UserModel usuarioData)
        {

            // Asignar los valores del usuario seleccionado a los controles del formulario

            //Detalles del Usuario
            cbActiveState.Checked = usuarioData.ActiveStateU;
            lblCreationDate.Text = usuarioData.CreationDate.ToString();
            lblLastUpdatedDate.Text = lblLastUpdatedDate != null ? usuarioData.LastUpdatedDate.ToString() : "N/A";
            lblDeactivationDate.Text = usuarioData.DeactivationDate != null ? usuarioData.DeactivationDate.ToString() : "N/A";
            lblReactivationDate.Text = usuarioData.ReactivationDate != null ? usuarioData.ReactivationDate.ToString() : "N/A";

            //Datos Generales
            tbName.Text = usuarioData.Name;
            tbLastname.Text = usuarioData.Lastname;
            cmbDepartamento.SelectedItem = usuarioData.Departamento;

            //Credenciales
            tbEmail.Text = usuarioData.Email;
            txtUsername.Text = usuarioData.Username;
            cbAdmin.Checked = usuarioData.Roles.AdminPerms;
            cbEmpleado.Checked = usuarioData.Roles.BasicPerms;
            cbIT.Checked = usuarioData.Roles.ITPerms;

            usuario = usuarioData;

        }

        //Boton para GUARDAR los datos del usuario
        private void btnConfirmUserCreation_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarDatosGenerales();
                ValidarPermisos();
                ValidarLogUser();

                string email = tbEmail.Text.Trim();
                usuario.Email = email;
                usuario.Roles.ITPerms = cbIT.Checked ? true : false;
                usuario.Roles.AdminPerms = cbAdmin.Checked ? true : false;
                usuario.Roles.BasicPerms = cbEmpleado.Checked ? true : false;
                UsuarioCreated?.Invoke(usuario);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos del usuario. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //****HABILITACION Y DESHABILITACION DE USUARIO****//
        private void cbActiveState_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbActiveState.Checked)
            {
                usuario.ActiveStateU = true;
                cbActiveState.BackColor = Color.MediumSeaGreen;
                cbActiveState.Text = "Activo";
                usuario.ReactivationDate = DateTime.Now;

            }
            else
            {
                usuario.ActiveStateU = false;
                cbActiveState.BackColor = Color.IndianRed;
                cbActiveState.Text = "Inactivo";
            }
        }
        //****BOTONES DE NAVEGACION****//
        //Botón para regresar a la ventana de datos generales
        private void btnDatosGenerales_Click(object sender, EventArgs e)
        {
            gbDatosGenerales.Visible = true;
            gbUserLog.Visible = false;
            tbName.Focus();
        }

        //Botón para ir a la ventana de credenciales
        private void btnUserLogDat_Click(object sender, EventArgs e)
        {
            try
            {

                ValidarDatosGenerales();

                gbDatosGenerales.Visible = false;
                gbUserLog.Visible = true;

                usuario.Name = tbName.Text.Trim();
                usuario.Lastname = tbLastname.Text.Trim();
                usuario.Departamento = (Departament)cmbDepartamento.SelectedItem;
                usuario.SetUsername();

                txtUsername.Text = usuario.Username;
                txtUsername.Enabled = false;
                txtPassword.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar los datos generales. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //****VALIDACIONES****//
        //Validar los datos generales
        public void ValidarDatosGenerales()
        {
            if (string.IsNullOrEmpty(tbName.Text.Trim()) || string.IsNullOrEmpty(tbLastname.Text.Trim()) || cmbDepartamento.SelectedIndex == -1)
            {
                throw new Exception("Los datos generales no pueden estar vacíos.");

            }

        }

        //Validar las credenciales
        public void ValidarLogUser()
        {
            if (string.IsNullOrEmpty(usuario.Username.Trim()) || string.IsNullOrEmpty(usuario.EncryptedPassword))
            {
                throw new Exception("La contraseña no puede estar vacía.");
            }
            else if (string.IsNullOrEmpty(tbEmail.Text.Trim()))
            {
                throw new Exception("El correo electrónico no puede estar vacío.");
            }


        }

        //Validar los permisos 
        public void ValidarPermisos()
        {
            if (!cbAdmin.Checked && !cbEmpleado.Checked && !cbIT.Checked)
            {
                throw new Exception("Debe seleccionar al menos un permiso.");
            }

        }



        public void LoadCDepartamento()
        {
            cmbDepartamento.Items.Clear();
            cmbDepartamento.DataSource = Enum.GetValues(typeof(Departament));
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Deseas generar automáticamente tu contraseña y guardarla?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                txtPassword.Text = usuario.GeneratePassword();
                tbEmail.Focus();

            }
            else
            {
                txtPassword.Clear();
                tbEmail.Focus();
            }

        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Deseas guardar esta contraseña como tu nueva clave?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    usuario.SetPassword(txtPassword.Text.Trim());
                    
                }
                else
                {
                    MessageBox.Show("La contraseña no puede estar vacía.", "¡Espera!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            else
            {
                txtPassword.Clear();
                tbEmail.Focus();
            }
        }

        private void btnActividad_Click(object sender, EventArgs e)
        {
            if (pnlActivity.Visible)
            {
                pnlActivity.Visible = false;
            }
            else
            {
                pnlActivity.Visible = true;

            }

        }

        //****ENTER Y EVENTOS RELACIONADOS****//
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtPassword != null)
                {
                    tbEmail.Focus();
                }
                else
                {
                    btnGeneratePassword_Click(sender, e);
                }

            }
        }

        public void DeshabilitarControlesAlVerPerfil()
        {
            tbName.Enabled = false;
            tbLastname.Enabled = false;
            cmbDepartamento.Enabled = false;
            tbEmail.Enabled = true;
            txtUsername.Enabled = false;
            txtPassword.Enabled = true;
            cbAdmin.Enabled = false;
            cbEmpleado.Enabled = false;
            cbIT.Enabled = false;
            btnGeneratePassword.Enabled = true;
            btnConfirmUserCreation.Enabled = true;
            cbActiveState.Enabled = false;
        }

        //private void tbEmail_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (true)
        //    {

        //    }
        //}

        //public bool ValidarEmail()
    }
}
