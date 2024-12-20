﻿using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using OctagonHelpdesk.Models;
using OctagonHelpdesk.Reportes;
using OctagonHelpdesk.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace OctagonHelpdesk.Formularios
{
    public partial class RegTicketFrm : Form
    {
        public TicketDao tickets = new TicketDao();
        UsuarioDao usuarios = new UsuarioDao();


        public UserModel currentUser { get; set; }


        public RegTicketFrm(UserModel usuario)
        {
            this.currentUser = usuario;
            InitializeComponent();
            InitializeBinding();


        }
        //Inicializa el BindingSource
        private void InitializeBinding()
        {

            bindingSource.DataSource = !currentUser.Roles.ITPerms || !currentUser.Roles.AdminPerms ? tickets.GetTicketsByUserID(currentUser.IDUser) : tickets.GetTickets();
            DgvRegTickets.DataSource = bindingSource;
            bindingNavigator1.BindingSource = bindingSource;
            bindingNavigatorDeleteItem.Enabled = false;

            userModelBindingSource.DataSource = usuarios.GetUsuarios();
        }
        private void UpdateLists()
        {
            bindingSource.ResetBindings(false);
            userModelBindingSource.DataSource = usuarios.GetUsuarios();
            userModelBindingSource.ResetBindings(false); // Actualiza tanto los enlaces de datos como la lista de datos subyacente
        }
        //BOTONES DE LA BARRA DE HERRAMIENTAS
        //Boton de Agregar
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            CrearTicket();
        }

        //Boton de Editar
        private void DgvRegTickets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SelectedTicketRow() != null)
            {
                EditarTicket(SelectedTicketRow());
            }
        }

        //Boton de Eliminar
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro de que desea eliminar este ticket?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                tickets.RemoveTicket(SelectedTicketRow());
                MessageBox.Show("Ticket eliminado correctamente", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindingSource.DataSource = !currentUser.Roles.ITPerms || !currentUser.Roles.AdminPerms ? tickets.GetTicketsByUserID(currentUser.IDUser) : tickets.GetTickets();
                bindingSource.ResetBindings(false);
                userModelBindingSource.DataSource = usuarios.GetUsuarios();
                userModelBindingSource.ResetBindings(false); // Actualiza tanto los enlaces de datos como la lista de datos subyacente
            }
            else
            {
                MessageBox.Show("No se ha eliminado el ticket", "Eliminación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //EVENTOS
        private void OnTicketCreated(Ticket ticket)
        {
            int indexTicket = tickets.FindPosition(ticket.IDTicket);
            if (indexTicket != -1)
            {
                tickets.UpdateTicket(ticket);
            }
            else
            {
                tickets.AddTicket(ticket);
            }
            bindingSource.DataSource = !currentUser.Roles.ITPerms || !currentUser.Roles.AdminPerms ? tickets.GetTicketsByUserID(currentUser.IDUser) : tickets.GetTickets();
            bindingSource.ResetBindings(false);
            userModelBindingSource.DataSource = usuarios.GetUsuarios();
            userModelBindingSource.ResetBindings(false); // Actualiza tanto los enlaces de datos como la lista de datos subyacente

        }

        //FUNCIONES DE APOYO
        //Crea un ticket y manda a llamar al formulario de creación de tickets
        private void CrearTicket()
        {
            CmpTicketFrm ticketFrm = new CmpTicketFrm(tickets, currentUser);
            ticketFrm.TicketCreated += OnTicketCreated;
            ticketFrm.ShowDialog();
        }

        //Manda a llamar al formulario de edición de tickets
        public void EditarTicket(Ticket ticketSel)
        {
            CmpTicketFrm ticketFrm = new CmpTicketFrm(ticketSel, currentUser);
            ticketFrm.TicketCreated += OnTicketCreated;
            ticketFrm.ShowDialog();
        }

        //Devuelve el ticket seleccionado en el DataGridView
        public Ticket SelectedTicketRow()
        {
            DataGridViewRow currentRow = DgvRegTickets.CurrentRow;
            Ticket ticketSel = new Ticket();

            if (currentRow != null)
            {
                ticketSel.IDTicket = Convert.ToInt32(currentRow.Cells[0].Value);
                ticketSel = tickets.GetTicket(ticketSel.IDTicket);
                return ticketSel;

            }
            return null;
        }

        private void DgvRegTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bindingNavigatorDeleteItem.Enabled = true;
        }

        //****FILTRO DE BUSQUEDA****//


        private void RegTicketFrm_Load(object sender, EventArgs e)
        {
            if (!currentUser.Roles.ITPerms || !currentUser.Roles.AdminPerms)
            {
                cmbFilterQuick.Enabled = false;
                cmbFilterQuick.SelectedItem = "Mis Tickets";
            }
            else
            {
                cmbFilterQuick.Enabled = true;
                cmbFilterQuick.SelectedItem = "Todos";
            }
        }

        private void GenerateReport()
        {
            List<Ticket> ticketsFiltered = new List<Ticket>();


            if (tickets.GetTickets() != null)
            {
                if (!currentUser.Roles.ITPerms || !currentUser.Roles.AdminPerms)
                {
                    ticketsFiltered = tickets.GetTicketsByUserID(currentUser.IDUser);

                }
                else
                {


                    if (cmbFilterQuick.SelectedItem.ToString() == "Todos")
                    {
                        ticketsFiltered = tickets.GetTickets();
                    }
                    else
                    {
                        ticketsFiltered = tickets.GetTicketsByUserID(currentUser.IDUser);
                    }
                }
                ReportDataSource rds = new ReportDataSource("DsDatos", ticketsFiltered);
                RptVistaPrevia reporte = new RptVistaPrevia();
                reporte.reportViewer1.LocalReport.DataSources.Clear();
                reporte.reportViewer1.LocalReport.DataSources.Add(rds);
                reporte.reportViewer1.LocalReport.ReportEmbeddedResource = "OctagonHelpdesk.Reportes.RptTickets.rdlc";
                reporte.reportViewer1.RefreshReport();
                reporte.ShowDialog();

            }
            else
            {
                MessageBox.Show("No hay tickets para mostrar", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void btnReportesVistaPrevia_Click(object sender, EventArgs e)
        {
            GenerateReport();

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Limpiar el DataGridView y su DataSource
            DgvRegTickets.DataSource = null;
            bindingSource.DataSource = null;
            userModelBindingSource.DataSource = null;

            base.OnFormClosing(e);
        }

        private void cmbFilterQuick_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterQuick.SelectedItem.ToString() == "Todos")
            {
                bindingSource.DataSource = tickets.GetTickets();
            }
            else
            {
                bindingSource.DataSource = tickets.GetTicketsByUserID(currentUser.IDUser);
            }
        }

        private void btnReportTicket_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }
    }
}

