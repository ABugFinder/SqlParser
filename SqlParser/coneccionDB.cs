using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SqlParser
{
    class coneccionDB
    {
        MySqlConnection conexionDB;
        public coneccionDB() {
            this.conexionDB = new MySqlConnection("DataBase = parse; Data Source = 127.0.0.1; Port = 3308");
        }
        private void coneccion() {
        
        }
    }
}
