using LogicLayer.Interfaces;
using LogicLayer.Models.News;
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
    public partial class HomeNewsForm : Form
    {
        private Form previousForm;
        private NewsCatalogue _newsCatalogue;
        private INews _selectedNews = null;
        public HomeNewsForm(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
            FillDgv();
        }
        private void FillDgv()
        {
            try
            {
                _newsCatalogue = Services.NewsService.GetNewsCatalogue();
                dgvNews.DataSource = _newsCatalogue.AllNews.Values.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void HomeNewsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logout(e);
        }
        private void Logout(FormClosingEventArgs e)
        {
            var window = MessageBox.Show(
                "LogOut?", "LogOut", MessageBoxButtons.OKCancel);

            if (window == DialogResult.OK)
            {
                previousForm.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillDgv();
        }

        private void bntAddNews_Click(object sender, EventArgs e)
        {
            AddNewsForm addNewsForm = new AddNewsForm(this, _newsCatalogue);
            Hide();
            addNewsForm.Show();
        }

        private void btnEditNews_Click(object sender, EventArgs e)
        {
            if (dgvNews.SelectedCells.Count > 0)
            {

            }
            else
            {
                MessageBox.Show("Select a row to edit!");
            }
        }

        private void btnDeleteNews_Click(object sender, EventArgs e)
        {
            if (dgvNews.SelectedCells.Count > 0) 
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this news?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        Services.NewsService.RemoveNewsFromCatalogue(_selectedNews, _newsCatalogue);
                        MessageBox.Show("News has been successfully removed from the catalogue!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    FillDgv();
                }
            }
            else
            {
                MessageBox.Show("Select a row to delete!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                List<INews> searchedNews = _newsCatalogue.GetAllNewsWhichContainText(tbxFilter.Text);
                if(searchedNews.Count > 0)
                {
                    dgvNews.DataSource = searchedNews;
                }
                else
                {
                    MessageBox.Show("No results found! Adjust your filters!");
                    FillDgv();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewNews_Click(object sender, EventArgs e)
        {

        }

        private void dgvNews_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNews.SelectedCells.Count > 0)
            {
                int rowId = dgvNews.SelectedCells[0].RowIndex;
                _selectedNews = _newsCatalogue.AllNews.Values.ToList()[rowId];
            }
        }
    }
}
