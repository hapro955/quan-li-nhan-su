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
    public partial class CHITIETLUONG : Form
    {
        ConnectDB conn = new ConnectDB();
        bool themmoi;
        public CHITIETLUONG()
        {
            InitializeComponent();
        }
        void KhoaDieuKhien()
        {
            txtMa.Enabled = false;
            cmbHeSoLuong.Enabled = false;
            cmbNhanVien.Enabled = false;
            dtpNgayTangLuong.Enabled = false;

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
            cmbHeSoLuong.Enabled = true;
            cmbNhanVien.Enabled = true;
            dtpNgayTangLuong.Enabled = true;

            bntThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThoat.Enabled = true;
        }
        void setNull()
        {
            txtMa.Text = "Mã chi tiết";
            cmbHeSoLuong.Text = "Hệ số lương";
            cmbNhanVien.Text = "Nhân viên";
        }
        private void loadDaTa()
        {
            string sql = "select a.IDChiTiet,c.HoTen,b.HeSoLuong,a.NgayTangLuong from ChiTietLuong a left join Luong b on a.IDLuong=b.IDLuong left join NhanVien c on a.IDNhanVien=c.IDNhanVien ";
            dgvChiTietLuong.DataSource = conn.GetDataTable(sql);
        }
        private void showHeSoLuong()
        {
            string sql = "select * from Luong";
            cmbHeSoLuong.DataSource = conn.GetDataTable(sql);
            cmbHeSoLuong.ValueMember = "IDLuong";
            cmbHeSoLuong.DisplayMember = "HeSoLuong";
        }
        private void showNhanVien()
        {
            string sql = "select * from NhanVien";
            cmbNhanVien.DataSource = conn.GetDataTable(sql);
            cmbNhanVien.ValueMember = "IDNhanVien";
            cmbNhanVien.DisplayMember = "HoTen";
        }

        private void CHITIETLUONG_Load(object sender, EventArgs e)
        {
            loadDaTa();
            showHeSoLuong();
            showNhanVien();
            KhoaDieuKhien();
            setNull();
        }

        private void dgvChiTietLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    txtMa.Text = Convert.ToString(dgvChiTietLuong.CurrentRow.Cells[1].Value);
                    cmbNhanVien.Text = Convert.ToString(dgvChiTietLuong.CurrentRow.Cells[2].Value);
                    cmbHeSoLuong.Text = Convert.ToString(dgvChiTietLuong.CurrentRow.Cells[3].Value);
                    dtpNgayTangLuong.Text = Convert.ToString(dgvChiTietLuong.CurrentRow.Cells[4].Value);
                }
            }
            catch
            {
                MessageBox.Show("lỗi không tải dữ liệu lên được!");
            }
        }

        private void dgvChiTietLuong_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvChiTietLuong.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1; 
        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            MoDieuKhien();
            setNull();
            txtMa.Enabled = false;
            cmbHeSoLuong.Text = "Hệ số lương";
            cmbNhanVien.Text = "Nhân viên";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            MoDieuKhien();
            txtMa.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            setNull();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (themmoi == true)
            {
                conn.OpenDB();
                int count = 0;
                try
                {
                    SqlCommand cmd = new SqlCommand("chitietluong_them", ConnectDB.connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@maluong", Convert.ToInt16(cmbHeSoLuong.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@manv", Convert.ToString(cmbNhanVien.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@ngaytangluong", Convert.ToString(dtpNgayTangLuong.Value));
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

                    SqlCommand cmd = new SqlCommand("chitietluong_sua", ConnectDB.connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@ma", Convert.ToString(txtMa.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@maluong", Convert.ToInt16(cmbHeSoLuong.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@manv", Convert.ToString(cmbNhanVien.SelectedValue));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@ngaytangluong", Convert.ToString(dtpNgayTangLuong.Value));
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
                SqlCommand cmd = new SqlCommand("chitietluong_xoa", ConnectDB.connect);
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
