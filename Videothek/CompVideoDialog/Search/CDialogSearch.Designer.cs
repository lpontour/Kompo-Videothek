namespace VideoDialog.Search
{
    partial class CDialogSearch
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.labelReturnDate = new System.Windows.Forms.Label();
            this.labelBorrower = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.labelGenre = new System.Windows.Forms.Label();
            this.labelBorrowingRate = new System.Windows.Forms.Label();
            this.labelReleaseYear = new System.Windows.Forms.Label();
            this.labelRunningTime = new System.Windows.Forms.Label();
            this.labelRated = new System.Windows.Forms.Label();
            this.comboBoxID = new System.Windows.Forms.ComboBox();
            this.comboBoxGenre = new System.Windows.Forms.ComboBox();
            this.comboBoxRunningTime = new System.Windows.Forms.ComboBox();
            this.comboBoxBorrowingRate = new System.Windows.Forms.ComboBox();
            this.comboBoxReleaseYear = new System.Windows.Forms.ComboBox();
            this.comboBoxTitle = new System.Windows.Forms.ComboBox();
            this.comboBoxRated = new System.Windows.Forms.ComboBox();
            this.comboBoxBorrower = new System.Windows.Forms.ComboBox();
            this.comboBoxReturnDate = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(488, 52);
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
            this.labelID.Location = new System.Drawing.Point(161, 14);
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
            this.labelReturnDate.Location = new System.Drawing.Point(161, 331);
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
            this.labelBorrower.Location = new System.Drawing.Point(488, 286);
            this.labelBorrower.Name = "labelBorrower";
            this.labelBorrower.Size = new System.Drawing.Size(104, 18);
            this.labelBorrower.TabIndex = 13;
            this.labelBorrower.Text = "Ausleihender";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(208, 449);
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
            this.buttonConfirm.Location = new System.Drawing.Point(491, 449);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(121, 46);
            this.buttonConfirm.TabIndex = 15;
            this.buttonConfirm.Text = "Bestätigen";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // labelGenre
            // 
            this.labelGenre.AutoSize = true;
            this.labelGenre.BackColor = System.Drawing.Color.Transparent;
            this.labelGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelGenre.Location = new System.Drawing.Point(161, 88);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(54, 18);
            this.labelGenre.TabIndex = 21;
            this.labelGenre.Text = "Genre";
            // 
            // labelBorrowingRate
            // 
            this.labelBorrowingRate.AutoSize = true;
            this.labelBorrowingRate.BackColor = System.Drawing.Color.Transparent;
            this.labelBorrowingRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelBorrowingRate.Location = new System.Drawing.Point(491, 128);
            this.labelBorrowingRate.Name = "labelBorrowingRate";
            this.labelBorrowingRate.Size = new System.Drawing.Size(47, 18);
            this.labelBorrowingRate.TabIndex = 22;
            this.labelBorrowingRate.Text = "Preis";
            // 
            // labelReleaseYear
            // 
            this.labelReleaseYear.AutoSize = true;
            this.labelReleaseYear.BackColor = System.Drawing.Color.Transparent;
            this.labelReleaseYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelReleaseYear.Location = new System.Drawing.Point(161, 167);
            this.labelReleaseYear.Name = "labelReleaseYear";
            this.labelReleaseYear.Size = new System.Drawing.Size(138, 18);
            this.labelReleaseYear.TabIndex = 23;
            this.labelReleaseYear.Text = "Erscheinungsjahr";
            // 
            // labelRunningTime
            // 
            this.labelRunningTime.AutoSize = true;
            this.labelRunningTime.BackColor = System.Drawing.Color.Transparent;
            this.labelRunningTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelRunningTime.Location = new System.Drawing.Point(491, 205);
            this.labelRunningTime.Name = "labelRunningTime";
            this.labelRunningTime.Size = new System.Drawing.Size(67, 18);
            this.labelRunningTime.TabIndex = 24;
            this.labelRunningTime.Text = "Laufzeit";
            // 
            // labelRated
            // 
            this.labelRated.AutoSize = true;
            this.labelRated.BackColor = System.Drawing.Color.Transparent;
            this.labelRated.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelRated.Location = new System.Drawing.Point(161, 248);
            this.labelRated.Name = "labelRated";
            this.labelRated.Size = new System.Drawing.Size(40, 18);
            this.labelRated.TabIndex = 25;
            this.labelRated.Text = "FSK";
            // 
            // comboBoxID
            // 
            this.comboBoxID.FormattingEnabled = true;
            this.comboBoxID.Location = new System.Drawing.Point(164, 35);
            this.comboBoxID.Name = "comboBoxID";
            this.comboBoxID.Size = new System.Drawing.Size(165, 21);
            this.comboBoxID.TabIndex = 26;
            this.comboBoxID.SelectedIndexChanged += new System.EventHandler(this.comboBoxID_SelectedIndexChanged);
            // 
            // comboBoxGenre
            // 
            this.comboBoxGenre.FormattingEnabled = true;
            this.comboBoxGenre.Location = new System.Drawing.Point(164, 109);
            this.comboBoxGenre.Name = "comboBoxGenre";
            this.comboBoxGenre.Size = new System.Drawing.Size(165, 21);
            this.comboBoxGenre.TabIndex = 27;
            this.comboBoxGenre.SelectedIndexChanged += new System.EventHandler(this.comboBoxGenre_SelectedIndexChanged);
            // 
            // comboBoxRunningTime
            // 
            this.comboBoxRunningTime.FormattingEnabled = true;
            this.comboBoxRunningTime.Location = new System.Drawing.Point(491, 226);
            this.comboBoxRunningTime.Name = "comboBoxRunningTime";
            this.comboBoxRunningTime.Size = new System.Drawing.Size(165, 21);
            this.comboBoxRunningTime.TabIndex = 28;
            this.comboBoxRunningTime.SelectedIndexChanged += new System.EventHandler(this.comboBoxRunningTime_SelectedIndexChanged);
            // 
            // comboBoxBorrowingRate
            // 
            this.comboBoxBorrowingRate.FormattingEnabled = true;
            this.comboBoxBorrowingRate.Location = new System.Drawing.Point(491, 149);
            this.comboBoxBorrowingRate.Name = "comboBoxBorrowingRate";
            this.comboBoxBorrowingRate.Size = new System.Drawing.Size(165, 21);
            this.comboBoxBorrowingRate.TabIndex = 29;
            this.comboBoxBorrowingRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxBorrowingRate_SelectedIndexChanged);
            // 
            // comboBoxReleaseYear
            // 
            this.comboBoxReleaseYear.FormattingEnabled = true;
            this.comboBoxReleaseYear.Location = new System.Drawing.Point(164, 188);
            this.comboBoxReleaseYear.Name = "comboBoxReleaseYear";
            this.comboBoxReleaseYear.Size = new System.Drawing.Size(165, 21);
            this.comboBoxReleaseYear.TabIndex = 30;
            this.comboBoxReleaseYear.SelectedIndexChanged += new System.EventHandler(this.comboBoxReleaseYear_SelectedIndexChanged);
            // 
            // comboBoxTitle
            // 
            this.comboBoxTitle.FormattingEnabled = true;
            this.comboBoxTitle.Location = new System.Drawing.Point(491, 73);
            this.comboBoxTitle.Name = "comboBoxTitle";
            this.comboBoxTitle.Size = new System.Drawing.Size(165, 21);
            this.comboBoxTitle.TabIndex = 31;
            this.comboBoxTitle.SelectedIndexChanged += new System.EventHandler(this.comboBoxTitle_SelectedIndexChanged);
            // 
            // comboBoxRated
            // 
            this.comboBoxRated.FormattingEnabled = true;
            this.comboBoxRated.Location = new System.Drawing.Point(164, 267);
            this.comboBoxRated.Name = "comboBoxRated";
            this.comboBoxRated.Size = new System.Drawing.Size(165, 21);
            this.comboBoxRated.TabIndex = 32;
            this.comboBoxRated.SelectedIndexChanged += new System.EventHandler(this.comboBoxRated_SelectedIndexChanged);
            // 
            // comboBoxBorrower
            // 
            this.comboBoxBorrower.FormattingEnabled = true;
            this.comboBoxBorrower.Location = new System.Drawing.Point(491, 307);
            this.comboBoxBorrower.Name = "comboBoxBorrower";
            this.comboBoxBorrower.Size = new System.Drawing.Size(165, 21);
            this.comboBoxBorrower.TabIndex = 33;
            this.comboBoxBorrower.SelectedIndexChanged += new System.EventHandler(this.comboBoxBorrower_SelectedIndexChanged);
            // 
            // comboBoxReturnDate
            // 
            this.comboBoxReturnDate.FormattingEnabled = true;
            this.comboBoxReturnDate.Location = new System.Drawing.Point(164, 352);
            this.comboBoxReturnDate.Name = "comboBoxReturnDate";
            this.comboBoxReturnDate.Size = new System.Drawing.Size(165, 21);
            this.comboBoxReturnDate.TabIndex = 34;
            this.comboBoxReturnDate.SelectedIndexChanged += new System.EventHandler(this.comboBoxReturnDate_SelectedIndexChanged);
            // 
            // CDialogSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VideoDialog.Properties.Resources.Videothek_verleihhüllen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 507);
            this.Controls.Add(this.comboBoxReturnDate);
            this.Controls.Add(this.comboBoxBorrower);
            this.Controls.Add(this.comboBoxRated);
            this.Controls.Add(this.comboBoxTitle);
            this.Controls.Add(this.comboBoxReleaseYear);
            this.Controls.Add(this.comboBoxBorrowingRate);
            this.Controls.Add(this.comboBoxRunningTime);
            this.Controls.Add(this.comboBoxGenre);
            this.Controls.Add(this.comboBoxID);
            this.Controls.Add(this.labelRated);
            this.Controls.Add(this.labelRunningTime);
            this.Controls.Add(this.labelReleaseYear);
            this.Controls.Add(this.labelBorrowingRate);
            this.Controls.Add(this.labelGenre);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelBorrower);
            this.Controls.Add(this.labelReturnDate);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelTitle);
            this.Name = "CDialogSearch";
            this.Text = "Suche";
            this.Load += new System.EventHandler(this.CDialogSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelReturnDate;
        private System.Windows.Forms.Label labelBorrower;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.Label labelBorrowingRate;
        private System.Windows.Forms.Label labelReleaseYear;
        private System.Windows.Forms.Label labelRunningTime;
        private System.Windows.Forms.Label labelRated;
        private System.Windows.Forms.ComboBox comboBoxID;
        private System.Windows.Forms.ComboBox comboBoxGenre;
        private System.Windows.Forms.ComboBox comboBoxRunningTime;
        private System.Windows.Forms.ComboBox comboBoxBorrowingRate;
        private System.Windows.Forms.ComboBox comboBoxReleaseYear;
        private System.Windows.Forms.ComboBox comboBoxTitle;
        private System.Windows.Forms.ComboBox comboBoxRated;
        private System.Windows.Forms.ComboBox comboBoxBorrower;
        private System.Windows.Forms.ComboBox comboBoxReturnDate;
    }
}