using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqlParser.Simbolos;

namespace SqlParser.Tablas
{
    class TablaIdentificador
    {
        public Identificador[] palabras;

        public TablaIdentificador(String[] identificadores, int[]lIdentificadores)
        {
            this.palabras = new Identificador[identificadores.Length];

            for(int x = 0; x < identificadores.Length; x++)
            {
                if (identificadores[x] != null && !identificadores[x].Equals(""))
                {
                    // Preguntamos si la palabra que llega en el arreglo existe
                    if (existePalabra(identificadores[x]))
                    {
                        // Se crea un appuntador de tipo Identificador para refereciar al objeto ya existente
                        Identificador apuntador = darPalabra(identificadores[x]);

                        // Si la linea actual no existe se concatena las ya existentes
                        if (!apuntador.existeLinea(lIdentificadores[x]))
                        {
                            apuntador.concatenarLinea(lIdentificadores[x]);
                        }

                    }
                    else
                    // Si no existe la palabra, se agraga una nueva con los parametros que lleva en el constructor
                    {
                        palabras[x] = new Identificador(identificadores[x], Convert.ToString(lIdentificadores[x]));
                    } 
                }
            }

        }


        private bool existePalabra(String palabra)
        {
            for (int x = 0; x < palabras.Length; x++)
            {
                if (palabras[x] != null && palabras[x].palabra != null && palabras[x].palabra.Equals(palabra))
                {
                    return true;
                } 
            }
            return false;
        }

        private Identificador darPalabra(String palabra)
        {
            for (int x = 0; x < palabras.Length; x++)
            {
                if (palabras[x].palabra.Equals(palabra))
                {
                    return palabras[x];
                }
            }
            return null;
        }

    }
}
