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
        public string regexT6 = "(\\W|^)\\$\\w+(\\W|$)|(\\W|^)[0-9]+(\\W|$)";
        public string regexT5 = "(\\W|^),(\\W|$)|(\\W|^)\\.(\\W|$)|(\\W|^)\\((\\W|$)|(\\W|^)\\)(\\W|$)|(\\W|^)'(\\W|$)|(\\W|^);(\\W|$)";
        public string regexT4 = "(\\W|^)[a-zA-Z]+(\\W|$)";
        public string regexT7 = "(\\W|^)\\+(\\W|$)|(\\W|^)-(\\W|$)|(\\W|^)\\*(\\W|$)|(\\W|^)/(\\W|$)";
        public string regexT8 = "(\\W|^)>(\\W|$)|(\\W|^)<(\\W|$)|(\\W|^)=(\\W|$)|(\\W|^)<=(\\W|$)|(\\W|^)>=(\\W|$)";

        public bool error = false;
        public int lError;
        public String pError;

        public Token[] palabras;

        public TablaLexica(String[] palabras, int[] lineas, TablaIdentificador tablaI, TablaConstante tablaC)
        {

            this.palabras = new Token[palabras.Length];
            //this.palabras[0].reiniciar();
            Token.sNumero = 1;


            // Creando todos los TOKENS
            for (int x = 0; x < palabras.Length; x++)
            {

                //Regex.IsMatch(palabra, @"\d+")
                if (palabras[x] != null && Regex.IsMatch(palabras[x], @regexT1)) { // Tipo 1 - Reservadas

                    Reservada apuntador = this.darReservada(palabras[x]);
                    this.palabras[x] = new Token(lineas[x], palabras[x], 1, apuntador.valor);

                } else if (palabras[x] != null && Regex.IsMatch(palabras[x], @regexT6)) { // Tipo 6 - Cosntantes

                    Constante apuntador = this.darConstante(palabras[x], tablaC);
                    if (apuntador != null)
                    {
                        this.palabras[x] = new Token(lineas[x], "Constante", 6, apuntador.valor); 
                    }

                } else if (palabras[x] != null && Regex.IsMatch(palabras[x], regexT5)) { // Tipo 5 - Delimitadores

                    Delimitador apuntador = this.darDelimitador(palabras[x]);
                    if (apuntador != null)
                    {
                        this.palabras[x] = new Token(lineas[x], palabras[x], 5, apuntador.valor);
                    }

                } else if (palabras[x] != null && Regex.IsMatch(palabras[x], @regexT4)) { // Tipo 4 - Identificador

                    Identificador apuntador = this.darIdentificador(palabras[x], tablaI);
                    if (apuntador != null) {

                        this.palabras[x] = new Token(lineas[x], palabras[x], 4, apuntador.valor);
                    }

                } else if (palabras[x] != null && Regex.IsMatch(palabras[x], @regexT7)) { // Tipo 7 - Operadores

                    Operador apuntador = this.darOperador(palabras[x]);
                    this.palabras[x] = new Token(lineas[x], palabras[x], 7, apuntador.valor);

                } else if (palabras[x] != null && Regex.IsMatch(palabras[x], @regexT8)) { // Tipo 8 - Relacionales

                    Relacional apuntador = this.darRelacional(palabras[x]);
                    this.palabras[x] = new Token(lineas[x], palabras[x], 8, apuntador.valor);

                } else { // Error

                    this.lError = lineas[x];
                    this.error = true;
                    this.pError = palabras[x];

                    x = palabras.Length;
                    
                }



            }

        }


        private Constante darConstante(String palabra, TablaConstante tc)
        {                                                 
            for (int x = 0; x < tc.palabras.Length; x++)     
            {
                if (tc != null && tc.palabras[x] != null && tc.palabras[x].palabra != null && tc.palabras[x].palabra.Equals(palabra))
                {
                    //String aux = palabras[x].TrimStart('$');

                    return tc.palabras[x];
                }
            }
            return null;
        }

        private Identificador darIdentificador(String palabra, TablaIdentificador ti)
        {
            for (int x = 0; x < ti.palabras.Length; x++)
            {
                if (ti != null && ti.palabras[x] != null && ti.palabras[x].palabra != null && ti.palabras[x].palabra.Equals(palabra))
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
