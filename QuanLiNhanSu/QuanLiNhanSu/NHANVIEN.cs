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
            cmbBangCap.Enabled = false;
            cmbPhongBan.Enabled = false;
            dtpNgaySinh.Enabled = false;
            dtpNgayVaoLam.Enabled = false;
            cmbTinh.Enabled = false;
            cmbThanhPho.Enabled = false;
            cmbPhuong.Enabled = false;
            cmbPho.Enabled = false;
            cmbSoNha.Enabled = false;

            bntThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThoat.Enabled = true;
            btnTimKiem1.Enabled = false;
            btnTimKiem2.Enabled = false;
            btnTimKiem3.Enabled = false;
            btnTimKiem4.Enabled = false;
            btnQuayLai1.Enabled = false;
            btnQuayLai2.Enabled = false;
            btnQuayLai3.Enabled = false;
            btnQuayLai4.Enabled = false;
        }
        void MoDieuKhien()
        {

            txtGioiTinh.Enabled = true;
            txtHoTen.Enabled = true;
            txtMaNhanVien.Enabled = true;
            cmbBangCap.Enabled = true;
            cmbPhongBan.Enabled = true;
            dtpNgaySinh.Enabled = true;
            dtpNgayVaoLam.Enabled = true;
            cmbTinh.Enabled = true;
            cmbThanhPho.Enabled = true;
            cmbPhuong.Enabled = true;
            cmbPho.Enabled = true;
            cmbSoNha.Enabled = true;

            bntThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThoat.Enabled = true;
            btnTimKiem1.Enabled = true;
            btnTimKiem2.Enabled = false;
            btnTimKiem3.Enabled = false;
            btnTimKiem4.Enabled = false;
            btnQuayLai1.Enabled = false;
            btnQuayLai2.Enabled = false;
            btnQuayLai3.Enabled = false;
            btnQuayLai4.Enabled = false;

        }
        void setNull()
        {
            txtMaNhanVien.Text = "Mã nhân viên";
            txtHoTen.Text = "Họ tên";
            txtGioiTinh.Text = "Giới tính";
            cmbPhongBan.Text = "Phòng ban";
            cmbBangCap.Text = "Bằng cấp";
            cmbTinh.Text = "Tỉnh";
            cmbThanhPho.Text = "Quận, huyện";
            cmbPhuong.Text = "Xã, phường";
            cmbPho.Text = "Phố,thôn";
            cmbSoNha.Text = "Số nhà";
        }
        private void loadDaTa()
        {
            string sql = "select a.IDNhanVien,a.HoTen,b.TenPhongBan,c.TenBangCap,a.NgaySinh,a.GioiTinh,a.NgayVaoLam,d.TenTinh,e.TenThanhPho,f.TenPhuong,g.TenPho,h.TenSoNha from NhanVien a left join PhongBan b on a.IDPhongBan=b.IDPhongBan left join BangCap c on a.IDBangCap=c.IDBangCap left join Tinh d on a.IDTinh=d.IDTinh left join ThanhPho e on a.IDThanhPho=e.IDThanhPho left join Phuong f on a.IDPhuong=f.IDPhuong left join Pho g on a.IDPho=g.IDPho left join SoNha h on a.IDSoNha=h.IDSoNha";
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
        private void showTinh()
        {
            string sql = "select * from Tinh";
            cmbTinh.DataSource = conn.GetDataTable(sql);
            cmbTinh.ValueMember = "IDTinh";
            cmbTinh.DisplayMember = "TenTinh";
        }
        private void showThanhPho()
        {
            conn.OpenDB();
            SqlCommand cmd = new SqlCommand("HuyenTheoTinh", ConnectDB.connect);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@ma", Convert.ToInt16(cmbTinh.SelectedValue));
            cmd.Parameters.Add(p);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbThanhPho.DataSource = dt;
            cmbThanhPho.ValueMember = "IDThanhPho";
            cmbThanhPho.DisplayMember = "TenThanhPho";
            conn.CloseDB();
        }
        private void showPhuong()
        {
            conn.OpenDB();
            SqlCommand cmd = new SqlCommand("XaTheoHuyen", ConnectDB.connect);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@ma", Convert.ToInt16(cmbThanhPho.SelectedValue));
            cmd.Parameters.Add(p);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbPhuong.DataSource = dt;
            cmbPhuong.ValueMember = "IDPhuong";
            cmbPhuong.DisplayMember = "TenPhuong";
            conn.CloseDB();
        }
        private void showPho()
        {
            conn.OpenDB();
            SqlCommand cmd = new SqlCommand("ThonTheoXa", ConnectDB.connect);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@ma", Convert.ToInt16(cmbPhuong.SelectedValue));
            cmd.Parameters.Add(p);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbPho.DataSource = dt;
            cmbPho.ValueMember = "IDPho";
            cmbPho.DisplayMember = "TenPho";
            conn.CloseDB();
        }
        private void showSoNha()
        {
            conn.OpenDB();
            SqlCommand cmd = new SqlCommand("SoNhaTheoPho", ConnectDB.connect);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@ma", Convert.ToInt16(cmbPho.SelectedValue));
            cmd.Parameters.Add(p);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbSoNha.DataSource = dt;
            cmbSoNha.ValueMember = "IDSoNha";
            cmbSoNha.DisplayMember = "TenSoNha";
            conn.CloseDB();
        }
        private void NHANVIEN_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            loadDaTa();
            showBangCap();
            showPhongBan();
            setNull();
            showTinh();
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
                    cmbBangCap.Text = Convert.ToString(dgvNhanVien.CurrentRow.Cells[4].Value);
                    dtpNgaySinh.Text = Convert.ToString(dgvNhanVien.CurrentRow.Cells[5].Value);
                    txtGioiTinh.Text = Convert.ToString(dgvNhanVien.CurrentRow.Cells[6].Value);
                    dtpNgayVaoLam.Text = Convert.ToString(dgvNhanVien.CurrentRow.Cells[7].Value);
                    cmbTinh.Text = Convert.ToString(dgvNhanVien.CurrentRow.Cells[8].Value);
                    cmbThanhPho.Text = Convert.ToString(dgvNhanVien.CurrentRow.Cells[9].Value);
                    cmbPhuong.Text = Convert.ToString(dgvNhanVien.CurrentRow.Cells[10].Value);
                    cmbPho.Text = Convert.ToString(dgvNhanVien.CurrentRow.Cells[11].Value);
                    cmbSoNha.Text = Convert.ToString(dgvNhanVien.CurrentRow.Cells[12].Value);
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
            txtGioiTinh.Text = "";
            cmbTinh.Text = "";
            cmbThanhPho.Text = "";
            cmbPhuong.Text = "";
            cmbPho.Text = "";
            cmbSoNha.Text = "";
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
                    p = new SqlParameter("@ngayvl", Convert.ToString(dtpNgayVaoLam.Value));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@idtinh", Convert.ToString(cmbTinh.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@idthanhpho", Convert.ToString(cmbThanhPho.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@idphuong", Convert.ToString(cmbPhuong.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@idpho", Convert.ToString(cmbPho.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@idsonha", Convert.ToString(cmbSoNha.SelectedValue));
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
                    p = new SqlParameter("@ngayvl", Convert.ToString(dtpNgayVaoLam.Value));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@idtinh", Convert.ToString(cmbTinh.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@idthanhpho", Convert.ToString(cmbThanhPho.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@idphuong", Convert.ToString(cmbPhuong.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@idpho", Convert.ToString(cmbPho.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@idsonha", Convert.ToString(cmbSoNha.SelectedValue));
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

        private void btnTimKiem1_Click(object sender, EventArgs e)
        {
            showThanhPho();
            btnTimKiem1.Enabled = false;
            btnQuayLai1.Enabled = true;
            btnTimKiem2.Enabled = true;
        }

        private void btnTimKiem2_Click(object sender, EventArgs e)
        {
            showPhuong();
            btnTimKiem2.Enabled = false;
            btnQuayLai1.Enabled = false;
            btnTimKiem3.Enabled = true;
            btnQuayLai2.Enabled = true;
        }

        private void btnTimKiem3_Click(object sender, EventArgs e)
        {
            showPho();
            btnTimKiem3.Enabled = false;
            btnQuayLai2.Enabled = false;
            btnTimKiem4.Enabled = true;
            btnQuayLai3.Enabled = true;
        }

        private void btnTimKiem4_Click(object sender, EventArgs e)
        {
            showSoNha();
            btnTimKiem4.Enabled = false;
            btnQuayLai3.Enabled = false;
            btnQuayLai4.Enabled = true;
        }

        private void btnQuayLai4_Click(object sender, EventArgs e)
        {
            cmbSoNha.Text = "";
            btnQuayLai4.Enabled = false;
            btnTimKiem4.Enabled = true;
            btnQuayLai3.Enabled = true;
        }

        private void btnQuayLai3_Click(object sender, EventArgs e)
        {
            cmbPho.Text = "";
            btnQuayLai3.Enabled = false;
            btnTimKiem4.Enabled = false;
            btnTimKiem3.Enabled = true;
            btnQuayLai2.Enabled = true;
        }

        private void btnQuayLai2_Click(object sender, EventArgs e)
        {
            cmbPhuong.Text = "";
            btnQuayLai2.Enabled = false;
            btnTimKiem3.Enabled = false;
            btnTimKiem2.Enabled = true;
            btnQuayLai1.Enabled = true;
        }

        private void btnQuayLai1_Click(object sender, EventArgs e)
        {
            cmbThanhPho.Text = "";
            btnQuayLai1.Enabled = false;
            btnTimKiem2.Enabled = false;
            btnTimKiem1.Enabled = true;
        }
    }
}
