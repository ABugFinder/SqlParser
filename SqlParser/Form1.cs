using SqlParser.Tablas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlParser
{
    public partial class Form1 : Form
    {
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
            TablaConstantes.Rows.Clear();
            TablaIdentificador.Rows.Clear();

            Consulta llenado = new Consulta(Texto.Text, TablaLexica, TablaConstantes, TablaIdentificador);

            if (llenado.tablas != null && llenado.tablas.tablaL != null && llenado.tablas.tablaL.pError != null && llenado.tablas.tablaL.error && !llenado.tablas.tablaL.pError.Equals("")) {
                labelError.Text += " Tipo 1 - Código 101: Símbolo desconocido.";
            } else if (llenado.tablas != null && llenado.analizadorSintactico != null && llenado.analizadorSintactico.error) {
                labelError.Text += " Tipo 2 - Código 100: error sintactico "+ llenado.analizadorSintactico.pError;
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
