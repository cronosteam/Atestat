using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chronos
{
    public partial class UserForm : Form
    {
        private Login mainForm;
        public UserForm(Login form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.ResetCredentials();
            mainForm.Show();
        }
    }
}
