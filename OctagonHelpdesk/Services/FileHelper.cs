using OctagonHelpdesk.Models;
using OctagonHelpdesk.Models.Enum;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctagonHelpdesk.Services
{
    internal class FileHelper
    {
        // Utility method to get the relative file path
        private string GetRelativeFilePath(string fileName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string dataFolderPath = Path.Combine(Directory.GetParent(currentDirectory).Parent.FullName, "Data");
            string fullFilePath = Path.Combine(dataFolderPath, fileName);

            return fullFilePath;
        }

        public void SaveUser(List<UserModel> userLists, bool perms)
        {
            
            string fileName = "users.dat";
            string fullPath = GetRelativeFilePath(fileName);

            using (FileStream archivo = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter escritor = new BinaryWriter(archivo))
                {
                    foreach (UserModel user in userLists)
                    {
                        escritor.Write(user.IDUser);
                        escritor.Write(user.ActiveStateU);
                        escritor.Write(user.Roles.AdminPerms);
                        escritor.Write(user.Roles.ITPerms);
                        escritor.Write(user.Roles.BasicPerms);
                        escritor.Write(user.Name);
                        escritor.Write(user.Lastname);
                        escritor.Write(user.Email);
                        escritor.Write((int)user.Departamento);
                        string fechaComoCadena = user.CreationDate.ToString("dd/MM/yyyy");
                        escritor.Write(fechaComoCadena);
                        string password = user.GetPassword(true);
                        //Console.WriteLine(password);
                        //if (password == null)
                       // {
                        //    Console.WriteLine("bad");
                        //    password = "123";
                        //}
                        escritor.Write(password);
                    }
                }
            }
        }

        public List<UserModel> GetUsers()
        {
            // Use a fixed filename or pass it as a constant
            string fileName = "users.dat";

            // Get the full path using the relative file path
            string fullPath = GetRelativeFilePath(fileName);

            List<UserModel> userModels = new List<UserModel>();
            if (!File.Exists(fullPath)) return null;

            using (FileStream archivo = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader lector = new BinaryReader(archivo))
                {
                    while (archivo.Position != archivo.Length)
                    {
                        try 
                        {
                            UserModel userModel = new UserModel
                            {
                                IDUser = lector.ReadInt32(),
                                ActiveStateU = lector.ReadBoolean(),
                                Roles = new Role
                                {
                                    AdminPerms = lector.ReadBoolean(),
                                    ITPerms = lector.ReadBoolean(),
                                    BasicPerms = lector.ReadBoolean()
                                },
                                Name = lector.ReadString(),
                                Lastname = lector.ReadString(),
                                Email = lector.ReadString(),
                                Departamento = (Departament)lector.ReadInt32()
                            };
                            string fechaComoCadena = lector.ReadString();
                            userModel.CreationDate = DateTime.ParseExact(fechaComoCadena, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                            userModels.Add(userModel);
                        } catch { }
                       
                    }
                }
            }
            return userModels;
        }

        public UserModel GetUser(int TargetID)
        {
            // Use a fixed filename or pass it as a constant
            string fileName = "users.dat";

            // Get the full path using the relative file path
            string fullPath = GetRelativeFilePath(fileName);

            UserModel userModels = new UserModel();
            if (!File.Exists(fullPath)) return null;

            using (FileStream archivo = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader lector = new BinaryReader(archivo))
                {
                    while (archivo.Position != archivo.Length)
                    {
                        UserModel temp = new UserModel
                        {
                            IDUser = lector.ReadInt32(),
                            ActiveStateU = lector.ReadBoolean(),
                            Roles = new Role
                            {
                                AdminPerms = lector.ReadBoolean(),
                                ITPerms = lector.ReadBoolean(),
                                BasicPerms = lector.ReadBoolean()
                            },
                            Name = lector.ReadString(),
                            Lastname = lector.ReadString(),
                            Email = lector.ReadString(),
                            Departamento = (Departament)lector.ReadInt32()
                        };
                        string fechaComoCadena = lector.ReadString();
                        temp.CreationDate = DateTime.ParseExact(fechaComoCadena, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        if (temp.IDUser == TargetID)
                        {
                            return temp;
                        }
                    }
                }
            }
            return null;
        }
    }
}
