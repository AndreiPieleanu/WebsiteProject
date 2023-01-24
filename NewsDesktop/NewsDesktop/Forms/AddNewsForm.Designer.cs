namespace NewsDesktop.Forms
{
    partial class AddNewsForm
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
            this.tbcNews = new System.Windows.Forms.TabControl();
            this.tbpNormalNews = new System.Windows.Forms.TabPage();
            this.btnPic2 = new System.Windows.Forms.Button();
            this.btnPic1 = new System.Windows.Forms.Button();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblTimeToRead = new System.Windows.Forms.Label();
            this.tbxTimeToRead = new System.Windows.Forms.TextBox();
            this.pbxAdRight = new System.Windows.Forms.PictureBox();
            this.pbxAdLeft = new System.Windows.Forms.PictureBox();
            this.lbxTags = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pbxPicture2 = new System.Windows.Forms.PictureBox();
            this.pbxPicture1 = new System.Windows.Forms.PictureBox();
            this.tbxText2 = new System.Windows.Forms.TextBox();
            this.tbxText1 = new System.Windows.Forms.TextBox();
            this.tbxSubtitle = new System.Windows.Forms.TextBox();
            this.tbxAuthor = new System.Windows.Forms.TextBox();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.tbpBreakingNews = new System.Windows.Forms.TabPage();
            this.tbpInfoNews = new System.Windows.Forms.TabPage();
            this.tbcNews.SuspendLayout();
            this.tbpNormalNews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAdRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAdLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPicture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPicture1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcNews
            // 
            this.tbcNews.Controls.Add(this.tbpNormalNews);
            this.tbcNews.Controls.Add(this.tbpBreakingNews);
            this.tbcNews.Controls.Add(this.tbpInfoNews);
            this.tbcNews.Location = new System.Drawing.Point(0, 0);
            this.tbcNews.Name = "tbcNews";
            this.tbcNews.SelectedIndex = 0;
            this.tbcNews.Size = new System.Drawing.Size(1488, 881);
            this.tbcNews.TabIndex = 0;
            // 
            // tbpNormalNews
            // 
            this.tbpNormalNews.Controls.Add(this.btnPic2);
            this.tbpNormalNews.Controls.Add(this.btnPic1);
            this.tbpNormalNews.Controls.Add(this.lblAuthor);
            this.tbpNormalNews.Controls.Add(this.lblTimeToRead);
            this.tbpNormalNews.Controls.Add(this.tbxTimeToRead);
            this.tbpNormalNews.Controls.Add(this.pbxAdRight);
            this.tbpNormalNews.Controls.Add(this.pbxAdLeft);
            this.tbpNormalNews.Controls.Add(this.lbxTags);
            this.tbpNormalNews.Controls.Add(this.btnAdd);
            this.tbpNormalNews.Controls.Add(this.btnClear);
            this.tbpNormalNews.Controls.Add(this.pbxPicture2);
            this.tbpNormalNews.Controls.Add(this.pbxPicture1);
            this.tbpNormalNews.Controls.Add(this.tbxText2);
            this.tbpNormalNews.Controls.Add(this.tbxText1);
            this.tbpNormalNews.Controls.Add(this.tbxSubtitle);
            this.tbpNormalNews.Controls.Add(this.tbxAuthor);
            this.tbpNormalNews.Controls.Add(this.tbxTitle);
            this.tbpNormalNews.Location = new System.Drawing.Point(4, 24);
            this.tbpNormalNews.Name = "tbpNormalNews";
            this.tbpNormalNews.Padding = new System.Windows.Forms.Padding(3);
            this.tbpNormalNews.Size = new System.Drawing.Size(1480, 853);
            this.tbpNormalNews.TabIndex = 0;
            this.tbpNormalNews.Text = "Normal news";
            this.tbpNormalNews.UseVisualStyleBackColor = true;
            // 
            // btnPic2
            // 
            this.btnPic2.Location = new System.Drawing.Point(234, 484);
            this.btnPic2.Name = "btnPic2";
            this.btnPic2.Size = new System.Drawing.Size(75, 23);
            this.btnPic2.TabIndex = 1;
            this.btnPic2.Text = "Upload pic";
            this.btnPic2.UseVisualStyleBackColor = true;
            this.btnPic2.Click += new System.EventHandler(this.btnPic2_Click);
            // 
            // btnPic1
            // 
            this.btnPic1.Location = new System.Drawing.Point(230, 173);
            this.btnPic1.Name = "btnPic1";
            this.btnPic1.Size = new System.Drawing.Size(75, 23);
            this.btnPic1.TabIndex = 2;
            this.btnPic1.Text = "Upload pic";
            this.btnPic1.UseVisualStyleBackColor = true;
            this.btnPic1.Click += new System.EventHandler(this.btnPic1_Click);
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(919, 96);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(50, 15);
            this.lblAuthor.TabIndex = 15;
            this.lblAuthor.Text = "Author: ";
            // 
            // lblTimeToRead
            // 
            this.lblTimeToRead.AutoSize = true;
            this.lblTimeToRead.Location = new System.Drawing.Point(230, 96);
            this.lblTimeToRead.Name = "lblTimeToRead";
            this.lblTimeToRead.Size = new System.Drawing.Size(79, 15);
            this.lblTimeToRead.TabIndex = 14;
            this.lblTimeToRead.Text = "Time to read: ";
            // 
            // tbxTimeToRead
            // 
            this.tbxTimeToRead.Location = new System.Drawing.Point(326, 93);
            this.tbxTimeToRead.Name = "tbxTimeToRead";
            this.tbxTimeToRead.Size = new System.Drawing.Size(100, 23);
            this.tbxTimeToRead.TabIndex = 13;
            // 
            // pbxAdRight
            // 
            this.pbxAdRight.Image = global::NewsDesktop.Properties.Resources.ad1;
            this.pbxAdRight.Location = new System.Drawing.Point(1256, 0);
            this.pbxAdRight.Name = "pbxAdRight";
            this.pbxAdRight.Size = new System.Drawing.Size(224, 853);
            this.pbxAdRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAdRight.TabIndex = 12;
            this.pbxAdRight.TabStop = false;
            // 
            // pbxAdLeft
            // 
            this.pbxAdLeft.Image = global::NewsDesktop.Properties.Resources.ad21;
            this.pbxAdLeft.Location = new System.Drawing.Point(0, 0);
            this.pbxAdLeft.Name = "pbxAdLeft";
            this.pbxAdLeft.Size = new System.Drawing.Size(224, 853);
            this.pbxAdLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAdLeft.TabIndex = 11;
            this.pbxAdLeft.TabStop = false;
            // 
            // lbxTags
            // 
            this.lbxTags.FormattingEnabled = true;
            this.lbxTags.ItemHeight = 15;
            this.lbxTags.Location = new System.Drawing.Point(230, 795);
            this.lbxTags.Name = "lbxTags";
            this.lbxTags.Size = new System.Drawing.Size(269, 49);
            this.lbxTags.TabIndex = 10;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(859, 804);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 36);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(743, 804);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 36);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear fields";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pbxPicture2
            // 
            this.pbxPicture2.Location = new System.Drawing.Point(326, 484);
            this.pbxPicture2.Name = "pbxPicture2";
            this.pbxPicture2.Size = new System.Drawing.Size(825, 184);
            this.pbxPicture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPicture2.TabIndex = 6;
            this.pbxPicture2.TabStop = false;
            // 
            // pbxPicture1
            // 
            this.pbxPicture1.Location = new System.Drawing.Point(326, 173);
            this.pbxPicture1.Name = "pbxPicture1";
            this.pbxPicture1.Size = new System.Drawing.Size(825, 184);
            this.pbxPicture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPicture1.TabIndex = 5;
            this.pbxPicture1.TabStop = false;
            // 
            // tbxText2
            // 
            this.tbxText2.Location = new System.Drawing.Point(230, 674);
            this.tbxText2.Multiline = true;
            this.tbxText2.Name = "tbxText2";
            this.tbxText2.Size = new System.Drawing.Size(1020, 115);
            this.tbxText2.TabIndex = 4;
            // 
            // tbxText1
            // 
            this.tbxText1.Location = new System.Drawing.Point(230, 363);
            this.tbxText1.Multiline = true;
            this.tbxText1.Name = "tbxText1";
            this.tbxText1.Size = new System.Drawing.Size(1020, 115);
            this.tbxText1.TabIndex = 3;
            // 
            // tbxSubtitle
            // 
            this.tbxSubtitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbxSubtitle.Location = new System.Drawing.Point(230, 128);
            this.tbxSubtitle.Multiline = true;
            this.tbxSubtitle.Name = "tbxSubtitle";
            this.tbxSubtitle.Size = new System.Drawing.Size(1020, 33);
            this.tbxSubtitle.TabIndex = 2;
            this.tbxSubtitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxAuthor
            // 
            this.tbxAuthor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbxAuthor.Location = new System.Drawing.Point(977, 93);
            this.tbxAuthor.Name = "tbxAuthor";
            this.tbxAuthor.ReadOnly = true;
            this.tbxAuthor.Size = new System.Drawing.Size(174, 29);
            this.tbxAuthor.TabIndex = 1;
            // 
            // tbxTitle
            // 
            this.tbxTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbxTitle.Location = new System.Drawing.Point(230, 16);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(1020, 50);
            this.tbxTitle.TabIndex = 0;
            this.tbxTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbpBreakingNews
            // 
            this.tbpBreakingNews.Location = new System.Drawing.Point(4, 24);
            this.tbpBreakingNews.Name = "tbpBreakingNews";
            this.tbpBreakingNews.Padding = new System.Windows.Forms.Padding(3);
            this.tbpBreakingNews.Size = new System.Drawing.Size(1480, 853);
            this.tbpBreakingNews.TabIndex = 1;
            this.tbpBreakingNews.Text = "Breaking news";
            this.tbpBreakingNews.UseVisualStyleBackColor = true;
            // 
            // tbpInfoNews
            // 
            this.tbpInfoNews.Location = new System.Drawing.Point(4, 24);
            this.tbpInfoNews.Name = "tbpInfoNews";
            this.tbpInfoNews.Padding = new System.Windows.Forms.Padding(3);
            this.tbpInfoNews.Size = new System.Drawing.Size(1480, 853);
            this.tbpInfoNews.TabIndex = 2;
            this.tbpInfoNews.Text = "Did you know?";
            this.tbpInfoNews.UseVisualStyleBackColor = true;
            // 
            // AddNewsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1486, 881);
            this.Controls.Add(this.tbcNews);
            this.Name = "AddNewsForm";
            this.Text = "AddNewsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddNewsForm_FormClosing);
            this.tbcNews.ResumeLayout(false);
            this.tbpNormalNews.ResumeLayout(false);
            this.tbpNormalNews.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAdRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAdLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPicture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPicture1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tbcNews;
        private TabPage tbpNormalNews;
        private TabPage tbpBreakingNews;
        private TabPage tbpInfoNews;
        private PictureBox pbxPicture2;
        private PictureBox pbxPicture1;
        private TextBox tbxText2;
        private TextBox tbxText1;
        private TextBox tbxSubtitle;
        private TextBox tbxAuthor;
        private TextBox tbxTitle;
        private PictureBox pbxAdRight;
        private PictureBox pbxAdLeft;
        private ListBox lbxTags;
        private Button btnAdd;
        private Button btnClear;
        private TextBox tbxTimeToRead;
        private Label lblTimeToRead;
        private Label lblAuthor;
        private Button btnPic2;
        private Button btnPic1;
    }
}