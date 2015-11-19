using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace start
{
    public partial class Form3 : Form
    {
        public SqlConnection sqlConnection = new SqlConnection("Data Source=Ankit_Gupta(SQLEXPRESS);Initial Catalog=file;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 b3 = new Form1();
            b3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
