using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
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

        //Lay Thong tin hang
        public void GetDataRowHang(DataTable tb, string tenHang)
        {
            DataRow row = tb.NewRow();
            DataProvider dp = new DataProvider();
            SqlDataAdapter adapter = new SqlDataAdapter("Select MaHang, TenHang, SoLuong = 1, GiaHang from Hang Where TenHang = N'" + tenHang.ToString() + "'", dp.cnn);
            adapter.Fill(tb);

        }
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
            //DataRow row = tb.NewRow();
            //DataProvider dp = new DataProvider();
            //SqlDataAdapter adapter = new SqlDataAdapter("Select MaHang, TenHang, SoLuong = 1, GiaHang from Hang Where TenHang = N'" + tenHang.ToString() + "'", dp.cnn);
            //adapter.Fill(tb);

        }
        public void GetDataRowNuoc(DataTable tb, string tenHang, int SoLuong)
        {
            DataRow row = tb.NewRow();
            DataProvider dp = new DataProvider();
            SqlDataAdapter adapter = new SqlDataAdapter("Select MaHang, TenHang, SoLuong = '" + SoLuong.ToString() + "' , GiaHang from Hang Where TenHang = N'" + tenHang.ToString() + "'", dp.cnn);
            adapter.Fill(tb);
        }

        // lay size banh
        public double getSizeBanh(string SizeBanh)
        {
            double size;
            DataProvider dp = new DataProvider();
            dp.ConnecTion();

            string sql = "Select SoLuongCon FROM Hang WHERE TenHang = 'Nhỏ'";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = dp.cnn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            try
            {
                string s = cmd.ExecuteScalar().ToString();
                size = double.Parse(s);
                dp.DisConnecTion();
                return size;
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Sai Size...", "error getSizeBanh");
                throw ex;
            }
            finally
            {
                dp.DisConnecTion();
            }
        }
    }
}
