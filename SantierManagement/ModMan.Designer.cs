namespace SantierManagement
{
    partial class ModMan
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
            this.buttonModificare = new System.Windows.Forms.Button();
            this.dataGridViewMan = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMan)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonModificare
            // 
            this.buttonModificare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModificare.Location = new System.Drawing.Point(182, 213);
            this.buttonModificare.Name = "buttonModificare";
            this.buttonModificare.Size = new System.Drawing.Size(121, 36);
            this.buttonModificare.TabIndex = 7;
            this.buttonModificare.Text = "Modificare";
            this.buttonModificare.UseVisualStyleBackColor = true;
            this.buttonModificare.Click += new System.EventHandler(this.buttonModificare_Click);
            // 
            // dataGridViewMan
            // 
            this.dataGridViewMan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMan.Location = new System.Drawing.Point(12, 33);
            this.dataGridViewMan.Name = "dataGridViewMan";
            this.dataGridViewMan.Size = new System.Drawing.Size(460, 175);
            this.dataGridViewMan.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(141, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 40);
            this.label1.TabIndex = 4;
            this.label1.Text = "Modificare date angajati\r\n\r\n";
            // 
            // ModMan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.buttonModificare);
            this.Controls.Add(this.dataGridViewMan);
            this.Controls.Add(this.label1);
            this.Name = "ModMan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModMan";
            this.Load += new System.EventHandler(this.ModMan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonModificare;
        private System.Windows.Forms.DataGridView dataGridViewMan;
        private System.Windows.Forms.Label label1;
    }
}