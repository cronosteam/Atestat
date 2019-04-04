using System;
using System.Net.Http;
using System.Windows.Forms;

namespace Chronos
{
    public partial class Login : Form
    {
        private readonly HttpClient myClient = new HttpClient();
        public Login()
        {
            InitializeComponent();
            textBox1.Text = "Username";
            textBox2.Text = "Password";
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";
            }
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if(textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.PasswordChar = '*';
            }
        }

        public void ResetCredentials()
        {
            textBox1.Text = "Username";
            textBox2.PasswordChar = '\0' ;
            textBox2.Text = "Password";
        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == string.Empty) {
                MessageBox.Show("Enter user name, please");
            }
            else if(textBox2.Text == string.Empty)
            {
                MessageBox.Show("Enter a password, please");
            }
            else
            {
                string res;
                try
                {
                    res = await myClient.GetStringAsync("http://localhost:3000/login?name=" + textBox1.Text + "&password=" + textBox2.Text);
                    if(Int32.Parse(res) >= 0)
                    {
                        this.Hide();
                        if(res == "0")
                        {
                            UserForm usr = new UserForm(this);
                            usr.Show();
                        }
                        else
                        {
                            AdminForm admin = new AdminForm(this);
                            admin.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong username or password.");
                    }
                }
                catch
                {
                    MessageBox.Show("Server is down...");
                }
            }
        }
    }
}
