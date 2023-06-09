﻿using System;
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
    public partial class HoGiaDinh : Form
    {
        string connectionString = @"Data Source=DESKTOP-C0C2AH8\SQLEXPRESS;Initial Catalog=quanlynhankhau;Integrated Security=True";

        public HoGiaDinh()
        {
            InitializeComponent();
        }

        private void HoGiaDinh_Load(object sender, EventArgs e)
        {
            layDS();
            LayTo();
        }

        public void LayTo()
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("select maTo, tenTo from tblTo", Cnn))
                {
                    Cmd.CommandType = CommandType.Text;
                    Cnn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ListTo.DataSource = dt;
                        ListTo.ValueMember = "maTo";
                        ListTo.DisplayMember = "tenTo";
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
                using (SqlCommand Cmd = new SqlCommand("select * from tblHoGiaDinh", Cnn))
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
            txtMaHo.Clear();
            txtTenChuHo.Clear();
            radioButtonNam.Checked = true;
            dtpNS.Value = DateTime.Now;

            //dtp.Value = DateTime.Now;
            txtSDT.Clear();
            txtSoNha.Clear();
            txtSearch.Clear();
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
                        Cmd.CommandText = "themHoGiaDinh";
                        Cnn.Open();
                        //@maTo, @hoTen, @sdt, @gioiTinh, @ngaySinh, @soNha
                        Cmd.Parameters.AddWithValue("@maTo", ListTo.SelectedValue.ToString());

                        Cmd.Parameters.AddWithValue("@hoTen", txtTenChuHo.Text);
                        Cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
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
                        Cmd.Parameters.AddWithValue("@soNha", txtSoNha.Text);
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




        private void dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHo.Text = dgv.CurrentRow.Cells["maHoGiaDinh"].Value.ToString();
            String maTo = dgv.CurrentRow.Cells["maTo"].Value.ToString();
            for (int i = 0; i < ListTo.Items.Count; i++)
            {
                ListTo.SelectedIndex = i;
                int value = (int)ListTo.SelectedValue;
                if (value.ToString().Equals(maTo))
                {
                    break;
                }

            }

            txtTenChuHo.Text = dgv.CurrentRow.Cells["hoten"].Value.ToString();
            txtSDT.Text = dgv.CurrentRow.Cells["sdt"].Value.ToString();
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
            txtSoNha.Text = dgv.CurrentRow.Cells["soNha"].Value.ToString();



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
                        Cmd.CommandText = "SuaHoGiaDinh";
                        Cnn.Open();
                        //@maHoGiaDinh,@maTo, @hoTen, @sdt, @gioiTinh, @ngaySinh, @soNha
                        Cmd.Parameters.AddWithValue("@maHoGiaDinh", txtMaHo.Text);
                        //Cmd.Parameters.AddWithValue("@maTo", txtMaTo.Text);
                        Cmd.Parameters.AddWithValue("@maTo", ListTo.SelectedValue.ToString());
                        Cmd.Parameters.AddWithValue("@hoTen", txtTenChuHo.Text);
                        Cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
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
                        Cmd.Parameters.AddWithValue("@soNha", txtSoNha.Text);
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
                                Cmd.CommandText = "XoaHoGiaDinh";
                                Cnn.Open();
                                Cmd.Parameters.AddWithValue("@maHoGiaDinh", txtMaHo.Text);
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
                using (SqlCommand Cmd = new SqlCommand("timkiemtheotenchuho", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cnn.Open();
                    Cmd.Parameters.AddWithValue("@hoten", txtSearch.Text);
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

        private void txtTenChuHo_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenChuHo.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTenChuHo, "Tên chủ hộ không được để trống!");
            }
            //else if (!Regex.IsMatch(txtTenChuHo.Text.Trim(), @"^[A-z,0-9]+$"))
            //{
            //    e.Cancel = true;
            //    errorProvider1.SetError(txtTenChuHo, "Tên chủ hộ không được sử dụng ký tự đặc biệt!");
            //}
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTenChuHo, "");
            }
        }

        private void txtSoNha_Validating(object sender, CancelEventArgs e)
        {
            if (txtSoNha.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSoNha, "Số nhà không được để trống!");
            }
            //else if (!Regex.IsMatch(txtSoNha.Text.Trim(), @"^[A-z,0-9]+$"))
            //{
            //    e.Cancel = true;
            //    errorProvider1.SetError(txtSoNha, "Số nhà không được sử dụng ký tự đặc biệt!");
            //}
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSoNha, "");
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
