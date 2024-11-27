using OctagonHelpdesk.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctagonHelpdesk.Models
{
    public class Ticket
    {
        public int IDTicket { get; set; }
        public bool ActiveState { get; set; }
        public int CreatedBy { get; set; }
        public string Subject { get; set; }
        public string Descripcion { get; set; }
        public State StateProcess { get; set; }
        public Priority Prioridad { get; set; }
        public int AsignadoA { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public DateTime DeactivationDate { get; set; }
        public DateTime ReactivationDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string imagepath { get; set; }




        public Ticket()
        {

        }

        public Ticket(int creadorPorID)
        {
            CreatedBy = creadorPorID;


        }

    }

}
