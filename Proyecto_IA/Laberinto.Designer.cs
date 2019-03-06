namespace Proyecto_IA
{
    partial class Laberinto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMapa = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnElegir = new System.Windows.Forms.Button();
            this.dgvpropiedades = new System.Windows.Forms.DataGridView();
            this.Terreno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.pbPersonaje = new System.Windows.Forms.PictureBox();
            this.cmbPersonaje = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.btnCelda_Inicial = new System.Windows.Forms.Button();
            this.btnCelda_Final = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpropiedades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonaje)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(300, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 0;
            // 
            // panelMapa
            // 
            this.panelMapa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelMapa.Location = new System.Drawing.Point(180, 185);
            this.panelMapa.Name = "panelMapa";
            this.panelMapa.Size = new System.Drawing.Size(504, 307);
            this.panelMapa.TabIndex = 1;
            this.panelMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMapa_Paint);
            this.panelMapa.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelMapa_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnElegir);
            this.panel1.Controls.Add(this.dgvpropiedades);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pbPersonaje);
            this.panel1.Controls.Add(this.cmbPersonaje);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 113);
            this.panel1.TabIndex = 2;
            // 
            // btnElegir
            // 
            this.btnElegir.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnElegir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElegir.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElegir.ForeColor = System.Drawing.Color.Black;
            this.btnElegir.Location = new System.Drawing.Point(318, 38);
            this.btnElegir.Name = "btnElegir";
            this.btnElegir.Size = new System.Drawing.Size(104, 28);
            this.btnElegir.TabIndex = 5;
            this.btnElegir.Text = "Elegir";
            this.btnElegir.UseVisualStyleBackColor = false;
            this.btnElegir.Click += new System.EventHandler(this.btnElegir_Click);
            // 
            // dgvpropiedades
            // 
            this.dgvpropiedades.AllowUserToAddRows = false;
            this.dgvpropiedades.AllowUserToDeleteRows = false;
            this.dgvpropiedades.AllowUserToResizeColumns = false;
            this.dgvpropiedades.AllowUserToResizeRows = false;
            this.dgvpropiedades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvpropiedades.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.dgvpropiedades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvpropiedades.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvpropiedades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvpropiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpropiedades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Terreno,
            this.codigo,
            this.Costo});
            this.dgvpropiedades.EnableHeadersVisualStyles = false;
            this.dgvpropiedades.Location = new System.Drawing.Point(492, 18);
            this.dgvpropiedades.Name = "dgvpropiedades";
            this.dgvpropiedades.ReadOnly = true;
            this.dgvpropiedades.RowHeadersVisible = false;
            this.dgvpropiedades.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvpropiedades.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.dgvpropiedades.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvpropiedades.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvpropiedades.Size = new System.Drawing.Size(272, 84);
            this.dgvpropiedades.TabIndex = 4;
            // 
            // Terreno
            // 
            this.Terreno.HeaderText = "Terreno";
            this.Terreno.Name = "Terreno";
            this.Terreno.ReadOnly = true;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // Costo
            // 
            this.Costo.HeaderText = "Costo";
            this.Costo.Name = "Costo";
            this.Costo.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Elige tu personaje:";
            // 
            // pbPersonaje
            // 
            this.pbPersonaje.BackColor = System.Drawing.Color.Transparent;
            this.pbPersonaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPersonaje.Location = new System.Drawing.Point(224, 18);
            this.pbPersonaje.Name = "pbPersonaje";
            this.pbPersonaje.Size = new System.Drawing.Size(70, 70);
            this.pbPersonaje.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonaje.TabIndex = 2;
            this.pbPersonaje.TabStop = false;
            // 
            // cmbPersonaje
            // 
            this.cmbPersonaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonaje.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPersonaje.FormattingEnabled = true;
            this.cmbPersonaje.Location = new System.Drawing.Point(47, 55);
            this.cmbPersonaje.Name = "cmbPersonaje";
            this.cmbPersonaje.Size = new System.Drawing.Size(121, 27);
            this.cmbPersonaje.TabIndex = 1;
            this.cmbPersonaje.SelectedIndexChanged += new System.EventHandler(this.cmbPersonaje_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Coordenadas:";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(21, 198);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 4;
            this.labelX.Text = "A";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(41, 198);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(13, 13);
            this.labelY.TabIndex = 5;
            this.labelY.Text = "1";
            // 
            // btnCelda_Inicial
            // 
            this.btnCelda_Inicial.Enabled = false;
            this.btnCelda_Inicial.Location = new System.Drawing.Point(10, 243);
            this.btnCelda_Inicial.Name = "btnCelda_Inicial";
            this.btnCelda_Inicial.Size = new System.Drawing.Size(111, 23);
            this.btnCelda_Inicial.TabIndex = 6;
            this.btnCelda_Inicial.Text = "Coordenada Inicial";
            this.btnCelda_Inicial.UseVisualStyleBackColor = true;
            this.btnCelda_Inicial.Click += new System.EventHandler(this.btnCelda_Inicial_Click);
            // 
            // btnCelda_Final
            // 
            this.btnCelda_Final.Enabled = false;
            this.btnCelda_Final.Location = new System.Drawing.Point(10, 283);
            this.btnCelda_Final.Name = "btnCelda_Final";
            this.btnCelda_Final.Size = new System.Drawing.Size(111, 23);
            this.btnCelda_Final.TabIndex = 7;
            this.btnCelda_Final.Text = "Coordenada Final";
            this.btnCelda_Final.UseVisualStyleBackColor = true;
            this.btnCelda_Final.Click += new System.EventHandler(this.btnCelda_Final_Click);
            // 
            // Laberinto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.btnCelda_Final);
            this.Controls.Add(this.btnCelda_Inicial);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMapa);
            this.Name = "Laberinto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laberinto";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Laberinto_FormClosed);
            this.Load += new System.EventHandler(this.Laberinto_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Laberinto_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpropiedades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonaje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMapa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbPersonaje;
        private System.Windows.Forms.ComboBox cmbPersonaje;
        private System.Windows.Forms.DataGridView dgvpropiedades;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Button btnCelda_Inicial;
        private System.Windows.Forms.Button btnCelda_Final;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terreno;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.Button btnElegir;
    }
}