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
    public partial class NHANVIENVACHUCVU : Form
    {
        ConnectDB conn = new ConnectDB();
        bool themmoi;
        public NHANVIENVACHUCVU()
        {
            InitializeComponent();
        }
        void KhoaDieuKhien()
        {
            txtTenChucVu.Enabled = false;
            txtTenNhanVien.Enabled = false;
            cmbMaChucVu.Enabled = false;
            cmbMaNhanVien.Enabled = false;
            dtpNgayNhanChuc.Enabled = false;
            txtMaChiTiet.Enabled = false;
            
            bntThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThoat.Enabled = true;
        }
        void MoDieuKhien()
        {
            txtTenChucVu.Enabled = true;
            txtTenNhanVien.Enabled = true;
            cmbMaChucVu.Enabled = true;
            cmbMaNhanVien.Enabled = true;
            dtpNgayNhanChuc.Enabled = true;
            txtMaChiTiet.Enabled = false;

            bntThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThoat.Enabled = true;
        }
        void setNull()
        {
            cmbMaChucVu.Text = "Mã chức vụ";
            cmbMaNhanVien.Text = "Mã nhân viên";
            txtTenChucVu.Text = "Chức vụ";
            txtTenNhanVien.Text = "Tên nhân viên";
            txtMaChiTiet.Text = "Mã chi tiết";
        }
        private void showNhanVien()
        {
            string sql = "select * from NhanVien";
            cmbMaNhanVien.DataSource = conn.GetDataTable(sql);
            cmbMaNhanVien.ValueMember = "IDNhanVien";
            cmbMaNhanVien.DisplayMember = "IDNhanVien";
        }
        private void showChucVu()
        {
            string sql = "select * from ChucVu";
            cmbMaChucVu.DataSource = conn.GetDataTable(sql);
            cmbMaChucVu.ValueMember = "IDChucVu";
            cmbMaChucVu.DisplayMember = "IDChucVu";
        }
        private void loadDaTa()
        {
            string sql = "select a.IDChiTiet,a.IDNhanVien,a.IDChucVu,b.HoTen,c.TenChucVu,a.NgayNhanChuc from NhanVienVaChucVu a inner join NhanVien b on a.IDNhanVien = b.IDNhanVien inner join ChucVu c on a.IDChucVu = c.IDChucVu";
            dgvChiTietChucVu.DataSource = conn.GetDataTable(sql);
        }
        private void NHANVIENVACHUCVU_Load(object sender, EventArgs e)
        {
            showChucVu();
            showNhanVien();
            loadDaTa();
            KhoaDieuKhien();
            setNull();
        }

        private void dgvChiTietChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    txtMaChiTiet.Text = Convert.ToString(dgvChiTietChucVu.CurrentRow.Cells[1].Value);
                    cmbMaNhanVien.Text = Convert.ToString(dgvChiTietChucVu.CurrentRow.Cells[2].Value);
                    cmbMaChucVu.Text = Convert.ToString(dgvChiTietChucVu.CurrentRow.Cells[3].Value);
                    txtTenNhanVien.Text = Convert.ToString(dgvChiTietChucVu.CurrentRow.Cells[4].Value);
                    txtTenChucVu.Text = Convert.ToString(dgvChiTietChucVu.CurrentRow.Cells[5].Value);
                    dtpNgayNhanChuc.Text = Convert.ToString(dgvChiTietChucVu.CurrentRow.Cells[6].Value);      
                }
            }
            catch
            {
                MessageBox.Show("lỗi không tải dữ liệu lên được!");
            }
        }

        private void dgvChiTietChucVu_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvChiTietChucVu.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1; 
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (themmoi == true)
            {
                conn.OpenDB();
                int count = 0;
                try
                {
                    SqlCommand cmd = new SqlCommand("nhanVienVaChucVu_them", ConnectDB.connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@manv", Convert.ToString(cmbMaNhanVien.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@macv", Convert.ToString(cmbMaChucVu.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@ngaync", Convert.ToString(dtpNgayNhanChuc.Value));
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

                    SqlCommand cmd = new SqlCommand("nhanVienVaChucVu_sua", ConnectDB.connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@mact", Convert.ToString(txtMaChiTiet.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@ngaync", Convert.ToString(dtpNgayNhanChuc.Value));
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            MoDieuKhien();
            cmbMaNhanVien.Enabled = false;
            cmbMaChucVu.Enabled = false;
            txtMaChiTiet.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.OpenDB();
            int count = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("nhanVienVaChucVu_xoa", ConnectDB.connect);
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
