using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlParser
{
    class Identificador
    {
        public static int svalor = 401;

        public String palabra;
        public int valor;
        public int linea;

        public Identificador(String palabra, int linea) {

            this.palabra = palabra;
            this.valor = svalor;
            svalor++;
            this.linea = linea; 

        }
 
    }
}
