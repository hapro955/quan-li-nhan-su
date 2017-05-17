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
namespace QuanLiNhanSu
{
    public partial class THONGKE_NHANVIENDUAN : Form
    {
        ConnectDB conn = new ConnectDB();
        public THONGKE_NHANVIENDUAN()
        {
            InitializeComponent();
        }
        private void showDuAn()
        {
            string sql = "select * from DuAn";
            cmbPhongBan.DataSource = conn.GetDataTable(sql);
            cmbPhongBan.ValueMember = "IDDuAn";
            cmbPhongBan.DisplayMember = "TenDuAn";
        }
        void setNull()
        {
            cmbPhongBan.Text = "Tên dự án";
        }
        private void THONGKE_NHANVIENDUAN_Load(object sender, EventArgs e)
        {
            showDuAn();
            setNull();
        }

        private void dgvThongKe_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvThongKe.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void ThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                conn.OpenDB();
                SqlCommand cmd = new SqlCommand("ThongKeNhanVien1", ConnectDB.connect);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@mada", Convert.ToString(cmbPhongBan.SelectedValue));
                cmd.Parameters.Add(p);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvThongKe.DataSource = dt;
                conn.CloseDB();
            }
            catch
            {
                MessageBox.Show("lỗi, không hiển thị được dữ liệu!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
