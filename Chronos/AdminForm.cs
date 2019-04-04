using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chronos
{
    public partial class AdminForm : Form
    {
        private readonly HttpClient myClient = new HttpClient();
        private Login mainForm;
        public AdminForm(Login form)
        {
            InitializeComponent();
            mainForm = form;
            fillGrid();
        }

        private async void fillGrid()
        {
            try
            {
                dataGridView1.DataSource = JsonConvert.DeserializeObject<DataTable>(await myClient.GetStringAsync("http://localhost:3000/users")); 
            }
            catch
            {
                MessageBox.Show("Server failed mid-time");
            }
            //dataGridView1.DataSource = ds;
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.ResetCredentials();
            mainForm.Show();
        }
    }
}
