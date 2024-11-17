﻿using OctagonHelpdesk.Services;
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
        private readonly UsuarioService usuarioServiceLocal;

        public UserModel usuario = new UserModel();
        public UserModel usuarioSel = new UserModel();

        //Primer Constructor para cuando se crea un Usuario
        public CrearUsuarioForm(UsuarioService usuarioService)
        {
            InitializeComponent();
            usuarioServiceLocal = usuarioService;
            InitializeFormWithoutUserData();


        }

        //Segundo Constructor, cuando se selecciona un Usuario del DataGridView
        public CrearUsuarioForm(UsuarioService usuarios, UserModel usuarioSelected)//Se envia la info del User Seleccionado
        {
            InitializeComponent();
            usuarioServiceLocal = usuarios;
            usuarioSel = usuarioSelected;
            InitializeFormWithUserData();
        }

        //Inicializar el formulario cuando es para crear un nuevo usuario
        private void InitializeFormWithoutUserData()
        {
            tbIDUser.Text = usuarioServiceLocal.AutogeneradorID().ToString();
            usuario.ActiveStateU = true;
            usuario.CreationDate = DateTime.Now;

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
                // Asignar otros valores según sea necesario
                usuario.CreationDate = usuarioSel.CreationDate;
            }
        }

        //Boton para guardar los datos del usuario
        private void btnConfirmUserCreation_Click(object sender, EventArgs e)
        {
            
            bool usuarioValid = false;
            string name = tbName.Text;
            string lastname = tbLastname.Text;
            string email = tbEmail.Text;
            int indexUsuario = int.Parse(tbIDUser.Text);

            usuarioValid = ValidarDatos(); //Validar los datos ingresados

            try
            {
                if (usuarioValid)
                {
                    usuario.IDUser = int.Parse(tbIDUser.Text);
                    usuario.Name = name;
                    usuario.Lastname = lastname;
                    usuario.Email = email;
                    usuario.LastUpdatedDate = DateTime.Now;

                    usuario.Departamento = (Departament)cmbDepartamento.SelectedItem;
                    usuarioValid = true;
                    UsuarioCreated?.Invoke(usuario);

                    this.Close();

                }
                else
                {
                    MessageBox.Show("Revise el Formato de los Datos Ingresados", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbLastname.Text) || string.IsNullOrEmpty(tbEmail.Text) || cmbDepartamento.SelectedIndex == -1)
            {
                return false;
            }
            return true;
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
