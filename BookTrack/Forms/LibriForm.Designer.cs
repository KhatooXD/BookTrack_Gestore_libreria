namespace BookTrack.Forms
{
    partial class LibriForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibriForm));
            this.lvListaLibri = new System.Windows.Forms.ListView();
            this.clnTitolo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnAutore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnGenere = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnAnno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnDisponibile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnPrezzo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAggiungiLibroLista = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // lvListaLibri
            // 
            this.lvListaLibri.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnTitolo,
            this.clnAutore,
            this.clnGenere,
            this.clnAnno,
            this.clnDisponibile,
            this.clnPrezzo});
            this.lvListaLibri.HideSelection = false;
            this.lvListaLibri.Location = new System.Drawing.Point(0, -1);
            this.lvListaLibri.Name = "lvListaLibri";
            this.lvListaLibri.Size = new System.Drawing.Size(687, 356);
            this.lvListaLibri.TabIndex = 0;
            this.lvListaLibri.UseCompatibleStateImageBehavior = false;
            this.lvListaLibri.View = System.Windows.Forms.View.Details;
            // 
            // clnTitolo
            // 
            this.clnTitolo.Text = "Titolo";
            this.clnTitolo.Width = 141;
            // 
            // clnAutore
            // 
            this.clnAutore.Text = "Autore";
            this.clnAutore.Width = 116;
            // 
            // clnGenere
            // 
            this.clnGenere.Text = "Genere";
            this.clnGenere.Width = 126;
            // 
            // clnAnno
            // 
            this.clnAnno.Text = "Anno";
            // 
            // clnDisponibile
            // 
            this.clnDisponibile.Text = "Disponibile";
            this.clnDisponibile.Width = 65;
            // 
            // clnPrezzo
            // 
            this.clnPrezzo.Text = "Prezzo";
            this.clnPrezzo.Width = 63;
            // 
            // btnAggiungiLibroLista
            // 
            this.btnAggiungiLibroLista.Location = new System.Drawing.Point(594, -1);
            this.btnAggiungiLibroLista.Name = "btnAggiungiLibroLista";
            this.btnAggiungiLibroLista.Size = new System.Drawing.Size(93, 23);
            this.btnAggiungiLibroLista.TabIndex = 1;
            this.btnAggiungiLibroLista.Text = "Aggiungi Libro";
            this.btnAggiungiLibroLista.UseVisualStyleBackColor = true;
            this.btnAggiungiLibroLista.Click += new System.EventHandler(this.btnAggiungiLibroLista_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // LibriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BookTrack.Properties.Resources.booktrack_logo;
            this.ClientSize = new System.Drawing.Size(686, 350);
            this.Controls.Add(this.btnAggiungiLibroLista);
            this.Controls.Add(this.lvListaLibri);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LibriForm";
            this.Text = "Libreria";
            this.Load += new System.EventHandler(this.LibriForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvListaLibri;
        private System.Windows.Forms.Button btnAggiungiLibroLista;
        private System.Windows.Forms.ColumnHeader clnTitolo;
        private System.Windows.Forms.ColumnHeader clnAutore;
        private System.Windows.Forms.ColumnHeader clnGenere;
        private System.Windows.Forms.ColumnHeader clnAnno;
        private System.Windows.Forms.ColumnHeader clnDisponibile;
        private System.Windows.Forms.ColumnHeader clnPrezzo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}