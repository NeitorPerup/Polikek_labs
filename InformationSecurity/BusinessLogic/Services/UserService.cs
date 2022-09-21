using InformationSecurity.FileStorage;
using InformationSecurity.Models;
using InformationSecurity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InformationSecurity.BusinessLogic.Services
{
    public class UserService
    {
        private FileDataListSingleton Source;

        public UserService()
        {
            Source = FileDataListSingleton.GetInstance();
        }

        public User Get(string login)
        {
            return Source.Users.FirstOrDefault(x => x.Login == login);
        }

        public List<UserViewModel> GetListViewModels()
        {
            return Source.Users
                .Select(x => new UserViewModel 
                { 
                    Login = x.Login,
                    IsActive = x.IsActive,
                    CheckPassword = x.CheckPassword
                })
                .ToList();
        }

        public List<User> GetList()
        {
            return Source.Users;
        }

        public void Add(User user)
        {
            Source.Users.Add(user);
        }

        public void Edit(User user, string oldLogin)
        {
            var item = Source.Users.FirstOrDefault(x => x.Login == oldLogin);
            if (item == null)
                return;

            item.Login = user.Login;
            item.CheckPassword = user.CheckPassword;
            item.IsActive = user.IsActive;
        }

        public bool IsUniqueLogin(string login)
        {
            return Get(login) == null;
        }

        public void Delete(string login)
        {
            var user = Source.Users.FirstOrDefault(x => x.Login == login);
            if (user != null)
                Source.Users.Remove(user);
        }
    }
}
