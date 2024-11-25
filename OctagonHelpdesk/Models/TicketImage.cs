using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctagonHelpdesk.Models
{
    public class TicketImage
    {
        // For future use
        public int IDTicket { get; set; }
        public string Imagepath;

        public void setimage(string imagename)
        {
            string temp = @"data\images\";
            Imagepath = temp+imagename.Trim();
        }

        


    }
}
