using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlParser.Simbolos
{
    class Token
    {
        public static int sNumero = 1;

        public int numero;
        public int linea;
        public String palabra;
        public int tipo;
        public int codigo;

        public Token(int linea, String palabra, int tipo, int codigo)
        {
            this.numero = sNumero;
            sNumero++;
            this.linea = linea;
            this.palabra = palabra;
            this.tipo = tipo;
            this.codigo = codigo;
        }
        
    }
}
