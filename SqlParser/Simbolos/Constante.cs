using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SqlParser.Simbolos
{
    class Constante
    {

        public static int svalor = 600;

        public String palabra;
        public int valor;
        public int numero;
        public int tipo;

        public Constante(String palabra, int numero)
        {

            this.palabra = palabra;
            this.valor = svalor;
            svalor++;
            this.numero = numero;
            this.tipo = tipoConstante(palabra);

        }


        public int tipoConstante(String palabra) {

            //rRegex.isMatch(cadena,@"\d+");

        

            Console.WriteLine("aqui puta: "+ palabra);
            if (Regex.IsMatch(palabra, @"((\W|^)\$\w+(\W|$))"))
            {
                return 62;
            }
            else {

                return 61;
            }

        }

        private void reiniciar()
        {
            svalor = 600;
        }
    }
}
