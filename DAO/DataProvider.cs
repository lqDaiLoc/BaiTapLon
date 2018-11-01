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
        public SqlConnection cn;
        public DataProvider()
        {
            string cnStr ="Server = .; Database = QLNhanVien; Integrated security = true";
            cn = new SqlConnection(cnStr);
        }
        public DataSet GetDataSet()
        {
            // tao dataSet 
            DataSet ds = new DataSet();
            // tao ket noi
            DataProvider dp = new DataProvider();
            
            // tao dataAdapter de do du lieu vao dataSet
            string sql = "Select * from NV";
            SqlDataAdapter da = new SqlDataAdapter(sql,dp.cn);
            da.Fill(ds, "NV");
            da.SelectCommand.CommandText = "Select * from NCC";
            da.Fill(ds, "NCC");
            da.SelectCommand.CommandText = "Select * from Banh";
            da.Fill(ds, "Banh");
            da.SelectCommand.CommandText = "Select * from DH";
            da.Fill(ds, "DH");
            da.SelectCommand.CommandText = "Select * from DH_Banh";
            da.Fill(ds, "DH_Banh");
            da.SelectCommand.CommandText = "Select * from Hang";
            da.Fill(ds, "Hang");
            da.SelectCommand.CommandText = "Select * from KH";
            da.Fill(ds, "KH");
            da.SelectCommand.CommandText = "Select * from Loai";
            da.Fill(ds, "Loai");
            da.SelectCommand.CommandText = "Select * from Users";
            da.Fill(ds, "Users");
            
            return ds;            
        }

        // lay table Banh
        public DataTable GetDataTableBanh()
        {
            DataSet ds = GetDataSet();
            DataTable tb = ds.Tables["Banh"];
            return tb;
        }
        
        // lay table DonHang
        public DataTable GetDataTableDH()
        {
            DataSet ds = GetDataSet();
            DataTable tb = ds.Tables["DH"];
            return tb;
        }
        // lay table DonHang_Banh
        public DataTable GetDataTableDH_Banh()
        {
            DataSet ds = GetDataSet();
            DataTable tb = ds.Tables["DH_Banh"];
            return tb;
        }
        // lay table Hang
        public DataTable GetDataTableHang()
        {
            DataSet ds = GetDataSet();
            DataTable tb = ds.Tables["Hang"];
            return tb;
        }
        // lay table KhachHang
        public DataTable GetDataTableKH()
        {
            DataSet ds = GetDataSet();
            DataTable tb = ds.Tables["KH"];
            return tb;
        }
        // lay table Loai
        public DataTable GetDataTableLoai()
        {
            DataSet ds = GetDataSet();
            DataTable tb = ds.Tables["Loai"];
            return tb;
        }
        // lay table NhaCungCap
        public DataTable GetDataTableNCC()
        {
            DataSet ds = GetDataSet();
            DataTable tb = ds.Tables["NCC"];
            return tb;
        }
        // lay table NhanVien
        public DataTable GetDataTableNV()
        {
            DataSet ds = GetDataSet();
            DataTable tb = ds.Tables["NV"];
            return tb;
        }
        // lay table Users
        public DataTable GetDataTableUsers()
        {
            DataSet ds = GetDataSet();
            DataTable tb = ds.Tables["Users"];
            return tb;
        }

        // update
        // update Table Banh
        public void updateTableBanh(DataTable tb)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Banh", cn);
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(tb);
        }
        // update Table Don Hang
        public void updateTableDonHang(DataTable tb)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DH", cn);
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(tb);
        }
        // update Table DonHang_Banh
        public void updateTableDonHang_Banh(DataTable tb)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DH_Banh", cn);
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(tb);
        }

        // ConnecTion
        public void Connection()
        {
            try
            {
                if (cn != null && cn.State == System.Data.ConnectionState.Closed)
                    cn.Open();
            }
            catch(SqlException ex)
            { 
                throw ex;
            }
        }
        public void DisConnection()
        {
            cn.Close();
        }

    }

}
