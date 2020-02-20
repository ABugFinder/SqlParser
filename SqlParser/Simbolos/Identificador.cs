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
        public String linea;
        public int[] lineas = new int[10];


        public Identificador(String palabra, String linea) {

            this.palabra = palabra;
            this.valor = svalor;
            svalor++;
            this.linea = linea;
            this.lineas.Prepend(Convert.ToInt32(linea));
        }

        public void concatenarLinea(int linea)
        {
            this.linea = this.linea + "," + Convert.ToString(linea);
            this.lineas.Prepend(Convert.ToInt32(linea));
        }

        public bool existeLinea(int linea)
        {
            for (int x = 0; x < lineas.Length; x++)
            {
                if (lineas[x].Equals(linea))
                {
                    return true;
                }
            }
            return false;
        }

        public void reiniciar()
        {
            svalor = 401;
        }

    }
}
