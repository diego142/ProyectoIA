namespace Proyecto_IA
{
    partial class Configuracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuracion));
            this.btnSel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCodigo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNombre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblListo = new System.Windows.Forms.Label();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.pbPersonaje = new System.Windows.Forms.PictureBox();
            this.dgvPersonaje = new System.Windows.Forms.DataGridView();
            this.terreno = new System.Windows.Forms.DataGridViewImageColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnSelPersonaje = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAgregarPersonaje = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblListo2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonaje)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSel
            // 
            this.btnSel.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnSel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSel.Location = new System.Drawing.Point(328, 76);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(145, 30);
            this.btnSel.TabIndex = 0;
            this.btnSel.Text = "seleccionar...";
            this.btnSel.UseVisualStyleBackColor = false;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione el archivo:";
            // 
            // cmbCodigo
            // 
            this.cmbCodigo.BackColor = System.Drawing.Color.White;
            this.cmbCodigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodigo.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCodigo.FormattingEnabled = true;
            this.cmbCodigo.Location = new System.Drawing.Point(17, 69);
            this.cmbCodigo.Name = "cmbCodigo";
            this.cmbCodigo.Size = new System.Drawing.Size(184, 42);
            this.cmbCodigo.TabIndex = 2;
            this.cmbCodigo.SelectedIndexChanged += new System.EventHandler(this.cmbCodigo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Codigo";
            // 
            // cmbNombre
            // 
            this.cmbNombre.BackColor = System.Drawing.Color.White;
            this.cmbNombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNombre.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNombre.FormattingEnabled = true;
            this.cmbNombre.Items.AddRange(new object[] {
            "Montaña",
            "Camino",
            "Agua",
            "Arena",
            "Bosque",
            "Lava",
            "Nieve"});
            this.cmbNombre.Location = new System.Drawing.Point(252, 69);
            this.cmbNombre.Name = "cmbNombre";
            this.cmbNombre.Size = new System.Drawing.Size(184, 42);
            this.cmbNombre.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(249, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre del terreno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(532, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Color";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblListo);
            this.panel1.Controls.Add(this.picBox);
            this.panel1.Controls.Add(this.btnColor);
            this.panel1.Controls.Add(this.btnAsignar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbNombre);
            this.panel1.Controls.Add(this.cmbCodigo);
            this.panel1.Location = new System.Drawing.Point(27, 157);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 150);
            this.panel1.TabIndex = 4;
            // 
            // lblListo
            // 
            this.lblListo.AutoSize = true;
            this.lblListo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListo.ForeColor = System.Drawing.Color.Silver;
            this.lblListo.Location = new System.Drawing.Point(797, 113);
            this.lblListo.Name = "lblListo";
            this.lblListo.Size = new System.Drawing.Size(126, 15);
            this.lblListo.TabIndex = 6;
            this.lblListo.Text = "¡Terrenos listos!";
            this.lblListo.Visible = false;
            // 
            // picBox
            // 
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Location = new System.Drawing.Point(718, 69);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(40, 40);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 5;
            this.picBox.TabStop = false;
            this.picBox.Click += new System.EventHandler(this.picBox_Click);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Transparent;
            this.btnColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColor.Location = new System.Drawing.Point(480, 69);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(184, 42);
            this.btnColor.TabIndex = 4;
            this.btnColor.Text = "Seleccionar";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnAsignar
            // 
            this.btnAsignar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignar.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignar.Location = new System.Drawing.Point(799, 69);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(123, 41);
            this.btnAsignar.TabIndex = 4;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(698, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "Imagen";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtNombre);
            this.panel2.Controls.Add(this.pbPersonaje);
            this.panel2.Controls.Add(this.dgvPersonaje);
            this.panel2.Controls.Add(this.btnSelPersonaje);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btnAgregarPersonaje);
            this.panel2.Location = new System.Drawing.Point(27, 334);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(940, 290);
            this.panel2.TabIndex = 6;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(132, 207);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(148, 32);
            this.txtNombre.TabIndex = 10;
            // 
            // pbPersonaje
            // 
            this.pbPersonaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPersonaje.Location = new System.Drawing.Point(283, 54);
            this.pbPersonaje.Name = "pbPersonaje";
            this.pbPersonaje.Size = new System.Drawing.Size(100, 100);
            this.pbPersonaje.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonaje.TabIndex = 9;
            this.pbPersonaje.TabStop = false;
            // 
            // dgvPersonaje
            // 
            this.dgvPersonaje.AllowUserToAddRows = false;
            this.dgvPersonaje.AllowUserToDeleteRows = false;
            this.dgvPersonaje.AllowUserToResizeColumns = false;
            this.dgvPersonaje.AllowUserToResizeRows = false;
            this.dgvPersonaje.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonaje.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.dgvPersonaje.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPersonaje.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPersonaje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonaje.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.terreno,
            this.color,
            this.nombre,
            this.costo});
            this.dgvPersonaje.EnableHeadersVisualStyles = false;
            this.dgvPersonaje.Location = new System.Drawing.Point(437, 43);
            this.dgvPersonaje.Name = "dgvPersonaje";
            this.dgvPersonaje.RowHeadersVisible = false;
            this.dgvPersonaje.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvPersonaje.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.dgvPersonaje.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPersonaje.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPersonaje.RowTemplate.Height = 35;
            this.dgvPersonaje.Size = new System.Drawing.Size(456, 166);
            this.dgvPersonaje.TabIndex = 8;
            // 
            // terreno
            // 
            this.terreno.FillWeight = 40F;
            this.terreno.HeaderText = "Imagen";
            this.terreno.Name = "terreno";
            this.terreno.ReadOnly = true;
            // 
            // color
            // 
            this.color.FillWeight = 30F;
            this.color.HeaderText = "Color";
            this.color.Name = "color";
            this.color.ReadOnly = true;
            this.color.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // nombre
            // 
            this.nombre.FillWeight = 40F;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            // 
            // costo
            // 
            this.costo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.costo.FillWeight = 30F;
            this.costo.HeaderText = "Costo";
            this.costo.Name = "costo";
            this.costo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.costo.ToolTipText = "<Selecionar>";
            // 
            // btnSelPersonaje
            // 
            this.btnSelPersonaje.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnSelPersonaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelPersonaje.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelPersonaje.Location = new System.Drawing.Point(155, 88);
            this.btnSelPersonaje.Name = "btnSelPersonaje";
            this.btnSelPersonaje.Size = new System.Drawing.Size(122, 29);
            this.btnSelPersonaje.TabIndex = 4;
            this.btnSelPersonaje.Text = "seleccionar...";
            this.btnSelPersonaje.UseVisualStyleBackColor = false;
            this.btnSelPersonaje.Click += new System.EventHandler(this.btnSelPersonaje_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 24);
            this.label6.TabIndex = 3;
            this.label6.Text = "Nombre:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 48);
            this.label9.TabIndex = 3;
            this.label9.Text = "Escoje un \r\npersonaje:";
            // 
            // btnAgregarPersonaje
            // 
            this.btnAgregarPersonaje.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnAgregarPersonaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPersonaje.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPersonaje.Location = new System.Drawing.Point(599, 225);
            this.btnAgregarPersonaje.Name = "btnAgregarPersonaje";
            this.btnAgregarPersonaje.Size = new System.Drawing.Size(123, 41);
            this.btnAgregarPersonaje.TabIndex = 4;
            this.btnAgregarPersonaje.Text = "Agregar";
            this.btnAgregarPersonaje.UseVisualStyleBackColor = false;
            this.btnAgregarPersonaje.Click += new System.EventHandler(this.btnAgregarPersonaje_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(302, 660);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(181, 51);
            this.btnRegresar.TabIndex = 7;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnSiguiente.Enabled = false;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.Location = new System.Drawing.Point(508, 660);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(181, 51);
            this.btnSiguiente.TabIndex = 7;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblListo2
            // 
            this.lblListo2.AutoSize = true;
            this.lblListo2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListo2.ForeColor = System.Drawing.Color.Silver;
            this.lblListo2.Location = new System.Drawing.Point(695, 682);
            this.lblListo2.Name = "lblListo2";
            this.lblListo2.Size = new System.Drawing.Size(63, 15);
            this.lblListo2.TabIndex = 6;
            this.lblListo2.Text = "<- Listo";
            this.lblListo2.Visible = false;
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.lblListo2);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Configuracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Configuracion_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonaje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSelPersonaje;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblListo;
        private System.Windows.Forms.Button btnAgregarPersonaje;
        private System.Windows.Forms.DataGridView dgvPersonaje;
        private System.Windows.Forms.PictureBox pbPersonaje;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblListo2;
        private System.Windows.Forms.DataGridViewImageColumn terreno;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewComboBoxColumn costo;
    }
}