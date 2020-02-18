using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqlParser.Simbolos;

namespace SqlParser.Tablas
{
    class TablaReservada
    {
        public Reservada[] palabras;
        

        public TablaReservada()
        {
            palabras = new Reservada[20];
            // public String lexema;
            // public String simbolo;
            // public int valor;

            palabras[0]  = new Reservada("SELECT", "s", 10);
            palabras[1]  = new Reservada("FROM", "f", 11);
            palabras[2]  = new Reservada("WHERE", "w", 12);
            palabras[3]  = new Reservada("IN", "n", 13);
            palabras[4]  = new Reservada("AND", "y", 14);
            palabras[5]  = new Reservada("OR", "o", 15);
            palabras[6]  = new Reservada("CREATE", "c", 16);
            palabras[7]  = new Reservada("TABLE", "t", 17);
            palabras[8]  = new Reservada("CHAR", "h", 18);
            palabras[9]  = new Reservada("NUMERIC", "u", 19);
            palabras[10] = new Reservada("NOT", "e", 20);
            palabras[11] = new Reservada("NULL", "g", 21);
            palabras[12] = new Reservada("CONSTRAINT", "b", 22);
            palabras[13] = new Reservada("KEY", "k", 23);
            palabras[14] = new Reservada("PRIMARY", "p", 24);
            palabras[15] = new Reservada("FOREING", "j", 25);
            palabras[16] = new Reservada("REFERENCES", "l", 26);
            palabras[17] = new Reservada("INSERT", "m", 27);
            palabras[18] = new Reservada("INTO", "q", 28);
            palabras[19] = new Reservada("VALUES", "v", 29);
        }
    }
}
