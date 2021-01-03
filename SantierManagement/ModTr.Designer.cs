namespace SantierManagement
{
    partial class ModTr
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
            this.dataGridViewTr = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTr)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonModificare
            // 
            this.buttonModificare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModificare.Location = new System.Drawing.Point(182, 211);
            this.buttonModificare.Name = "buttonModificare";
            this.buttonModificare.Size = new System.Drawing.Size(121, 36);
            this.buttonModificare.TabIndex = 11;
            this.buttonModificare.Text = "Modificare";
            this.buttonModificare.UseVisualStyleBackColor = true;
            this.buttonModificare.Click += new System.EventHandler(this.buttonModificare_Click);
            // 
            // dataGridViewTr
            // 
            this.dataGridViewTr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTr.Location = new System.Drawing.Point(12, 30);
            this.dataGridViewTr.Name = "dataGridViewTr";
            this.dataGridViewTr.Size = new System.Drawing.Size(460, 175);
            this.dataGridViewTr.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Modificare date transport";
            // 
            // ModTr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.buttonModificare);
            this.Controls.Add(this.dataGridViewTr);
            this.Controls.Add(this.label1);
            this.Name = "ModTr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModTr";
            this.Load += new System.EventHandler(this.ModTr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonModificare;
        private System.Windows.Forms.DataGridView dataGridViewTr;
        private System.Windows.Forms.Label label1;
    }
}