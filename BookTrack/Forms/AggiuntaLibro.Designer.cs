namespace BookTrack.Forms
{
    partial class AggiuntaLibro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AggiuntaLibro));
            this.lblTitolo = new System.Windows.Forms.Label();
            this.lblAutore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGenere = new System.Windows.Forms.Label();
            this.lblAnnoLibro = new System.Windows.Forms.Label();
            this.txtTitolo = new System.Windows.Forms.TextBox();
            this.txtAutore = new System.Windows.Forms.TextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtGenere = new System.Windows.Forms.TextBox();
            this.txtAnno = new System.Windows.Forms.TextBox();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitolo
            // 
            this.lblTitolo.AutoSize = true;
            this.lblTitolo.Location = new System.Drawing.Point(12, 9);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(62, 13);
            this.lblTitolo.TabIndex = 0;
            this.lblTitolo.Text = "Titolo Libro:";
            // 
            // lblAutore
            // 
            this.lblAutore.AutoSize = true;
            this.lblAutore.Location = new System.Drawing.Point(12, 32);
            this.lblAutore.Name = "lblAutore";
            this.lblAutore.Size = new System.Drawing.Size(67, 13);
            this.lblAutore.TabIndex = 1;
            this.lblAutore.Text = "Autore Libro:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Costo Libro:";
            // 
            // lblGenere
            // 
            this.lblGenere.AutoSize = true;
            this.lblGenere.Location = new System.Drawing.Point(7, 79);
            this.lblGenere.Name = "lblGenere";
            this.lblGenere.Size = new System.Drawing.Size(71, 13);
            this.lblGenere.TabIndex = 3;
            this.lblGenere.Text = "Genere Libro:";
            // 
            // lblAnnoLibro
            // 
            this.lblAnnoLibro.AutoSize = true;
            this.lblAnnoLibro.Location = new System.Drawing.Point(7, 102);
            this.lblAnnoLibro.Name = "lblAnnoLibro";
            this.lblAnnoLibro.Size = new System.Drawing.Size(114, 13);
            this.lblAnnoLibro.TabIndex = 5;
            this.lblAnnoLibro.Text = "Anno di pubblicazione:";
            // 
            // txtTitolo
            // 
            this.txtTitolo.Location = new System.Drawing.Point(127, 6);
            this.txtTitolo.Name = "txtTitolo";
            this.txtTitolo.Size = new System.Drawing.Size(100, 20);
            this.txtTitolo.TabIndex = 6;
            // 
            // txtAutore
            // 
            this.txtAutore.Location = new System.Drawing.Point(127, 29);
            this.txtAutore.Name = "txtAutore";
            this.txtAutore.Size = new System.Drawing.Size(100, 20);
            this.txtAutore.TabIndex = 7;
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(127, 53);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(100, 20);
            this.txtCosto.TabIndex = 8;
            // 
            // txtGenere
            // 
            this.txtGenere.Location = new System.Drawing.Point(127, 76);
            this.txtGenere.Name = "txtGenere";
            this.txtGenere.Size = new System.Drawing.Size(100, 20);
            this.txtGenere.TabIndex = 9;
            // 
            // txtAnno
            // 
            this.txtAnno.Location = new System.Drawing.Point(127, 99);
            this.txtAnno.Name = "txtAnno";
            this.txtAnno.Size = new System.Drawing.Size(100, 20);
            this.txtAnno.TabIndex = 10;
            // 
            // btnAggiungi
            // 
            this.btnAggiungi.Location = new System.Drawing.Point(308, 121);
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(75, 23);
            this.btnAggiungi.TabIndex = 11;
            this.btnAggiungi.Text = "Aggiungi";
            this.btnAggiungi.UseVisualStyleBackColor = true;
            // 
            // AggiuntaLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 186);
            this.Controls.Add(this.btnAggiungi);
            this.Controls.Add(this.txtAnno);
            this.Controls.Add(this.txtGenere);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.txtAutore);
            this.Controls.Add(this.txtTitolo);
            this.Controls.Add(this.lblAnnoLibro);
            this.Controls.Add(this.lblGenere);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAutore);
            this.Controls.Add(this.lblTitolo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AggiuntaLibro";
            this.Text = "Aggiungi Libro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Label lblAutore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGenere;
        private System.Windows.Forms.Label lblAnnoLibro;
        private System.Windows.Forms.TextBox txtTitolo;
        private System.Windows.Forms.TextBox txtAutore;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.TextBox txtGenere;
        private System.Windows.Forms.TextBox txtAnno;
        private System.Windows.Forms.Button btnAggiungi;
    }
}