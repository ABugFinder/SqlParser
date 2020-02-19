using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqlParser.Simbolos;

namespace SqlParser.Tablas
{
    class CrearTablas
    {
        // Tablas dinámicas
        public TablaConstante tablaC;
        public TablaIdentificador tablaI;
        public TablaLexica tablaL;

        public CrearTablas(String[] palabras, int[] lineas, String[] constantes, 
                           String[] identificadores, int[] nConstantes, int[] lIdentificadores)
        {
            this.tablaC = new TablaConstante(constantes, nConstantes);
            this.tablaI = new TablaIdentificador(identificadores, lIdentificadores);
            this.tablaL = new TablaLexica(palabras, lineas, tablaI, tablaC);
        }

    }
}
