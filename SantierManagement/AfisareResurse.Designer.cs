namespace SantierManagement
{
    partial class AfisareResurse
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
            this.comboBoxSantier = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxMaterial = new System.Windows.Forms.ListBox();
            this.listBoxManopera = new System.Windows.Forms.ListBox();
            this.listBoxTransport = new System.Windows.Forms.ListBox();
            this.listBoxUtilaje = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Șantierul";
            // 
            // comboBoxSantier
            // 
            this.comboBoxSantier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSantier.FormattingEnabled = true;
            this.comboBoxSantier.Location = new System.Drawing.Point(154, 25);
            this.comboBoxSantier.Name = "comboBoxSantier";
            this.comboBoxSantier.Size = new System.Drawing.Size(868, 28);
            this.comboBoxSantier.TabIndex = 1;
            this.comboBoxSantier.SelectionChangeCommitted += new System.EventHandler(this.comboBoxSantiere_SelectionChangeCommited);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Materiale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(529, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fortă de muncă";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Utilaje";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(529, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Materiale transportate";
            // 
            // listBoxMaterial
            // 
            this.listBoxMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMaterial.FormattingEnabled = true;
            this.listBoxMaterial.ItemHeight = 20;
            this.listBoxMaterial.Location = new System.Drawing.Point(36, 117);
            this.listBoxMaterial.Name = "listBoxMaterial";
            this.listBoxMaterial.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxMaterial.Size = new System.Drawing.Size(489, 184);
            this.listBoxMaterial.TabIndex = 6;
            // 
            // listBoxManopera
            // 
            this.listBoxManopera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxManopera.FormattingEnabled = true;
            this.listBoxManopera.ItemHeight = 20;
            this.listBoxManopera.Location = new System.Drawing.Point(533, 117);
            this.listBoxManopera.Name = "listBoxManopera";
            this.listBoxManopera.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxManopera.Size = new System.Drawing.Size(489, 184);
            this.listBoxManopera.TabIndex = 7;
            // 
            // listBoxTransport
            // 
            this.listBoxTransport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTransport.FormattingEnabled = true;
            this.listBoxTransport.ItemHeight = 20;
            this.listBoxTransport.Location = new System.Drawing.Point(533, 358);
            this.listBoxTransport.Name = "listBoxTransport";
            this.listBoxTransport.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxTransport.Size = new System.Drawing.Size(489, 184);
            this.listBoxTransport.TabIndex = 9;
            // 
            // listBoxUtilaje
            // 
            this.listBoxUtilaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxUtilaje.FormattingEnabled = true;
            this.listBoxUtilaje.ItemHeight = 20;
            this.listBoxUtilaje.Location = new System.Drawing.Point(36, 358);
            this.listBoxUtilaje.Name = "listBoxUtilaje";
            this.listBoxUtilaje.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxUtilaje.Size = new System.Drawing.Size(489, 184);
            this.listBoxUtilaje.TabIndex = 8;
            // 
            // AfisareResurse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 569);
            this.Controls.Add(this.listBoxTransport);
            this.Controls.Add(this.listBoxUtilaje);
            this.Controls.Add(this.listBoxManopera);
            this.Controls.Add(this.listBoxMaterial);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxSantier);
            this.Controls.Add(this.label1);
            this.Name = "AfisareResurse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AfisareResurse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSantier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBoxMaterial;
        private System.Windows.Forms.ListBox listBoxManopera;
        private System.Windows.Forms.ListBox listBoxTransport;
        private System.Windows.Forms.ListBox listBoxUtilaje;
    }
}