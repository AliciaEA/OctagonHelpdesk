﻿using OctagonHelpdesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctagonHelpdesk.Services
{
    public class TicketDao
    {
        public List<Ticket> tickets = new List<Ticket>();

        public TicketDao() 
        {
            FillTickets();
        }

        private void FillTickets()
        {
            TicketFileHelper ticketFileHelper = new TicketFileHelper();
            tickets = ticketFileHelper.GetTickets(); 
        }

        public void SaveTicketstoDisk(List<Ticket> tickets)
        {
            TicketFileHelper ticketFileHelper = new TicketFileHelper();
            ticketFileHelper.SaveTickets(tickets);
        }

        //Añado el ticket a la lista de tickets
        public void AddTicket(Ticket ticket)
        {
            tickets.Add(ticket);
        }

        //Para eliminar, busco su posicion y solo desactivo o inhabilito el estado del ticket
        public void RemoveTicket(Ticket ticket)
        {
            int position = FindPosition(ticket.IDTicket);
            tickets[position].ActiveState = false;
            tickets[position].DeactivationDate = DateTime.Now;
        }
        
        //Para actualizar, busco la posición del ticket y lo actualizo
        public void UpdateTicket(Ticket ticket)
        {
            int position = FindPosition(ticket.IDTicket);
            tickets[position] = ticket;
            tickets[position].LastUpdatedDate = DateTime.Now;
        }
        
        //Busco la posicion del ticket en la lista
        public int FindPosition(int IDTicket)
        {
            int position = tickets.FindIndex(ticket => ticket.IDTicket == IDTicket);
            return position;
        }

        //Retorno la lista de tickets
        public List<Ticket> GetTickets()
        {
            return tickets;
        }

        public Ticket GetTicket(int IDTicket)
        {
            return tickets.Find(ticket => ticket.IDTicket == IDTicket);
        }
        public int AutogeneradorID()
        {
            if (tickets.Count == 0)
            {
                return 1;
            }
            return tickets.Last().IDTicket + 1;
        }

    }
}
