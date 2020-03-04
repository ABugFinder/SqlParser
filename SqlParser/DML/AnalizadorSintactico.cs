using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqlParser.Tablas;

namespace SqlParser.DML
{
    class AnalizadorSintactico
    {
        int apunt;
        String[] terminales = {"4", "8", "10", "11", "12", "13", "14", "15", "50", "51", "53", "54", "61", "62", "72", "199"};
        public Pila pila;

        //int[] a = new int[] { 1, 2, 3 };
        public String[,] dml = new String[,] {
            { null, "300", "301", "302", "303", "304", "305", "306", "307", "308", "309", "310", "311", "312", "313", "314", "315", "316", "317", "318", "319"},
            { "4", null, "302", "304 303", null, "4 305", null, "308 307", null, "4 309", "4", null, "313 312", null, "304 314", null, null, "304", null, null, null},
            { "8", null, null, null, null, null, "99", null, null, null, null, null, null, null, null, "315 316", "8", null, null, null, null},
            { "10", "10 301 11 306 310", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
            { "11", null, null, null, "99", null, "99", null, null, null, null, null, null, null, null, null, null, null, null, null, null},
            { "12", null, null, null, null, null, null, null, "99", null, "99", "12 311", null, null, null, null, null, null, null, null, null},
            { "13", null, null, null, null, null, "99", null, null, null, null, null, null, null, null, "13 52 300 53", null, null, null, null, null},
            { "14", null, null, null, null, null, "99", null, null, null, null, null, null, "317 311", null, null, null, null, "14", null, null},
            { "15", null, null, null, null, null, "99", null, null, null, null, null, null, "317 311", null, null, null, null, "15", null, null},
            { "50", null, null, null, "50 302", null, "99", null, "50 306", null, "99", null, null, null, null, null, null, null, null, null, null},
            { "51", null, null, null, null, null, "51 4", null, null, null, null, null, null, null, null, null, null, null, null, null, null},
            { "53", null, null, null, null, null, "99", null, "99", null, "99", "99", null, "99", null, null, null, null, null, null, null},
            { "54", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "54 318 54", null, null, null},
            { "61", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "319", null, null, "61"},
            { "62", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "62", null},
            { "72", null, "72", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
            { "199", null, null, null, "99", null, "99", null, "99", null, "99", "99", null, "99", null, null, null, null, null, null, null}
        };

        public AnalizadorSintactico(TablaLexica tablaLexica)
        {
            String x, k;

            this.pila = new Pila();
            this.apunt = 0;

            pila.push("$");
            pila.push("300");

            do {

                x = pila.pop();
                if (apunt >= tablaLexica.palabras.Length)
                {
                    k = "199";

                } else {

                    if (tablaLexica.palabras[apunt].tipo == 4 || tablaLexica.palabras[apunt].tipo == 8)
                    {
                        k = Convert.ToString(tablaLexica.palabras[apunt].tipo);
                    } 
                    else
                    {
                        k = Convert.ToString(tablaLexica.palabras[apunt].codigo);
                    }
                }

                if (isTerminal(x) || x.Equals("199"))
                {
                    if (x.Equals(k))
                    {
                        apunt++;
                    }
                    else
                    {
                        //Error
                    }

                } else
                {
                    if (posicionador(x, k) != null)
                    {
                        if (!posicionador(x, k).Equals("199"))
                        {
                            pushInversa(posicionador(x, k));
                        }
                    }
                    else 
                    {
                        //Error
                    }
                }

            } while(apunt <= tablaLexica.palabras.Length);

        }

        /*
         *  
         *  insertarPila('$');
         *  insertarPila(300);
         *  insertar '$' al final de Tabla Léxica
         *  APUN = Apuntador al primer Token de Tabla Léxica
         *  
         *  do{
         *      
         *      X = extraerPila();
         *      K = Tabla Léxica[APUN];
         *      if(X = TERMINAL || X = '$' -> 199){
         *          if(X = K){
         *              Avanzar APUN;
         *          } else {
         *              ERROR();
         *          }
         *      } else {
         *          if(M[X,K] = PRODUCCION){
         *              if(PRODUCCION != 'λ' -> 99){
         *                  insertarPila(PRODUCCION); -> forma inversa
         *              }
         *          } else {
         *              ERROR();
         *          }
         *      }
         *      
         *  }while(X == '$');
         *  
         */

        public void pushInversa(String linea)
        {
            String[] aux = linea.Split(' ');

            for (int x = aux.Length - 1; x >= 0; x--)
            {
                pila.push(aux[x]);
            }
        }

        public bool isTerminal(String codigo)
        {

            for (int x = 0; x < terminales.Length; x++)
            {
                if (terminales[x].Equals(codigo))
                {
                    return true;
                }
            }
            return false;
        }

        public String posicionador(String x, String k)
        {
            //Declarando iteradores para la matriz
            int i = 0, j = 0;

            for (int c = 0; c < dml.Length; c++)
            {
                if (dml[c,0].Equals(x))
                {
                    i = c;
                }
            }

            for (int c = 0; c < dml.Length; c++)
            {
                if (dml[0, c].Equals(k))
                {
                    j = c;
                }
            }

            return dml[i, j];
        }

    }
}
