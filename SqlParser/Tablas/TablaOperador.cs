using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqlParser.Simbolos;

namespace SqlParser.Tablas
{
    class TablaOperador
    {
        public Operador[] palabras;

        public TablaOperador()
        {
            palabras = new Operador[4];

            // public String operador;
            // public int valor;

            palabras[0] = new Operador("+", 70);
            palabras[1] = new Operador("-", 71);
            palabras[2] = new Operador("*", 72);
            palabras[3] = new Operador("/", 73);

        }   
    }
}
