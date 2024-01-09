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

namespace CTAS
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Form f = new formAdmin();
            f.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            Form f = new formUser();
            f.Show();
        }
    }
}
