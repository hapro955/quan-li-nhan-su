﻿using System;
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
    public partial class CHUCVU : Form
    {
        ConnectDB conn = new ConnectDB();
        bool themmoi;
        public CHUCVU()
        {
            InitializeComponent();
        }
        void KhoaDieuKhien()
        {
            txtMa.Enabled = false;
            txtTen.Enabled = false;

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

            bntThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThoat.Enabled = true;
        }
        void setNull()
        {
            txtMa.Text = "Mã chức vụ";
            txtTen.Text = "Tên chức vụ";
        }
        private void loadDaTa()
        {
            string sql = "select * from ChucVu";
            dgvChucVu.DataSource = conn.GetDataTable(sql);
        }
        private void CHUCVU_Load(object sender, EventArgs e)
        {
            loadDaTa();
            KhoaDieuKhien();
            setNull();
        }

        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    txtMa.Text = Convert.ToString(dgvChucVu.CurrentRow.Cells[1].Value);
                    txtTen.Text = Convert.ToString(dgvChucVu.CurrentRow.Cells[2].Value);
                }
            }
            catch
            {
                MessageBox.Show("lỗi không tải dữ liệu lên được!");
            }
        }

        private void dgvChucVu_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvChucVu.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1; 
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
                    SqlCommand cmd = new SqlCommand("chucVu_them", ConnectDB.connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@ten", Convert.ToString(txtTen.Text));
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

                    SqlCommand cmd = new SqlCommand("chucVu_sua", ConnectDB.connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@ma", Convert.ToString(txtMa.Text));
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@ten", Convert.ToString(txtTen.Text));
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
                SqlCommand cmd = new SqlCommand("chuvVu_xoa", ConnectDB.connect);
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
                MessageBox.Show("Nhân viên đang có bằng cấp này, không thể xóa!");
            conn.CloseDB();
        }
    }
}
