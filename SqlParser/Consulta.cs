﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using SqlParser.Simbolos;
using SqlParser.Tablas;
using SqlParser.DML;

namespace SqlParser
{
    class Consulta
    {
        public CrearTablas tablas;

        String[] identificadores = new String[50];
        int[] lIdentificadores = new int[50];

        String[] constantes = new String[50];
        int[] nConstantes = new int[50];

        String[] palabras = new String[250];
        int[] lineas = new int[250];

        public string regexT4 = "(\\W|^)\\@?[a-zA-Z]+\\#?(\\W|$)";
        public string regexT6 = "((\\W|^)\\'[\\w\\s]*\\'(\\W|$))";
        public string regexT1 = "(\\W|^)SELECT(\\W|$)|(\\W|^)FROM(\\W|$)|(\\W|^)WHERE(\\W|$)|(\\W|^)IN(\\W|$)|(\\W|^)AND(\\W|$)|(\\W|^)OR(\\W|$)|(\\W|^)CREATE(\\W|$)|(\\W|^)TABLE(\\W|$)|(\\W|^)CHAR(\\W|$)|(\\W|^)NUMERIC(\\W|$)|(\\W|^)NOT(\\W|$)|(\\W|^)NULL(\\W|$)|(\\W|^)CONSTRAINT(\\W|$)|(\\W|^)KEY(\\W|$)|(\\W|^)PRIMARY(\\W|$)|(\\W|^)FOREIGIN(\\W|$)| (\\W|^)FOREIGN(\\W|$)|(\\W|^)REFERENCES(\\W|$)|(\\W|^)INSERT(\\W|$)|(\\W|^)INTO(\\W|$)|(\\W|^)VALUES(\\W|$)";

        int contPalabras = 0;
        int contConstantes = 0, contIdentificadores = 0;

        public AnalizadorSintactico analizadorSintactico;

        //String[] palabras, int[] lineas, String[] constantes,  String[] identificadores, int[] nConstantes, int[] lIdentificadores
        public Consulta(String texto, DataGridView tablaLexica, DataGridView tablaConstante, DataGridView tablaIdentificador) {
            if (!texto.Equals("")) {


                this.separarPalabras(texto);


                //imprimir las palabras en consola eliminar despues
                
                tablas = new CrearTablas(this.palabras, this.lineas, this.constantes, this.identificadores,
                                         this.nConstantes, this.lIdentificadores);

                this.llenarTablasConstante(tablaConstante, tablas);

                this.llenarTablasIdentificador(tablaIdentificador, tablas);

                this.llenarTablasLexica(tablaLexica, tablas);

                if (tablas.tablaL.error != true) {
                    this.analizadorSintactico = new AnalizadorSintactico(tablas.tablaL);
                }

            }
        }

        public void separarPalabras(String texto) {

            String[] lineas = Regex.Split(texto, @"\n");

            for (int linea = 0; linea < lineas.Length; linea++)
            {

                String[] lPalabras = Regex.Split(lineas[linea], @"(\*|\,|\(|\)|\;|>=|<=|\=|<|>|\.|\'[\w\s]*\'|\@?\w+\#?)"); //lineas[linea].Split(',','\'',' ','.',';');


                for (int numPalabra = 0; numPalabra < lPalabras.Length; numPalabra++) {

                    //lPalabras[numPalabra] = Regex.Replace(lPalabras[numPalabra], @"\s+", "");

                    
                    if (lPalabras[numPalabra] != null && lPalabras[numPalabra] != "" && lPalabras[numPalabra] != " ")
                    {
                        
                        if (lPalabras[numPalabra] != null && Regex.IsMatch(lPalabras[numPalabra], @regexT6))
                        { // Tipo 6 - Cosntantes

                            String[] constante = Regex.Split(lPalabras[numPalabra], @"(\')");

                            for (int cons = 0; cons < constante.Length; cons++)
                            {

                                if (constante[cons] != null && !constante[cons].Equals(""))
                                {
                                    if (constante[cons] != null && Regex.IsMatch(constante[cons], @"\w"))
                                    {
                                        
                                        String aux = "$" + constante[cons];

                                        this.palabras[this.contPalabras] = aux;
                                        this.lineas[this.contPalabras] = linea + 1;
                                        /*
                                        this.constantes.Prepend(aux);
                                        this.nConstantes.Prepend(contPalabras);
                                        */
                                        this.constantes[this.contConstantes] = aux;
                                        this.nConstantes[this.contConstantes] = contPalabras;

                                        contConstantes++;

                                        //Console.WriteLine(this.constantes[0]);

                                    }
                                    else
                                    {
                                        this.palabras[this.contPalabras] = constante[cons];
                                        this.lineas[this.contPalabras] = linea + 1;
                                    }

                                    this.contPalabras++; 
                                }

                            }


                        }
                        else if (lPalabras != null && lPalabras[numPalabra] != null && Regex.IsMatch(lPalabras[numPalabra], @"((\W|^)[0-9]+(\W|$))"))
                        {

                           
                            
                            this.palabras[this.contPalabras] = lPalabras[numPalabra];
                            this.lineas[this.contPalabras] = linea + 1;

                            this.constantes[this.contConstantes] = lPalabras[numPalabra];
                            this.nConstantes[this.contConstantes] = contPalabras + 1;

                            contPalabras++;
                            contConstantes++;

                            //Console.WriteLine(this.constantes[0]);
                        }
                        else if (lPalabras != null && lPalabras[numPalabra] != null && Regex.IsMatch(lPalabras[numPalabra], @regexT4) && !Regex.IsMatch(lPalabras[numPalabra], @regexT1))
                        { //tipo 4 - Identificador 

                            this.palabras[this.contPalabras] = lPalabras[numPalabra];
                            this.lineas[this.contPalabras] = linea + 1;
                            /*
                            this.identificadores.Prepend(lPalabras[numPalabra]);
                            this.lIdentificadores.Prepend(linea);
                            */

                            this.identificadores[this.contIdentificadores] = lPalabras[numPalabra];               
                            this.lIdentificadores[this.contIdentificadores] = linea + 1; 
 
                            this.contIdentificadores++;
                            this.contPalabras++;
                        }
                        else
                        {

                            this.palabras[this.contPalabras] = lPalabras[numPalabra];
                            this.lineas[this.contPalabras] = linea + 1;

                            this.contPalabras++;
                        } 
                    }

                }
            }
        }

        private void llenarTablasLexica(DataGridView tablaLexica, CrearTablas tablas) {

            for (int x = 0; x < tablas.tablaL.palabras.Length; x++) {


                if (tablas != null && tablas.tablaL != null && tablas.tablaL.palabras[x]!=null) {

                    String[] datos = {Convert.ToString(tablas.tablaL.palabras[x].numero),
                                  Convert.ToString(tablas.tablaL.palabras[x].linea),
                                  tablas.tablaL.palabras[x].palabra,
                                  Convert.ToString(tablas.tablaL.palabras[x].tipo),
                                  Convert.ToString(tablas.tablaL.palabras[x].codigo)};

                    tablaLexica.Rows.Add(datos);
                }

            }
        }

        private void llenarTablasConstante(DataGridView tablaConstante, CrearTablas tablas)
        {

            for (int x = 0; x < tablas.tablaC.palabras.Length; x++)
            {

                if (tablas != null && tablas.tablaC != null && tablas.tablaC.palabras[x] != null)
                {

                    String aux = tablas.tablaC.palabras[x].palabra.TrimStart('$');

                    //Console.WriteLine("Entró");
                    String[] datos = {Convert.ToString(tablas.tablaC.palabras[x].numero), 
                                      aux,
                                      Convert.ToString(tablas.tablaC.palabras[x].tipo),
                                      Convert.ToString(tablas.tablaC.palabras[x].valor)};

                    tablaConstante.Rows.Add(datos); 
                }
            }
        }

        //'
        //*PALABRA ASDAD ASD ASD  FGDFGDFG
        // '

        private void llenarTablasIdentificador(DataGridView tablaIdentificador, CrearTablas tablas)
        {
            for (int x = 0; x < tablas.tablaI.palabras.Length; x++)
            {
                if (tablas != null && tablas.tablaI != null && tablas.tablaI.palabras[x] != null)
                {
                    String[] datos = { tablas.tablaI.palabras[x].palabra,
                                  Convert.ToString(tablas.tablaI.palabras[x].valor),
                                  tablas.tablaI.palabras[x].linea};

                    tablaIdentificador.Rows.Add(datos); 
                }
            }

        }
    }
}