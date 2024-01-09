using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace CTAS
{
    public partial class formAddMovie : Form
    {
        public formAddMovie()
        {
            InitializeComponent();
        }

        public string conString = "Data Source=localhost;Initial Catalog=CTAS;Integrated Security=True;Encrypt=False";

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            if(conn.State==System.Data.ConnectionState.Open)
            {
                string q = "insert into test(ID,Name)values('"+tboxID.Text.ToString()+"','"+ tboxName.Text.ToString()+"')"; 
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Connection Made Successfully");
            }
            conn.Close();
        }

        private void btnAddMovieToTheDatabase_Click(object sender, EventArgs e)
        {
            Movie mov = new Movie();
            mov.title = tboxMovieTitle.Text.ToString();
            mov.genre = comboboxMovieGenre.Text.ToString();
            mov.duration = comboboxDurationHours.Text.ToString()+ ":" +comboboxDurationMinutes.Text.ToString();
            DateTime dt = Convert.ToDateTime(dtpMovieDatePicker.Value);
            mov.visionDate = dt.Day.ToString()+"/"+dt.Month.ToString()+"/"+dt.Year.ToString();
            mov.saloon = comboboxSaloon.Text.ToString();
            mov.session = comboboxSessionHour.Text.ToString()+":"+comboboxSessionMinutes.Text.ToString();
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                string q = "insert into Movies(title,genre,duration,visionDate,saloon,session,seats)values('"+ mov.title + "','" +mov.genre + "','" + mov.duration + "','" + mov.visionDate + "','" + mov.saloon + "','" + mov.session +"','" + mov.seats + "')";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
