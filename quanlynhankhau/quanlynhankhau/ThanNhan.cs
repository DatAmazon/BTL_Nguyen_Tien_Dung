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
    public partial class ThanNhan : Form
    {
        string connectionString = @"Data Source=DESKTOP-C0C2AH8\SQLEXPRESS;Initial Catalog=quanlynhankhau;Integrated Security=True";

        public ThanNhan()
        {
            InitializeComponent();
        }


        private void ThanNhan_Load(object sender, EventArgs e)
        {
            layDS();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            layDS();
            resetForm();
        }

        public void layDS()
        {
            try
            {
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("select * from tblThanNhan", Cnn))
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
            txtMaThanNhan.Clear();
            txtMaHoGD.Clear();
            txtHoTen.Clear();
            txtGioiTinh.Clear();
            txtNgaySinh.Clear();
            txtQuanHeVoiChuHo.Clear();
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
                        Cmd.CommandText = "themThanNhan";
                        Cnn.Open();
                        //@maHoGiaDinh, @hoten, @gioiTinh, @ngaySinh, @quanHeVoiChuHo
                        Cmd.Parameters.AddWithValue("@maHoGiaDinh", txtMaHoGD.Text);
                        Cmd.Parameters.AddWithValue("@hoten", txtHoTen.Text);
                        Cmd.Parameters.AddWithValue("@gioiTinh", txtGioiTinh.Text);
                        Cmd.Parameters.AddWithValue("@ngaySinh", txtNgaySinh.Text);
                        Cmd.Parameters.AddWithValue("@quanHeVoiChuHo", txtQuanHeVoiChuHo.Text);
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
            txtMaThanNhan.Text = dgv.CurrentRow.Cells["maThanNhan"].Value.ToString();
            txtMaHoGD.Text = dgv.CurrentRow.Cells["maHoGiaDinh"].Value.ToString();
            txtHoTen.Text = dgv.CurrentRow.Cells["hoTen"].Value.ToString();
            txtGioiTinh.Text = dgv.CurrentRow.Cells["gioiTinh"].Value.ToString();
            txtNgaySinh.Text = dgv.CurrentRow.Cells["ngaySinh"].Value.ToString();
            txtQuanHeVoiChuHo.Text = dgv.CurrentRow.Cells["quanHeVoiChuHo"].Value.ToString();

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand())
                {
                    Cmd.Connection = Cnn;
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "SuaThanNhan";
                    Cnn.Open();
                    //@maThanNhan, @maHoGiaDinh, @hoten, @gioiTinh, @ngaySinh, @quanHeVoiChuHo
                    Cmd.Parameters.AddWithValue("@maThanNhan", txtMaThanNhan.Text);
                    Cmd.Parameters.AddWithValue("@maHoGiaDinh", txtMaHoGD.Text);
                    Cmd.Parameters.AddWithValue("@hoten", txtHoTen.Text);
                    Cmd.Parameters.AddWithValue("@gioiTinh", txtGioiTinh.Text);
                    Cmd.Parameters.AddWithValue("@ngaySinh", txtNgaySinh.Text);
                    Cmd.Parameters.AddWithValue("@quanHeVoiChuHo", txtQuanHeVoiChuHo.Text);
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
                                Cmd.CommandText = "XoaThanNhan";
                                Cnn.Open();
                                Cmd.Parameters.AddWithValue("@maThanNhan", txtMaThanNhan.Text);
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
                using (SqlCommand Cmd = new SqlCommand("timkiemtheotenthanhan", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cnn.Open();
                    Cmd.Parameters.AddWithValue("@hoTen", txtSearch.Text);
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


    }
}
