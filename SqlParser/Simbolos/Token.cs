using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlParser.Simbolos
{
    class Token
    {
        public int numero;
        public int linea;
        public String palabra;
        public int tipo;
        public int codigo;

        public Token(int numero ,int linea,String palabra ,Constante[]constantes, Identificador[]Identificadores)
        {

            this.numero = numero;
            this.linea = linea;
            this.palabra = palabra;

        }
        
    }
}
