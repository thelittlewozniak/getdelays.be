using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDelaysAPI
{
    interface IAPI
    {
        User Login(string email, string password);
    }
}
