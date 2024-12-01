using OctagonHelpdesk.Models.Enum;
using OctagonHelpdesk.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System;

public class TicketFileHelper
{
    private string rutaArchivo;

    public TicketFileHelper()
    {
        // Establecer la ruta del archivo relativa al directorio raíz del proyecto
        string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
        rutaArchivo = Path.Combine(projectDirectory, @"Data\tickets.dat");

        // Crear el directorio si no existe
        string directory = Path.GetDirectoryName(rutaArchivo);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        // Crear el archivo si no existe
        if (!File.Exists(rutaArchivo))
        {
            using (FileStream fs = File.Create(rutaArchivo))
            {
            }
        }
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
                    escritor.Write(ticket.imagepath ?? string.Empty); // Manejar nulo
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
                            imagepath = lector.ReadString()
                        };

                        // Manejar el caso en el que imagepath es una cadena vacía
                        if (string.IsNullOrEmpty(ticket.imagepath))
                        {
                            ticket.imagepath = null;
                        }

                        tickets.Add(ticket);
                    }
                    catch (EndOfStreamException)
                    {
                        // Manejar el caso en el que se alcanza el final del archivo inesperadamente
                        break;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error al leer el ticket en la posición {archivo.Position}: {ex.Message}");
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
