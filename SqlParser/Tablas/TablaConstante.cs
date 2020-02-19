using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqlParser.Simbolos;

namespace SqlParser.Tablas
{

    class TablaConstante
    {
        public Constante[] palabras;

        public TablaConstante(String[] constantes, int[] nConstantes)
        {
            this.palabras = new Constante[constantes.Length];

            for (int x = 0; x < constantes.Length; x++)
            {
                this.palabras[x] = new Constante(constantes[x], nConstantes[x]);
            }

        }


    }
}
