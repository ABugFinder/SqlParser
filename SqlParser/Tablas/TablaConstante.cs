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

            //this.palabras[0].reiniciar();
            Constante.svalor = 600;

            for (int x = 0; x < constantes.Length; x++)
            {

                if (constantes[x] != null && !constantes[x].Equals(""))
                {
                    Console.WriteLine(constantes[x] + " Entró");

                    this.palabras[x] = new Constante(constantes[x], nConstantes[x]);
                }
            }

        }


    }
}
