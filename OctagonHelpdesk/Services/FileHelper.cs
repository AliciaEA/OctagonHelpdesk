﻿using OctagonHelpdesk.Models;
using OctagonHelpdesk.Models.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace OctagonHelpdesk.Services
{
    internal class FileHelper
    {
        private string rutaArchivo = @"data\data.dat";
        private string rutaDataArchivo = @"..\..\Data\data.dat";

        public FileHelper()
        {
            //Ruta del archivo
            string dataStorePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaDataArchivo);
            rutaArchivo = dataStorePath;

            string path = rutaArchivo;
        }

        public void SaveUsers(List<UserModel> userLists)
        {
            using (FileStream archivo = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write))
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
                        escritor.Write(user.Username);
                        escritor.Write(user.Name);
                        escritor.Write(user.Lastname);
                        escritor.Write(user.Email);
                        escritor.Write((int)user.Departamento);
                        escritor.Write(user.CreationDate.ToString("dd/MM/yyyy HH:mm:ss"));
                        escritor.Write(user.EncryptedPassword); // Guardar la contraseña encriptada

                        // Escribir LastUpdatedDate
                        escritor.Write(user.LastUpdatedDate.HasValue);
                        if (user.LastUpdatedDate.HasValue)
                        {
                            escritor.Write(user.LastUpdatedDate.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                        }

                        // Escribir DeactivationDate
                        escritor.Write(user.DeactivationDate.HasValue);
                        if (user.DeactivationDate.HasValue)
                        {
                            escritor.Write(user.DeactivationDate.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                        }

                        // Escribir ReactivationDate
                        escritor.Write(user.ReactivationDate.HasValue);
                        if (user.ReactivationDate.HasValue)
                        {
                            escritor.Write(user.ReactivationDate.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                        }
                    }
                }
            }
        }

        public List<UserModel> GetUsers()
        {
            List<UserModel> userModels = new List<UserModel>();
            if (!File.Exists(rutaArchivo)) return null;

            using (FileStream archivo = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader lector = new BinaryReader(archivo))
                {
                    while (archivo.Position < archivo.Length)
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
                                Username = lector.ReadString(),
                                Name = lector.ReadString(),
                                Lastname = lector.ReadString(),
                                Email = lector.ReadString(),
                                Departamento = (Departament)lector.ReadInt32(),
                                CreationDate = ParseDate(lector.ReadString())
                            };

                            userModel.SetEncryptedPassword(lector.ReadString()); // Leer la contraseña encriptada


                            if (lector.ReadBoolean())
                            {
                                userModel.LastUpdatedDate = SafeParseDate(lector.ReadString());
                            }

                            if (lector.ReadBoolean())
                            {
                                userModel.DeactivationDate = SafeParseDate(lector.ReadString());
                            }

                            if (lector.ReadBoolean())
                            {
                                userModel.ReactivationDate = SafeParseDate(lector.ReadString());
                            }

                           

                            userModels.Add(userModel);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"Error al leer el usuario: {ex.Message}");
                        }
                    }
                }
            }
            return userModels;
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
        public void SaveUser(UserModel user)
        {
            List<UserModel> users = GetUsers() ?? new List<UserModel>();
            users.Add(user);
            SaveUsers(users);
        }
    }
}
