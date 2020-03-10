using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using SqlParser.Tablas;

namespace SqlParser.DML
{
    class AnalizadorSintactico
    {
        int apunt;
        String[] terminales = {"4", "8", "10", "11", "12", "13", "14", "15", "50", "51", "53", "54", "61", "62", "72", "199"};
        public Pila pila;

        public bool error = false;

        public String pError = "";

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

            for (int c = 0; c < tablaLexica.palabras.Length; c++) {
                if (tablaLexica != null && tablaLexica.palabras != null && tablaLexica.palabras[c] != null)
                {
                    Console.WriteLine(tablaLexica.palabras[c].palabra); 
                }
            }
            
            String x, k = "199";

            this.pila = new Pila();
            this.apunt = 0;

            pila.push("$");
            pila.push("300");

            do {

                if (tablaLexica != null && tablaLexica.palabras != null && apunt < tablaLexica.palabras.Length && tablaLexica.palabras[apunt] != null)
                {
                    Console.WriteLine("entro al if grandote");
                    x = pila.pop();
                    Console.WriteLine("pop en " + x);
                    if (apunt >= tablaLexica.palabras.Length)
                    {
                        k = "199";

                    }
                    else
                    {

                        if (tablaLexica != null && tablaLexica.palabras != null && tablaLexica.palabras[apunt] != null && (tablaLexica.palabras[apunt].tipo == 4 || tablaLexica.palabras[apunt].tipo == 8))
                        {
                            Console.WriteLine("entro en tipo 4 u 8 an palabra" + tablaLexica.palabras[apunt].palabra);
                            k = Convert.ToString(tablaLexica.palabras[apunt].tipo);
                        }
                        else
                        {
                            Console.WriteLine("lexica es '" + tablaLexica.palabras[apunt] + "' an pos " + apunt);
                            if (tablaLexica != null && tablaLexica.palabras != null && tablaLexica.palabras[apunt] != null)
                            {

                                Console.WriteLine("entro en el ultimo if");
                                k = Convert.ToString(tablaLexica.palabras[apunt].codigo);
                                Console.WriteLine("la palabra es: " + tablaLexica.palabras[apunt].palabra);
                            }

                        }
                    }

                    Console.WriteLine("k es " + k);

                    if (isTerminal(x) || x.Equals("199"))
                    {
                        if (x.Equals(k))
                        {
                            apunt++;
                            Console.WriteLine(x + "es terminal");
                        }
                        else
                        {
                            this.error = false;
                            if (tablaLexica != null && tablaLexica.palabras != null && tablaLexica.palabras[apunt] != null)
                            {
                                this.pError = tablaLexica.palabras[apunt].palabra;
                                Console.WriteLine("error1 " + tablaLexica.palabras[apunt].palabra);
                            }
                            apunt = tablaLexica.palabras.Length + 2;
                        }

                    }
                    else
                    {
                        if (posicionador(x, k) != null)
                        {
                            if (!Regex.IsMatch(posicionador(x, k), @"(\\W|^)99(\\W|$)"))
                            {
                                pushInversa(posicionador(x, k));
                                Console.WriteLine("objeto de tabla: " + posicionador(x, k));
                            }
                        }
                        else
                        {
                            this.error = true;
                            if (tablaLexica != null && tablaLexica.palabras != null && tablaLexica.palabras[apunt] != null)
                            {
                                this.pError = tablaLexica.palabras[apunt].palabra;
                                Console.WriteLine("error2 " + tablaLexica.palabras[apunt].palabra);
                            }

                            apunt = tablaLexica.palabras.Length + 2;
                        }
                    }
                }
                else {
                    apunt++;
                }

            } while(apunt < tablaLexica.palabras.Length + 1);

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


            for (int c = 0; c < dml.GetLength(0); c++)
            {
                if (dml != null && dml[c, 0] != null && dml[c,0].Equals(k))
                {
                    i = c;
                }
                
            }

            for (int c = 0; c < dml.GetLength(1); c++)
            {
                if (dml != null && dml[0, c] != null && dml[0, c].Equals(x))
                {
                    j = c;
                }
            }

            Console.WriteLine("comparacion en "+x+","+k+" " + dml[i, j]);

            return dml[i, j];
        }

    }
}
