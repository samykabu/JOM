namespace AdminUtility
{
    partial class Newcategory
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
            this.SaveBT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ArabicName = new System.Windows.Forms.TextBox();
            this.EnglishName = new System.Windows.Forms.TextBox();
            this.SelectedSectionID = new System.Windows.Forms.ComboBox();
            this.Categories = new System.Windows.Forms.ComboBox();
            this.DataTypeCombo = new System.Windows.Forms.ComboBox();
            this.CancelBT = new System.Windows.Forms.Button();
            this.EditBT = new System.Windows.Forms.Button();
            this.HeaderImg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DispalyFileSelection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaveBT
            // 
            this.SaveBT.Location = new System.Drawing.Point(166, 193);
            this.SaveBT.Name = "SaveBT";
            this.SaveBT.Size = new System.Drawing.Size(75, 23);
            this.SaveBT.TabIndex = 0;
            this.SaveBT.Text = "Save";
            this.SaveBT.UseVisualStyleBackColor = true;
            this.SaveBT.Click += new System.EventHandler(this.SaveBtClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Arabic Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "English Name";
            // 
            // ArabicName
            // 
            this.ArabicName.Location = new System.Drawing.Point(83, 115);
            this.ArabicName.Name = "ArabicName";
            this.ArabicName.Size = new System.Drawing.Size(249, 20);
            this.ArabicName.TabIndex = 3;
            // 
            // EnglishName
            // 
            this.EnglishName.Location = new System.Drawing.Point(83, 141);
            this.EnglishName.Name = "EnglishName";
            this.EnglishName.Size = new System.Drawing.Size(249, 20);
            this.EnglishName.TabIndex = 4;
            // 
            // SelectedSectionID
            // 
            this.SelectedSectionID.FormattingEnabled = true;
            this.SelectedSectionID.Location = new System.Drawing.Point(83, 34);
            this.SelectedSectionID.Name = "SelectedSectionID";
            this.SelectedSectionID.Size = new System.Drawing.Size(249, 21);
            this.SelectedSectionID.TabIndex = 5;
            this.SelectedSectionID.SelectedIndexChanged += new System.EventHandler(this.FillCategories);
            // 
            // Categories
            // 
            this.Categories.FormattingEnabled = true;
            this.Categories.Location = new System.Drawing.Point(83, 61);
            this.Categories.Name = "Categories";
            this.Categories.Size = new System.Drawing.Size(207, 21);
            this.Categories.TabIndex = 6;
            // 
            // DataTypeCombo
            // 
            this.DataTypeCombo.FormattingEnabled = true;
            this.DataTypeCombo.Items.AddRange(new object[] {
            "Image",
            "ImageGalary",
            "Video",
            "Folder (3D View)"});
            this.DataTypeCombo.Location = new System.Drawing.Point(83, 88);
            this.DataTypeCombo.Name = "DataTypeCombo";
            this.DataTypeCombo.Size = new System.Drawing.Size(249, 21);
            this.DataTypeCombo.TabIndex = 7;
            // 
            // CancelBT
            // 
            this.CancelBT.Location = new System.Drawing.Point(257, 193);
            this.CancelBT.Name = "CancelBT";
            this.CancelBT.Size = new System.Drawing.Size(75, 23);
            this.CancelBT.TabIndex = 8;
            this.CancelBT.Text = "Cancel";
            this.CancelBT.UseVisualStyleBackColor = true;
            this.CancelBT.Click += new System.EventHandler(this.CancelClick);
            // 
            // EditBT
            // 
            this.EditBT.Location = new System.Drawing.Point(296, 59);
            this.EditBT.Name = "EditBT";
            this.EditBT.Size = new System.Drawing.Size(36, 23);
            this.EditBT.TabIndex = 9;
            this.EditBT.Text = "Edit";
            this.EditBT.UseVisualStyleBackColor = true;
            this.EditBT.Click += new System.EventHandler(this.EditCategoryClick);
            // 
            // HeaderImg
            // 
            this.HeaderImg.Location = new System.Drawing.Point(83, 167);
            this.HeaderImg.Name = "HeaderImg";
            this.HeaderImg.Size = new System.Drawing.Size(207, 20);
            this.HeaderImg.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Header Image";
            // 
            // DispalyFileSelection
            // 
            this.DispalyFileSelection.Location = new System.Drawing.Point(296, 164);
            this.DispalyFileSelection.Name = "DispalyFileSelection";
            this.DispalyFileSelection.Size = new System.Drawing.Size(36, 23);
            this.DispalyFileSelection.TabIndex = 12;
            this.DispalyFileSelection.Text = "..";
            this.DispalyFileSelection.UseVisualStyleBackColor = true;
            this.DispalyFileSelection.Click += new System.EventHandler(this.DispalyFileSelection_Click);
            // 
            // Newcategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 222);
            this.Controls.Add(this.DispalyFileSelection);
            this.Controls.Add(this.HeaderImg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EditBT);
            this.Controls.Add(this.CancelBT);
            this.Controls.Add(this.DataTypeCombo);
            this.Controls.Add(this.Categories);
            this.Controls.Add(this.SelectedSectionID);
            this.Controls.Add(this.EnglishName);
            this.Controls.Add(this.ArabicName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveBT);
            this.Name = "Newcategory";
            this.Text = "Newcategory";
            this.Load += new System.EventHandler(this.Newcategory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveBT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ArabicName;
        private System.Windows.Forms.TextBox EnglishName;
        private System.Windows.Forms.ComboBox SelectedSectionID;
        private System.Windows.Forms.ComboBox Categories;
        private System.Windows.Forms.ComboBox DataTypeCombo;
        private System.Windows.Forms.Button CancelBT;
        private System.Windows.Forms.Button EditBT;
        private System.Windows.Forms.TextBox HeaderImg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button DispalyFileSelection;
    }
}