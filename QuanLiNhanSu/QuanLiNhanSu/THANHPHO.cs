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
    public partial class THANHPHO : Form
    {
        ConnectDB conn = new ConnectDB();
        bool themmoi;
        public THANHPHO()
        {
            InitializeComponent();
        }
        void KhoaDieuKhien()
        {
            txtMa.Enabled = false;
            txtTen.Enabled = false;
            cmbTinh.Enabled = false;

            bntThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThoat.Enabled = true;
        }
        void MoDieuKhien()
        {
            txtMa.Enabled = true;
            txtTen.Enabled = true;
            cmbTinh.Enabled = true;

            bntThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThoat.Enabled = true;
        }
        void setNull()
        {
            txtMa.Text = "Mã quận, huyện";
            txtTen.Text = "Tên quận, huyện";
            cmbTinh.Text = "Tên tỉnh";
        }
        private void loadDaTa()
        {
            string sql = "select a.IDThanhPho,a.TenThanhPho,b.TenTinh from ThanhPho a left join Tinh b on a.IDTinh=b.IDTinh ";
            dgvThanhPho.DataSource = conn.GetDataTable(sql);
        }

        private void dgvTinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    txtMa.Text = Convert.ToString(dgvThanhPho.CurrentRow.Cells[1].Value);
                    txtTen.Text = Convert.ToString(dgvThanhPho.CurrentRow.Cells[2].Value);
                    cmbTinh.Text = Convert.ToString(dgvThanhPho.CurrentRow.Cells[3].Value);
                }
            }
            catch
            {
                MessageBox.Show("lỗi không tải dữ liệu lên được!");
            }
        }
        private void showTinh()
        {
            string sql = "select * from Tinh";
            cmbTinh.DataSource = conn.GetDataTable(sql);
            cmbTinh.ValueMember = "IDTinh";
            cmbTinh.DisplayMember = "TenTinh";
        }
        private void THANHPHO_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            loadDaTa();
            showTinh();
            setNull();
        }

        private void dgvThanhPho_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvThanhPho.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1; 
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            setNull();
        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            MoDieuKhien();
            setNull();
            txtMa.Enabled = false;
            txtTen.Text = "";
            cmbTinh.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            MoDieuKhien();
            txtMa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (themmoi == true)
            {
                conn.OpenDB();
                int count = 0;
                try
                {
                    SqlCommand cmd = new SqlCommand("thanhPho_them", ConnectDB.connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@ten", Convert.ToString(txtTen.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@tinh", Convert.ToString(cmbTinh.SelectedValue));
                    cmd.Parameters.Add(p);
                    count = cmd.ExecuteNonQuery();
                }
                catch
                {
                    count = -1;
                }
                if (count > 0)
                {
                    MessageBox.Show("thêm mới thành công!");
                    loadDaTa();
                    KhoaDieuKhien();
                    setNull();
                }
                else
                    MessageBox.Show("lỗi không thêm được!");
                conn.CloseDB();
            }
            else
            {
                conn.OpenDB();
                int count = 0;
                try
                {

                    SqlCommand cmd = new SqlCommand("thanhPho_sua", ConnectDB.connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@ma", Convert.ToString(txtMa.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@ten", Convert.ToString(txtTen.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@tinh", Convert.ToString(cmbTinh.SelectedValue));
                    cmd.Parameters.Add(p);
                    count = cmd.ExecuteNonQuery();

                }
                catch
                {
                    count = -1;
                }
                if (count > 0)
                {
                    MessageBox.Show("sửa thành công!");
                    loadDaTa();
                    KhoaDieuKhien();
                    setNull();
                }
                else
                    MessageBox.Show("sửa không thành công!");
                conn.CloseDB();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.OpenDB();
            int count = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("thanhPho_xoa", ConnectDB.connect);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@ma", Convert.ToString(txtMa.Text));
                cmd.Parameters.Add(p);
                count = cmd.ExecuteNonQuery();
            }
            catch
            {
                count = -1;
            }
            if (count > 0)
            {
                MessageBox.Show("xóa thành công!");
                loadDaTa();
                KhoaDieuKhien();
                setNull();
            }
            else
                MessageBox.Show("xóa không thành công!");
            conn.CloseDB();
        }
    }
}
