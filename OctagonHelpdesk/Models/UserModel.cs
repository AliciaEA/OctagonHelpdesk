    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Security.Cryptography;
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
            public string Name { get; set; }
            public string Lastname { get; set; }
            public string Email { get; set; }
            public Departament Departamento { get; set; }
            public DateTime CreationDate { get; set; }


            private string EncryptedPassword;

            // Implementar UserRoles -M

            public UserModel()
            {
                Roles = new Role();

                //Mario: Logica basica es asi: en cuanto se crea el objeto y se le asignan las propiedades de un usuario existente
                // se busca entre donde esten almacenados los roles y se le asigna
                // la creacion de usuario va en otro lugar, en esta clase se trabaja con la asumcion de que el usuario ya existe
                UserRolesService userRolesService = new UserRolesService();
                userRolesService.RetrieveRoles(this);
                // Mario: To do, Find a way to dispose of the UserRolesServices after it's used so it doesn't hog memory

            }

            public string GetPassword(bool perms)
            {
                if (perms)
                {
                    return EncryptedPassword;
                }
                return EncryptedPassword;
            }

            public void SetPassword(string password, bool loggedin)
            {
                if (loggedin)
                {
                    EncryptedPassword = HelperPassword.HashPassword(password);
                }

            }

            public bool ChecKPassword(string password)
            {
                //To do, Code a way Retrieve Hashed password from wherever we store it in and compare it -M
                //To do, stop being gay. PD: I love u Mario Cricket
                return HelperPassword.VerifyPassword(password, EncryptedPassword);
            }


            public void MassFill(int IDuser,bool state, string password)
            {
                this.IDUser = IDuser;
                this.ActiveStateU = state;
                this.SetPassword(password,true);
            }
        }
    }
