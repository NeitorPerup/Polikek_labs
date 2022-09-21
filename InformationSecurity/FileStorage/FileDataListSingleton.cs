using InformationSecurity.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Text;

namespace InformationSecurity.FileStorage
{
    public class FileDataListSingleton : IDisposable
    {
        private static FileDataListSingleton instance;

        private readonly string UserFileName = "Users.des";
        private const string DesKey = "ENlpX4kb";
        private const string DesIV = "ENlpX4kb";
        public List<User> Users { get; set; }

        private FileDataListSingleton()
        {
            Users = LoadUsers();
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }

        ~FileDataListSingleton() 
        {
            SaveUsers(Users);
        }

        public List<User> LoadUsers()
        {
            var list = new List<User>();
            if (File.Exists(UserFileName))
            {
                using (FileStream fsInput = new FileStream(UserFileName, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                        //des.Mode = CipherMode.OFB;
                        des.Key = Encoding.ASCII.GetBytes(DesKey);
                        des.IV = Encoding.ASCII.GetBytes(DesIV);
                        var desencrypt = des.CreateDecryptor();

                        using (CryptoStream cryptoStream = new CryptoStream(fsInput, desencrypt, CryptoStreamMode.Read))
                        {
                            byte[] byteArrayInput = new byte[fsInput.Length - 0];
                            cryptoStream.Read(byteArrayInput, 0, byteArrayInput.Length);
                            string json = Encoding.ASCII.GetString(byteArrayInput);
                            list = JsonConvert.DeserializeObject<List<User>>(json);

                            if (list == null || list.Count == 0)
                                list = new List<User>{new User
                            {
                                Login = "Admin",
                                IsAdmin = true
                            } };
                        }
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }
            else
            {
                list.Add(new User
                {
                    Login = "Admin",
                    IsAdmin = true
                });
                SaveUsers(list);
            }

            return list;
        }

        private void SaveUsers(List<User> users)
        {
            using (FileStream fsEncrypted = new FileStream(UserFileName, FileMode.Create, FileAccess.Write))
            {
                try
                {
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    //des.Mode = CipherMode.OFB;
                    des.Key = Encoding.ASCII.GetBytes(DesKey);
                    des.IV = Encoding.ASCII.GetBytes(DesIV);
                    var desencrypt = des.CreateEncryptor();
                    using (var cryptoStream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write))
                    {
                        string jsonUsers = JsonConvert.SerializeObject(users);
                        byte[] byteArrayInput = Encoding.ASCII.GetBytes(jsonUsers);
                        cryptoStream.Write(byteArrayInput, 0, byteArrayInput.Length);
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        public void Dispose()
        {
            SaveUsers(Users);
        }
    }
}
