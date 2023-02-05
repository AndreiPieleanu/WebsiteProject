using LogicLayer.Enums;
using LogicLayer.Interfaces;
using LogicLayer.Models.News;
using LogicLayer.Models;
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
    public partial class EditNewsForm : Form
    {
        private Form parentForm;
        private NewsCatalogue _newsCatalogue;
        private List<NewsCategory> newsCategories = new List<NewsCategory>();
        private NewsCategory selectedNewsCategory = NewsCategory.War;
        private INews editableNews;
        private Tuple<string, string> dividedText = new Tuple<string, string>(string.Empty, string.Empty);
        public EditNewsForm(Form parentForm, NewsCatalogue newsCatalogue, INews editableNews)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            _newsCatalogue = newsCatalogue;
            this.editableNews = editableNews;
            dividedText = this.editableNews.BreakTextIn2EqualHalves();
            tbxAuthor.Text = Services.LoggedUser.PersonalDetails.ToString();
            newsCategories = Services.NewsService.GetNewsCategories();
            FillBoxesWithData();
        }
        private void FillBoxesWithData()
        {
            switch (editableNews.NewsType)
            {
                case NewsType.Articles:
                    Article article = (Article)editableNews;
                    FillComboBoxWithCategories(cbxNewsCategory);
                    tbxTitle.Text = article.Title;
                    tbxSubtitle.Text = article.SubTitle;
                    tbxTimeToRead.Text = article.ReadingTime.ToString();
                    foreach(string tag in article.Tags)
                    {
                        lbxTags.Items.Add(tag);
                    }
                    cbxNewsCategory.Text = article.Category.ToString();
                    tbxText1.Text = dividedText.Item1;
                    tbxText2.Text = dividedText.Item2;
                    pbxPicture1.Load(article.Image.ImageLocation);
                    if(article.SecondaryImage is not null)
                    {
                        pbxPicture2.Load(article.SecondaryImage.ImageLocation);
                    }
                    tbcNews.SelectedTab = tbpNormalNews;
                    break;
                case NewsType.BreakingNews:
                    BreakingNews breakingNews = (BreakingNews)editableNews;
                    FillComboBoxWithCategories(cbxNewsCategory2);
                    tbxTitle2.Text = breakingNews.Title;
                    tbxSubtitle2.Text = breakingNews.SubTitle;
                    tbxTimeToRead2.Text = breakingNews.ReadingTime.ToString();
                    foreach (string tag in breakingNews.Tags)
                    {
                        lbxTags2.Items.Add(tag);
                    }
                    cbxNewsCategory2.Text = breakingNews.Category.ToString();
                    tbxText1_2.Text = dividedText.Item1;
                    tbxText2_2.Text = dividedText.Item2;
                    pbxPicture1_2.Load(breakingNews.Image.ImageLocation);
                    if (breakingNews.SecondaryImage is not null)
                    {
                        pbxPicture2_2.Load(breakingNews.SecondaryImage.ImageLocation);
                    }
                    tbcNews.SelectedTab = tbpBreakingNews;
                    break;
                case NewsType.InfoNews:
                    InfoNews infoNews = (InfoNews)editableNews;
                    FillComboBoxWithCategories(cbxNewsCategory3);
                    tbxTitle3.Text = infoNews.Title;
                    tbxSubtitle3.Text = infoNews.SubTitle;
                    tbxTimeToRead3.Text = infoNews.ReadingTime.ToString();
                    foreach (string tag in infoNews.Tags)
                    {
                        lbxTags3.Items.Add(tag);
                    }
                    cbxNewsCategory3.Text = infoNews.Category.ToString();
                    tbxText1_3.Text = dividedText.Item1;
                    tbxText2_3.Text = dividedText.Item2;
                    pbxPicture1_3.Load(infoNews.Image.ImageLocation);
                    tbcNews.SelectedTab = tbpInfoNews;
                    break;
                default:
                    break;
            }
        }
        private void EditNewsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Show();
        }
        private void tbcNews_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (editableNews.NewsType)
            {
                case NewsType.Articles:
                    tbcNews.SelectedTab = tbpNormalNews;
                    break;
                case NewsType.BreakingNews:
                    tbcNews.SelectedTab = tbpBreakingNews;
                    break;
                case NewsType.InfoNews:
                    tbcNews.SelectedTab = tbpInfoNews;
                    break;
                default:
                    break;
            }
        }
        private void SetImageBasedOnPbx(PictureBox pbx)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;*.png;)|*.jpg;*.jpeg;*.png;";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pbx.Image = new Bitmap(opnfd.FileName);
            }
        }

        private void EmptyFieldsTab1()
        {
            tbxTitle.Clear();
            tbxTimeToRead.Clear();
            tbxSubtitle.Clear();
            tbxText1.Clear();
            tbxText2.Clear();
            lbxTags.Items.Clear();
            tbxTag.Clear();
            pbxPicture1.Image = null;
            pbxPicture2.Image = null;
        }
        private void EmptyFieldsTab2()
        {
            tbxTitle2.Clear();
            tbxTimeToRead2.Clear();
            tbxSubtitle2.Clear();
            tbxText1_2.Clear();
            tbxText2_2.Clear();
            lbxTags2.Items.Clear();
            tbxTag2.Clear();
            pbxPicture1_2.Image = null;
            pbxPicture2_2.Image = null;
        }
        private void EmptyFieldsTab3()
        {
            tbxTitle3.Clear();
            tbxTimeToRead3.Clear();
            tbxSubtitle3.Clear();
            tbxText1_3.Clear();
            tbxText2_3.Clear();
            lbxTags3.Items.Clear();
            tbxTag3.Clear();
            pbxPicture1_3.Image = null;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            EmptyFieldsTab1();
        }
        private void btnClear2_Click(object sender, EventArgs e)
        {
            EmptyFieldsTab2();
        }

        private void btnClear3_Click(object sender, EventArgs e)
        {
            EmptyFieldsTab3();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> tags = new List<string>();
                foreach (var item in lbxTags.Items)
                {
                    tags.Add(item.ToString()!);
                }
                INews constructedNews = new Article(editableNews.Id, tbxTitle.Text, tbxSubtitle.Text, Services.LoggedUser, DateTime.Now, selectedNewsCategory, Convert.ToInt32(tbxTimeToRead.Text), tbxText1.Text + tbxText2.Text, new NormalImage(pbxPicture1.Image.Width, pbxPicture1.Image.Height, pbxPicture1.ImageLocation), tags, new NormalImage(pbxPicture2.Image.Width, pbxPicture2.Image.Height, pbxPicture2.ImageLocation));

                Services.NewsService.EditNewsFromCatalogue(constructedNews, _newsCatalogue);
                MessageBox.Show("News has been edited successfully");
                EmptyFieldsTab1();
            }
            catch (FormatException)
            {
                MessageBox.Show("Reading time input is invalid!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAdd2_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> tags = new List<string>();
                foreach (var item in lbxTags2.Items)
                {
                    tags.Add(item.ToString()!);
                }
                INews constructedNews = new BreakingNews(editableNews.Id, tbxTitle.Text, tbxSubtitle.Text, Services.LoggedUser, DateTime.Now, selectedNewsCategory, Convert.ToInt32(tbxTimeToRead.Text), tbxText1.Text + tbxText2.Text, new ThumbnailImage(pbxPicture1.Image.Width, pbxPicture1.Image.Height, pbxPicture1.ImageLocation), tags, new NormalImage(pbxPicture2.Image.Width, pbxPicture2.Image.Height, pbxPicture2.ImageLocation));

                Services.NewsService.EditNewsFromCatalogue(constructedNews, _newsCatalogue);
                MessageBox.Show("News has been edited successfully");
                EmptyFieldsTab2();
            }
            catch (FormatException)
            {
                MessageBox.Show("Reading time input is invalid!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAdd3_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> tags = new List<string>();
                foreach (var item in lbxTags3.Items)
                {
                    tags.Add(item.ToString()!);
                }
                INews constructedNews = new InfoNews(editableNews.Id, tbxTitle.Text, tbxSubtitle.Text, Services.LoggedUser, DateTime.Now, selectedNewsCategory, Convert.ToInt32(tbxTimeToRead.Text), tbxText1.Text + tbxText2.Text, new NormalImage(pbxPicture1.Image.Width, pbxPicture1.Image.Height, pbxPicture1.ImageLocation), tags);

                Services.NewsService.EditNewsFromCatalogue(constructedNews, _newsCatalogue);
                MessageBox.Show("News has been edited successfully");
                EmptyFieldsTab3();
            }
            catch (FormatException)
            {
                MessageBox.Show("Reading time input is invalid!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnPic1_Click(object sender, EventArgs e)
        {
            SetImageBasedOnPbx(pbxPicture1);
        }

        private void btnPic2_Click(object sender, EventArgs e)
        {
            SetImageBasedOnPbx(pbxPicture2);
        }
        private void btnPic1_2_Click(object sender, EventArgs e)
        {
            SetImageBasedOnPbx(pbxPicture1_2);
        }

        private void btnPic2_2_Click(object sender, EventArgs e)
        {
            SetImageBasedOnPbx(pbxPicture2_2);
        }

        private void btnPic1_3_Click(object sender, EventArgs e)
        {
            SetImageBasedOnPbx(pbxPicture1_3);
        }
        private void cbxNewsCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetNewsCategoryFromComboBox(cbxNewsCategory);
        }

        private void cbxNewsCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetNewsCategoryFromComboBox(cbxNewsCategory2);
        }

        private void cbxNewsCategory3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetNewsCategoryFromComboBox(cbxNewsCategory3);
        }
        private void SetNewsCategoryFromComboBox(ComboBox cbx)
        {
            int index = cbx.SelectedIndex;
            if (index > 0)
            {
                selectedNewsCategory = (NewsCategory)index;
            }
        }
        private void FillComboBoxWithCategories(ComboBox cbx)
        {
            cbx.Items.Clear();
            cbx.Items.Add("--Select news category--");
            foreach (NewsCategory category in newsCategories)
            {
                cbx.Items.Add(category);
            }
        }

        private void InserTagToLbxFromTbx(ListBox lbx, TextBox tbx)
        {
            if (!string.IsNullOrEmpty(tbx.Text))
            {
                lbx.Items.Add(tbx.Text);
                tbx.Clear();
            }
            else
            {
                MessageBox.Show("Invalid tag!");
            }
        }
        private void RemoveSelectedIndexFromLbx(ListBox lbx)
        {
            if (lbx.SelectedIndex != -1)
            {
                lbx.Items.RemoveAt(lbx.SelectedIndex);
            }
            else
            {
                MessageBox.Show("No tag selected to be removed!");
            }

        }
        private void btnAddTag_Click(object sender, EventArgs e)
        {
            InserTagToLbxFromTbx(lbxTags, tbxTag);
        }
        private void btnRemoveTag_Click(object sender, EventArgs e)
        {
            RemoveSelectedIndexFromLbx(lbxTags);
        }

        private void btnAddTag2_Click(object sender, EventArgs e)
        {
            InserTagToLbxFromTbx(lbxTags2, tbxTag2);
        }

        private void btnRemoveTag2_Click(object sender, EventArgs e)
        {
            RemoveSelectedIndexFromLbx(lbxTags2);
        }

        private void btnAddTag3_Click(object sender, EventArgs e)
        {
            InserTagToLbxFromTbx(lbxTags3, tbxTag3);
        }

        private void btnRemoveTag3_Click(object sender, EventArgs e)
        {
            RemoveSelectedIndexFromLbx(lbxTags3);
        }
    }
}
