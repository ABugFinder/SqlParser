using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqlParser.Simbolos;

namespace SqlParser.Tablas
{
    class TablaDelimitador
    {
        public Delimitador[] palabras;

        public TablaDelimitador()
        {
            palabras = new Delimitador[6];
            // public String delimitador;
            // public int valor;

            palabras[0] = new Delimitador(",", 50);
            palabras[1] = new Delimitador(".", 51);
            palabras[2] = new Delimitador("(", 52);
            palabras[3] = new Delimitador(")", 53);
            palabras[4] = new Delimitador("'", 54);
            palabras[5] = new Delimitador(";", 55);
        }
    }
}
