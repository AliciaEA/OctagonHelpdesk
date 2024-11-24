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

        }
        private void CrearUsuarioForm_Load_1(object sender, EventArgs e)
        {


        }

        //Elementos Escenciales del Form
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

            bool usuarioValid = false;
            usuarioValid = ValidarDatosGenerales() && ValidarPermisos() && ValidarLogUser(); //Validar los datos ingresados
            if (usuarioValid)
            {
                string email = tbEmail.Text.Trim();
                usuario.Email = email;
                usuario.Roles.ITPerms = cbIT.Checked ? true : false;
                usuario.Roles.AdminPerms = cbAdmin.Checked ? true : false;
                usuario.Roles.BasicPerms = cbEmpleado.Checked ? true : false;
                UsuarioCreated?.Invoke(usuario);
                
                

                this.Close();

            }
            else
            {
                MessageBox.Show("Revise el formato de los datos ingresados, no se admiten campos vacíos. Mínimo uno de los permisos debe estar activo", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        //Boton para regresar a la ventana de datos generales
        private void btnDatosGenerales_Click(object sender, EventArgs e)
        {
            gbDatosGenerales.Visible = true;
            gbUserLog.Visible = false;
        }

        //Boton para ir a la ventana de credenciales
        private void btnUserLogDat_Click(object sender, EventArgs e)
        {

            if (ValidarDatosGenerales())
            {
                gbDatosGenerales.Visible = false;
                gbUserLog.Visible = true;

                usuario.Name = tbName.Text.Trim();
                usuario.Lastname = tbLastname.Text.Trim();
                usuario.Departamento = (Departament)cmbDepartamento.SelectedItem;
                usuario.SetUsername();
                
                txtUsername.Text = usuario.Username;
                txtUsername.Enabled = false;
                
               
            }
            else
            {
                MessageBox.Show("Para generar las credenciales del empleado, se necesita rellenar estos campos. No se admiten campos vacíos", "¡Espera!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //****VALIDACIONES****//
        //Validar los datos generales
        public bool ValidarDatosGenerales()
        {
            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbLastname.Text) || cmbDepartamento.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }
        //Validar las credenciales
        public bool ValidarLogUser()
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(usuario.EncryptedPassword))
            {
                return false;
            }
            return true;
        }

        //Validar los permisos 
        public bool ValidarPermisos()
        {
            if (cbAdmin.Checked || cbEmpleado.Checked || cbIT.Checked)
            {
                return true;
            }
            return false;
        }



        public void LoadCDepartamento()
        {
            cmbDepartamento.Items.Clear();
            cmbDepartamento.DataSource = Enum.GetValues(typeof(Departament));
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Deseas generar automaticamente tu contraseña y guardarla?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                txtPassword.Text = usuario.GeneratePassword();
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
                usuario.SetPassword(txtPassword.Text.Trim());
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

        //private void tbEmail_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (true)
        //    {

        //    }
        //}

        //public bool ValidarEmail()
    }
}
