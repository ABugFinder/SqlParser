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
            /*
                SELECT ANOMBRE, CALIFICACION, TURNO
                FROM ALUMNOS, INSCRITOS, MATERIAS, CARRERAS
                WHERE MNOMBRE='LENAUT2' AND TURNO = 'TM'
                AND CNOMBRE='ISC' AND SEMESTRE='2017II' AND CALIFICACION >= 70
             */

            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            */
        }
    }
}
