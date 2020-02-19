using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlParser.Simbolos
{
    public class Reservada
    {
        public String palabra;
        public String simbolo;
        public int valor;

        public Reservada(String lexema, String simbolo, int valor)
        {
            this.palabra = lexema;
            this.simbolo = simbolo;
            this.valor = valor;
        }

    }
}
