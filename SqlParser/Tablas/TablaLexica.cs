using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using SqlParser.Simbolos;

namespace SqlParser.Tablas
{
    class TablaLexica
    {
        // Tablas estáticas
        public TablaDelimitador tablaD = new TablaDelimitador();
        public TablaOperador tablaO = new TablaOperador();
        public TablaRelacional tablaRel = new TablaRelacional();
        public TablaReservada tablaRes = new TablaReservada();

        public string regexT1 = "(\\W|^)SELECT(\\W|$)|(\\W|^)FROM(\\W|$)|(\\W|^)WHERE(\\W|$)|(\\W|^)IN(\\W|$)|(\\W|^)AND(\\W|$)|(\\W|^)OR(\\W|$)|(\\W|^)CREATE(\\W|$)|(\\W|^)TABLE(\\W|$)|(\\W|^)CHAR(\\W|$)|(\\W|^)NUMERIC(\\W|$)|(\\W|^)NOT(\\W|$)|(\\W|^)NULL(\\W|$)|(\\W|^)CONSTRAINT(\\W|$)|(\\W|^)KEY(\\W|$)|(\\W|^)PRIMARY(\\W|$)|(\\W|^)FOREIGIN(\\W|$)| (\\W|^)FOREIGN(\\W|$)|(\\W|^)REFERENCES(\\W|$)|(\\W|^)INSERT(\\W|$)|(\\W|^)INTO(\\W|$)|(\\W|^)VALUES(\\W|$)";
        public string regexT2 = "(\\W|^)'\\w+'(\\W|$)";
        public string regexT3 = "";
        public string regexT4 = "";
        public string regexT5 = "";

        public Token[] palabras;

        public TablaLexica(String[] palabras, int[] lineas, TablaIdentificador tablaI, TablaConstante tablaC)
        {

            this.palabras = new Token[palabras.Length];

            // Creando todos los TOKENS
            for (int x = 0; x < palabras.Length; x++)
            {

                //Regex.IsMatch(palabra, @"\d+")
                if (Regex.IsMatch(palabras[x], @regexT1)) { // Tipo 1 - Reservadas
                    Reservada apuntador = this.darReservada(palabras[x]);
                    this.palabras[x] = new Token(lineas[x], palabras[x], 1, apuntador.valor);

                } else if (Regex.IsMatch(palabras[x], @regexT2)) { // Tipo 4 - Cosntantes
                    Constante apuntador = this.darConstante(palabras[x], tablaC);
                    this.palabras[x] = new Token(lineas[x], palabras[x], 1, apuntador.valor);

                } else if () { // Tipo 5 - 

                } else if () { // Tipo 6 -

                } else if () { // Tipo 7 -

                } else if () { // Tipo 8 -

                } else { // Error
                    x = palabras.Length;
                }

            }

        }


        private Constante darConstante(String palabra, TablaConstante tc)
        {                                                 
            for (int x = 0; x < tc.palabras.Length; x++)     
            {
                if (tc.palabras[x].palabra.Equals(palabra))
                {
                    return tc.palabras[x];
                }
            }
            return null;
        }

        private Identificador darIdentificador(String palabra, TablaIdentificador ti)
        {
            for (int x = 0; x < ti.palabras.Length; x++)
            {
                if (ti.palabras[x].palabra.Equals(palabra))
                {
                    return ti.palabras[x];
                }
            }
            return null;
        }

        private Delimitador darDelimitador(String palabra) 
        {
            for (int x = 0; x < tablaD.palabras.Length; x++)
            {
                if (tablaD.palabras[x].palabra.Equals(palabra))
                {
                    return tablaD.palabras[x];
                }
            }
            return null;
        }

        private Operador darOperador(String palabra)
        {
            for (int x = 0; x < tablaO.palabras.Length; x++)
            {
                if (tablaO.palabras[x].palabra.Equals(palabra))
                {
                    return tablaO.palabras[x];
                }
            }
            return null;
        }

        private Relacional darRelacional(String palabra)
        {
            for (int x = 0; x < tablaRel.palabras.Length; x++)
            {
                if (tablaRel.palabras[x].palabra.Equals(palabra))
                {
                    return tablaRel.palabras[x];
                }
            }
            return null;
        }

        private Reservada darReservada(String palabra)
        {
            for (int x = 0; x < tablaRes.palabras.Length; x++)
            {
                if (tablaRes.palabras[x].palabra.Equals(palabra))
                {
                    return tablaRes.palabras[x];
                }
            }
            return null;
        }

    }
}
