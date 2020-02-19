using System;
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

        int contPalabras = 0;

        //String[] palabras, int[] lineas, String[] constantes,  String[] identificadores, int[] nConstantes, int[] lIdentificadores
        public TablaIniciador(String texto, DataGridView tablaLexica, DataGridView tablaConstante, DataGridView tablaIdentificador) {
            if (!texto.Equals("")) {

                Console.WriteLine("entro");

                this.separarPalabras(texto);

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
                String[] lPalabras = lineas[linea].Split(',','\'',' ','.',';');

                for (int numPalabra = 0; numPalabra < lPalabras.Length; numPalabra++) {

                    if ((numPalabra-1)!=-1 && (numPalabra+1)<lineas[linea].Length && palabras[numPalabra - 1] != null && palabras[numPalabra + 1] != null && palabras[numPalabra - 1].Equals('\'')
                          && palabras[numPalabra + 1].Equals('\'') && Regex.IsMatch(palabras[numPalabra], @regexT6))
                    { // Tipo 6 - Cosntantes

                        this.palabras[this.contPalabras] = lPalabras[numPalabra];
                        this.lineas[this.contPalabras] = linea;

                        this.constantes.Prepend(lPalabras[numPalabra]);
                        this.nConstantes.Prepend(contPalabras);


                    }
                    else if (palabras != null && palabras[numPalabra] != null && Regex.IsMatch(palabras[numPalabra], @regexT4))
                    { //tipo 4 - Identificador 

                        this.palabras[this.contPalabras] = lPalabras[numPalabra];
                        this.lineas[this.contPalabras] = linea;

                        this.identificadores.Prepend(lPalabras[numPalabra]);
                        this.lIdentificadores.Prepend(linea);

                    }
                    else {

                        this.palabras[this.contPalabras] = lPalabras[numPalabra];
                        this.lineas[this.contPalabras] = linea;
                    }

                    contPalabras++;
                }
            }
        }

        private void llenarTablasLexica(DataGridView tablaLexica, CrearTablas tablas) {

            for (int x = 0; x < tablas.tablaL.palabras.Length; x++) {
                String[] datos = {Convert.ToString(tablas.tablaL.palabras[x].numero), 
                                  Convert.ToString(tablas.tablaL.palabras[x].linea),
                                  tablas.tablaL.palabras[x].palabra,
                                  Convert.ToString(tablas.tablaL.palabras[x].tipo),
                                  Convert.ToString(tablas.tablaL.palabras[x].codigo)};

                tablaLexica.Rows.Add(datos);
            }
        }

        private void llenarTablasConstante(DataGridView tablaConstante, CrearTablas tablas)
        {

            for (int x = 0; x < tablas.tablaC.palabras.Length; x++)
            {
                String[] datos = {Convert.ToString(tablas.tablaC.palabras[x].numero),
                                  tablas.tablaC.palabras[x].palabra,
                                  Convert.ToString(tablas.tablaC.palabras[x].tipo),
                                  Convert.ToString(tablas.tablaC.palabras[x].valor)};

                tablaConstante.Rows.Add(datos);
            }
        }

        private void llenarTablasIdentificador(DataGridView tablaIdentificador, CrearTablas tablas)
        {
            for (int x = 0; x < tablas.tablaI.palabras.Length; x++)
            {
                String[] datos = { tablas.tablaI.palabras[x].palabra,
                                  Convert.ToString(tablas.tablaI.palabras[x].valor),
                                  tablas.tablaI.palabras[x].linea};

                tablaIdentificador.Rows.Add(datos);
            }

        }
    }
}
