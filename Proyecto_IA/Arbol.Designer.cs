namespace Proyecto_IA
{
    partial class Arbol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Arbol));
            this.VistaArbol = new System.Windows.Forms.TreeView();
            this.lblRuta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // VistaArbol
            // 
            this.VistaArbol.BackColor = System.Drawing.Color.DarkSlateGray;
            this.VistaArbol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VistaArbol.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.VistaArbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VistaArbol.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VistaArbol.ForeColor = System.Drawing.Color.White;
            this.VistaArbol.Indent = 40;
            this.VistaArbol.ItemHeight = 30;
            this.VistaArbol.LineColor = System.Drawing.Color.Gold;
            this.VistaArbol.Location = new System.Drawing.Point(0, 0);
            this.VistaArbol.Name = "VistaArbol";
            this.VistaArbol.Size = new System.Drawing.Size(1084, 561);
            this.VistaArbol.TabIndex = 0;
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuta.ForeColor = System.Drawing.Color.White;
            this.lblRuta.Location = new System.Drawing.Point(12, 532);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(63, 19);
            this.lblRuta.TabIndex = 1;
            this.lblRuta.Text = "Ruta: ";
            // 
            // Arbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.lblRuta);
            this.Controls.Add(this.VistaArbol);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Arbol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arbol";
            this.Load += new System.EventHandler(this.Arbol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView VistaArbol;
        private System.Windows.Forms.Label lblRuta;
    }
}