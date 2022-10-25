using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Annonsinlämmning
{
    class Account
    {
       


        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public int Ssn { get; set; }
        public string Email { get; set; }
    }
}
