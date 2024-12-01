using System;
using System.Text;
using OctagonHelpdesk.Services;
using OctagonHelpdesk.Models.Enum;

namespace OctagonHelpdesk.Models
{
    public class UserModel
    {
        // Alicia: Nota: Cambie el orden de los atributos

        // Nota: si esta en ingles ignoralo
        // SI ESTA EN ESPAÑOL LEELO
        public int IDUser { get; set; }

        //En vez de eliminar al empleado, solo se desactiva su Estado
        public bool ActiveStateU { get; set; }

        public Role Roles;
        public string Username { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public Departament Departamento { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public DateTime? DeactivationDate { get; set; }
        public DateTime? ReactivationDate { get; set; }

        public string EncryptedPassword { get; private set; } // Campo para la contraseña encriptada

        // Implementar UserRoles -M

        public UserModel()
        {
            Roles = new Role();

            ////Mario: Logica basica es asi: en cuanto se crea el objeto y se le asignan las propiedades de un usuario existente
            //// se busca entre donde esten almacenados los roles y se le asigna
            //// la creacion de usuario va en otro lugar, en esta clase se trabaja con la asumcion de que el usuario ya existe
            //UserRolesService userRolesService = new UserRolesService();
            //userRolesService.RetrieveRoles(this);
            //// Mario: To do, Find a way to dispose of the UserRolesServices after it's used so it doesn't hog memory
        }

       
        public string GeneratePassword()
        {
            string password = HelperPassword.GeneratePassword();
            SetPassword(password);
            return password;
        }

        public void SetPassword(string password)
        {
            if (!HelperPassword.Checkifhashed(password))
            {
                EncryptedPassword = HelperPassword.HashPassword(password);
            }
            else
            {
                EncryptedPassword = password;
            }
        }

        public void SetUsername()
        {
            string idFormatted = IDUser < 10 ? $"0{IDUser}" : IDUser.ToString();
            Username = $"{Name[0]}{Lastname}{idFormatted}".ToLower();
        }


        internal void SetEncryptedPassword(string encryptedPassword)
        {
            EncryptedPassword = encryptedPassword;
        }


    }
}
