using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqlParser.Simbolos;

namespace SqlParser.Tablas
{
    class TablaRelacional
    {
        
        public Relacional[] palabras;

        public TablaRelacional()
        {
            palabras = new Relacional[5];
            // public String relacional;
            // public int valor;

            palabras[0] = new Relacional(">", 81);
            palabras[1] = new Relacional("<", 82);
            palabras[2] = new Relacional("=", 83);
            palabras[3] = new Relacional(">=", 84);
            palabras[4] = new Relacional("<=", 85);
        }

    }
}
