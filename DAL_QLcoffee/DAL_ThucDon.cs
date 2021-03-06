using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QLcoffee;

namespace DAL_QLcoffee
{
    public class DAL_ThucDon : DataConnect
    {
        // Bo sung 3 ham:
        public DataTable DanhSachTenMon()
        {
            try
            {
                connection.Open();
                SqlCommand scm = new SqlCommand();
                scm.CommandType = CommandType.StoredProcedure;
                scm.CommandText = "DanhSanhMon";
                scm.Connection = connection;
                DataTable tb = new DataTable();
                tb.Load(scm.ExecuteReader());
                return tb;
            }
            finally
            {
                connection.Close();
            }
        }
        public string DonGiaMon(string tenmon)
        {
            try
            {
                connection.Open();
                SqlCommand scm = new SqlCommand();
                scm.CommandType = CommandType.StoredProcedure;
                scm.CommandText = "DonGiaMon";
                scm.Parameters.AddWithValue("@tenmon", tenmon);
                scm.Connection = connection;
                return scm.ExecuteScalar().ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show("Tên món không hợp lệ! Vui lòng kiểm tra lại." + x.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return "0";
        }
        public bool ThanhToanTien(string tenkh, string tennv, DateTime ngaylap, float tongtien)
        {
            try
            {
                connection.Open();
                SqlCommand scm = new SqlCommand();
                scm.CommandType = CommandType.StoredProcedure;
                scm.CommandText = "ThanhToan";
                scm.Parameters.AddWithValue("@TenKH", tenkh);
                scm.Parameters.AddWithValue("@TenNV", tennv);
                scm.Parameters.AddWithValue("@Ngaylap", ngaylap);
                scm.Parameters.AddWithValue("@TongTien", tongtien);
                scm.Connection = connection;
                if (scm.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Khách hàng không hợp lệ! Vui lòng load lại giao diện hóa đơn.");
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        // Get Danh sach thuc don
        public DataTable DSThucDon()
        {
            try
            {
                connection.Open();
                SqlCommand scm = new SqlCommand();
                scm.CommandType = CommandType.StoredProcedure;
                scm.CommandText = "DanhSachTD";
                scm.Connection = connection;
                DataTable tb = new DataTable();
                tb.Load(scm.ExecuteReader());
                return tb;
            }
            finally
            {
                connection.Close();
            }
        }

        // Them mot thuc don moi
        public bool LuuThucDon(DTO_ThucDon td)
        {
            try
            {
                connection.Open();
                SqlCommand scm = new SqlCommand();
                scm.CommandType = CommandType.StoredProcedure;
                scm.CommandText = "InsertTD";
                scm.Parameters.AddWithValue("@TenTD", td.TenTD);
                scm.Parameters.AddWithValue("@Gia",  td.Gia);
                scm.Parameters.AddWithValue("@HinhAnh", td.HinhAnh);
                scm.Connection = connection;
                if (scm.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        // Cap nhat thuc don
        public bool SuaThucDon(DTO_ThucDon td)
        {
            try
            {
                connection.Open();
                SqlCommand scm = new SqlCommand();
                scm.CommandType = CommandType.StoredProcedure;
                scm.CommandText = "SuaTD";
                scm.Parameters.AddWithValue("@MaTD", td.MaTD);
                scm.Parameters.AddWithValue("@TenTD", td.TenTD);
                scm.Parameters.AddWithValue("@Gia", td.Gia);
                scm.Parameters.AddWithValue("@HinhAnh", td.HinhAnh);
                scm.Connection = connection;
                if (scm.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public bool XoaThucDon(string MaTD)
        {
            try
            {
                connection.Open();
                SqlCommand scm = new SqlCommand();
                scm.CommandType = CommandType.StoredProcedure;
                scm.CommandText = "DeleteTD";
                scm.Parameters.AddWithValue("@MaTD", MaTD);
                scm.Connection = connection;
                if (scm.ExecuteNonQuery() > 0)
                    return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        // Tim kiem thuc don
        public DataTable TimKiemThucDon(string tenTD)
        {
            try
            {
                connection.Open();
                SqlCommand scm = new SqlCommand();
                scm.CommandType = CommandType.StoredProcedure;
                scm.CommandText = "SearchTD";
                scm.Parameters.AddWithValue("@TenTD", tenTD);
                scm.Connection = connection;
                DataTable tb = new DataTable();
                tb.Load(scm.ExecuteReader());
                return tb;
            }
            finally
            {
                connection.Close();
            }
        }

        // Xem thống kê
        public DataTable XemThongKe(DateTime ngayBD, DateTime ngayKT)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "XemThongKe";
                command.Parameters.AddWithValue("ngaybd", ngayBD);
                command.Parameters.AddWithValue("ngaykt", ngayKT);
                command.Connection = connection;
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                return table;
            }
            finally
            {
                connection.Close();
            }
        }
        //BoSungThongKe
        public DataTable XemTopMon(DateTime ngayBD, DateTime ngayKT)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "XemTopMon";
                command.Parameters.AddWithValue("ngaybd", ngayBD);
                command.Parameters.AddWithValue("ngaykt", ngayKT);
                command.Connection = connection;
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                return table;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool LuuHD(int mahd, string tentd, int soluong)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "LuuHD";
                command.Parameters.AddWithValue("@mahd", mahd);
                command.Parameters.AddWithValue("@tentd", tentd);
                command.Parameters.AddWithValue("@soluong", soluong);
                command.Connection = connection;
                if (command.ExecuteNonQuery() > 0) 
                {
                    return true;
                }
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public string LayMaHD()
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "LayMaHD";
                command.Connection = connection;
                return Convert.ToString(command.ExecuteScalar());
            }
            catch (Exception)
            {
                return "1";
            }
            finally
            {
                connection.Close();
            }
        }
        public DataTable XemchitietHD(int mahd)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "XemchitietHD";
                command.Connection = connection;
                command.Parameters.AddWithValue("@mahd", mahd);
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                return table;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
