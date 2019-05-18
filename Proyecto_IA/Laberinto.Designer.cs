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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Laberinto));
            this.label1 = new System.Windows.Forms.Label();
            this.panelMapa = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnModificar = new System.Windows.Forms.Button();
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
            this.btnRegresar = new System.Windows.Forms.Button();
            this.listBoxOrdenExpansion = new System.Windows.Forms.ListBox();
            this.btnArriba = new System.Windows.Forms.Button();
            this.btnAbajo = new System.Windows.Forms.Button();
            this.btnJugar = new System.Windows.Forms.Button();
            this.cbBT = new System.Windows.Forms.CheckBox();
            this.cbAS = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpropiedades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonaje)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.panelMapa.Location = new System.Drawing.Point(190, 160);
            this.panelMapa.Name = "panelMapa";
            this.panelMapa.Size = new System.Drawing.Size(10, 10);
            this.panelMapa.TabIndex = 1;
            this.panelMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMapa_Paint);
            this.panelMapa.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelMapa_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnModificar);
            this.panel1.Controls.Add(this.btnElegir);
            this.panel1.Controls.Add(this.dgvpropiedades);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pbPersonaje);
            this.panel1.Controls.Add(this.cmbPersonaje);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 123);
            this.panel1.TabIndex = 2;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Transparent;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(693, 3);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(91, 24);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Visible = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnElegir
            // 
            this.btnElegir.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnElegir.Cursor = System.Windows.Forms.Cursors.Hand;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvpropiedades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvpropiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpropiedades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Terreno,
            this.codigo,
            this.Costo});
            this.dgvpropiedades.EnableHeadersVisualStyles = false;
            this.dgvpropiedades.Location = new System.Drawing.Point(512, 30);
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
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Coordenadas:";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.BackColor = System.Drawing.Color.Transparent;
            this.labelX.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX.ForeColor = System.Drawing.Color.White;
            this.labelX.Location = new System.Drawing.Point(49, 174);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(18, 19);
            this.labelX.TabIndex = 4;
            this.labelX.Text = "A";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.BackColor = System.Drawing.Color.Transparent;
            this.labelY.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelY.ForeColor = System.Drawing.Color.White;
            this.labelY.Location = new System.Drawing.Point(77, 174);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(18, 19);
            this.labelY.TabIndex = 5;
            this.labelY.Text = "1";
            // 
            // btnCelda_Inicial
            // 
            this.btnCelda_Inicial.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCelda_Inicial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCelda_Inicial.Enabled = false;
            this.btnCelda_Inicial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCelda_Inicial.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCelda_Inicial.Location = new System.Drawing.Point(19, 210);
            this.btnCelda_Inicial.Name = "btnCelda_Inicial";
            this.btnCelda_Inicial.Size = new System.Drawing.Size(120, 48);
            this.btnCelda_Inicial.TabIndex = 6;
            this.btnCelda_Inicial.Text = "Coordenada Inicial";
            this.btnCelda_Inicial.UseVisualStyleBackColor = false;
            this.btnCelda_Inicial.Click += new System.EventHandler(this.btnCelda_Inicial_Click);
            // 
            // btnCelda_Final
            // 
            this.btnCelda_Final.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCelda_Final.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCelda_Final.Enabled = false;
            this.btnCelda_Final.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCelda_Final.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCelda_Final.Location = new System.Drawing.Point(19, 264);
            this.btnCelda_Final.Name = "btnCelda_Final";
            this.btnCelda_Final.Size = new System.Drawing.Size(120, 49);
            this.btnCelda_Final.TabIndex = 7;
            this.btnCelda_Final.Text = "Coordenada Final";
            this.btnCelda_Final.UseVisualStyleBackColor = false;
            this.btnCelda_Final.Click += new System.EventHandler(this.btnCelda_Final_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Teal;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(20, 691);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(116, 31);
            this.btnRegresar.TabIndex = 8;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // listBoxOrdenExpansion
            // 
            this.listBoxOrdenExpansion.BackColor = System.Drawing.Color.MediumTurquoise;
            this.listBoxOrdenExpansion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxOrdenExpansion.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxOrdenExpansion.FormattingEnabled = true;
            this.listBoxOrdenExpansion.ItemHeight = 20;
            this.listBoxOrdenExpansion.Items.AddRange(new object[] {
            "Arriba",
            "Derecha",
            "Abajo",
            "Izquierda"});
            this.listBoxOrdenExpansion.Location = new System.Drawing.Point(53, 320);
            this.listBoxOrdenExpansion.Name = "listBoxOrdenExpansion";
            this.listBoxOrdenExpansion.Size = new System.Drawing.Size(91, 82);
            this.listBoxOrdenExpansion.TabIndex = 9;
            // 
            // btnArriba
            // 
            this.btnArriba.BackColor = System.Drawing.Color.DarkCyan;
            this.btnArriba.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArriba.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArriba.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArriba.Location = new System.Drawing.Point(15, 319);
            this.btnArriba.Name = "btnArriba";
            this.btnArriba.Size = new System.Drawing.Size(32, 40);
            this.btnArriba.TabIndex = 10;
            this.btnArriba.Text = "↑";
            this.btnArriba.UseVisualStyleBackColor = false;
            this.btnArriba.Click += new System.EventHandler(this.btnArriba_Click);
            // 
            // btnAbajo
            // 
            this.btnAbajo.BackColor = System.Drawing.Color.DarkCyan;
            this.btnAbajo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbajo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbajo.Location = new System.Drawing.Point(15, 365);
            this.btnAbajo.Name = "btnAbajo";
            this.btnAbajo.Size = new System.Drawing.Size(32, 40);
            this.btnAbajo.TabIndex = 11;
            this.btnAbajo.Text = "↓";
            this.btnAbajo.UseVisualStyleBackColor = false;
            this.btnAbajo.Click += new System.EventHandler(this.btnAbajo_Click);
            // 
            // btnJugar
            // 
            this.btnJugar.BackColor = System.Drawing.Color.Purple;
            this.btnJugar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJugar.Enabled = false;
            this.btnJugar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJugar.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJugar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnJugar.Location = new System.Drawing.Point(15, 523);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(120, 49);
            this.btnJugar.TabIndex = 7;
            this.btnJugar.Text = "¡Jugar!";
            this.btnJugar.UseVisualStyleBackColor = false;
            this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            // 
            // cbBT
            // 
            this.cbBT.AutoSize = true;
            this.cbBT.Enabled = false;
            this.cbBT.Font = new System.Drawing.Font("Consolas", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBT.Location = new System.Drawing.Point(3, 12);
            this.cbBT.Name = "cbBT";
            this.cbBT.Size = new System.Drawing.Size(123, 22);
            this.cbBT.TabIndex = 12;
            this.cbBT.Text = "BackTracking";
            this.cbBT.UseVisualStyleBackColor = true;
            this.cbBT.CheckedChanged += new System.EventHandler(this.cbBT_CheckedChanged);
            // 
            // cbAS
            // 
            this.cbAS.AutoSize = true;
            this.cbAS.Enabled = false;
            this.cbAS.Font = new System.Drawing.Font("Consolas", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAS.Location = new System.Drawing.Point(3, 36);
            this.cbAS.Name = "cbAS";
            this.cbAS.Size = new System.Drawing.Size(48, 23);
            this.cbAS.TabIndex = 13;
            this.cbAS.Text = "A★";
            this.cbAS.UseVisualStyleBackColor = true;
            this.cbAS.CheckedChanged += new System.EventHandler(this.cbAS_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumTurquoise;
            this.panel2.Controls.Add(this.cbAS);
            this.panel2.Controls.Add(this.cbBT);
            this.panel2.Location = new System.Drawing.Point(15, 411);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(129, 63);
            this.panel2.TabIndex = 14;
            // 
            // Laberinto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(889, 734);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAbajo);
            this.Controls.Add(this.btnArriba);
            this.Controls.Add(this.listBoxOrdenExpansion);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnJugar);
            this.Controls.Add(this.btnCelda_Final);
            this.Controls.Add(this.btnCelda_Inicial);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMapa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Laberinto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laberinto";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Laberinto_FormClosed);
            this.Load += new System.EventHandler(this.Laberinto_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Laberinto_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Laberinto_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpropiedades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonaje)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.ListBox listBoxOrdenExpansion;
        private System.Windows.Forms.Button btnArriba;
        private System.Windows.Forms.Button btnAbajo;
        private System.Windows.Forms.Button btnJugar;
        private System.Windows.Forms.CheckBox cbBT;
        private System.Windows.Forms.CheckBox cbAS;
        private System.Windows.Forms.Panel panel2;
    }
}