using OctagonHelpdesk.Models;
using OctagonHelpdesk.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;


namespace OctagonHelpdesk.Formularios
{
    public partial class RegTicketFrm : Form
    {
        public TicketDao tickets = new TicketDao();
        public List<Ticket> ticketsList;
        public UserModel currentUser { get; set; }


        public RegTicketFrm(UserModel currentUser)
        {
            ticketsList = tickets.tickets;
            InitializeComponent();
            InitializeBinding();
            this.currentUser = currentUser;

        }
        //Inicializa el BindingSource
        private void InitializeBinding()
        {
            bindingSource.DataSource = tickets.GetTickets();
            DgvRegTickets.DataSource = bindingSource;
            bindingNavigator1.BindingSource = bindingSource;
            bindingNavigatorDeleteItem.Enabled = false;
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
                bindingSource.ResetBindings(false);
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
            bindingSource.ResetBindings(false);
            tickets.SaveTicketstoDisk(ticketsList);
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
            CmpTicketFrm ticketFrm = new CmpTicketFrm(tickets, ticketSel, currentUser);
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
        public void FilterMyTickets()
        {
            bindingSource.Filter = $"IDUser = {currentUser.IDUser}";
        }

        private void RegTicketFrm_Load(object sender, EventArgs e)
        {
            if (!currentUser.Roles.ITPerms || !currentUser.Roles.AdminPerms)
            {
                FilterMyTickets();
            }
        }
    }
}

