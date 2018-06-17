using getdelays.be.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace getdelays.be.Models.DAL
{
    public class DALUser:IUser
    {
        private Context context;
        public DALUser()
        {
            context = Context.Instance();
        }
        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }
        public User GetUser(int idUser)
        {
            var user = (from User u in context.Users where u.Id == idUser select u).First();
            return user;
        }
        public User GetUser(string email)
        {
            var user = (from User u in context.Users where u.email == email select u).First();
            return user;
        }
        public void AddUser(User u)
        {
            context.Users.Add(u);
            context.SaveChanges();
        }
        public void DeleteUser(User u)
        {
            context.Users.Remove(u);
            context.SaveChanges();
        }
        public void UpdateUser(User u, User newu)
        {
            var user = (from User us in context.Users where us == u select us).First();
            user = newu;
            context.SaveChanges();
        }
    }
}