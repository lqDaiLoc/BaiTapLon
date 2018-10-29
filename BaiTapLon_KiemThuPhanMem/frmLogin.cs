using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUS;

namespace BaiTapLon_KiemThuPhanMem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public string chucVu;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("chưa điền tên đăng nhập or mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDangNhap.Text = txtMatKhau.Text = "";
                txtDangNhap.Focus();
            }
            else
            {
                LoginBUS lg = new LoginBUS();
                chucVu = lg.chucVu;
                if (lg.Login(txtDangNhap.Text, txtMatKhau.Text ))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // nếu sai mật khẩu
                    DialogResult result = MessageBox.Show("sai mật khẩu", "Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.Cancel)
                        Application.Exit();
                    else
                    {
                        txtDangNhap.Text = txtMatKhau.Text = "";
                        txtDangNhap.Focus();
                    }
                }
            }

        }
    }
}
