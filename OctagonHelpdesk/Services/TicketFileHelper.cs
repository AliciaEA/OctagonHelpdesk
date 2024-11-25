using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OctagonHelpdesk.Models.Enum;
using OctagonHelpdesk.Models;
using System.Security.AccessControl;

namespace OctagonHelpdesk.Services
{
    public class TicketFileHelper
    {
        private string rutaArchivo = @"data\tickets.dat";
        //string rutaArchivo = @"tickets.dat";
        string globalpath = AppDomain.CurrentDomain.BaseDirectory;
        string localpath;



        public TicketFileHelper()
        {
         /*   localpath = Path.Combine(globalpath, @"..\..\Data");
            rutaArchivo = Path.Combine(localpath, rutaArchivo);

            Console.WriteLine(rutaArchivo);

            DirectoryInfo dInfo = new DirectoryInfo(rutaArchivo);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(
                "Everyone",
                FileSystemRights.FullControl,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None,
                AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity); */
        }


        private DateTime dateformater(string date)
        {
            return DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public void SaveTickets(List<Ticket> ticketList)
        {
            using (FileStream archivo = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter escritor = new BinaryWriter(archivo))
                {
                    foreach (Ticket ticket in ticketList)
                    {
                        escritor.Write(ticket.IDTicket);
                        escritor.Write(ticket.ActiveState);
                        escritor.Write(ticket.CreatedBy);
                        escritor.Write(ticket.Subject);
                        escritor.Write(ticket.Descripcion);
                        escritor.Write((int)ticket.StateProcess);
                        escritor.Write((int)ticket.Prioridad);
                        escritor.Write(ticket.AsignadoA);
                        escritor.Write(ticket.CreationDate.ToString("dd/MM/yyyy"));
                        escritor.Write(ticket.LastUpdatedDate.ToString("dd/MM/yyyy"));
                        escritor.Write(ticket.DeactivationDate.ToString("dd/MM/yyyy"));
                        escritor.Write(ticket.ReactivationDate.ToString("dd/MM/yyyy"));
                        escritor.Write(ticket.CloseDate.ToString("dd/MM/yyyy"));
                      //  escritor.Write(ticket.ticketimage.IDTicket);
                      //  escritor.Write(ticket.ticketimage.Imagepath);
                        escritor.Write(ticket.Imagepath ?? string.Empty);
                    }
                }
            }
        }

        public List<Ticket> GetTickets()
        {
            List<Ticket> tickets = new List<Ticket>();
            if (!File.Exists(rutaArchivo)) return null;

            using (FileStream archivo = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader lector = new BinaryReader(archivo))
                {
                    while (archivo.Position < archivo.Length)
                    {
                        try
                        {
                            Ticket ticket = new Ticket
                            {
                                IDTicket = lector.ReadInt32(),
                                ActiveState = lector.ReadBoolean(),
                                CreatedBy = lector.ReadInt32(),
                                Subject = lector.ReadString(),
                                Descripcion = lector.ReadString(),
                                StateProcess = (State)lector.ReadInt32(),
                                Prioridad = (Priority)lector.ReadInt32(),
                                AsignadoA = lector.ReadInt32(),
                                CreationDate = ParseDate(lector.ReadString()),
                                LastUpdatedDate = ParseDate(lector.ReadString()),
                                DeactivationDate = ParseDate(lector.ReadString()),
                                ReactivationDate = ParseDate(lector.ReadString()),
                                CloseDate = ParseDate(lector.ReadString()),
                                //ticketimage = new TicketImage
                                //{
                                //   IDTicket = lector.ReadInt32(),
                                //    Imagepath = lector.ReadString()
                                //}
                                Imagepath = lector.ReadString()
                            };

                            Console.WriteLine("Debug #05: "+ticket.Imagepath);

                            tickets.Add(ticket);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"Error al leer el ticket: {ex.Message}");
                        }
                    }
                }
            }
            return tickets;
        }

        private DateTime ParseDate(string dateString)
        {
            if (DateTime.TryParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return date;
            }
            else
            {
                throw new FormatException($"{dateString} no es una fecha válida.");
            }
        }

        public void SaveTicket(Ticket ticket)
        {
            List<Ticket> tickets = GetTickets() ?? new List<Ticket>();
            tickets.Add(ticket);
            SaveTickets(tickets);
        }


    }
}
