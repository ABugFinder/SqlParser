﻿using SqlParser.Tablas;
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

            TablaIniciador llenado = new TablaIniciador(Texto.Text, TablaLexica, TablaConstantes, TablaIdentificador);

            if (llenado.tablas != null && llenado.tablas.tablaL!=null && llenado.tablas.tablaL.pError != null && llenado.tablas.tablaL.error && !llenado.tablas.tablaL.pError.Equals("")) {
                labelError.Text += "Error en la linea: " + llenado.tablas.tablaL.lError + " Token = " + llenado.tablas.tablaL.pError;
            } else
            {
                labelError.Text += "Sin error";
            }
        }
    }
}
