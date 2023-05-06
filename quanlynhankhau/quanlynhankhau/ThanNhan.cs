using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            LayHo();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            layDS();
            resetForm();
        }

        public void LayHo()
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("select maHoGiaDinh, hoten from tblHoGiaDinh", Cnn))
                {
                    Cmd.CommandType = CommandType.Text;
                    Cnn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ListHo.DataSource = dt;
                        ListHo.ValueMember = "maHoGiaDinh";
                        ListHo.DisplayMember = "hoten";
                        //ListQuan.da
                    }
                    Cnn.Close();
                }
            }
        }

        public void layDS()
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("select * from tblThanNhan", Cnn))
                //using (SqlCommand Cmd = new SqlCommand("SELECT maPhuong, tenPhuong, tblQuan.* FROM tblPhuong JOIN tblQuan on tblPhuong.maPhuong = tblQuan.maQuan", Cnn))
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
        public void resetForm()
        {
            txtMaThanNhan.Clear();
            //txtMaHoGD.Clear();
            txtHoTen.Clear();
            radioButtonNam.Checked = true;
            dtpNS.Value = DateTime.Now;
            txtQuanHeVoiChuHo.Clear();
            txtSearch.Clear();
        }
        private void To_Load(object sender, EventArgs e)
        {
            layDS();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand())
                    {
                        Cmd.Connection = Cnn;
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "themThanNhan";
                        Cnn.Open();
                        Cmd.Parameters.AddWithValue("@maHogiadinh", ListHo.SelectedValue.ToString());


                        Cmd.Parameters.AddWithValue("@hoten", txtHoTen.Text);
                        string gioiTinh = "";
                        if (radioButtonNam.Checked)
                        {
                            gioiTinh = "Nam";
                        }
                        else if (radioButtonNu.Checked)
                        {
                            gioiTinh = "Nữ";
                        }
                        Cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                        Cmd.Parameters.AddWithValue("@ngaySinh", dtpNS.Value);

                        //Cmd.Parameters.AddWithValue("@gioiTinh", txtGioiTinh.Text);
                        //Cmd.Parameters.AddWithValue("@ngaySinh", txtNgaySinh.Text);
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
        }


        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaThanNhan.Text = dgv.CurrentRow.Cells["maThanNhan"].Value.ToString();
            //txtMaHoGD.Text = dgv.CurrentRow.Cells["maHoGiaDinh"].Value.ToString();

            String maho = dgv.CurrentRow.Cells["maHoGiaDinh"].Value.ToString();
            //  ListQuan.SelectedIndex = ListQuan.FindString(maquan);

            for (int i = 0; i < ListHo.Items.Count; i++)
            {
                ListHo.SelectedIndex = i;
                int value = (int)ListHo.SelectedValue;
                if (value.ToString().Equals(maho))
                {
                    break;
                }

            }
            txtHoTen.Text = dgv.CurrentRow.Cells["hoTen"].Value.ToString();
            string gioiTinh = dgv.CurrentRow.Cells["gioiTinh"].Value.ToString();
            if (gioiTinh == "Nam")
            {
                radioButtonNam.Checked = true;
                radioButtonNu.Checked = false;
            }
            else if (gioiTinh == "Nữ")
            {
                radioButtonNam.Checked = false;
                radioButtonNu.Checked = true;
            }


            dtpNS.Text = dgv.CurrentRow.Cells["ngaySinh"].Value.ToString();
            txtQuanHeVoiChuHo.Text = dgv.CurrentRow.Cells["quanHeVoiChuHo"].Value.ToString();

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
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
                        Cmd.Parameters.AddWithValue("@maHo", ListHo.SelectedValue.ToString());
                        Cmd.Parameters.AddWithValue("@hoten", txtHoTen.Text);
                        string gioiTinh = "";
                        if (radioButtonNam.Checked)
                        {
                            gioiTinh = "Nam";
                        }
                        else if (radioButtonNu.Checked)
                        {
                            gioiTinh = "Nữ";
                        }
                        Cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                        Cmd.Parameters.AddWithValue("@ngaySinh", dtpNS.Value);
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

        private void txtHoTen_Validating(object sender, CancelEventArgs e)
        {
            if (txtHoTen.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtHoTen, "Họ tên không được để trống!");
            }
            //else if (!Regex.IsMatch(txtHoTen.Text.Trim(), @"^[A-z,0-9]+$"))
            //{
            //    e.Cancel = true;
            //    errorProvider1.SetError(txtHoTen, "Họ tên không được sử dụng ký tự đặc biệt!");
            //}
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtHoTen, "");
            }
        }

        private void txtQuanHeVoiChuHo_Validating(object sender, CancelEventArgs e)
        {
            if (txtQuanHeVoiChuHo.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtQuanHeVoiChuHo, "Quan hệ với chủ hộ không được để trống!");
            }
            //else if (!Regex.IsMatch(txtQuanHeVoiChuHo.Text.Trim(), @"^[A-z,0-9]+$"))
            //{
            //    e.Cancel = true;
            //    errorProvider1.SetError(txtQuanHeVoiChuHo, "Quan hệ với chủ hộ không được sử dụng ký tự đặc biệt!");
            //}
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtQuanHeVoiChuHo, "");
            }
        }
    }
}
