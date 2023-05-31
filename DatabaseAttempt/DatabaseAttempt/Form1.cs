using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Linq.Expressions;

namespace DatabaseAttempt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.con.Open();
                OleDbCommand command = new OleDbCommand("INSERT INTO Student_Info([StudentID], [FirstName], [MiddleName], [LastName], [Gender], [Age], [BirthDate])VALUES (?,?,?,?,?,?,?)", Connection.con);
                command.Parameters.AddWithValue("@StudentID", textBox1.Text);
                command.Parameters.AddWithValue("@FirstName", textBox2.Text);
                command.Parameters.AddWithValue("@MiddleName", textBox3.Text);
                command.Parameters.AddWithValue("@LastName", textBox4.Text);
                command.Parameters.AddWithValue("@Gender", textBox5.Text);
                command.Parameters.AddWithValue("@Age", textBox6.Text);
                command.Parameters.AddWithValue("@BirthDate", textBox7.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error." + ex.Message);
            }
            finally
            {
                Connection.con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.con.Open();
                string update = "UPDATE student_info SET FirstName=@FirstName, MiddleName=@MiddleName, LastName=@LastName, Gender=@Gender, Age=@Age, BirthDate=@BirthDate WHERE StudentID=@StudentID";
                OleDbCommand command = new OleDbCommand(update, Connection.con);
                command.Parameters.AddWithValue("@FirstName", textBox2.Text);
                command.Parameters.AddWithValue("@MiddleName", textBox3.Text);
                command.Parameters.AddWithValue("@LastName", textBox4.Text);
                command.Parameters.AddWithValue("@Gender", textBox5.Text);
                command.Parameters.AddWithValue("@Age", textBox6.Text);
                command.Parameters.AddWithValue("@BirthDate", textBox7.Text);
                command.Parameters.AddWithValue("@StudentID", textBox1.Text);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record updated successfully.");
                }
                else
                {
                    MessageBox.Show("No record found with StudentID " + textBox1.Text + ".");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            finally
            {
                Connection.con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {


                Connection.con.Open();
                string delete = "DELETE FROM student_info WHERE StudentID=@StudentID";
                OleDbCommand command = new OleDbCommand(delete, Connection.con);
                command.Parameters.AddWithValue("@StudentID", textBox1.Text);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record deleted successfully.");
                }
                else
                {
                    MessageBox.Show("No record dound with StudentID" + textBox1.Text + ".");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error." + ex.Message);
            }
            finally
            {
                Connection.con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.con.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM Student_Info", Connection.con);
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error." + ex.Message);
            }
            finally
            {
                Connection.con.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sampleDBDataSet.Student_Info' table. You can move, or remove it, as needed.
            this.student_InfoTableAdapter.Fill(this.sampleDBDataSet.Student_Info);

        }
    }
}
