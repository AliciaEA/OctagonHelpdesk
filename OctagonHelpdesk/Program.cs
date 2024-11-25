using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using OctagonHelpdesk.Models;
using OctagonHelpdesk.Models.Enum;
using OctagonHelpdesk.Services;

namespace OctagonHelpdesk
{
    internal static class Program
    {
        private static string rutaDirImages = @"data\images";
        private static string rutaArchivoUsuarios = @"data\data.dat";
        private static string rutaArchivoTickets = @"data\tickets.dat";


        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Verificar si el archivo de usuarios existe
            if (!File.Exists(rutaArchivoUsuarios))
            {
                // Crear el usuario por defecto (admin)
                CrearUsuarioAdminPorDefecto();
            }

            FileVerification();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string targetDirectory = Path.Combine(baseDirectory, @"..\..\Data");
            EnsureFolderPermissions(targetDirectory);


            Application.Run(new MdiParentFrm());
        }

        private static void FileVerification()
        {
            


            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            if (!Directory.Exists(rutaDirImages))
            {
                Directory.CreateDirectory(rutaDirImages);
            }

            if (!File.Exists(rutaArchivoUsuarios))
            {
                using (FileStream fs = File.Create(rutaArchivoUsuarios))
                {
                }
            }           

            //Si no existe el archivo de tickets, lo crea
            if (!File.Exists(rutaArchivoTickets))
            {
                using (FileStream fs = File.Create(rutaArchivoTickets))
                {
                }
            }
        }

        public static void EnsureFolderPermissions(string folderPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(folderPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(
                "Everyone",
                FileSystemRights.FullControl,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None,
                AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);

            string filePathdata = Path.Combine(folderPath, "data.dat");
            string filePathTicket = Path.Combine(folderPath, "tickets.dat");
            if (!File.Exists(filePathdata))
            {
                using (FileStream fs = File.Create(filePathdata))
                {
                }
            }

            if (!File.Exists(filePathTicket))
            {
                using (FileStream fs = File.Create(filePathTicket))
                {
                }
            }
            string filePathimages = Path.Combine(folderPath, "images");
            if (!Directory.Exists(filePathimages))
            {
                Directory.CreateDirectory(filePathimages);
            }

        }


        private static void CrearUsuarioAdminPorDefecto()
        {
            var adminUser = new UserModel
            {
                IDUser = 1,
                ActiveStateU = true,
                Roles = new Role
                {
                    AdminPerms = true,
                    ITPerms = true,
                    BasicPerms = true
                },
                Username = "auser01",
                Name = "Admin",
                Lastname = "User",
                Email = "admin@octagonhelpdesk.com",
                Departamento = Departament.Informatica,
                CreationDate = DateTime.Now
            };

            // Establecer la contraseña del admin
            adminUser.SetPassword("admin123");

            // Guardar el usuario en el archivo
            var fileHelper = new FileHelper();
            fileHelper.SaveUser(adminUser);
        }
    }
}
