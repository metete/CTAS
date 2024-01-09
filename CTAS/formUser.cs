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
    public partial class formUser : Form
    {
        public formUser()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=localhost;Initial Catalog=CTAS;Integrated Security=True;Encrypt=False";

        private void btnListMovies_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string q = "SELECT id AS ID,title as Title,genre as Genre,visionDate as VisionDate,duration as Duration,saloon as Saloon,session as Session from Movies";
            SqlDataAdapter da = new SqlDataAdapter(q, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvMovies.DataSource = dt;
            connection.Close();
        }

        private void btnBuyTicket_Click(object sender, EventArgs e)
        {
           
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                int id = Convert.ToInt32(dgvMovies.CurrentRow.Cells[0].Value);
                string q = "select Seats from Movies where id = " + id + " ";
                SqlCommand cmd = new SqlCommand(q, connection);
                string seats = "";

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    seats = reader.GetString(0);
                }
                Form f = new Form1(seats,id);
                f.Show();

                connection.Close();
        }
    }
}
