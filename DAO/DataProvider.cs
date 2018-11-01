using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DataProvider
    {
        public SqlConnection cnn;
        public DataProvider()
        {
            string cnnStr = "Data Source=LAPTOP-RJRD8U96;Initial Catalog=QLBanPizza;Integrated Security=True";
            cnn = new SqlConnection(cnnStr);
        }
//---------------------------------------------------------------------------------------------------------------
        public DataSet GetDataSet()
        {
            // tao dataSet 
            DataSet data = new DataSet();
            // tao ket noi
            DataProvider dp = new DataProvider();
            
            // tao dataAdapter de do du lieu vao dataSet
            string sql = "Select * from NhanVien";
            SqlDataAdapter da = new SqlDataAdapter(sql,dp.cnn);
            da.Fill(data, "NhanVien");
            da.SelectCommand.CommandText = "Select * from NhaCungCap";
            da.Fill(data, "NhaCungCap");
            da.SelectCommand.CommandText = "Select * from Banh";
            da.Fill(data, "Banh");
            da.SelectCommand.CommandText = "Select * from DonHang";
            da.Fill(data, "DonHang");
            da.SelectCommand.CommandText = "Select * from DonHang_Banh";
            da.Fill(data, "DonHang_Banh");
            da.SelectCommand.CommandText = "Select * from Hang";
            da.Fill(data, "Hang");
            da.SelectCommand.CommandText = "Select * from KhachHang";
            da.Fill(data, "KhachHang");
            da.SelectCommand.CommandText = "Select * from Loai";
            da.Fill(data, "Loai");
            da.SelectCommand.CommandText = "Select * from Users";
            da.Fill(data, "Users");
            
            return data;            
        }
//---------------------------------------------------------------------------------------------------------------
        // lay table Banh
        public DataTable GetDataTableBanh()
        {
            DataSet data = GetDataSet();
            DataTable tb = data.Tables["Banh"];
            return tb;
        }
        // lay table DonHang
        public DataTable GetDataTableDonHang()
        {
            DataSet data = GetDataSet();
            DataTable tb = data.Tables["DonHang"];
            return tb;
        }
        // lay table DonHang_Banh
        public DataTable GetDataTableDonHang_Banh()
        {
            DataSet data = GetDataSet();
            DataTable tb = data.Tables["DonHang_Banh"];
            return tb;
        }
        // lay table Hang
        public DataTable GetDataTableHang()
        {
            DataSet data = GetDataSet();
            DataTable tb = data.Tables["Hang"];
            return tb;
        }
        // lay table KhachHang
        public DataTable GetDataTableKhachHang()
        {
            DataSet data = GetDataSet();
            DataTable tb = data.Tables["KhachHang"];
            return tb;
        }
        // lay table Loai
        public DataTable GetDataTableLoai()
        {
            DataSet data = GetDataSet();
            DataTable tb = data.Tables["Loai"];
            return tb;
        }
        // lay table NhaCungCap
        public DataTable GetDataTableNhaCungCap()
        {
            DataSet data = GetDataSet();
            DataTable tb = data.Tables["NhaCungCap"];
            return tb;
        }
        // lay table NhanVien
        public DataTable GetDataTableNhanVien()
        {
            DataSet data = GetDataSet();
            DataTable tb = data.Tables["NhanVien"];
            return tb;
        }
        // lay table Users
        public DataTable GetDataTableUsers()
        {
            DataSet data = GetDataSet();
            DataTable tb = data.Tables["Users"];
            return tb;
        }
//---------------------------------------------------------------------------------------------------------------
        // update
        // update Table Banh
        public void updateTableBanh(DataTable tb)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Banh", cnn);
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(tb);
        }
        // update Table Don Hang
        public void updateTableDonHang(DataTable tb)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DonHang", cnn);
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(tb);
        }
        // update Table DonHang_Banh
        public void updateTableDonHang_Banh(DataTable tb)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DonHang_Banh", cnn);
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(tb);
        }
//---------------------------------------------------------------------------------------------------------------
        // ConnecTion
        public void ConnecTion()
        {
            try
            {
                if (cnn != null && cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
            }
            catch(SqlException ex)
            { 
                throw ex;
            }
        }
        public void DisConnecTion()
        {
            cnn.Close();
        }
//---------------------------------------------------------------------------------------------------------------
    }

}
