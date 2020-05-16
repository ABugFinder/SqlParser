using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SqlParser
{
    class coneccionDB
    {
        public MySqlConnection conexionDB;
        public coneccionDB(String sql, Label error, bool consultaError, Label resultado) {
            this.conexionDB = new MySqlConnection("datasource=127.0.0.1;port=3308;username=root;password=;database=parse;");
            MySqlCommand conexionCommand = new MySqlCommand(sql, conexionDB);
            try
            {
                conexionDB.Open();
                Console.WriteLine("conexion lograda");
                MySqlDataReader conexionReader = conexionCommand.ExecuteReader(System.Data.CommandBehavior.SingleResult);

                if (conexionReader.HasRows) {

                    resultado.Text += "\n";
                    while (conexionReader.Read()) {

                        for (int j = 0; j<conexionReader.FieldCount; j++) {
                            resultado.Text += " "+ conexionReader.GetString(j);
                        }
                        resultado.Text += "\n";
                    }

                }
                else {
                    Console.WriteLine("consulta lograda");
                }
                conexionReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("conexion fallida: "+ e.Message);
                error.Text = e.Message ;
                consultaError = true;
            }
        }
      
    }
}
