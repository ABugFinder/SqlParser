using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using SqlParser.Simbolos;

namespace SqlParser
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Identificador(String palabra, String linea)
            Identificador prueba1 = new Identificador("Alumnos", 10);
            Identificador prueba2 = new Identificador("ProfesGeis", 10);

            Console.WriteLine(prueba1.valor + " - " + prueba2.valor + " - " + prueba2.palabra);

            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            */
        }
    }
}
