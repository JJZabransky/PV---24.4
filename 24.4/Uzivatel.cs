using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24._4
{
    public class Uzivatel
    {
        private int id;
        private string username;
        private string pasword;

        public int ID { get { return id; } set { id = value; } }
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return pasword; } set { pasword = value; } }

        public Uzivatel(string username, string pasword)
        {
            this.username = username;
            this.pasword = pasword;
        }
    }
}
