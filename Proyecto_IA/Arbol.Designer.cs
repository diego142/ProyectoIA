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
            this.VistaArbol = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // VistaArbol
            // 
            this.VistaArbol.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VistaArbol.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.VistaArbol.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VistaArbol.Location = new System.Drawing.Point(211, 86);
            this.VistaArbol.Name = "VistaArbol";
            this.VistaArbol.Size = new System.Drawing.Size(350, 367);
            this.VistaArbol.TabIndex = 0;
            // 
            // Arbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(770, 548);
            this.Controls.Add(this.VistaArbol);
            this.Name = "Arbol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arbol";
            this.Load += new System.EventHandler(this.Arbol_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView VistaArbol;
    }
}