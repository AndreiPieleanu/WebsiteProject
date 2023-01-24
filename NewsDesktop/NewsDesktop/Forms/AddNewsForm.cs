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
        public AddNewsForm(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            tbxAuthor.Text = Services.LoggedUser.PersonalDetails.ToString();
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

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
