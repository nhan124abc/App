
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
        //private string connectionString = "Data Source=DESKTOP-4EFMBF6;Initial Catalog=CuaHangHoa;Integrated Security=True;Encrypt=False";
        private string connectionString = "Data Source=NHU-PHAM\\SQLEXPRESS;Initial Catalog=CuaHangHoa;Integrated Security=True";
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
                int count = (int)cmd.ExecuteNonQuery();
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
            //public bool CheckAdmin(UserDTO user)
            //{
            //    SqlConnection conn = new SqlConnection(connectionString);
            //    conn.Open();
            //    string query = "SELECT COUNT(*) FROM NhanVien WHERE TenTK=@Username AND MK=@Password AND ChucVu=N'Quản Lý'";
            //    using (SqlCommand cmd = new SqlCommand(query, conn))
            //        {
            //            cmd.Parameters.AddWithValue("@Username", user.Username);
            //            cmd.Parameters.AddWithValue("@Password", user.Password);
            //            int count = (int)cmd.ExecuteScalar();
            //            return count > 0;
            //        }

            //}

        public bool AddEmployee(UserDTO user)
         {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "insert into NhanVien(TenNV, ChucVu, SoDienThoai, Email, TenTK, MK, DiaChi, GioiTinh, NgaySinh) values(@tennv, @chucvu, @sdt, @email, @tentk, @matkhau, @diachi, @gioitinh, @ngsinh)";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@tennv", user.TenNV);
                command.Parameters.AddWithValue("@chucvu", user.ChucVu);
                command.Parameters.AddWithValue("@sdt", user.SDT);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@tentk", user.Username);
                command.Parameters.AddWithValue("@matkhau", user.Password);
                command.Parameters.AddWithValue("@diachi", user.DiaChi);
                command.Parameters.AddWithValue("@gioitinh", user.GioiTinh);
                command.Parameters.AddWithValue("@ngsinh", user.NgaySinh);
                int count = (int)command.ExecuteNonQuery();
                return count > 0;
            }
        }
        
        public bool DeleteEmployee(UserDTO user)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "delete from NhanVien where MaNV = @manv";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@manv", user.MaNV);
                int count = (int)command.ExecuteNonQuery();
                return count > 0;
            }

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

        public DataTable SearchEmployee(UserDTO user)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select * from NhanVien where TenNV like @tennv";
                using ( SqlCommand cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@tennv", "%" + user.TenNV + "%");
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
    public class HoaDAO
    {



        //private string connectionString = "Data Source=DESKTOP-4EFMBF6;Initial Catalog=CuaHangHoa;Integrated Security=True;Encrypt=False";
        private string connectionString = "Data Source=NHU-PHAM\\SQLEXPRESS;Initial Catalog=CuaHangHoa;Integrated Security=True";
        public DataTable LoadDataFlower()

        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MaHoa, TenHoa, Gia, SoLuongTon, MoTa, HSD,HinhAnh FROM Hoa WHERE TrangThai = 1";


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
        public int GetMaHoa(int hoa)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT top 1 MaHoa from Hoa where MaHoa=@mahoa order by MaHoa DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mahoa",hoa);
                    object result = cmd.ExecuteScalar();
                    int maHoa = result != DBNull.Value ? Convert.ToInt32(result) : 0; 
                    return maHoa;
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
        public bool AddFlower(HoaDTO flowers)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "insert into Hoa (TenHoa, MoTa) values (@tenhoa, @mota)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@tenhoa", flowers.TenHoa);
                cmd.Parameters.AddWithValue("@mota", flowers.MoTa);
                int count = (int)cmd.ExecuteNonQuery();
                return count > 0;
            }
        }
        public bool DeleteFlower(HoaDTO flowers)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "update Hoa set TrangThai = 0  where MaHoa = @mahoa";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mahoa", flowers.MaHoa);
                    int count = (int)cmd.ExecuteNonQuery();
                    return count > 0;
                }
            }
        }
        public bool EditFlower(HoaDTO flowers)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "update Hoa set TenHoa = @tenhoa, MoTa = @mota where MaHoa = @mahoa";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mahoa", flowers.MaHoa);
                    cmd.Parameters.AddWithValue("@tenhoa", flowers.TenHoa);
                    cmd.Parameters.AddWithValue("@mota", flowers.MoTa);

                    int count = cmd.ExecuteNonQuery();
                    return count > 0;
                }
            }
        }
        public DataTable SearchFlower(HoaDTO flowers)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select * from Hoa where TenHoa LIKE @tenhoa";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenhoa", "%" + flowers.TenHoa + "%");
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
    public class KHDAO
    {
        //private string connectionString = "Data Source=DESKTOP-4EFMBF6;Initial Catalog=CuaHangHoa;Integrated Security=True;Encrypt=False";
        private string connectionString = "Data Source=NHU-PHAM\\SQLEXPRESS;Initial Catalog=CuaHangHoa;Integrated Security=True";
        public DataTable LoadDataKH(KHDTO user)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM KhachHang Where SoDienThoai=@sdt";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@sdt", user.SDT);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable ds = new DataTable();
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }
        public int GetMaKH(KHDTO user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT top 1 MaKH from KhachHang where SoDienThoai=@sdt order by MaKH DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@sdt", user.SDT);
                    object result = cmd.ExecuteScalar();
                    int maKH = result != DBNull.Value ? Convert.ToInt32(result) : 0; 
                    return maKH;
                }
            }
        }
        public bool AddKH(KHDTO user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO KhachHang VALUES(@ten,@sdt)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ten", user.TenKH);
                    cmd.Parameters.AddWithValue("@sdt", user.SDT);

                    int count = cmd.ExecuteNonQuery();
                    return count > 0;
                }
            }
        }
    }
    public class CTHDDAO
    {
        // private string connectionString = "Data Source=DESKTOP-4EFMBF6;Initial Catalog=CuaHangHoa;Integrated Security=True;Encrypt=False";
        private string connectionString = "Data Source=NHU-PHAM\\SQLEXPRESS;Initial Catalog=CuaHangHoa;Integrated Security=True";
        public bool AddCTHD(CTHDDTO cthd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();


                string query = "INSERT INTO ChiTietDonHang VALUES(@mahd,@mahoa,@soluong,@dongia)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mahd", cthd.MaHD);
                    cmd.Parameters.AddWithValue("@mahoa", cthd.MaHoa);
                    cmd.Parameters.AddWithValue("@soluong", cthd.SoLuong);
                    cmd.Parameters.AddWithValue("@dongia", cthd.DonGia);
                   

                    int count = (int)cmd.ExecuteNonQuery();
                    return count > 0;
                }
            }

        }




        //public bool InsertFlower(HoaDTO flowers)

    }
    public class DONHANGDAO
    {
        // private string connectionString = "Data Source=DESKTOP-4EFMBF6;Initial Catalog=CuaHangHoa;Integrated Security=True;Encrypt=False";
        private string connectionString = "Data Source=NHU-PHAM\\SQLEXPRESS;Initial Catalog=CuaHangHoa;Integrated Security=True";
        public bool AddHD(HDBanDTO user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO DonHang VALUES(@makh,@ngayban,@tongtien,@trangthai)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@makh", user.MaKH);
                    cmd.Parameters.AddWithValue("@ngayban", user.NgayBan);
                    cmd.Parameters.AddWithValue("@tongtien", user.TongTien);
                    cmd.Parameters.AddWithValue("@trangthai", user.TrangThai);
                    int count=(int)cmd.ExecuteNonQuery();
                    return count > 0;
                }
                //string query1 = "SELECT SCOPE_IDENTITY() AS MaHD;";
                //using (SqlCommand cmd1 = new SqlCommand(query1, conn))
                //{
                //    object result = cmd1.ExecuteScalar();
                //    int maHD = Convert.ToInt32(result);
                //    return maHD;
                //}
            }
        }
        public int GetMAHD()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT top 1 MaDH from DonHang order by MaDH DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    int maHD = result != DBNull.Value ? Convert.ToInt32(result) : 0; // Trả về 0 nếu là DBNull
                    
                    return maHD;
                }
            }
        }
        public DataTable LoadHD()
        {
            string query = "SELECT MaHD, MaKH, NgayBan, TongTien, TrangThai FROM HoaDonBan";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

    }
} 

