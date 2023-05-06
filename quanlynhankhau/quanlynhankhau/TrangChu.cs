using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlynhankhau
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void btnPhuong_Click(object sender, EventArgs e)
        {
            Phuong frm = new Phuong();
            frm.ShowDialog();
        }

        private void btlQuan_Click(object sender, EventArgs e)
        {
            Quan frm = new Quan();
            frm.ShowDialog();
        }

        private void btnTo_Click(object sender, EventArgs e)
        {
            To frm = new To();
            frm.ShowDialog();
        }

        private void btnHoGiaDinh_Click(object sender, EventArgs e)
        {
            HoGiaDinh frm = new HoGiaDinh();
            frm.ShowDialog();
        }

        private void btnThanNhan_Click(object sender, EventArgs e)
        {
            ThanNhan frm = new ThanNhan();
            frm.ShowDialog();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{

        //}

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn nuốn thoát không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
