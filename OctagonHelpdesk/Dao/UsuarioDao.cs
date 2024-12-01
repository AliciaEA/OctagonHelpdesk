using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OctagonHelpdesk.Models;


namespace OctagonHelpdesk.Services
{
    public class UsuarioDao
    {
        public List<UserModel> usuarios = new List<UserModel>();
        FileHelper fileHelper = new FileHelper();

        public UsuarioDao() 
        {
            //MassFillLocal();
            //fileHelper.SaveUser(usuarios,true);
            
            usuarios = fileHelper.GetUsers();
        }

        
        public void InsertU(int index, UserModel usuario)
        {
            usuarios.Insert(index, usuario);
           
        }

        public void Fillusers(List<UserModel> usuariosL)
        {
            
            usuariosL = fileHelper.GetUsers();
            //List < UserModel> temp = fileHelper.GetUsers();
            //if (usuarios == null)
            //{
            //    MessageBox.Show("Error", "Recorda este error dao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    foreach (var user in temp)
            //    {
            //        Console.WriteLine(user.IDUser);
            //        Console.WriteLine(user.Name);
            //        Console.WriteLine(user.GetPassword(true));
            //    }
            //}
        }

        public void AddUsuario(UserModel usuario)
        {
            usuario.CreationDate = DateTime.Now;
            usuarios.Add(usuario);
            fileHelper.SaveUsers(usuarios);

        }
        //public void RemoveUsuario(UserModel LoggedUser,UserModel usuario)
        public void RemoveUsuario(UserModel usuario)
        {
            int position = FindPosition(usuario.IDUser);
            usuarios[position].ActiveStateU = false;
            usuarios[position].DeactivationDate = DateTime.Now;
            fileHelper.SaveUsers(usuarios);
        }
        public void UpdateUsuario(UserModel usuario)
        {
            int position = FindPosition(usuario.IDUser);
            usuarios[position] = usuario;
            usuarios[position].LastUpdatedDate = DateTime.Now;
            fileHelper.SaveUsers(usuarios);
        }

        public List<UserModel> GetUsuarios()
        {
            usuarios = fileHelper.GetUsers();
            return usuarios;
        }

        public UserModel GetUsuario(int id)
        {
           
            return usuarios.Find(usuario => usuario.IDUser == id);
        }
        public UserModel GetUsuario(string username)
        {
            usuarios = fileHelper.GetUsers();
            return usuarios.Find(usuario => usuario.Username == username);
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
    }
}
