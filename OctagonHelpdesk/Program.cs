using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OctagonHelpdesk.Models;
using OctagonHelpdesk.Models.Enum;
using OctagonHelpdesk.Services;

namespace OctagonHelpdesk
{
    internal static class Program
    {
        private static string rutaArchivoUsuarios = @"data\data.dat";

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

            Application.Run(new MdiParentFrm());
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
