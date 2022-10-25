using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Annonsinlämmning
{
    class Advert
    {
       

        public string Category { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Person { get; set; }
        
    }
}
