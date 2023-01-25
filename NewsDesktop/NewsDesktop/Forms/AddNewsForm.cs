using FluentValidation.Results;
using LogicLayer.Enums;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using LogicLayer.Models.News;
using LogicLayer.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsDesktop.Forms
{
    public partial class AddNewsForm : Form
    {
        private Form parentForm;
        private NewsCatalogue _newsCatalogue;
        private List<NewsCategory> newsCategories = new List<NewsCategory>();
        private NewsCategory selectedNewsCategory = NewsCategory.War;
        public AddNewsForm(Form parentForm, NewsCatalogue newsCatalogue)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            _newsCatalogue = newsCatalogue;
            tbxAuthor.Text = Services.LoggedUser.PersonalDetails.ToString();
            newsCategories = Services.NewsService.GetNewsCategories();
            cbxNewsCategory.Items.Add("--Select news category--");
            foreach (NewsCategory category in newsCategories)
            {
                cbxNewsCategory.Items.Add(category);
            }
        }

        private void btnPic1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;*.png;)|*.jpg;*.jpeg;*.png;";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pbxPicture1.Image = new Bitmap(opnfd.FileName);
            }
        }

        private void btnPic2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;*.png;)|*.jpg;*.jpeg;*.png;";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pbxPicture2.Image = new Bitmap(opnfd.FileName);
            }
        }
        private void AddNewsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            EmptyFields();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> tags = new List<string>();
                foreach(var item in lbxTags.Items)
                {
                    tags.Add(item.ToString()!);
                }
                INews constructedNews = new Article(tbxTitle.Text, tbxSubtitle.Text, Services.LoggedUser, DateTime.Now, selectedNewsCategory, Convert.ToInt32(tbxTimeToRead.Text), tbxText1.Text + tbxText2.Text, new NormalImage(pbxPicture1.Image.Width, pbxPicture1.Image.Height, pbxPicture1.ImageLocation), tags, new NormalImage(pbxPicture2.Image.Width, pbxPicture2.Image.Height, pbxPicture2.ImageLocation));

                Services.NewsService.AddNewsToCatalogue(constructedNews, _newsCatalogue);
                MessageBox.Show("News has been posted successfully");
                EmptyFields();
            }
            catch (FormatException)
            {
                MessageBox.Show("Reading time input is invalid!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EmptyFields()
        {
            tbxTitle.Clear();
            tbxTimeToRead.Clear();
            tbxAuthor.Clear();
            tbxSubtitle.Clear();
            tbxText1.Clear();
            tbxText2.Clear();
            pbxPicture1.Image = null;
            pbxPicture2.Image = null;
        }

        private void cbxNewsCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbxNewsCategory.SelectedIndex;
            if(index > 0)
            {
                selectedNewsCategory = (NewsCategory)index;
            }
        }
    }
}
