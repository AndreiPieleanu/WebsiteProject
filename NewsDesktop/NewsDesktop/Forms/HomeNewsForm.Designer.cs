namespace NewsDesktop.Forms
{
    partial class HomeNewsForm
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
            this.dgvNews = new System.Windows.Forms.DataGridView();
            this.bntAddNews = new System.Windows.Forms.Button();
            this.btnEditNews = new System.Windows.Forms.Button();
            this.btnDeleteNews = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxFilter = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNews)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNews
            // 
            this.dgvNews.AllowUserToAddRows = false;
            this.dgvNews.AllowUserToDeleteRows = false;
            this.dgvNews.Location = new System.Drawing.Point(12, 115);
            this.dgvNews.Name = "dgvNews";
            this.dgvNews.ReadOnly = true;
            this.dgvNews.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvNews.RowTemplate.Height = 25;
            this.dgvNews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNews.Size = new System.Drawing.Size(1145, 323);
            this.dgvNews.TabIndex = 0;
            this.dgvNews.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNews_CellContentClick);
            // 
            // bntAddNews
            // 
            this.bntAddNews.Location = new System.Drawing.Point(23, 56);
            this.bntAddNews.Name = "bntAddNews";
            this.bntAddNews.Size = new System.Drawing.Size(130, 39);
            this.bntAddNews.TabIndex = 1;
            this.bntAddNews.Text = "Add news";
            this.bntAddNews.UseVisualStyleBackColor = true;
            this.bntAddNews.Click += new System.EventHandler(this.bntAddNews_Click);
            // 
            // btnEditNews
            // 
            this.btnEditNews.Location = new System.Drawing.Point(159, 56);
            this.btnEditNews.Name = "btnEditNews";
            this.btnEditNews.Size = new System.Drawing.Size(130, 39);
            this.btnEditNews.TabIndex = 2;
            this.btnEditNews.Text = "Edit news";
            this.btnEditNews.UseVisualStyleBackColor = true;
            this.btnEditNews.Click += new System.EventHandler(this.btnEditNews_Click);
            // 
            // btnDeleteNews
            // 
            this.btnDeleteNews.Location = new System.Drawing.Point(295, 56);
            this.btnDeleteNews.Name = "btnDeleteNews";
            this.btnDeleteNews.Size = new System.Drawing.Size(130, 39);
            this.btnDeleteNews.TabIndex = 3;
            this.btnDeleteNews.Text = "Delete news";
            this.btnDeleteNews.UseVisualStyleBackColor = true;
            this.btnDeleteNews.Click += new System.EventHandler(this.btnDeleteNews_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(705, 56);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(130, 39);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxFilter
            // 
            this.tbxFilter.Location = new System.Drawing.Point(431, 65);
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.Size = new System.Drawing.Size(268, 23);
            this.tbxFilter.TabIndex = 5;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(841, 56);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 39);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // HomeNewsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 450);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tbxFilter);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDeleteNews);
            this.Controls.Add(this.btnEditNews);
            this.Controls.Add(this.bntAddNews);
            this.Controls.Add(this.dgvNews);
            this.Name = "HomeNewsForm";
            this.Text = "HomeNewsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HomeNewsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNews)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvNews;
        private Button bntAddNews;
        private Button btnEditNews;
        private Button btnDeleteNews;
        private Button btnSearch;
        private TextBox tbxFilter;
        private Button btnRefresh;
    }
}