using getdelays.be.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace getdelays.be.Models.DAL
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
            string passwordCrypt = EncryptPassword(password);
            var user= (from User u in context.Users where u.email == email && u.password == passwordCrypt select u).FirstOrDefault();
            return user;
        }
        public void AddUser(User u)
        {
            u.password = EncryptPassword(u.password);
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
            var user = (from User us in context.Users where us == u select us).FirstOrDefault();
            user = newu;
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