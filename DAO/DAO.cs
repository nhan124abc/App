
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UserDAO
    {
        private string connectionString = "Data Source=DESKTOP-4EFMBF6;Initial Catalog=CuaHangHoa;Integrated Security=True;Encrypt=False";
        public bool CheckLogin(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM NhanVien WHERE TenTK=@Username AND MK=@Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public bool EditNV(UserDTO user)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "update NhanVien set TenNV=@Hoten ,ChucVu=@chucvu,SoDienThoai=@SDT,Email=@email," +
                "DiaChi=@diachi,GioiTinh=@gioitinh,NgaySinh=@ngaysinh,TenTK=@tentk,MK=@mk where MaNV=@manv";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Hoten", user.TenNV);
                cmd.Parameters.AddWithValue("@chucvu", user.ChucVu);
                cmd.Parameters.AddWithValue("@SDT", user.SDT);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@diachi", user.DiaChi);
                cmd.Parameters.AddWithValue("@gioitinh", user.GioiTinh);
                cmd.Parameters.AddWithValue("@ngaysinh", user.NgaySinh);
                cmd.Parameters.AddWithValue("@tentk", user.Username);
                cmd.Parameters.AddWithValue("@mk", user.Password);
                cmd.Parameters.AddWithValue("@manv", user.MaNV);
                int count =(int) cmd.ExecuteNonQuery();
                return count > 0;
            }
        }
            public DataTable LoadNV()
            {
                string query = "SELECT MaNV, TenNV, ChucVu, SoDienThoai, Email, DiaChi, " + "CASE WHEN GioiTinh = 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh," + "NgaySinh,TenTK,MK FROM NhanVien";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        public bool CheckAdmin(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM NhanVien WHERE TenTK=@Username AND MK=@Password AND LTRIM(RTRIM(ChucVu)) = N'Quản Lý'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);

                    int count = (int)cmd.ExecuteScalar(); // Dùng ExecuteScalar
                    return count > 0;
                }
            }
        }

    }
    public class HoaDAO
        {
            private string connectionString = "Data Source=DESKTOP-4EFMBF6;Initial Catalog=CuaHangHoa;Integrated Security=True;Encrypt=False";
            public DataTable LoadDataFlower()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Hoa";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable ds = new DataTable();
                            adapter.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
            public DataTable LoadDataFlowerinput(HoaDTO hoa)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Hoa WHERE MaHoa=@Mahoa AND TenHoa=@tenhoa";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Mahoa", hoa.MaHoa);
                        cmd.Parameters.AddWithValue("@tenhoa", hoa.TenHoa);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable ds = new DataTable();

                            adapter.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
        }

    } 

