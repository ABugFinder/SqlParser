using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlParser.Simbolos
{
    public class Relacional
    {
        public String palabra;
        public int valor;

        public Relacional(String relacional, int valor)
        {
            this.palabra = relacional;
            this.valor = valor;
        }
    }
}
