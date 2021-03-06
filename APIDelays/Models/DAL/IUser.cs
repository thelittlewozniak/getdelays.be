﻿using api.getdelays.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.getdelays.DAL
{
    interface IUser
    {
        List<User> GetUsers();
        User GetUser(int idUser);
        User GetUser(string email);
        User Login(string email, string password);
        void AddUser(User u);
        void DeleteUser(User u);
        void UpdateUser(User u, User newu);
    }
}
