using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDelaysAPI
{
    public interface IAPI
    {
        User Login(string email, string password);
        User MakeAccount(string email, string name, string surname, string password, string phoneNumber);
        bool DeleteUser(User user);
        User UpdateUser(string email, string name, string surname, string phoneNumber, User user);
    }
}
