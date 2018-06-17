using getdelays.be.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getdelays.be.Models.DAL
{
    interface IUser
    {
        List<User> GetUsers();
        User GetUser(int idUser);
        User GetUser(string email);
        void AddUser(User u);
        void DeleteUser(User u);
        void UpdateUser(User u, User newu);
    }
}
