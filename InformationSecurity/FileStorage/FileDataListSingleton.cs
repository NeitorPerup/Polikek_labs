using InformationSecurity.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Text;
using InformationSecurity.BusinessLogic.Services.GOSTCryptoService;

namespace InformationSecurity.FileStorage
{
    public class FileDataListSingleton : IDisposable
    {
        private static FileDataListSingleton instance;

        private readonly string UserFileName = "Users.des";
        private Gamma gam;
        private string Key = "jэ{уST…ИMЉіЦ\"“Г4т :бо‹JmU|Oxe";
        private string S = "жжјJЌс";
        byte[] byteKey, byteS;

        public List<User> Users { get; set; }

        private FileDataListSingleton()
        {
            byteKey = Encoding.Default.GetBytes(Key);
            byteS = Encoding.Default.GetBytes(S);
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
                        byte[] byteArrayInput = new byte[fsInput.Length];
                        fsInput.Read(byteArrayInput, 0, byteArrayInput.Length);
                        gam = new Gamma(byteArrayInput, byteKey, byteS);
                        byte[] decryptedText = gam.StartGamma();

                        string json = Encoding.Default.GetString(decryptedText);
                        list = JsonConvert.DeserializeObject<List<User>>(json);

                        if (list == null || list.Count == 0)
                            list = new List<User>{new User
                            {
                                Login = "Admin",
                                IsAdmin = true
                            } };
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
                    string jsonUsers = JsonConvert.SerializeObject(users);
                    byte[] byteUsers = Encoding.Default.GetBytes(jsonUsers);
                    gam = new Gamma(byteUsers, byteKey, byteS);
                    byte[] encryptedText = gam.StartGamma();
                    fsEncrypted.Write(encryptedText, 0, encryptedText.Length);
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
