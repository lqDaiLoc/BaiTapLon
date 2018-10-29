using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;


namespace BaiTapLon_KiemThuPhanMem
{
    public partial class FrmChinh : Form
    {
        public FrmChinh()
        {
            InitializeComponent();
        }
        double tienNuoc = 0;
        double tienLoaiPizza = 0;
        double tienVoBanh = 0;
        double tienSize = 1;
        double tienTpPhu = 0;
        double tongTien = 0;
         

        private void FrmChinh_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            frmLogin frm = new frmLogin();
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Enabled = true;
                // Neu la Manager thi cho phep them 1 so chuc nang nua
                // con ko phai la Manager thi chuc nang nhap tt khach va nhap tt nv ko dc mo~
                if(frm.chucVu == "Supervisor")
                {
                    btnNhapTTKhach.Enabled = true;
                    btnNhapTTNhanVien.Enabled = true;
                } 
            }
        }
        
        private void CheckedChange_radTenBanh(object sender, EventArgs e)
        {
            RadioButton rad = sender as RadioButton;
            lblTenBanh.Text = rad.Text;
            if (rad.Checked)
            {
                BUS_ChucNang bus = new BUS_ChucNang();
                tienLoaiPizza = bus.getTienBanh(rad.Text);
            }
            lblTienTenBanh.Text = tienLoaiPizza.ToString();
        }

        private void CheckedChange_radSize(object sender, EventArgs e)
        {
            RadioButton rad = sender as RadioButton;
            lblSize.Text = rad.Text;
            if (rad.Checked)
            {
                BUS_ChucNang bus = new BUS_ChucNang();
                tienSize = bus.getSizeBanh(rad.Text);
                lblTienSize.Text = "x" + tienSize.ToString();
                

            }
        }

        private bool isNumber(string s)
        {
            char[] arr;
            arr = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
                if (!char.IsDigit(arr[i]))
                    return false;
            return true;
            
        }

        private void TextChanged_ThucUong(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            
            if (!isNumber(txt.Text))
                errorProvider1.SetError(txt, "Phải nhập số");
            else
                errorProvider1.Clear();
            if (String.IsNullOrWhiteSpace(txt.Text))
                txt.Text = "0";
                        
            
        }

        private void txtThucUong_Click(object sender, EventArgs e)
        {
            //TextBox txt = sender as TextBox;
            //txt.Text = "";
        }
        
        private void btnChonNuoc_Click(object sender, EventArgs e)
        {
            lblThucUong.Text = "";
            tienNuoc = 0;
            if (txtSoLuongCoCa.Text != "0")
            {
                lblThucUong.Text += "CoCa (" + txtSoLuongCoCa.Text + ")\n";
                tienNuoc += 10000 * int.Parse(txtSoLuongCoCa.Text);
            }
            if (txtSoLuongSuprise.Text != "0")
            {
                lblThucUong.Text += "Suprise (" + txtSoLuongSuprise.Text + ")\n";
                tienNuoc += 10000 * int.Parse(txtSoLuongSuprise.Text);
            }
            if (txtSoLuongNumberOne.Text != "0")
            {
                lblThucUong.Text += "Number One (" + txtSoLuongNumberOne.Text + ")\n";
                tienNuoc += 10000 * int.Parse(txtSoLuongNumberOne.Text);
            }
            if (txtSoLuongSuoi.Text != "0")
            {
                lblThucUong.Text += "Nước Suối (" + txtSoLuongSuoi.Text + ")\n";
                tienNuoc += 7000 * int.Parse(txtSoLuongSuoi.Text);
            }
            if (txtSoLuongDrThanh.Text != "0")
            { 
            lblThucUong.Text += "DrThanh (" + txtSoLuongDrThanh.Text + ")\n";
                tienNuoc += 12000 * int.Parse(txtSoLuongDrThanh.Text);
            }
            if (txtSoLuongPesi.Text != "0")
            {
                lblThucUong.Text += "Pesi (" + txtSoLuongPesi.Text + ")\n";
                tienNuoc += 10000 * int.Parse(txtSoLuongPesi.Text);
            }
            if (txtSoLuongCam.Text != "0")
            {
                lblThucUong.Text += "Cam (" + txtSoLuongCam.Text + ")\n";
                tienNuoc += 12000 * int.Parse(txtSoLuongCam.Text);
            }
            if (txtSoLuongBiDao.Text != "0")
            {
                lblThucUong.Text += "Bí Đao (" + txtSoLuongBiDao.Text + ")\n";
                tienNuoc += 8000 * int.Parse(txtSoLuongBiDao.Text);
            }
            if (txtSoLuongSting.Text != "0")
            {
                lblThucUong.Text += "Sting (" + txtSoLuongSting.Text + ")\n";
                tienNuoc += 11000 * int.Parse(txtSoLuongSting.Text);
            }
            if (txtSoLuongSoda.Text != "0")
            {
                lblThucUong.Text += "SoDa (" + txtSoLuongSoda.Text + ")\n";
                tienNuoc += 10000 * int.Parse(txtSoLuongSoda.Text);
            }
            lblTienNuoc.Text = tienNuoc.ToString();
            tongTien += tienNuoc;
            
        }

        private void CheckedChanged_TpPhu(object sender, EventArgs e)
        {
            CheckBox check = sender as CheckBox;
            if(check.Checked)
            {
                lblTpPhu.Text += check.Text + ", ";
                tienTpPhu += 30000;
                
            }
            if(!check.Checked )
            {
                //check.Text.Length
                lblTpPhu.Text = lblTpPhu.Text.Replace(check.Text + ", ", "");
                tienTpPhu -= 30000;
              
            }
            lblTienPhu.Text = tienTpPhu.ToString();
           
        }
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (lblTenBanh.Text != "")
            {
                ListViewItem pizza = new ListViewItem(lblTenBanh.Text);
                pizza.SubItems.Add(lblTpPhu.Text);
                pizza.SubItems.Add(lblSize.Text);
                pizza.SubItems.Add(lblDeBanh.Text + " " + lblVienBanh.Text);
                pizza.SubItems.Add(lblThucUong.Text);
                tongTien = (tienVoBanh + tienTpPhu + tienNuoc + tienLoaiPizza) * tienSize;
                pizza.SubItems.Add(tongTien.ToString());
                listView1.Items.Add(pizza);
                
                // Thanh phan phu
                checkBox1.Checked = checkBox2.Checked = checkBox3.Checked = checkBox4.Checked = checkBox5.Checked = false;
                checkBox6.Checked = checkBox7.Checked = checkBox8.Checked = checkBox9.Checked = false;
                checkBox10.Checked = checkBox11.Checked = checkBox12.Checked = false;
                // Size
                radLon.Checked = radNho.Checked = radThuong.Checked = false;
                // Ten Banh
                radHaiSan.Checked = radXucXich.Checked = radThapCam.Checked = radTom.Checked = radRau.Checked = false;
                // Thuc Uong
                txtSoLuongBiDao.Text = txtSoLuongCam.Text = txtSoLuongCoCa.Text = txtSoLuongDrThanh.Text = txtSoLuongNumberOne.Text = "0";
                txtSoLuongPesi.Text = txtSoLuongSoda.Text = txtSoLuongSting.Text = txtSoLuongSuoi.Text = txtSoLuongSuprise.Text = "0";
                // cac label 
                lblVienBanh.Text = lblDeBanh.Text = lblSize.Text = lblTenBanh.Text = lblThucUong.Text = lblTpPhu.Text = "";

                // tiền các loại
                tienLoaiPizza = tienNuoc = tienSize = tienTpPhu = tienVoBanh = 0;
                // label tien
                lblTienNuoc.Text = lblTienPhu.Text = lblTienSize.Text = lblTienTenBanh.Text = lblTienVoBanh.Text = "";

            }
            else
            {
                MessageBox.Show("Bạn chưa nhập bánh!!!", "Cảnh báo", MessageBoxButtons.OK);
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CheckedChang_DeBanh(object sender, EventArgs e)
        {
            RadioButton rad = sender as RadioButton;
            if (rad.Checked)
            {
                lblDeBanh.Text = "Đế Bánh " + rad.Text;
            }
            else
                lblDeBanh.Text = "";

        }

        private void CheckedChang_VienBanh(object sender, EventArgs e)
        {
            RadioButton rad = sender as RadioButton;
            if (rad.Checked)
            {
                lblVienBanh.Text = "Viền Bánh " + rad.Text;
                tienVoBanh = 50000;
            }
            
            lblTienVoBanh.Text = tienVoBanh.ToString();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Tên Bánh
            
            // Thành phần phũ 
        }

        private void btnXoaBill_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    listView1.Items[i].Remove();
                    
                }
            }
        }

    }
}
