using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiNhanSu
{
    public partial class MENU : Form
    {
        public MENU()
        {
            InitializeComponent();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bằngCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BANGCAP bc = new BANGCAP();
            bc.Show();
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CHUCVU cv = new CHUCVU();
            cv.Show();
        }

        private void dựÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DUAN da = new DUAN();
            da.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NHANVIEN nv = new NHANVIEN();
            nv.Show();
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PHONGBAN pb = new PHONGBAN();
            pb.Show();
        }

        private void nhânViênVàChứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NHANVIENVACHUCVU nvcv = new NHANVIENVACHUCVU();
            nvcv.Show();
        }

        private void nhânViênVàDựÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NHANVIENVADUAN nvda = new NHANVIENVADUAN();
            nvda.Show();
        }

        private void nhânViênCủaPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            THONGKE_NHANVIENPHONGBAN tk1 = new THONGKE_NHANVIENPHONGBAN();
            tk1.Show();
        }

        private void nhânViênCủaDựÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            THONGKE_NHANVIENDUAN tk2 = new THONGKE_NHANVIENDUAN();
            tk2.Show();
        }

        private void tỉnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TINH t = new TINH();
            t.Show();
        }

        private void quậnHuyệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            THANHPHO tp = new THANHPHO();
            tp.Show();
        }

        private void phườngXãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PHUONG p = new PHUONG();
            p.Show();
        }

        private void phốThônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PHO p = new PHO();
            p.Show();
        }

        private void sốNhàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SONHA sh = new SONHA();
            sh.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LUONG l = new LUONG();
            l.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CHITIETLUONG ctl = new CHITIETLUONG();
            ctl.Show();
        }
    }
}
