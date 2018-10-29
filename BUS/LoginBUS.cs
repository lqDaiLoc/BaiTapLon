using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAO;
using System.Windows.Forms;

namespace BUS
{
    public class LoginBUS
    {
        //private string userName, passWord;
        
        // danh cho ham Login
        public string chucVu;
        public bool Login(string userName, string passWord)
        {
            DataProvider dp = new DataProvider();
            dp.ConnecTion();
            string sqlStr = "SELECT ChucVu FROM NhanVien WHERE MaNV = N'" + userName + "' AND Ten = N'" + passWord + "'";
            SqlCommand cmd = new SqlCommand(sqlStr);
            cmd.Connection = dp.cnn;
            cmd.CommandText = sqlStr;
            cmd.CommandType = CommandType.Text;

            try
            {
                chucVu = cmd.ExecuteScalar().ToString();

                dp.DisConnecTion();
                if (chucVu != null)
                    return true;
                return false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ko lay duoc du lieu", " error ");
                throw ex;
            }
            finally
            {
                dp.DisConnecTion();
            }
        }

    }
}
