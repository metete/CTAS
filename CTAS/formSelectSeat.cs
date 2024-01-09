using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTAS
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=CTAS;Integrated Security=True;Encrypt=False";
        int a;

        public Form1(string seats, int id)
        {
            InitializeComponent();
            int i = 0;
            this.Text = id.ToString();
            a = Convert.ToInt32(this.Text);
            char[] s = new char[50];
            s = seats.ToCharArray();
            foreach (var b in gboxSeats.Controls.OfType<Button>())
            {
                b.Text = (i).ToString();
                if (s[i] == '1')
                {
                    b.Enabled = false;
                    b.BackColor = Color.Red;
                }
                else
                {
                    b.BackColor = Color.Green;
                }
                i++;
            }
        }


        private void button45_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to select seat number " + (sender as Button).Text + "?", "asd", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {



                MessageBox.Show("You selected seat number " + (sender as Button).Text);

                string query = "SELECT seats FROM Movies WHERE id = " + a.ToString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            string cellValue = result.ToString();


                            char[] seats = cellValue.ToCharArray();
                            seats[Convert.ToInt32((sender as Button).Text)] = '1';
                            string newSeats = seats.ToString();

                            string updateQuery = "UPDATE Movies SET seats = " +  newSeats +" WHERE id = " + a.ToString();


                            using (SqlConnection connec = new SqlConnection(connectionString))
                            {
                                connec.Open();

                                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connec))
                                {
                                    updateCommand.Parameters.AddWithValue("@newSeats", "newSeats"); 
                                    int rowsAffected = updateCommand.ExecuteNonQuery();
                                }
                            }



                        }
                        else
                        {
                            Console.WriteLine("No data found.");
                        }
                    }
                }


                /*SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                int id = Convert.ToInt32(a);

                string q = "select seats from Movies where id = " + id.ToString();

                SqlCommand cmd = new SqlCommand(q, connection);
                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    char seats = new char[50]; 
                    seats = (r["seats"] as string).ToCharArray;
                    string newSeats; 
                    q = "update Movies set seats = " + (r["seats"] as string) + "where id = " + id.ToString();
                    
                    
                    cmd = new SqlCommand(q, connection);
                }
                
                connection.Close();
            }*/
            }
        }
    }
}
