using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace start
{
    public partial class Form2 : Form
    {
        public SqlConnection sqlConnection = new SqlConnection(@"Data Source=Ankit_Gupta\SQLEXPRESS;Initial Catalog=file;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 b2 = new Form1();
            b2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            int i,j;
            string m;
            m = textBox2.Text;
            i = int.Parse(m);
            if (i < 1944 || i > 2013)
            {
                MessageBox.Show("Please Enter Year between 1944 and 2013", "Error");
            }
            else
            {
                if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
                {
                    MessageBox.Show("Please Select Male,Female or Both", "Error");
                }
                else
                {
                    if (radioButton3.Checked)
                    {
                        for (j = i; j <= 2013; j++)
                        {
                            int a, b;
                            string k, n;
                            b = j;
                            k = j.ToString();
                            SqlCommand sqlComman = new SqlCommand();
                            sqlComman.Connection = sqlConnection;
                            sqlConnection.Open();
                            sqlComman.CommandText = "select sum(cast (Amount as int)) from merg where [Given Name]='" + textBox1.Text + "' AND Year='" + k + "';";
                            sqlComman.ExecuteNonQuery();
                            object z = sqlComman.ExecuteScalar();
                            if (z == null || z == DBNull.Value)
                            {
                                a = 0;
                            }
                            else
                            {
                                n = sqlComman.ExecuteScalar().ToString();
                                a = int.Parse(n);
                            }
                            sqlConnection.Close();
                            chart1.Series["Series1"].Points.AddXY(b, a);
                            chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                        }
                    }
                    else if (radioButton1.Checked)
                    {
                        for (j = i; j <= 2013; j++)
                        {
                            int a, b;
                            string k, n;
                            b = j;
                            k = j.ToString();
                            SqlCommand sqlComman = new SqlCommand();
                            sqlComman.Connection = sqlConnection;
                            sqlConnection.Open();
                            sqlComman.CommandText = "SELECT amount FROM malef where [Given Name] = '" + textBox1.Text + "'  AND Year = '" + k + "';";
                            sqlComman.ExecuteNonQuery();
                            object z = sqlComman.ExecuteScalar();
                            if (z == null || z == DBNull.Value)
                            {
                                a = 0;
                            }
                            else
                            {
                                n = sqlComman.ExecuteScalar().ToString();
                                a = int.Parse(n);
                            }
                            sqlConnection.Close();
                            chart1.Series["Series1"].Points.AddXY(b, a);
                            chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        for (j = i; j <= 2013; j++)
                        {
                            int a, b;
                            string k, n;
                            b = j;
                            k = j.ToString();
                            SqlCommand sqlComman = new SqlCommand();
                            sqlComman.Connection = sqlConnection;
                            sqlConnection.Open();
                            sqlComman.CommandText = "SELECT amount FROM fem where [Given Name] = '" + textBox1.Text + "' AND Year = '" + k + "'; ";
                            sqlComman.ExecuteNonQuery();
                            object z = sqlComman.ExecuteScalar();
                            if (z == null || z == DBNull.Value)
                            {
                                a = 0;
                            }
                            else
                            {
                                n = sqlComman.ExecuteScalar().ToString();
                                a = int.Parse(n);
                            }
                            sqlConnection.Close();
                            chart1.Series["Series1"].Points.AddXY(b, a);
                            chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                        }
                    }
                }
            }
        }


        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = sqlConnection;
            sqlConnection.Open();
            cmd1.CommandText = "select distinct [Given Name] from merg";
            cmd1.ExecuteNonQuery();
            SqlDataReader reader = cmd1.ExecuteReader();
            AutoCompleteStringCollection variable = new AutoCompleteStringCollection();
            while (reader.Read())
            {
                variable.Add(reader.GetString(0));
            }
            textBox1.AutoCompleteCustomSource = variable;
            reader.Close();
            sqlConnection.Close();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.CommandText = "select distinct [Year] from merg";
            cmd.ExecuteNonQuery();
            SqlDataReader reader2 = cmd.ExecuteReader();
            AutoCompleteStringCollection variable2 = new AutoCompleteStringCollection();
            while (reader2.Read())
            {
                variable2.Add(reader2.GetString(0));
            }
            textBox2.AutoCompleteCustomSource = variable2;
            reader2.Close();
            sqlConnection.Close();
        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
