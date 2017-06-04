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
    public partial class PHO : Form
    {
        ConnectDB conn = new ConnectDB();
        bool themmoi;
        public PHO()
        {
            InitializeComponent();
        }
        void KhoaDieuKhien()
        {
            txtMa.Enabled = false;
            txtTen.Enabled = false;
            cmbPhuong.Enabled = false;

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
            cmbPhuong.Enabled = true;

            bntThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThoat.Enabled = true;
        }
        void setNull()
        {
            txtMa.Text = "Mã phố, làng";
            txtTen.Text = "Tên phố, làng";
            cmbPhuong.Text = "Tên phường, xã";
        }
        private void loadDaTa()
        {
            string sql = "select a.IDPho,a.TenPho,b.TenPhuong from Pho a left join Phuong b on a.IDPhuong=b.IDPhuong ";
            dgvPho.DataSource = conn.GetDataTable(sql);
        }
        private void showPhuong()
        {
            string sql = "select * from Phuong";
            cmbPhuong.DataSource = conn.GetDataTable(sql);
            cmbPhuong.ValueMember = "IDPhuong";
            cmbPhuong.DisplayMember = "TenPhuong";
        }

        private void dgvPhuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    txtMa.Text = Convert.ToString(dgvPho.CurrentRow.Cells[1].Value);
                    txtTen.Text = Convert.ToString(dgvPho.CurrentRow.Cells[2].Value);
                    cmbPhuong.Text = Convert.ToString(dgvPho.CurrentRow.Cells[3].Value);
                }
            }
            catch
            {
                MessageBox.Show("lỗi không tải dữ liệu lên được!");
            }
        }

        private void dgvPhuong_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvPho.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1; 
        }

        private void PHO_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            loadDaTa();
            showPhuong();
            setNull();
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
            cmbPhuong.Text = "";
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
                    SqlCommand cmd = new SqlCommand("pho_them", ConnectDB.connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@ten", Convert.ToString(txtTen.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@phuong", Convert.ToString(cmbPhuong.SelectedValue));
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

                    SqlCommand cmd = new SqlCommand("pho_sua", ConnectDB.connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@ma", Convert.ToString(txtMa.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@ten", Convert.ToString(txtTen.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@phuong", Convert.ToString(cmbPhuong.SelectedValue));
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
                SqlCommand cmd = new SqlCommand("pho_xoa", ConnectDB.connect);
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
