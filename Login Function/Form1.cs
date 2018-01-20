using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Function
{
    public partial class Form1 : Form
    {
        List<string> registerinfo = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void userNameLbl_Click(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string user =userNameTextBox.Text;
            string pass = passwordTextBox.Text;
            Login login = new Login(user, pass);
            login.CheckLogin();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            registerinfo.Add(userNameTextBox.Text);
            registerinfo.Add(passwordTextBox.Text);
            Login login = new Login(registerinfo);
            login.CheckRegister();
            

        }
    }
}
