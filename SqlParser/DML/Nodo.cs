using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlParser.DML
{
    class Nodo
    {
        public string dato;
        public Nodo sig;
        public Nodo ant;

        public Nodo(string dato)
        {
            this.dato = dato;
            sig = null;
            ant = null;
        }


    }
}
