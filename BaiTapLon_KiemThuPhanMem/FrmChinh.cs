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
        DataTable tb = new DataTable();
        DataTable tbtmp = new DataTable();
        BUS_ChucNang bus = new BUS_ChucNang();

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
        
        //Chon Ten Banh
        private void CheckedChange_radTenBanh(object sender, EventArgs e)
        {
            
            RadioButton rad = sender as RadioButton;
            lblTenBanh.Text = rad.Text;
            if (rad.Checked)
            {
                tienLoaiPizza = bus.getTienHang(rad.Text);
                bus.GetDataRowHang(tb, rad.Text);
            }
            else
            {
                bus.RemoveGetDataRowHang(tb,rad.Text);
            }
            lblTienTenBanh.Text = tienLoaiPizza.ToString();
        }
        //Chon Size
        private void CheckedChange_radSize(object sender, EventArgs e)
        {
            RadioButton rad = sender as RadioButton;
            lblSize.Text = rad.Text;
            if (rad.Checked)
            {
                tienSize = bus.getTienHang(rad.Text);
                //bus.GetDataRowHang(tb, rad.Text);
                lblTienSize.Text = "x" + tienSize.ToString();
                

            }
        }
        //Chon nước uống
        private void btnChonNuoc_Click(object sender, EventArgs e)
        {
            lblThucUong.Text = "";
            tienNuoc = 0;
            int slCoCa = int.Parse(txtSoLuongCoCa.Text);
            txtSoLuongCoCa.Text = slCoCa.ToString();
            if (slCoCa != 0)
            {
                bus.GetDataRowNuoc(tb, "CoCa", slCoCa);
                lblThucUong.Text += "CoCa (" + slCoCa + ")\n";
                tienNuoc += (bus.getTienHang("CoCa")) * slCoCa;
            }
            int slSuprise = int.Parse(txtSoLuongSuprise.Text);
            txtSoLuongSuprise.Text = slSuprise.ToString();
            if (slSuprise != 0)
            {
                bus.GetDataRowNuoc(tb, "Suprise", slSuprise);
                lblThucUong.Text += "Suprise (" + slSuprise + ")\n";
                tienNuoc += (bus.getTienHang("Suprise")) * slSuprise;
            }
            int slNumber1 = int.Parse(txtSoLuongNumberOne.Text);
            txtSoLuongNumberOne.Text = slNumber1.ToString();
            if (slNumber1 != 0)
            {
                bus.GetDataRowNuoc(tb, "Number One", slNumber1);
                lblThucUong.Text += "Number One (" + slNumber1 + ")\n";
                tienNuoc += (bus.getTienHang("Number One")) * slNumber1;
            }
            int slSuoi = int.Parse(txtSoLuongSuoi.Text);
            txtSoLuongSuoi.Text = slSuoi.ToString();
            if (slSuoi != 0)
            {
                bus.GetDataRowNuoc(tb, "Nước Suối", slSuoi);
                lblThucUong.Text += "Nước Suối (" + slSuoi + ")\n";
                tienNuoc += (bus.getTienHang("Nước Suối")) * slSuoi;
            }
            int slDrThanh = int.Parse(txtSoLuongDrThanh.Text);
            txtSoLuongDrThanh.Text = slDrThanh.ToString();
            if (slDrThanh != 0)
            {
                bus.GetDataRowNuoc(tb, "DrThanh", slDrThanh);
                lblThucUong.Text += "DrThanh (" + slDrThanh + ")\n";
                tienNuoc += (bus.getTienHang("DrThanh")) * slDrThanh;
            }
            int slPepsi = int.Parse(txtSoLuongPesi.Text);
            txtSoLuongPesi.Text = slPepsi.ToString();
            if (slPepsi != 0)
            {
                bus.GetDataRowNuoc(tb, "Pepsi", slPepsi);
                lblThucUong.Text += "Pepsi (" + slPepsi + ")\n";
                tienNuoc += (bus.getTienHang("Pepsi")) * slPepsi;
            }
            int slCam = int.Parse(txtSoLuongCam.Text);
            txtSoLuongCam.Text = slCam.ToString();
            if (slCam != 0)
            {
                bus.GetDataRowNuoc(tb, "Cam", slCam);
                lblThucUong.Text += "Cam (" + slCam + ")\n";
                tienNuoc += (bus.getTienHang("Cam")) * slCam;
            }
            int slBiDao = int.Parse(txtSoLuongBiDao.Text);
            txtSoLuongBiDao.Text = slBiDao.ToString();
            if (slBiDao != 0)
            {
                bus.GetDataRowNuoc(tb, "Bí Đao", slBiDao);
                lblThucUong.Text += "Bí Đao (" + slBiDao + ")\n";
                tienNuoc += (bus.getTienHang("Bí Đao")) * slBiDao;
            }
            int slSting = int.Parse(txtSoLuongSting.Text);
            txtSoLuongSting.Text = slSting.ToString();
            if (slSting != 0)
            {
                bus.GetDataRowNuoc(tb, "Sting", slSting);
                lblThucUong.Text += "Sting (" + slSting + ")\n";
                tienNuoc += (bus.getTienHang("Sting")) * slSting;
            }
            int slSoda = int.Parse(txtSoLuongSoda.Text);
            txtSoLuongSoda.Text = slSoda.ToString();
            if (slSoda != 0)
            {
                bus.GetDataRowNuoc(tb, "SoDa", slSoda);
                lblThucUong.Text += "SoDa (" + slSoda + ")\n";
                tienNuoc += (bus.getTienHang("SoDa")) * slSoda;
            }
            lblTienNuoc.Text = tienNuoc.ToString();
            tongTien += tienNuoc;

        }
        // CHon tp Phu
        private void CheckedChanged_TpPhu(object sender, EventArgs e)
        {
            CheckBox check = sender as CheckBox;
            if (check.Checked)
            {
                bus.GetDataRowHang(tb, check.Text);
                lblTpPhu.Text += check.Text + ", ";
                tienTpPhu += bus.getTienHang(check.Text);
            }
            if (!check.Checked)
            {
                bus.RemoveGetDataRowHang(tb, check.Text);
                lblTpPhu.Text = lblTpPhu.Text.Replace(check.Text + ", ", "");
                tienTpPhu -= bus.getTienHang(check.Text);
            }
            lblTienPhu.Text = tienTpPhu.ToString();
        }
        // Chon De Banh
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
        // Chon Vien Banh
        private void CheckedChang_VienBanh(object sender, EventArgs e)
        {
            RadioButton rad = sender as RadioButton;
            if (rad.Checked)
            {
                lblVienBanh.Text = rad.Text;
                tienVoBanh = bus.getTienHang(rad.Text);
            }

            lblTienVoBanh.Text = tienVoBanh.ToString();
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
                tbtmp = tb;
                //dataGridView1.DataSourceChanged += tbtmp;
                dataGridView2.DataSource = tbtmp;

                
                
                //----------------------------------------------------------------------------------------------------------
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
                //----------------------------------------------------------------------------------------------------------
                return;
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

        private void btnLuu_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = tbtmp;
        }
    }
}
