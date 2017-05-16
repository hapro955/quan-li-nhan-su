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
    public partial class NHANVIENVADUAN : Form
    {
        ConnectDB conn = new ConnectDB();
        bool themmoi;
        public NHANVIENVADUAN()
        {
            InitializeComponent();
        }
        void KhoaDieuKhien()
        {
            txtSoGioLam.Enabled = false;
            txtTenDuAn.Enabled = false;
            txtTenNhanVien.Enabled = false;
            txtMaChiTiet.Enabled = false;
            dtpNgayThamGia.Enabled = false;
            cmbDuAn.Enabled = false;
            cmbMaNhanVien.Enabled = false;

            bntThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThoat.Enabled = true;
        }
        void MoDieuKhien()
        {
            txtSoGioLam.Enabled = true;
            txtTenDuAn.Enabled = true;
            txtTenNhanVien.Enabled = true;
            txtMaChiTiet.Enabled = true;
            dtpNgayThamGia.Enabled = true;
            cmbDuAn.Enabled = true;
            cmbMaNhanVien.Enabled = true;

            bntThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThoat.Enabled = true;
        }
        void setNull()
        {
            txtSoGioLam.Text = "Số giờ làm";
            txtTenDuAn.Text = "Tên dự án"; 
            txtTenNhanVien.Text = "Tên nhân viên"; 
            txtMaChiTiet.Text = "Mã chi tiết"; 
            cmbDuAn.Text = "Mã dự án"; 
            cmbMaNhanVien.Text = "Mã nhân viên";
        }
        private void showNhanVien()
        {
            string sql = "select * from NhanVien";
            cmbMaNhanVien.DataSource = conn.GetDataTable(sql);
            cmbMaNhanVien.ValueMember = "IDNhanVien";
            cmbMaNhanVien.DisplayMember = "IDNhanVien";
        }
        private void showDuAn()
        {
            string sql = "select * from DuAn";
            cmbDuAn.DataSource = conn.GetDataTable(sql);
            cmbDuAn.ValueMember = "IDDuAn";
            cmbDuAn.DisplayMember = "IDDuAn";
        }
        private void loadDaTa()
        {
            string sql = "select a.IDChiTiet,a.IDNhanVien,a.IDDuAn,b.HoTen,c.TenDuAn,a.NgayThamGia,a.SoGioLam from NhanVienVaDuAn a inner join NhanVien b on a.IDNhanVien = b.IDNhanVien inner join DuAn c on a.IDDuAn = c.IDDuAn";
            dgvChiTietDuAn.DataSource = conn.GetDataTable(sql);
        }

        private void NHANVIENVADUAN_Load(object sender, EventArgs e)
        {
            showDuAn();
            showNhanVien();
            loadDaTa();
            KhoaDieuKhien();
            setNull();
        }

        private void dgvChiTietDuAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    txtMaChiTiet.Text = Convert.ToString(dgvChiTietDuAn.CurrentRow.Cells[1].Value);
                    cmbMaNhanVien.Text = Convert.ToString(dgvChiTietDuAn.CurrentRow.Cells[2].Value);
                    cmbDuAn.Text = Convert.ToString(dgvChiTietDuAn.CurrentRow.Cells[3].Value);
                    txtTenNhanVien.Text = Convert.ToString(dgvChiTietDuAn.CurrentRow.Cells[4].Value);
                    txtTenDuAn.Text = Convert.ToString(dgvChiTietDuAn.CurrentRow.Cells[5].Value);
                    dtpNgayThamGia.Text = Convert.ToString(dgvChiTietDuAn.CurrentRow.Cells[6].Value);
                    txtSoGioLam.Text = Convert.ToString(dgvChiTietDuAn.CurrentRow.Cells[7].Value);
                }
            }
            catch
            {
                MessageBox.Show("lỗi không tải dữ liệu lên được!");
            }
        }

        private void dgvChiTietDuAn_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvChiTietDuAn.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1; 
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
            txtMaChiTiet.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            MoDieuKhien();
            cmbMaNhanVien.Enabled = false;
            cmbDuAn.Enabled = false;
            txtMaChiTiet.Enabled = false;
            txtTenDuAn.Enabled = false;
            txtTenNhanVien.Enabled = false;
            txtSoGioLam.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (themmoi == true)
            {
                conn.OpenDB();
                int count = 0;
                try
                {
                    SqlCommand cmd = new SqlCommand("nhanVienVaDuAn_them", ConnectDB.connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@manv", Convert.ToString(cmbMaNhanVien.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@mada", Convert.ToString(cmbDuAn.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@ngaytg", Convert.ToString(dtpNgayThamGia.Value));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@giolam", Convert.ToString(txtSoGioLam.Text));
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

                    SqlCommand cmd = new SqlCommand("nhanVienVaDuAn_sua", ConnectDB.connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@mact", Convert.ToString(txtMaChiTiet.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@ngaytg", Convert.ToString(dtpNgayThamGia.Value));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@giolam", Convert.ToString(txtSoGioLam.Text));
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
                SqlCommand cmd = new SqlCommand("nhanVienVaDuAn_xoa", ConnectDB.connect);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@mact", Convert.ToString(txtMaChiTiet.Text));
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
