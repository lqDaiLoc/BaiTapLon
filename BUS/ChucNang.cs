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
        public double getTienBanh(string tenBanh)
        {
            double kq ;
            DataProvider dp = new DataProvider();
            dp.ConnecTion();
            
            string sql = "SELECT GiaHang FROM Hang WHERE TenHang = N'" + "B"+ tenBanh + "'";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = dp.cnn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            try
            {

                string s = cmd.ExecuteScalar().ToString();
                kq = double.Parse(s);
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
