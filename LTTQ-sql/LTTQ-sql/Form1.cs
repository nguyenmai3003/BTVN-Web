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

namespace LTTQ_sql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // b1: lấy chuỗi kết nối 
            string connectionString = "Data Source=DESKTOP-7Q9EJ6A;Initial Catalog=QLVLXD;Integrated Security=True";

            // b2: mở kết nối 
            SqlConnection connection = new SqlConnection(connectionString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            // b3: tạo lệnh sql
            string sqlSelect = "select * from tblChatLieu";

            // b4: thực thi lệnh sql
            SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connection);
            DataTable dtCL = new DataTable();
            adapter.Fill(dtCL);
            dgvChatLieu.DataSource = dtCL;

            // b5: đóng kết nối
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
                adapter.Dispose();
                dtCL.Dispose();
            }
            //dinh dang cho datagridbview
            dgvChatLieu.BackgroundColor=Color.Yellow;
            dgvChatLieu.AutoResizeColumns();
            dgvChatLieu.Columns[0].HeaderText = " mã CL";
            dgvChatLieu.Columns[1].HeaderText = " tên CL";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}