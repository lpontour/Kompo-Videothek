namespace VideoDialog.Loan
{
    partial class CDialogLoanDelete
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
            this.textBoxReturnDate = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxBorrower = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.labelReturnDate = new System.Windows.Forms.Label();
            this.labelBorrower = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxReturnDate
            // 
            this.textBoxReturnDate.Location = new System.Drawing.Point(491, 228);
            this.textBoxReturnDate.Name = "textBoxReturnDate";
            this.textBoxReturnDate.Size = new System.Drawing.Size(165, 20);
            this.textBoxReturnDate.TabIndex = 1;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(491, 102);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(165, 20);
            this.textBoxTitle.TabIndex = 3;
            // 
            // textBoxBorrower
            // 
            this.textBoxBorrower.Location = new System.Drawing.Point(164, 228);
            this.textBoxBorrower.Name = "textBoxBorrower";
            this.textBoxBorrower.Size = new System.Drawing.Size(165, 20);
            this.textBoxBorrower.TabIndex = 4;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(164, 102);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(165, 20);
            this.textBoxID.TabIndex = 6;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(488, 81);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(40, 18);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = "Titel";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.BackColor = System.Drawing.Color.Transparent;
            this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelID.Location = new System.Drawing.Point(161, 81);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(24, 18);
            this.labelID.TabIndex = 9;
            this.labelID.Text = "ID";
            // 
            // labelReturnDate
            // 
            this.labelReturnDate.AutoSize = true;
            this.labelReturnDate.BackColor = System.Drawing.Color.Transparent;
            this.labelReturnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelReturnDate.Location = new System.Drawing.Point(488, 207);
            this.labelReturnDate.Name = "labelReturnDate";
            this.labelReturnDate.Size = new System.Drawing.Size(129, 18);
            this.labelReturnDate.TabIndex = 12;
            this.labelReturnDate.Text = "Rückgabedatum";
            // 
            // labelBorrower
            // 
            this.labelBorrower.AutoSize = true;
            this.labelBorrower.BackColor = System.Drawing.Color.Transparent;
            this.labelBorrower.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelBorrower.Location = new System.Drawing.Point(161, 207);
            this.labelBorrower.Name = "labelBorrower";
            this.labelBorrower.Size = new System.Drawing.Size(104, 18);
            this.labelBorrower.TabIndex = 13;
            this.labelBorrower.Text = "Ausleihender";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(208, 327);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(121, 46);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfirm.Location = new System.Drawing.Point(491, 327);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(121, 46);
            this.buttonConfirm.TabIndex = 15;
            this.buttonConfirm.Text = "Bestätigen";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // CDialogLoanDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VideoDialog.Properties.Resources.Videothek_verleihhüllen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 507);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelBorrower);
            this.Controls.Add(this.labelReturnDate);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxBorrower);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.textBoxReturnDate);
            this.Name = "CDialogLoanDelete";
            this.Text = "Rückgabe eines Films";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxReturnDate;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxBorrower;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelReturnDate;
        private System.Windows.Forms.Label labelBorrower;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConfirm;
    }
}