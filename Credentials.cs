using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallReporter
{
    class Credentials
    {
        public Credentials(string username, string password, string date)
        {
            UserName = username;
            Password = password;
            Date = date;
        } 

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Date { get; set; }

    }
}
