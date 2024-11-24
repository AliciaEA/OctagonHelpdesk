using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OctagonHelpdesk.Models;


namespace OctagonHelpdesk.Services
{
    public class UsuarioService
    {
        private List<UserModel> usuarios = new List<UserModel>();
        FileHelper fileHelper = new FileHelper();

        public UsuarioService() 
        {          
            MassFillLocal();
            fileHelper.SaveUser(usuarios,true);
            Fillusers();
        }

        private void MassFillLocal()
        {
            UserModel TestingUser = new UserModel();
            UserModel TestingUser2 = new UserModel();
            TestingUser.MassFill(1, true, "123","Mario");
            TestingUser2.MassFill(2, true, "321", "Banano");
            AddUsuario(TestingUser);
            AddUsuario(TestingUser2);
        }


        public void Fillusers()
        {
            
            usuarios = fileHelper.GetUsers();
            List < UserModel> temp = fileHelper.GetUsers();
            if (usuarios == null)
            {
                MessageBox.Show("imbecil");
            }
            else
            {
                foreach (var user in temp)
                {
                    Console.WriteLine(user.IDUser);
                    Console.WriteLine(user.Name);
                    Console.WriteLine(user.GetPassword(true));
                }
            }
        }

        public void AddUsuario(UserModel usuario)
        {
            usuario.CreationDate = DateTime.Now;
            usuarios.Add(usuario);

        }
        //public void RemoveUsuario(UserModel LoggedUser,UserModel usuario)
        public void RemoveUsuario(UserModel usuario)
        {
            int position = FindPosition(usuario.IDUser);
            usuarios[position].ActiveStateU = false;
            usuarios[position].DeactivationDate = DateTime.Now;

        }
        public void UpdateUsuario(UserModel usuario)
        {
            int position = FindPosition(usuario.IDUser);
            usuarios[position] = usuario;
            usuarios[position].LastUpdatedDate = DateTime.Now;
        }

        public List<UserModel> GetUsuarios()
        {
            return usuarios;
        }

        public UserModel GetUsuario(int id)
        {
            return usuarios.Find(usuario => usuario.IDUser == id);
        }

        public int AutogeneradorID()
        {
            if (usuarios.Count == 0)
            {
                return 1;
            }
            return usuarios.Last().IDUser + 1;
        }
        public int FindPosition(int id)
        {
            return usuarios.FindIndex(usuario => usuario.IDUser == id);

        }


        public bool CheckUser(string UserID, string password)
        {
            int ID = 0;
            try
            {
                ID = int.Parse(UserID);
            }
            catch { }

            foreach (var user in usuarios)
            {
                if (user.IDUser == ID)
                {
                    return user.ChecKPassword(password);
                }
            } 

            return false;
        }

    }
}
