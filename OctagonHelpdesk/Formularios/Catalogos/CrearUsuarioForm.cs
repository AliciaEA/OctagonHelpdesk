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

namespace OctagonHelpdesk.Formularios
{
    public partial class CrearUsuarioForm : Form
    {

        public event Action<UserModel> UsuarioCreated;
        private readonly UsuarioService usuarioServiceLocal;

        public UserModel usuario { get; set; }
        public CrearUsuarioForm(UsuarioService usuarioService)
        {
            InitializeComponent();
            usuarioServiceLocal = usuarioService;
            
        }

        private void btnConfirmUserCreation_Click(object sender, EventArgs e)
        {
            // Se tiene que autogenerar el ID del usuario
            usuario.IDUser = usuarioServiceLocal.AutogeneradorID();
            usuario.Name = tbName.Text;
            usuario.Email = tbEmail.Text;
            usuario.CreationDate = DateTime.Now;
            usuario.ActiveStateU = true;
            usuario.Departamento = (Departament)cmbDepartamento.SelectedItem;

            UsuarioCreated?.Invoke(usuario);

            FileHelper fileHelper = new FileHelper();

            List<UserModel> userModels = new List<UserModel>();
            userModels = fileHelper.GetUsers();

            try
            {
                fileHelper.SaveUser(userModels, usuario.Roles.AdminPerms);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Womp womp");
            }


            this.Close();

        }

        private void CrearUsuarioForm_Load(object sender, EventArgs e)
        {

        }

        private void CrearUsuarioForm_Load_1(object sender, EventArgs e)
        {
            cmbDepartamento.Items.Clear();
            cmbDepartamento.SelectedIndex = -1;
            cmbDepartamento.DataSource = Enum.GetValues(typeof(Departament));
        }
    }
}
