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
        public SqlConnection sqlConnection = new SqlConnection(@"Data Source=Ankit_Gupta\SQLEXPRESS;Initial Catalog=file;Integrated Security=True");
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
            int x, y, z;
            string a, b;
            a = textBox1.Text;
            b = textBox2.Text;
            if (b == "")
            {
                MessageBox.Show("please enter valid number in 'Top List' space  ", "Error");
            }
            else if(a == "")
            {
                MessageBox.Show("please enter year between 1944 and 2013", "Error");
            }
            else
            {
                x = int.Parse(a);
                y = int.Parse(b);
                if (x < 1944 || x > 2013 )
                {
                    MessageBox.Show("please enter year between 1944 and 2013", "Error");
                }

                else
                {

                    if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
                    {
                        MessageBox.Show("please select male , female or both", "Error");
                    }


                    else
                    {

                        if (radioButton3.Checked == true)
                        {
                            SqlCommand sqlComman = new SqlCommand();
                            sqlComman.Connection = sqlConnection;
                            sqlConnection.Open();
                            sqlComman.CommandText = "SELECT count(*) FROM  merg where Year ='" + textBox1.Text + "'  ";
                            sqlComman.ExecuteNonQuery();
                            z = Convert.ToInt32(sqlComman.ExecuteScalar().ToString());
                            sqlConnection.Close();


                            if (y > z)
                            {
                                MessageBox.Show("please enter valid number in 'Top List' space  ", "Error");
                            }
                            else
                            {
                                SqlCommand sqlCommand = new SqlCommand();
                                sqlCommand.Connection = sqlConnection;
                                sqlConnection.Open();
                                sqlCommand.CommandText = "select top " + textBox2.Text + " [Given Name],Amount,Position,Gender  from merg where Year='" + textBox1.Text + "' order by CAST(Amount as int) desc; ";
                                sqlCommand.ExecuteNonQuery();
                                sqlConnection.Close();
                                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                dataGridView1.DataSource = dt;
                            }
                        }

                        else if (radioButton1.Checked)
                        {
                            SqlCommand sqlComman = new SqlCommand();
                            sqlComman.Connection = sqlConnection;
                            sqlConnection.Open();
                            sqlComman.CommandText = "SELECT count(*) FROM fem where Year ='" + textBox1.Text + "'  ";
                            sqlComman.ExecuteNonQuery();
                            z = Convert.ToInt32(sqlComman.ExecuteScalar().ToString());
                            sqlConnection.Close();


                            if (y > z)
                            {
                                MessageBox.Show("please enter valid number in 'Top List' space  ", "Error");
                            }
                            else
                            {
                                SqlCommand sqlCommand = new SqlCommand();
                                sqlCommand.Connection = sqlConnection;
                                sqlConnection.Open();
                                sqlCommand.CommandText = "SELECT top " + textBox2.Text + " [Given Name],Amount,Position  FROM malef where Year='" + textBox1.Text + "' order by CAST(Amount as int) desc;  ";
                                sqlCommand.ExecuteNonQuery();
                                sqlConnection.Close();
                                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                dataGridView1.DataSource = dt;
                            }
                        }
                        else if (radioButton2.Checked)
                        {
                            SqlCommand sqlComman = new SqlCommand();
                            sqlComman.Connection = sqlConnection;
                            sqlConnection.Open();
                            sqlComman.CommandText = "SELECT count(*) FROM malef where Year ='" + textBox1.Text + "' ";
                            sqlComman.ExecuteNonQuery();
                            z = Convert.ToInt32(sqlComman.ExecuteScalar().ToString());
                            sqlConnection.Close();


                            if (y > z)
                            {
                                MessageBox.Show("please enter valid number in 'Top List' space  ", "Error");
                            }
                            else
                            {
                                SqlCommand sqlCommand = new SqlCommand();
                                sqlCommand.Connection = sqlConnection;
                                sqlConnection.Open();
                                sqlCommand.CommandText = "SELECT top " + textBox2.Text + " [Given Name],Amount,Position  FROM fem where Year='" + textBox1.Text + "' order by CAST(Amount as int) desc; ";
                                sqlCommand.ExecuteNonQuery();
                                sqlConnection.Close();
                                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                dataGridView1.DataSource = dt;
                            }
                        }
                    }
                }
            }
            int i;
            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                }
                else
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = sqlConnection;
            sqlConnection.Open();
            cmd1.CommandText = "select distinct [Year] from merg";
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
        }
    }
}
