using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace BTH5_Bai4
{
    public partial class Form1 : Form
    {
        SqlConnection sc = null;
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            string stn = "Server = .; Database = QLBanHang; Integrated Security = true";
            sc = new SqlConnection(stn);
            dgvCategory.DataSource = GetData();
        }

        private void Connect()
        {
           
            try
            {
                if (sc != null && sc.State != ConnectionState.Open)
                    sc.Open();

            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Kết nối đã mở hoặc chưa có CSDL" + ex.Message);
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Sai mật khẩu" + ex.Message);
            }

            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show("Trùng tên" + ex.Message);
            }  

        }

        private void DisConnect()
        {
            if (sc != null && sc.State != ConnectionState.Closed)
            {
                sc.Close();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {

            string str = "DELETE FROM LoaiSP WHERE MaLoaiSP = " + txtMaloai.Text;
            SqlCommand cmd = new SqlCommand(str, sc);
            Connect();
            int sodong = cmd.ExecuteNonQuery();
            dgvCategory.DataSource = GetData();
            MessageBox.Show("So dong da xoa : " + sodong.ToString());
            DisConnect();
        }

        private List<object> GetData()
        {
            Connect();
            string sql = "SELECT * FROM LoaiSP";
            List<object> list = new List<object>();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, sc);
                SqlDataReader dr = cmd.ExecuteReader();
                int id;
                string name;
                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                    name = dr.GetString(1);
                    var proid = new
                    {
                        MaLoaiSP = id,
                        TenLoaiSP = name
                    };
                    list.Add(proid);
                }
                dr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Loi");
            }
            finally
            {
                DisConnect();
            }
            return list;
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
