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
        private readonly UsuarioDao usuarioServiceLocal;

        public UserModel usuario = new UserModel();
        public UserModel usuarioSel = new UserModel();

        //Primer Constructor para cuando se crea un Usuario
        public CrearUsuarioForm(UsuarioDao usuarioService )
        {
            InitializeComponent();
            usuarioServiceLocal = usuarioService;
            InitializeFormWithoutUserData();


        }

        //Segundo Constructor, cuando se selecciona un Usuario del DataGridView
        public CrearUsuarioForm(UsuarioDao usuarios, UserModel usuarioSelected)//Se envia la info del User Seleccionado
        {
            InitializeComponent();
            usuarioServiceLocal = usuarios;
            usuarioSel = usuarioSelected;
            
        }
        //Inicializar el formulario para ver perfil

        //Inicializar el formulario cuando es para crear un nuevo usuario
        private void InitializeFormWithoutUserData()
        {
            usuario.IDUser = usuarioServiceLocal.AutogeneradorID();
            cbActiveState.Enabled = false;
            cbActiveState.Visible = false;
            usuario.ActiveStateU = true;

        }

        //Inicializar el formulario cuando se ha seleccionado un usuario del DataGridView
        private void InitializeFormWithUserData()
        {
            if (usuarioSel != null)
            {
                // Asignar los valores del usuario seleccionado a los controles del formulario
                cbActiveState.Checked = usuarioSel.ActiveStateU;
                tbName.Text = usuarioSel.Name;
                tbLastname.Text = usuarioSel.Lastname;
                tbEmail.Text = usuarioSel.Email;
                cmbDepartamento.SelectedItem = usuarioSel.Departamento;
                txtUsername.Text = usuarioSel.Username;
                cbAdmin.Checked = usuarioSel.Roles.AdminPerms;
                cbEmpleado.Checked = usuarioSel.Roles.BasicPerms;
                cbIT.Checked = usuarioSel.Roles.ITPerms;

                // Asignar otros valores según sea necesario
                usuario = usuarioSel;
            }
        }

        //Boton para guardar los datos del usuario
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

        public bool ValidarDatosGenerales()
        {
            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbLastname.Text) || cmbDepartamento.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }
        public bool ValidarUserLog()
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(tbEmail.Text))
            {
                return false;
            }
            return true;
        }
        public bool ValidarPermisos()
        {
            if (cbAdmin.Checked || cbEmpleado.Checked || cbIT.Checked)
            {
                return true;
            }
            return false;
        }
        public bool ValidarLogUser()
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                return false;
            }
            return true;
        }

        public void LoadCDepartamento()
        {
            cmbDepartamento.Items.Clear();
            cmbDepartamento.DataSource = Enum.GetValues(typeof(Departament));
        }

        private void CrearUsuarioForm_Load_1(object sender, EventArgs e)
        {
            LoadCDepartamento();
            gbDatosGenerales.Visible = true;
            gbUserLog.Visible = false;
            if (usuarioSel != null)
            {
                InitializeFormWithUserData();

            }
        }

        private void btnDatosGenerales_Click(object sender, EventArgs e)
        {
            gbDatosGenerales.Visible = true;
            gbUserLog.Visible = false;
            

        }

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
                usuario.SetPassword(txtPassword.Text);
                txtPassword.Text = usuario.EncryptedPassword;

                
               
                
               

            }
            else
            {
                MessageBox.Show("Para generar las credenciales del empleado, se necesita rellenar estos campos. No se admiten campos vacíos", "¡Espera!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

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
    }
}
