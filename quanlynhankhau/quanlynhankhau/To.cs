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
    public partial class To : Form
    {
        string connectionString = @"Data Source=DESKTOP-C0C2AH8\SQLEXPRESS;Initial Catalog=quanlynhankhau;Integrated Security=True";

        public To()
        {
            InitializeComponent();
        }
        public void layDS()
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
        public void LayPhuong()
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("select maPhuong,tenPhuong from tblPhuong", Cnn))
                {
                    Cmd.CommandType = CommandType.Text;
                    Cnn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ListPhuong.DataSource = dt;
                        ListPhuong.ValueMember = "maPhuong";
                        ListPhuong.DisplayMember = "tenPhuong";
                        //ListQuan.da
                    }
                    Cnn.Close();
                }
            }
        }
        public void resetForm()
        {
            //txtMaPhuong.Clear();
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
            LayPhuong();
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
                        Cmd.CommandText = "themTo";
                        Cnn.Open();
                        //Cmd.Parameters.AddWithValue("@maPhuong", txtMaPhuong.Text);
                        Cmd.Parameters.AddWithValue("@maPhuong", ListPhuong.SelectedValue.ToString());
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

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTo.Text = dgv.CurrentRow.Cells["maTo"].Value.ToString();
            //txtMaPhuong.Text = dgv.CurrentRow.Cells["maPhuong"].Value.ToString();
            txtTenTo.Text = dgv.CurrentRow.Cells["tenTo"].Value.ToString();
            txtCBCA.Text = dgv.CurrentRow.Cells["canBoCongAn"].Value.ToString();
            txtToTruong.Text = dgv.CurrentRow.Cells["toTruong"].Value.ToString();
            txtSDT.Text = dgv.CurrentRow.Cells["sdtToTruong"].Value.ToString();

            String maphuong = dgv.CurrentRow.Cells["maPhuong"].Value.ToString();
            //  ListQuan.SelectedIndex = ListQuan.FindString(maquan);

            for (int i = 0; i < ListPhuong.Items.Count; i++)
            {
                ListPhuong.SelectedIndex = i;
                int value = (int)ListPhuong.SelectedValue;
                if (value.ToString().Equals(maphuong))
                {
                    break;
                }

            }

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
                        Cmd.CommandText = "SuaTo";
                        Cnn.Open();
                        Cmd.Parameters.AddWithValue("@maTo", txtMaTo.Text);
                        //Cmd.Parameters.AddWithValue("@maPhuong", txtMaPhuong.Text);
                        Cmd.Parameters.AddWithValue("@maQuan", ListPhuong.SelectedValue.ToString());
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


        private void txtTenTo_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenTo.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTenTo, "Tên tổ không được để trống!");
            }
            //else if (!Regex.IsMatch(txtTenTo.Text.Trim(), @"^[A-z,0-9]+$"))
            //{
            //    e.Cancel = true;
            //    errorProvider1.SetError(txtTenTo, "Tên tổ không được sử dụng ký tự đặc biệt!");
            //}
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTenTo, "");
            }
        }

        private void txtCBCA_Validating(object sender, CancelEventArgs e)
        {
            if (txtCBCA.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCBCA, "CBCA không được để trống!");
            }
            //else if (!Regex.IsMatch(txtCBCA.Text.Trim(), @"^[A-z,0-9]+$"))
            //{
            //    e.Cancel = true;
            //    errorProvider1.SetError(txtCBCA, "CBCA không được sử dụng ký tự đặc biệt!");
            //}
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCBCA, "");
            }
        }

        private void txtToTruong_Validating(object sender, CancelEventArgs e)
        {
            if (txtToTruong.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtToTruong, "Tổ trưởng không được để trống!");
            }
            //else if (!Regex.IsMatch(txtToTruong.Text.Trim(), @"^[A-z,0-9]+$"))
            //{
            //    e.Cancel = true;
            //    errorProvider1.SetError(txtToTruong, "Tổ trưởng không được sử dụng ký tự đặc biệt!");
            //}
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtToTruong, "");
            }
        }

        private void txtSDT_Validating(object sender, CancelEventArgs e)
        {
            if (txtSDT.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSDT, "SĐT không được để trống!");
            }
            else if (!Regex.IsMatch(txtSDT.Text.Trim(), "^0\\d{9,10}$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSDT, "SĐT không đúng định dạng!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSDT, "");
            }
        }
    }
}
