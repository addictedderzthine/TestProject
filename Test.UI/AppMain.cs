#region region

using System;
using System.Windows.Forms;
using Test.Business;

#endregion

namespace TestProject.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonExit.Click += (sender, e) => Close();
            buttonLogin.Click += ButtonLogin_Click;
        }

        private string UserName
        {
            get => textBoxUserName.Text;
            set => textBoxUserName.Text = value;
        }

        private string Password
        {
            get => textBoxPassword.Text;
            set => textBoxPassword.Text = value;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UserLogin login = new UserLogin(UserName, Password);
                login.DoLogin();
                MessageBox.Show("Success");
                ShowProductUi();
            }
            catch (InvalidLoginException exception)
            {
                MessageBox.Show(exception.Message);
                //TODO: add logging if needed

            }
           
        }

        private static void ShowProductUi()
        {
            using (Products products = new Products())
            {
                products.ShowDialog();
            }
        }
    }
}
