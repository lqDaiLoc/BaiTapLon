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
            dp.Connection();
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
                dp.DisConnection();
                return kq;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Tên bánh sai...", "Error getTienBanh");
                throw ex;
            }
            finally
            {
                dp.DisConnection();   
            }
        }

        //
        
        // lay size banh
        public double getSizeBanh(string SizeBanh)
        {
            double size;
            DataProvider dp = new DataProvider();
            dp.Connection();

            string sql = "Select SoLuongCon FROM Hang WHERE TenHang = 'Nhỏ'";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = dp.cn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            try
            {
                string s = cmd.ExecuteScalar().ToString();
                size = double.Parse(s);
                dp.DisConnection();
                return size;
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Sai size...", "Error getSizeBanh");
                throw ex;
            }
            finally
            {
                dp.DisConnection();
            }
        }
    }
}
