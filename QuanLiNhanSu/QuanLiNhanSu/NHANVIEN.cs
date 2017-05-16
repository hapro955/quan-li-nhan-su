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
    public partial class NHANVIEN : Form
    {
        ConnectDB conn = new ConnectDB();
        bool themmoi;
        public NHANVIEN()
        {
            InitializeComponent();
        }
        void KhoaDieuKhien()
        {
            txtGioiTinh.Enabled = false;
            txtHoTen.Enabled = false;
            txtMaNhanVien.Enabled = false;
            txtQueQuan.Enabled = false;
            cmbBangCap.Enabled = false;
            cmbPhongBan.Enabled = false;
            dtpNgaySinh.Enabled = false;
            dtpNgayVaoLam.Enabled = false;

            bntThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThoat.Enabled = true;
        }
        void MoDieuKhien()
        {

            txtGioiTinh.Enabled = true;
            txtHoTen.Enabled = true;
            txtMaNhanVien.Enabled = true;
            txtQueQuan.Enabled = true;
            cmbBangCap.Enabled = true;
            cmbPhongBan.Enabled = true;
            dtpNgaySinh.Enabled = true;
            dtpNgayVaoLam.Enabled = true;

            bntThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThoat.Enabled = true;
        }
        void setNull()
        {
            txtQueQuan.Text = "Quê quán";
            txtMaNhanVien.Text = "Mã nhân viên";
            txtHoTen.Text = "Họ tên";
            txtGioiTinh.Text = "Giới tính";
            cmbPhongBan.Text = "Phòng ban";
            cmbBangCap.Text = "Bằng cấp";
        }
        private void loadDaTa()
        {
            string sql = "select a.IDNhanVien,a.HoTen,b.TenPhongBan,c.TenBangCap,a.NgaySinh,a.GioiTinh,a.NgayVaoLam,a.QueQuan from NhanVien a inner join PhongBan b on a.IDPhongBan=b.IDPhongBan inner join BangCap c on a.IDBangCap=c.IDBangCap";
            dgvNhanVien.DataSource = conn.GetDataTable(sql);
        }
        private void showBangCap()
        {
            string sql = "select * from BangCap";
            cmbBangCap.DataSource = conn.GetDataTable(sql);
            cmbBangCap.ValueMember = "IDBangCap";
            cmbBangCap.DisplayMember = "TenBangCap";
        }
        private void showPhongBan()
        {
            string sql = "select * from PhongBan";
            cmbPhongBan.DataSource = conn.GetDataTable(sql);
            cmbPhongBan.ValueMember = "IDPhongBan";
            cmbPhongBan.DisplayMember = "TenPhongBan";
        }
        private void NHANVIEN_Load(object sender, EventArgs e)
        {
            loadDaTa();
            showBangCap();
            showPhongBan();
            KhoaDieuKhien();
            setNull();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    txtMaNhanVien.Text = Convert.ToString(dgvNhanVien.CurrentRow.Cells[1].Value);
                    txtHoTen.Text = Convert.ToString(dgvNhanVien.CurrentRow.Cells[2].Value);
                    cmbPhongBan.Text = Convert.ToString(dgvNhanVien.CurrentRow.Cells[3].Value);
                    cmbBangCap.Text=Convert.ToString(dgvNhanVien.CurrentRow.Cells[4].Value);
                    dtpNgaySinh.Text = Convert.ToString(dgvNhanVien.CurrentRow.Cells[5].Value);
                    txtGioiTinh.Text = Convert.ToString(dgvNhanVien.CurrentRow.Cells[6].Value);
                    dtpNgayVaoLam.Text = Convert.ToString(dgvNhanVien.CurrentRow.Cells[7].Value);
                    txtQueQuan.Text = Convert.ToString(dgvNhanVien.CurrentRow.Cells[8].Value);
                }
            }
            catch
            {
                MessageBox.Show("lỗi không tải dữ liệu lên được!");
            }
        }

        private void dgvNhanVien_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvNhanVien.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1; 
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
            txtMaNhanVien.Enabled = false;
            txtHoTen.Text = "";
            txtQueQuan.Text = "";
            txtGioiTinh.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            MoDieuKhien();
            txtMaNhanVien.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (themmoi == true)
            {
                conn.OpenDB();
                int count = 0;
                try
                {
                    SqlCommand cmd = new SqlCommand("nhanVien_them", ConnectDB.connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@mapb", Convert.ToString(cmbPhongBan.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@mabc", Convert.ToString(cmbBangCap.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@ten", Convert.ToString(txtHoTen.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@ns", Convert.ToString(dtpNgaySinh.Value));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@gt", Convert.ToString(txtGioiTinh.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@qq", Convert.ToString(txtQueQuan.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@ngayvl", Convert.ToString(dtpNgayVaoLam.Value));
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

                    SqlCommand cmd = new SqlCommand("nhanVien_sua", ConnectDB.connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@manv", Convert.ToString(txtMaNhanVien.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@mapb", Convert.ToString(cmbPhongBan.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@mabc", Convert.ToString(cmbBangCap.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@ten", Convert.ToString(txtHoTen.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@ns", Convert.ToString(dtpNgaySinh.Value));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@gt", Convert.ToString(txtGioiTinh.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@qq", Convert.ToString(txtQueQuan.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@ngayvl", Convert.ToString(dtpNgayVaoLam.Value));
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
                SqlCommand cmd = new SqlCommand("nhanVien_xoa", ConnectDB.connect);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@ma", Convert.ToString(txtMaNhanVien.Text));
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
                MessageBox.Show("Nhân viên đang trong dự án, không thể xóa!");
            conn.CloseDB();
        }

    
    }
}
