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
    public partial class SONHA : Form
    {
        ConnectDB conn = new ConnectDB();
        bool themmoi;
        public SONHA()
        {
            InitializeComponent();
        }
        void KhoaDieuKhien()
        {
            txtMa.Enabled = false;
            txtTen.Enabled = false;
            cmbPho.Enabled = false;

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
            cmbPho.Enabled = true;

            bntThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThoat.Enabled = true;
        }
        void setNull()
        {
            txtMa.Text = "Mã số nhà";
            txtTen.Text = "Tên số nhà";
            cmbPho.Text = "Tên phố";
        }
        private void loadDaTa()
        {
            string sql = "select a.IDSoNha,a.TenSoNha,b.TenPho from SoNha a left join Pho b on a.IDPho=b.IDPho ";
            dgvSoNha.DataSource = conn.GetDataTable(sql);
        }
        private void showPho()
        {
            string sql = "select * from Pho";
            cmbPho.DataSource = conn.GetDataTable(sql);
            cmbPho.ValueMember = "IDPho";
            cmbPho.DisplayMember = "TenPho";
        }

        private void dgvPho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    txtMa.Text = Convert.ToString(dgvSoNha.CurrentRow.Cells[1].Value);
                    txtTen.Text = Convert.ToString(dgvSoNha.CurrentRow.Cells[2].Value);
                    cmbPho.Text = Convert.ToString(dgvSoNha.CurrentRow.Cells[3].Value);
                }
            }
            catch
            {
                MessageBox.Show("lỗi không tải dữ liệu lên được!");
            }
        }

        private void dgvPho_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvSoNha.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1; 

        }

        private void SONHA_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            loadDaTa();
            showPho();
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
            cmbPho.Text = "";
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
                    SqlCommand cmd = new SqlCommand("soNha_them", ConnectDB.connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@ten", Convert.ToInt16(txtTen.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@pho", Convert.ToString(cmbPho.SelectedValue));
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

                    SqlCommand cmd = new SqlCommand("soNha_sua", ConnectDB.connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@ma", Convert.ToString(txtMa.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@ten", Convert.ToInt16(txtTen.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@pho", Convert.ToString(cmbPho.SelectedValue));
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
                SqlCommand cmd = new SqlCommand("soNha_xoa", ConnectDB.connect);
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
