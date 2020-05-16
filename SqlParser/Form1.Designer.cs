namespace SqlParser
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Texto = new System.Windows.Forms.TextBox();
            this.BtnIniciar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.TablaLexica = new System.Windows.Forms.DataGridView();
            this.NumeroToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineaToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelError = new System.Windows.Forms.Label();
            this.LabelResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TablaLexica)).BeginInit();
            this.SuspendLayout();
            // 
            // Texto
            // 
            this.Texto.Location = new System.Drawing.Point(12, 12);
            this.Texto.Multiline = true;
            this.Texto.Name = "Texto";
            this.Texto.Size = new System.Drawing.Size(539, 173);
            this.Texto.TabIndex = 1;
            this.Texto.TextChanged += new System.EventHandler(this.Texto_TextChanged);
            // 
            // BtnIniciar
            // 
            this.BtnIniciar.Location = new System.Drawing.Point(12, 191);
            this.BtnIniciar.Name = "BtnIniciar";
            this.BtnIniciar.Size = new System.Drawing.Size(164, 23);
            this.BtnIniciar.TabIndex = 0;
            this.BtnIniciar.Text = "Iniciar";
            this.BtnIniciar.UseVisualStyleBackColor = true;
            this.BtnIniciar.Click += new System.EventHandler(this.BtnIniciar_Click);
            // 
            // TablaLexica
            // 
            this.TablaLexica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaLexica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroToken,
            this.LineaToken,
            this.Token,
            this.TipoToken,
            this.CodigoToken});
            this.TablaLexica.Location = new System.Drawing.Point(12, 326);
            this.TablaLexica.Name = "TablaLexica";
            this.TablaLexica.Size = new System.Drawing.Size(539, 316);
            this.TablaLexica.TabIndex = 2;
            this.TablaLexica.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // NumeroToken
            // 
            this.NumeroToken.HeaderText = "No.";
            this.NumeroToken.Name = "NumeroToken";
            // 
            // LineaToken
            // 
            this.LineaToken.HeaderText = "Linea";
            this.LineaToken.Name = "LineaToken";
            // 
            // Token
            // 
            this.Token.HeaderText = "TOKEN";
            this.Token.Name = "Token";
            // 
            // TipoToken
            // 
            this.TipoToken.HeaderText = "Tipo";
            this.TipoToken.Name = "TipoToken";
            // 
            // CodigoToken
            // 
            this.CodigoToken.HeaderText = "Codigo";
            this.CodigoToken.Name = "CodigoToken";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(182, 196);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(32, 13);
            this.labelError.TabIndex = 5;
            this.labelError.Text = "Error:";
            // 
            // LabelResult
            // 
            this.LabelResult.AutoSize = true;
            this.LabelResult.Location = new System.Drawing.Point(594, 15);
            this.LabelResult.Name = "LabelResult";
            this.LabelResult.Size = new System.Drawing.Size(58, 13);
            this.LabelResult.TabIndex = 6;
            this.LabelResult.Text = "Resultado:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 662);
            this.Controls.Add(this.LabelResult);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.TablaLexica);
            this.Controls.Add(this.Texto);
            this.Controls.Add(this.BtnIniciar);
            this.Name = "Form1";
            this.Text = "Escaner";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaLexica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Texto;
        private System.Windows.Forms.Button BtnIniciar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView TablaLexica;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroToken;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineaToken;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoToken;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoToken;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label LabelResult;
    }
}

