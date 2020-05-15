using SqlParser.Tablas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlParser
{
    public partial class Form1 : Form
    {
        public String[,] errores = new string[,] {
            {"201","204","205","206","207","208"},
            {"10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29", "4", "50 51 52 53 54", "61 62", "70 71 72 73", "8"},
            {"Se esperaba palabra reservada", "Se esperaba identificador" ,"Se esperaba delimitador", "Se esperaba constante", "Se esperaba operador", "Se esperaba operador relacional"}
        };
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();

            DataTable lexica = new DataTable();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            labelError.Text = "Error:";

            TablaLexica.Rows.Clear();
            //TablaConstantes.Rows.Clear();
            //TablaIdentificador.Rows.Clear();

            Consulta llenado = new Consulta(Texto.Text, TablaLexica);

            if (llenado.tablas != null && llenado.tablas.tablaL != null && llenado.tablas.tablaL.pError != null && llenado.tablas.tablaL.error && !llenado.tablas.tablaL.pError.Equals("")) {
                
                labelError.Text += " Tipo 1 - Código 100: Error Lexico";
            } else if (llenado.tablas != null && llenado.analizadorSintactico != null && llenado.analizadorSintactico.error && llenado.analizadorSintactico.codigoDeErrores != null) {

                for (int j = 0; j < llenado.analizadorSintactico.codigoDeErrores.Length; j++) {
                    for (int z = 0; z < errores.GetLength(1); z++) {
                        if (Regex.IsMatch(errores[1,z], @"("+llenado.analizadorSintactico.codigoDeErrores[j]+")")) {

                            labelError.Text += " Tipo 2 " + "Linea: " + llenado.analizadorSintactico.lError + " - Código"+ errores[0,z] +":"+ errores[2,z]+" O \n";

                        }
                    }
                }
            }
            else{

                labelError.Text += "Sin error";
            }
        }

        private void Texto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
