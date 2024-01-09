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
using System.Data.Common;
using System.Reflection;

namespace CTAS
{
    public partial class formAdmin : Form
    {
        public formAdmin()
        {
            InitializeComponent();
        }
       
        private List<T> GetList<T>(IDataReader reader){
            List<T> list = new List<T>();
            while (reader.Read())
            {
                var type = typeof(T);
                T obj = (T)Activator.CreateInstance(type);
                foreach(var prop in type.GetProperties())
                {
                    var propType = prop.PropertyType; 
                    prop.SetValue(obj, Convert.ChangeType(reader[prop.Name].ToString(),propType));
                }
                list.Add(obj);
            }
            return list;
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            Form f = new formAddMovie();
            f.Show();
        }
        string connectionString = "Data Source=localhost;Initial Catalog=CTAS;Integrated Security=True;Encrypt=False";
        private void btnListMovies_Click(object sender, EventArgs e)
        {

        }

        public void FillDataGridView(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string q = "SELECT id AS ID,title as Title,genre as Genre,visionDate as ScreeningDate,duration as Duration,saloon as Saloon,session as Session from Movies";
            SqlDataAdapter da = new SqlDataAdapter(q, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvMovies.DataSource = dt;
            connection.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                int id = Convert.ToInt32(dgvMovies.CurrentRow.Cells[0].Value);
                string q = "delete from Movies where id = " + id + " ";
                SqlCommand cmd = new SqlCommand(q, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }catch (Exception ex) { }
            FillDataGridView(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
            Form f =new formAddMovie();
            f.Show();
            FillDataGridView(sender, e);
        }

        private void dgvMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
