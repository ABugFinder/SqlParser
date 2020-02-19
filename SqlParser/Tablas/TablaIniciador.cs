﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlParser.Tablas
{
    class TablaIniciador
    {
        public CrearTablas tablas;

        String[] identificadores = new String[50];
        int[] lIdentificadores = new int[50];

        String[] constantes = new String[50];
        int[] nConstantes = new int[50];

        String[] palabras = new String[250];
        int[] lineas = new int[250];

        public string regexT4 = "(\\W|^)[a-zA-Z]+(\\W|$)";
        public string regexT6 = "(\\W|^)'\\w+'(\\W|$)";

        int contPalabras = 1;

        //String[] palabras, int[] lineas, String[] constantes,  String[] identificadores, int[] nConstantes, int[] lIdentificadores
        public TablaIniciador(String texto, DataGridView tablaLexica, DataGridView tablaConstante, DataGridView tablaIdentificador) {
            if (!texto.Equals("")) {


                this.separarPalabras(texto);

                //imprimir las palabras en consola eliminar despues
                for (int x = 0; x < this.constantes.Length; x++) {

                    Console.WriteLine(this.constantes[x]);

                }

                tablas = new CrearTablas(this.palabras, this.lineas, this.constantes, this.identificadores, this.nConstantes, this.lIdentificadores);

                this.llenarTablasConstante(tablaConstante, tablas);

                this.llenarTablasIdentificador(tablaIdentificador, tablas);

                this.llenarTablasLexica(tablaLexica, tablas);
            
            }
        }

        public void separarPalabras(String texto) {

            String[] lineas = texto.Split('\n');

            for (int linea = 0; linea < lineas.Length; linea++)
            {
                String[] lPalabras = Regex.Split(lineas[linea], @"()");//lineas[linea].Split(',','\'',' ','.',';');

                for (int numPalabra = 0; numPalabra < lPalabras.Length; numPalabra++) {

                    if (lPalabras[numPalabra] != null  && Regex.IsMatch(lPalabras[numPalabra], @regexT6))
                    { // Tipo 6 - Cosntantes

                        Console.WriteLine("entro");

                        this.palabras[this.contPalabras] = lPalabras[numPalabra];
                        this.lineas[this.contPalabras] = linea+1;

                        this.constantes.Prepend(lPalabras[numPalabra]);
                        this.nConstantes.Prepend(contPalabras);

                        contPalabras++;


                    }
                    else if (lPalabras != null && lPalabras[numPalabra] != null && Regex.IsMatch(lPalabras[numPalabra], @regexT4))
                    { //tipo 4 - Identificador 

                        this.palabras[this.contPalabras] = lPalabras[numPalabra];
                        this.lineas[this.contPalabras] = linea+1;

                        this.identificadores.Prepend(lPalabras[numPalabra]);
                        this.lIdentificadores.Prepend(linea+1);

                        contPalabras++;

                    }
                    else {

                        this.palabras[this.contPalabras] = lPalabras[numPalabra];
                        this.lineas[this.contPalabras] = linea+1;

                        contPalabras++;
                    }

                    
                }
            }
        }

        private void llenarTablasLexica(DataGridView tablaLexica, CrearTablas tablas) {

            for (int x = 0; x < tablas.tablaL.palabras.Length; x++) {


                if (tablas != null && tablas.tablaL != null && tablas.tablaL.palabras[x]!=null) {

                    String[] datos =       {Convert.ToString(tablas.tablaL.palabras[x].numero),
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
                    String[] datos = {Convert.ToString(tablas.tablaC.palabras[x].numero),
                                  tablas.tablaC.palabras[x].palabra,
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
