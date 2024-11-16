using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using OctagonHelpdesk.Models;


namespace OctagonHelpdesk.Services
{
    public class UsuarioService
    {
        public List<UserModel> Usuarios = new List<UserModel>();
        FileHelper fileHelper = new FileHelper();
        public UsuarioService() 
        {
           
            this.Usuarios=fileHelper.GetUsers();
            //MassFillLocal();

        }

        //Test code begin
        public UsuarioService(int id,string password)
        {
            this.Usuarios = fileHelper.GetUsers();
            UserModel user = new UserModel
            {
                IDUser = id,
                Name = "Mitch",
                Lastname = "Gonz",
                ActiveStateU = true,
                CreationDate = DateTime.Now,
                Departamento = 0,
                Email = "mail"
            };
           
            user.SetPassword(password, true);
            this.AddUsuario(user);
            fileHelper.SaveUser(Usuarios,true);
            this.Usuarios = fileHelper.GetUsers();

        }

        //Test code end


        private void MassFillLocal()
        {
            UserModel TestingUser = new UserModel();
            TestingUser.MassFill(1, true, "123");
            AddUsuario(TestingUser);
        }



        public void AddUsuario(UserModel usuario)
        { 
            if(Usuarios != null)
            {
                Usuarios.Add(usuario);
                fileHelper.SaveUser(Usuarios,true);
            }
        }
        public void RemoveUsuario(UserModel LoggedUser,UserModel usuario)
        {
            int position = FindPosition(usuario.IDUser);
            Usuarios[position].ActiveStateU = false;

        }
        public void UpdateUsuario(UserModel usuario)
        {
            int position = FindPosition(usuario.IDUser);
            Usuarios[position] = usuario;
        }

        public List<UserModel> GetUsuarios()
        {
            return Usuarios;
        }

        public int AutogeneradorID()
        {
            if (Usuarios.Count == 0)
            {
                return 1;
            }
            return Usuarios.Last().IDUser + 1;
        }
        public int FindPosition(int id)
        {
            return Usuarios.FindIndex(usuario => usuario.IDUser == id);

        }


        public bool CheckUser(int UserID, string password)
        {  
           for (int i = 0; i < Usuarios.Count; i++)
            {
                if ((UserID == Usuarios[i].IDUser)&& UserID != 0) 
                { 
                    if (Usuarios[i].ChecKPassword(password))
                    {
                        return true;
                    }

                }
            }

            return false;
        }

    }
}
