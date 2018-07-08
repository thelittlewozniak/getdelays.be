using api.getdelays.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.getdelays.DAL
{
    public class DALUser : IUser
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
            var user = (from User u in context.Users where u.Id == idUser select u).FirstOrDefault();
            return user;
        }
        public User GetUser(string email)
        {
            var user = (from User u in context.Users where u.email == email select u).FirstOrDefault();
            return user;
        }
        public User Login(string email, string password)
        {
            var user= (from User u in context.Users where u.email == email && u.password == password select u).FirstOrDefault();
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
            context.Users.SingleOrDefault(us => us.Id == u.Id).name = newu.name;
            context.Users.SingleOrDefault(us => us.Id == u.Id).surname = newu.surname;
            context.Users.SingleOrDefault(us => us.Id == u.Id).email = newu.email;
            context.Users.SingleOrDefault(us => us.Id == u.Id).phoneNumber = newu.phoneNumber;
            context.SaveChanges();
        }
        private string EncryptPassword(string password)
        {
            byte[] bytePassword = System.Text.Encoding.ASCII.GetBytes(password);
            bytePassword = new System.Security.Cryptography.SHA256Managed().ComputeHash(bytePassword);
            return System.Text.Encoding.ASCII.GetString(bytePassword);
        }
    }
}