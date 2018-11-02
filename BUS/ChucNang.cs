using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using TOD;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace BUS
{
    public class BUS_ChucNang
    {

        //lay gia tien cua ten banh
        public double getTienHang(string tenBanh)
        {
            double kq = 0;
            DataProvider dp = new DataProvider();
            dp.ConnecTion();
            DataTable tb_Banh = dp.GetDataTableHang();
            try
            {   
                foreach(DataRow row in tb_Banh.Rows)
                {
                    if (row[1].ToString() == (tenBanh))
                    {
                        kq = double.Parse(row[5].ToString());
                        return kq;
                    }
                }
                dp.DisConnecTion();
                return kq;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Tên Bánh Sai...", "error getTienBanh");
                throw ex;
            }
            finally
            {
                dp.DisConnecTion();
                
            }

        }

        /// <summary>
        /// Nhap thong tin hang vao tb
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="tenHang"></param>
        public void GetDataRowHang(DataTable tb, string tenHang)
        {
            DataRow row = tb.NewRow();
            DataProvider dp = new DataProvider();
            SqlDataAdapter adapter = new SqlDataAdapter("Select MaHang, TenHang, MaLoai, SoLuong = 1, GiaHang from Hang Where TenHang = N'" + tenHang.ToString() + "'", dp.cnn);

            adapter.Fill(tb);

        }
        /// <summary>
        /// Xoa thong tin cua hang khoi table
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="tenHang"></param>
        public void RemoveGetDataRowHang(DataTable tb, string tenHang)
        {   
            foreach(DataRow ros in tb.Rows)
            {
                if (ros["TenHang"].ToString() == tenHang)
                {
                    tb.Rows.Remove(ros);
                    return;    
                }
            }
        }
        /// <summary>
        /// Lay thong tin nuoc uong cua khach vao table, Co lay so luong
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="tenHang"></param>
        /// <param name="SoLuong"></param>
        public void GetDataRowNuoc(DataTable tb, string tenHang, int SoLuong)
        {
            DataRow row = tb.NewRow();
            DataProvider dp = new DataProvider();
            SqlDataAdapter adapter = new SqlDataAdapter("Select MaHang, TenHang, MaLoai, SoLuong = '" + SoLuong.ToString() + "' , GiaHang from Hang Where TenHang = N'" + tenHang.ToString() + "'", dp.cnn);
            adapter.Fill(tb);
        }
        /// <summary>
        /// Them bill vao listView
        /// </summary>
        /// <param name="bill"></param>
        public void AddItem(Build bill, ListView listView1)
        {
            ListViewItem pizza = new ListViewItem(bill.TenBanh);
            pizza.SubItems.Add(bill.TpPhu);
            pizza.SubItems.Add(bill.Size);
            pizza.SubItems.Add(bill.DeBanh + " " + bill.VienBanh);
            pizza.SubItems.Add(bill.ThucUong);
            pizza.SubItems.Add(bill.TongTien.ToString());
            listView1.Items.Add(pizza);
        }
    }
}
