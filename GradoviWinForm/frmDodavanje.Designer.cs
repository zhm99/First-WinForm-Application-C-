namespace GradoviWinForm
{
    partial class frmDodavanje
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.txtPostanskiBroj = new System.Windows.Forms.TextBox();
            this.btnUpisati = new System.Windows.Forms.Button();
            this.btnOdustati = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Postanski broj:";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(106, 21);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(196, 20);
            this.txtNaziv.TabIndex = 2;
            // 
            // txtPostanskiBroj
            // 
            this.txtPostanskiBroj.Location = new System.Drawing.Point(107, 60);
            this.txtPostanskiBroj.Name = "txtPostanskiBroj";
            this.txtPostanskiBroj.Size = new System.Drawing.Size(196, 20);
            this.txtPostanskiBroj.TabIndex = 3;
            // 
            // btnUpisati
            // 
            this.btnUpisati.Location = new System.Drawing.Point(139, 112);
            this.btnUpisati.Name = "btnUpisati";
            this.btnUpisati.Size = new System.Drawing.Size(75, 23);
            this.btnUpisati.TabIndex = 4;
            this.btnUpisati.Text = "Upisati";
            this.btnUpisati.UseVisualStyleBackColor = true;
            this.btnUpisati.Click += new System.EventHandler(this.btnUpisati_Click);
            // 
            // btnOdustati
            // 
            this.btnOdustati.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOdustati.Location = new System.Drawing.Point(227, 112);
            this.btnOdustati.Name = "btnOdustati";
            this.btnOdustati.Size = new System.Drawing.Size(75, 23);
            this.btnOdustati.TabIndex = 5;
            this.btnOdustati.Text = "Odustati";
            this.btnOdustati.UseVisualStyleBackColor = true;
            this.btnOdustati.Click += new System.EventHandler(this.btnOdustati_Click);
            // 
            // frmDodavanje
            // 
            this.AcceptButton = this.btnUpisati;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOdustati;
            this.ClientSize = new System.Drawing.Size(338, 152);
            this.Controls.Add(this.btnOdustati);
            this.Controls.Add(this.btnUpisati);
            this.Controls.Add(this.txtPostanskiBroj);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDodavanje";
            this.Text = "Dodavanje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.TextBox txtPostanskiBroj;
        private System.Windows.Forms.Button btnUpisati;
        private System.Windows.Forms.Button btnOdustati;
    }
}