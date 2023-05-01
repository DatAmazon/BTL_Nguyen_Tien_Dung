using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlynhankhau
{
    public partial class To : Form
    {
        string connectionString = @"Data Source=DESKTOP-C0C2AH8\SQLEXPRESS;Initial Catalog=quanlynhankhau;Integrated Security=True";

        public To()
        {
            InitializeComponent();
        }
        public void layDS()
        {
            try
            {
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("select * from tblTo", Cnn))
                    {
                        Cmd.CommandType = CommandType.Text;
                        Cnn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgv.DataSource = dt;
                        }
                        Cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void resetForm()
        {
            txtMaPhuong.Clear();
            txtTenTo.Clear();
            txtCBCA.Clear();
            txtMaTo.Clear();

            //dtp.Value = DateTime.Now;
            txtSDT.Clear();
            txtToTruong.Clear();
            txtSearch.Clear();
        }
        private void To_Load(object sender, EventArgs e)
        {
            layDS();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand())
                    {
                        Cmd.Connection = Cnn;
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "themTo";
                        Cnn.Open();
                        Cmd.Parameters.AddWithValue("@maPhuong", txtMaPhuong.Text);
                        Cmd.Parameters.AddWithValue("@tenTo", txtTenTo.Text);
                        Cmd.Parameters.AddWithValue("@cbca", txtCBCA.Text);
                        Cmd.Parameters.AddWithValue("@toTruong", txtToTruong.Text);
                        Cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                        //thêm sửa xóa có thay đổi gì trong db k?
                        int i = Cmd.ExecuteNonQuery();
                        if (i == 0)
                        {
                            MessageBox.Show("Thêm thất bại");
                        }
                        else
                        {
                            MessageBox.Show("Thêm thành công");
                        }
                        Cnn.Close();
                        resetForm();
                        layDS();
                    }
                }
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show("Bạn phải điền đủ các trường dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTo.Text = dgv.CurrentRow.Cells["maTo"].Value.ToString();
            txtMaPhuong.Text = dgv.CurrentRow.Cells["maPhuong"].Value.ToString();
            txtTenTo.Text = dgv.CurrentRow.Cells["tenTo"].Value.ToString();
            txtCBCA.Text = dgv.CurrentRow.Cells["canBoCongAn"].Value.ToString();
            txtToTruong.Text = dgv.CurrentRow.Cells["toTruong"].Value.ToString();
            txtSDT.Text = dgv.CurrentRow.Cells["sdtToTruong"].Value.ToString();

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand())
                {
                    Cmd.Connection = Cnn;
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "SuaTo";
                    Cnn.Open();
                    Cmd.Parameters.AddWithValue("@maTo", txtMaTo.Text);
                    Cmd.Parameters.AddWithValue("@maPhuong", txtMaPhuong.Text);
                    Cmd.Parameters.AddWithValue("@tenTo", txtTenTo.Text);
                    Cmd.Parameters.AddWithValue("@cbca", txtCBCA.Text);
                    Cmd.Parameters.AddWithValue("@toTruong", txtToTruong.Text);
                    Cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                    //thêm sửa xóa có thay đổi gì trong db k?
                    int i = Cmd.ExecuteNonQuery();
                    if (i == 0)
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                    else
                    {
                        MessageBox.Show("Sửa thành công");
                    }
                    Cnn.Close();
                    resetForm();
                    layDS();
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult kq = MessageBox.Show("Bạn nuốn xóa không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (kq == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection Cnn = new SqlConnection(connectionString))
                        {
                            using (SqlCommand Cmd = new SqlCommand())
                            {
                                Cmd.Connection = Cnn;
                                Cmd.CommandType = CommandType.StoredProcedure;
                                Cmd.CommandText = "XoaTo";
                                Cnn.Open();
                                Cmd.Parameters.AddWithValue("@maTo", txtMaTo.Text);
                                //thêm sửa xóa có thay đổi gì trong db k?
                                int i = Cmd.ExecuteNonQuery();
                                if (i == 0)
                                {
                                    Console.WriteLine("Delete success");
                                }
                                else
                                {
                                    Console.WriteLine("Delete fail");
                                }
                                Cnn.Close();
                                resetForm();
                                layDS();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Giá trị tham chiếu đến bản ghi khác", "Lỗi không xóa được");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi", "Bản ghi bị ràng buộc khóa");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("timkiemtheotento", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cnn.Open();
                    Cmd.Parameters.AddWithValue("@tento", txtSearch.Text);
                    using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgv.DataSource = dt;
                    }
                    Cnn.Close();
                }
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            layDS();
            resetForm();
        }

    }
}
