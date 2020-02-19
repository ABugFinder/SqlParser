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
        public TablaDelimitador tablaD = new TablaDelimitador();
        public TablaOperador tablaO = new TablaOperador();
        public TablaRelacional tablaRel = new TablaRelacional();
        public TablaReservada tablaRes = new TablaReservada();

        public TablaConstante tablaC;

        public CrearTablas(String[] palabras, String[] constantes, String[] identificadores,
                           int[] nConstantes, int[] lIdentificador)
        {
            this.tablaC = new TablaConstante(constantes, nConstantes);
        }

    }
}
