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
        public CrearUsuarioForm(UsuarioDao usuarioService)
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
            InitializeFormWithUserData();
        }

        //Inicializar el formulario cuando es para crear un nuevo usuario
        private void InitializeFormWithoutUserData()
        {
            usuario.IDUser = usuarioServiceLocal.AutogeneradorID();
            tbIDUser.Text = usuario.IDUser.ToString();
            usuario.ActiveStateU = true;

        }

        //Inicializar el formulario cuando se ha seleccionado un usuario del DataGridView
        private void InitializeFormWithUserData()
        {
            if (usuarioSel != null)
            {
                // Asignar los valores del usuario seleccionado a los controles del formulario
                tbIDUser.Text = usuarioSel.IDUser.ToString();
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
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string name = tbName.Text;
            string lastname = tbLastname.Text;
            string email = tbEmail.Text;
            int indexUsuario = int.Parse(tbIDUser.Text);

            usuarioValid = ValidarDatos() && ValidarPermisos(); //Validar los datos ingresados

            //try
            //{
            if (usuarioValid)
            {
                usuario.Username = username;
                usuario.SetPassword(password);
                usuario.Name = name;
                usuario.Lastname = lastname;
                usuario.Email = email;
                usuario.Departamento = (Departament)cmbDepartamento.SelectedItem;

                usuario.Roles.ITPerms = cbIT.Checked ? true : false;
                usuario.Roles.AdminPerms = cbAdmin.Checked ? true : false;
                usuario.Roles.BasicPerms = cbEmpleado.Checked ? true : false;



                usuarioValid = true;
                UsuarioCreated?.Invoke(usuario);

                this.Close();

            }
            else
            {
                MessageBox.Show("Revise el formato de los datos ingresados, no se admiten campos vacíos. Mínimo uno de los permisos debe estar activo", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        public bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbLastname.Text) || string.IsNullOrEmpty(tbEmail.Text) || string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) || cmbDepartamento.SelectedIndex == -1)
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


        private void CrearUsuarioForm_Load_1(object sender, EventArgs e)
        {
            cmbDepartamento.Items.Clear();
            cmbDepartamento.SelectedIndex = -1;
            cmbDepartamento.DataSource = Enum.GetValues(typeof(Departament));

            tbIDUser.Enabled = false;
        }
    }
}
