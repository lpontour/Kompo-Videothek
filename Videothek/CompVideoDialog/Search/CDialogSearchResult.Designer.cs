namespace VideoDialog.Search
{
    partial class CDialogSearchResult
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
            this.dataGridViewVideoTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVideoTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewVideoTable
            // 
            this.dataGridViewVideoTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewVideoTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVideoTable.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewVideoTable.Name = "dataGridViewVideoTable";
            this.dataGridViewVideoTable.Size = new System.Drawing.Size(760, 426);
            this.dataGridViewVideoTable.TabIndex = 0;
            // 
            // CDialogSearchResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 507);
            this.Controls.Add(this.dataGridViewVideoTable);
            this.Name = "CDialogSearchResult";
            this.Text = "Suchergebnisse";
            this.Load += new System.EventHandler(this.CDialogSearchResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVideoTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewVideoTable;
    }
}