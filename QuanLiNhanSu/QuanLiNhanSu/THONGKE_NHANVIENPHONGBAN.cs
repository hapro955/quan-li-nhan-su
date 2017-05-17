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
    public partial class THONGKE_NHANVIENPHONGBAN : Form
    {
        ConnectDB conn = new ConnectDB();
        public THONGKE_NHANVIENPHONGBAN()
        {
            InitializeComponent();
        }
        private void showPhongBan()
        {
            string sql = "select * from PhongBan";
            cmbPhongBan.DataSource = conn.GetDataTable(sql);
            cmbPhongBan.ValueMember = "IDPhongBan";
            cmbPhongBan.DisplayMember = "TenPhongBan";
        }
        void setNull()
        {
            cmbPhongBan.Text = "Tên Phòng Ban";
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvThongKe_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvThongKe.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void THONGKE_NHANVIENPHONGBAN_Load(object sender, EventArgs e)
        {
            showPhongBan();
            setNull();
        }
        private void ThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                conn.OpenDB();
                SqlCommand cmd = new SqlCommand("ThongKeNhanVien", ConnectDB.connect);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@mapb", Convert.ToString(cmbPhongBan.SelectedValue));
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

    
    }
}
