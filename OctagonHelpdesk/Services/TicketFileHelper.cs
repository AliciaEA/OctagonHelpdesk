using OctagonHelpdesk.Models;
using OctagonHelpdesk.Models.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class TicketFileHelper
{
    private readonly string rutaArchivo;

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
                    escritor.Write(ticket.Description);
                    escritor.Write((int)ticket.StateProcess);
                    escritor.Write((int)ticket.Prioridad);
                    escritor.Write(ticket.AsignadoA.HasValue); // Escribir si AsignadoA tiene un valor
                    if (ticket.AsignadoA.HasValue)
                    {
                        escritor.Write(ticket.AsignadoA.Value); // Escribir el valor de AsignadoA
                    }
                    escritor.Write(ticket.CreationDate.ToString("dd/MM/yyyy HH:mm:ss"));
                    // Escribir LastUpdatedDate
                    escritor.Write(ticket.LastUpdatedDate.HasValue);
                    if (ticket.LastUpdatedDate.HasValue)
                    {
                        escritor.Write(ticket.LastUpdatedDate.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                    }

                    // Escribir DeactivationDate
                    escritor.Write(ticket.DeactivationDate.HasValue);
                    if (ticket.DeactivationDate.HasValue)
                    {
                        escritor.Write(ticket.DeactivationDate.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                    }

                    // Escribir ReactivationDate
                    escritor.Write(ticket.ReactivationDate.HasValue);
                    if (ticket.ReactivationDate.HasValue)
                    {
                        escritor.Write(ticket.ReactivationDate.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                    }
                    escritor.Write(ticket.CloseDate.HasValue);
                    if (ticket.CloseDate.HasValue)
                    {
                        escritor.Write(ticket.CloseDate.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                    }
                    escritor.Write(ticket.imagepath ?? string.Empty);
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
                            Description = lector.ReadString(),
                            StateProcess = (State)lector.ReadInt32(),
                            Prioridad = (Priority)lector.ReadInt32(),
                            
                        };

                        bool hasAsignadoA = lector.ReadBoolean(); // Leer si AsignadoA tiene un valor
                        ticket.AsignadoA = hasAsignadoA ? lector.ReadInt32() : (int?)null; // Leer el valor de AsignadoA si no es nulo

                        ticket.CreationDate = ParseDate(lector.ReadString());
                        if (lector.ReadBoolean())
                        {
                            ticket.LastUpdatedDate = SafeParseDate(lector.ReadString());
                        }

                        if (lector.ReadBoolean())
                        {
                            ticket.DeactivationDate = SafeParseDate(lector.ReadString());
                        }

                        if (lector.ReadBoolean())
                        {
                            ticket.ReactivationDate = SafeParseDate(lector.ReadString());
                        }
                        if (lector.ReadBoolean())
                        {
                            ticket.CloseDate = SafeParseDate(lector.ReadString());
                        }
                        ticket.imagepath = lector.ReadString();
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
        if (DateTime.TryParseExact(dateString, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
        {
            return date;
        }
        else
        {
            throw new FormatException($"La cadena '{dateString}' no es una fecha válida.");
        }
    }
    private DateTime? SafeParseDate(string dateString)
    {
        if (DateTime.TryParseExact(dateString, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
        {
            return date;
        }
        else
        {
            // Manejar el error de fecha no válida
            return null;
        }
    }

    public void SaveTicket(Ticket ticket)
    {
        List<Ticket> tickets = GetTickets() ?? new List<Ticket>();
        tickets.Add(ticket);
        SaveTickets(tickets);
    }
}
