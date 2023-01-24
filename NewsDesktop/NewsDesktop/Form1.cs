using LogicLayer.Interfaces;
using NewsDesktop.Forms;

namespace NewsDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAndreiDebug_Click(object sender, EventArgs e)
        {
            tbxEmail.Text = "andrei@gmail.com";
            tbxPassword.Text = "andrei";
        }

        private void btnDanielDebug_Click(object sender, EventArgs e)
        {
            tbxEmail.Text = "daniel@gmail.com";
            tbxPassword.Text = "daniel";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                IUser loggedUser = Services.UserService.GetUser(tbxEmail.Text, tbxPassword.Text);
                Services.LoggedUser = loggedUser;
                HomeNewsForm form = new HomeNewsForm(this);
                Hide();
                form.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}