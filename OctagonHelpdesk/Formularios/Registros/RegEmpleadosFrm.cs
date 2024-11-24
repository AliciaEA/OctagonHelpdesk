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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using OctagonHelpdesk.Models.Enum;
using OctagonHelpdesk.DataSet;

namespace OctagonHelpdesk.Formularios
{
    public partial class RegEmpleadosFrm : Form
    {
        public UsuarioDao usuarios = new UsuarioDao();
        public UserModel currentUser { get; set; }

        public RegEmpleadosFrm(UserModel currentUser)
        {
            InitializeComponent();
            InitializeBinding();
            this.currentUser = currentUser;
        }

        //Rellena el DataGridView con los datos de bindingSource1
        private void InitializeBinding()
        {

            DgvRegUsuarios.DataSource = bindingSource1;
            bindingSource1.DataSource = usuarios.GetUsuarios();
            bindingNavigatorDeleteItem.Enabled = false;
        }

        //Inicializa los filtros de busqueda
        private void InitializeFilters()
        {
            // Llenar ComboBox de Departamento
            cmbFilterDepartment.DataSource = Enum.GetValues(typeof(Departament));

            // Llenar ComboBox de Roles
            cmbFilterRole.Items.Add("Admin");
            cmbFilterRole.Items.Add("IT");
            cmbFilterRole.Items.Add("Empleado");

            // Llenar ComboBox de Estado
            cmbFilterState.Items.Add("Todos");
            cmbFilterState.Items.Add("Activo");
            cmbFilterState.Items.Add("Inactivo");
            cmbFilterState.SelectedIndex = 0; // Seleccionar "Todos" por defecto
        }

        //Cada que se guarda un usuario, se analiza, guarda y actualiza en la lista de usuarios
        private void OnUsuarioCreated(UserModel usuario)
        {
            int indexUsuario = usuarios.FindPosition(usuario.IDUser); // Busca la posición del usuario en la lista

            if (indexUsuario != -1) //Si el usuario ya existe, se actualiza
            {
                usuarios.UpdateUsuario(usuario);
            }
            else
            {
                usuarios.AddUsuario(usuario); //Si no existe, se agrega
            }
            bindingSource1.ResetBindings(false); // Actualiza el DataGridView
        }

        //Botones de la barra de herramientas, Agrega un registro
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            CrearUsuario();
        }

        //Botones de la barra de herramientas, Elimina un registro
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Seguro que deseas eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                usuarios.RemoveUsuario(SelectedRow());
                MessageBox.Show("El registro fue eliminado.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindingSource1.ResetBindings(false);

            }
            else
            {
                MessageBox.Show("El registro no fue eliminado.", "Operación cancelada");
            }
        }

        //Cuando se da doble clic en un registro, se selecciona y se envía a la ventana de edición
        private void DgvRegUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (SelectedRow() != null)
            {
                EditarUsuario(SelectedRow());
            }
        }
        public UserModel SelectedRow()
        {
            UserModel usuarioSel = new UserModel();
            DataGridViewRow row = DgvRegUsuarios.CurrentRow;
            if (row != null)
            {
                //Tomo los datos del usuario segun la fila seleccionada
                usuarioSel.IDUser = Convert.ToInt32(row.Cells[0].Value);
                usuarioSel = usuarios.GetUsuario(usuarioSel.IDUser);

                return usuarioSel;
            }
            return null;


        }

        //Envio los datos y llamo a un nuevo evento para la edición
        public void EditarUsuario(UserModel usuarioSel)
        {
            CrearUsuarioForm formEmpleado = new CrearUsuarioForm(usuarioSel, currentUser);
            formEmpleado.UsuarioCreated += OnUsuarioCreated;
            formEmpleado.ShowDialog();
        }

        //Envio los datos y llamo a un nuevo evento para la creación
        public void CrearUsuario()
        {
            CrearUsuarioForm formEmpleado = new CrearUsuarioForm(usuarios,currentUser);
            formEmpleado.UsuarioCreated += OnUsuarioCreated;
            formEmpleado.ShowDialog();
        }

        private void DgvRegUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bindingNavigatorDeleteItem.Enabled = true;
        }

        //****FILTRO DE BUSQUEDA****//
        private void ApplyFilters()
        {
            List<string> filters = new List<string>();

            if (cmbFilterDepartment.SelectedIndex != -1)
            {
                filters.Add($"Departamento = '{cmbFilterDepartment.SelectedItem}'");
            }

            if (cmbFilterRole.SelectedIndex != -1)
            {
                string role = cmbFilterRole.SelectedItem.ToString();
                if (role == "Admin")
                {
                    filters.Add("Roles.AdminPerms = true");
                }
                else if (role == "IT")
                {
                    filters.Add("Roles.ITPerms = true");
                }
                else if (role == "Empleado")
                {
                    filters.Add("Roles.BasicPerms = true");
                }
            }

            if (cmbFilterState.SelectedIndex != 0) // Si no es "Todos"
            {
                if (cmbFilterState.SelectedItem.ToString() == "Activo")
                {
                    filters.Add("ActiveStateU = true");
                }
                else if (cmbFilterState.SelectedItem.ToString() == "Inactivo")
                {
                    filters.Add("ActiveStateU = false");
                }
            }

            bindingSource1.Filter = string.Join(" AND ", filters);
        }

        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void GenerateReport()
        {
            DsDatos dsDatos = new DsDatos();
            foreach (DataGridViewRow row in DgvRegUsuarios.Rows)
            {
                if (row.DataBoundItem is DataRowView dataRowView)
                {
                    dsDatos.UsersDT.ImportRow(dataRowView.Row);
                }
            }

            RprUsers rds = new ReportDataSource("DsDatos", dsDatos.Tables["UsersDT"]);
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.LocalReport.ReportPath = "Reportes/RptUsers.rdlc";
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(rds);
            reportViewer.RefreshReport();

            Form reportForm = new Form();
            reportForm.Controls.Add(reportViewer);
            reportViewer.Dock = DockStyle.Fill;
            reportForm.ShowDialog();
        }
    }
}
