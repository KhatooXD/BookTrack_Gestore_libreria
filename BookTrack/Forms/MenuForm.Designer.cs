namespace BookTrack.Forms
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.btnVisualizzaLibriDisponibili = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnRicerca = new System.Windows.Forms.Button();
            this.btnRimuovi = new System.Windows.Forms.Button();
            this.btnStoricoPrestiti = new System.Windows.Forms.Button();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVisualizzaLibriDisponibili
            // 
            this.btnVisualizzaLibriDisponibili.Location = new System.Drawing.Point(12, 12);
            this.btnVisualizzaLibriDisponibili.Name = "btnVisualizzaLibriDisponibili";
            this.btnVisualizzaLibriDisponibili.Size = new System.Drawing.Size(138, 34);
            this.btnVisualizzaLibriDisponibili.TabIndex = 2;
            this.btnVisualizzaLibriDisponibili.Text = "Visualizza Libri Disponibili";
            this.btnVisualizzaLibriDisponibili.UseVisualStyleBackColor = true;
            this.btnVisualizzaLibriDisponibili.Click += new System.EventHandler(this.btnVisualizzaLibriDisponibili_Click);
            // 
            // btnRicerca
            // 
            this.btnRicerca.Location = new System.Drawing.Point(12, 52);
            this.btnRicerca.Name = "btnRicerca";
            this.btnRicerca.Size = new System.Drawing.Size(138, 34);
            this.btnRicerca.TabIndex = 3;
            this.btnRicerca.Text = "Ricerca Libri";
            this.btnRicerca.UseVisualStyleBackColor = true;
            this.btnRicerca.Click += new System.EventHandler(this.btnRicerca_Click);
            // 
            // btnRimuovi
            // 
            this.btnRimuovi.Location = new System.Drawing.Point(289, 199);
            this.btnRimuovi.Name = "btnRimuovi";
            this.btnRimuovi.Size = new System.Drawing.Size(138, 34);
            this.btnRimuovi.TabIndex = 4;
            this.btnRimuovi.Text = "Rimuovi Libro";
            this.btnRimuovi.UseVisualStyleBackColor = true;
            this.btnRimuovi.Click += new System.EventHandler(this.btnRimuovi_Click);
            // 
            // btnStoricoPrestiti
            // 
            this.btnStoricoPrestiti.Location = new System.Drawing.Point(12, 92);
            this.btnStoricoPrestiti.Name = "btnStoricoPrestiti";
            this.btnStoricoPrestiti.Size = new System.Drawing.Size(138, 34);
            this.btnStoricoPrestiti.TabIndex = 6;
            this.btnStoricoPrestiti.Text = "Storico Prestiti";
            this.btnStoricoPrestiti.UseVisualStyleBackColor = true;
            this.btnStoricoPrestiti.Click += new System.EventHandler(this.btnStoricoPrestiti_Click);
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.BackColor = System.Drawing.Color.Transparent;
            this.lblAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdmin.ForeColor = System.Drawing.Color.Black;
            this.lblAdmin.Location = new System.Drawing.Point(284, 151);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(125, 29);
            this.lblAdmin.TabIndex = 7;
            this.lblAdmin.Text = "Gestione:";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BookTrack.Properties.Resources.BookTrack_background;
            this.ClientSize = new System.Drawing.Size(439, 245);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.btnStoricoPrestiti);
            this.Controls.Add(this.btnRimuovi);
            this.Controls.Add(this.btnRicerca);
            this.Controls.Add(this.btnVisualizzaLibriDisponibili);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnVisualizzaLibriDisponibili;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnRicerca;
        private System.Windows.Forms.Button btnRimuovi;
        private System.Windows.Forms.Button btnStoricoPrestiti;
        private System.Windows.Forms.Label lblAdmin;
    }
}