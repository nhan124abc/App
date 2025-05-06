
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{

    public class UserDAO
    {
       // private string connectionString = "Data Source=DESKTOP-4EFMBF6;Initial Catalog=CuaHangHoa;Integrated Security=True;Encrypt=False";
       private string connectionString = "Data Source=NHU-PHAM\\SQLEXPRESS;Initial Catalog=CuaHangHoa;Integrated Security=True";
        public int  CheckLogin(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MaNV FROM NhanVien WHERE TenTK=@Username AND MK=@Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    object result = cmd.ExecuteScalar();
                    int maNV = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    return maNV;
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

        public int CheckAdmin(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MaNV FROM NhanVien WHERE TenTK=@Username AND MK=@Password AND LTRIM(RTRIM(ChucVu)) = N'Quản Lý'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);


                    object result = cmd.ExecuteScalar();
                    int maNV = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    return maNV;

               

                }

            }
        }

        public DataTable SearchEmployee(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select * from NhanVien where TenNV like @tennv";
                using (SqlCommand cmd = new SqlCommand(query, conn))
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
                string query = "SELECT MaHoa, TenHoa, Gia, SoLuongTon, MoTa, HSD, HinhAnh FROM Hoa WHERE TrangThai = 1";


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
                    cmd.Parameters.AddWithValue("@mahoa", "%"+hoa+"%");
                    object result = cmd.ExecuteScalar();
                    int maHoa = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    return maHoa;
                }
            }
        }
        public int GetMaHoa(string hoa)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT top 1 MaHoa from Hoa where TenHoa like @tenhoa order by MaHoa DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenhoa", "%" + hoa + "%");
                    object result = cmd.ExecuteScalar();
                    int maHoa = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    return maHoa;
                }
            }
        }
        public int LoadDataFlowerinput(int hoa)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT top 1 SoLuongTon FROM Hoa WHERE MaHoa=@Mahoa ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Mahoa", hoa);

                    object result = cmd.ExecuteScalar();
                    int sl = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    return sl;
                }
            }
        }
        public bool CheckFlower(string hoa)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT count(*) FROM Hoa WHERE TenHoa like @tenhoa and TrangThai=1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenhoa", "%"+hoa+"%");
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public bool AddFlower(HoaDTO flowers)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "insert into Hoa (TenHoa, MoTa,HinhAnh,Gia,SoLuongTon) values (@tenhoa, @mota,@hinhanh,@dongia,@soluong)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@tenhoa", flowers.TenHoa);
                cmd.Parameters.AddWithValue("@mota", flowers.MoTa);
                cmd.Parameters.AddWithValue("@hinhanh", flowers.HinhAnh);
                cmd.Parameters.AddWithValue("@dongia", flowers.DonGia);
                cmd.Parameters.AddWithValue("@soluong", flowers.SoLuong);
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
                string query = "select MaHoa, TenHoa, Gia, SoLuongTon, MoTa, HSD, HinhAnh from Hoa where TenHoa LIKE @tenhoa and TrangThai=1";
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
        public bool UpdateFlower(HoaDTO flowers)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "update Hoa set SoLuongTon = SoLuongTon-@soluong where MaHoa = @mahoa";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@soluong", flowers.SoLuong);
                    cmd.Parameters.AddWithValue("@mahoa", flowers.MaHoa);
                    int count = (int)cmd.ExecuteNonQuery();
                    return count > 0;
                }
            }
        }
        public bool UpdateFlowerNH(HoaDTO flowers)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "update Hoa set SoLuongTon = SoLuongTon+@soluong , HinhAnh=@hinhanh ,Gia=@gia where MaHoa = @mahoa";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@soluong", flowers.SoLuong);
                    cmd.Parameters.AddWithValue("@mahoa", flowers.MaHoa);
                    cmd.Parameters.AddWithValue("@hinhanh", flowers.HinhAnh);
                    cmd.Parameters.AddWithValue("@gia", flowers.DonGia);
                    int count = (int)cmd.ExecuteNonQuery();
                    return count > 0;
                }
            }
        }

    }
    public class KHDAO
    {
        //private string connectionString = "Data Source=DESKTOP-4EFMBF6;Initial Catalog=CuaHangHoa;Integrated Security=True;Encrypt=False";
        private string connectionString = "Data Source=NHU-PHAM\\SQLEXPRESS;Initial Catalog=CuaHangHoa;Integrated Security=True";
        
        public DataTable LoadKH()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT MaKH,TenKH,SoDienThoai FROM KhachHang where TrangThai=1";
            using(SqlCommand cmd = new SqlCommand(query,conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable ds = new DataTable();
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }
        public DataTable LoadDataKH(KHDTO user)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT MaKH,TenKH,SoDienThoai FROM KhachHang Where SoDienThoai = @sdt and TrangThai=1";
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
                string query = "SELECT top 1 MaKH from KhachHang where SoDienThoai = @sdt and TrangThai=1 order by MaKH DESC";
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
                string query = "INSERT INTO KhachHang (TenKH,SoDienThoai,TrangThai)VALUES(@ten,@sdt,1)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ten", user.TenKH);
                    cmd.Parameters.AddWithValue("@sdt", user.SDT);

                    int count = cmd.ExecuteNonQuery();
                    return count > 0;
                }
            }
        }

        public bool EditKH(KHDTO user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "update KhachHang set TenKH = @tenkh, SoDienThoai = @sdt where MaKH = @makh and TrangThai=1";
                using(SqlCommand cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@tenkh", user.TenKH);
                    cmd.Parameters.AddWithValue("@sdt", user.SDT);
                    cmd.Parameters.AddWithValue("@makh", user.MaKH);

                    int count = cmd.ExecuteNonQuery();
                    return count > 0;
                }
            }
        }

        public DataTable SearchKH(KHDTO user)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select MaKH,TenKH,SoDienThoai from KhachHang where TenKH like @tenkh and TrangThai=1";
                using( SqlCommand cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@tenkh", "%" + user.TenKH + "%");
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable ds = new DataTable();
                        adapter.Fill(ds);
                        return ds;
                    }
                }
            }
        }

        public bool CancelKH(KHDTO user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "update KhachHang set TrangThai =0 where MaKH = @makh";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@makh", user.MaKH);

                    int count = cmd.ExecuteNonQuery();
                    return count > 0;
                }
            }
        }


    }
    public class CTHDDAO
    {
       //private string connectionString = "Data Source=DESKTOP-4EFMBF6;Initial Catalog=CuaHangHoa;Integrated Security=True;Encrypt=False";
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
        public DataTable LoadCTHDInput(CTHDDTO cthd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Select * from ChiTietDonHang where MaDH=@madh";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@madh", cthd.MaHD);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;


                }


            }
        }

    }
    public class DONHANGDAO
    {
        //private string connectionString = "Data Source=DESKTOP-4EFMBF6;Initial Catalog=CuaHangHoa;Integrated Security=True;Encrypt=False";
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
                    int count = (int)cmd.ExecuteNonQuery();
                    return count > 0;
                }
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
            string query = "SELECT MaDH, MaKH, NgayDatHang, TongTien, TrangThai FROM DonHang";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public bool CancelHD(HDBanDTO hd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "update DonHang set TrangThai = N'Đã hủy' where MaDH = @madh";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@madh", hd.MaHD);

                    int count = cmd.ExecuteNonQuery();
                    return count > 0;
                }
            }
        }
        public Double GetTotalPrice(string loaiLoc, DateTime ngay)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "";

                if (loaiLoc == "Ngày")
                {
                    query = "SELECT SUM(TongTien) FROM DonHang WHERE CAST(NgayDatHang AS DATE) = @ngay and TrangThai like N'Đã Thanh Toán'";
                }
                else if (loaiLoc == "Tháng")
                {
                    query = "SELECT SUM(TongTien) FROM DonHang WHERE MONTH(NgayDatHang) = @thang AND YEAR(NgayDatHang) = @nam and TrangThai like N'Đã Thanh Toán'";
                }
                else if (loaiLoc == "Năm")
                {
                    query = "SELECT SUM(TongTien) FROM DonHang WHERE YEAR(NgayDatHang) = @nam and TrangThai like N'Đã Thanh Toán'";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (loaiLoc == "Ngày")
                        cmd.Parameters.AddWithValue("@ngay", ngay.Date);
                    else if (loaiLoc == "Tháng")
                    {
                        cmd.Parameters.AddWithValue("@thang", ngay.Month);
                        cmd.Parameters.AddWithValue("@nam", ngay.Year);
                    }
                    else if (loaiLoc == "Năm")
                    {
                        cmd.Parameters.AddWithValue("@nam", ngay.Year);
                    }

                    object result = cmd.ExecuteScalar();
                    double totalPrice = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                    return totalPrice;
                }
            }
        }

    }
    public class NhaCungCapDAO
    {
        //private string connectionString = "Data Source=DESKTOP-4EFMBF6;Initial Catalog=CuaHangHoa;Integrated Security=True;Encrypt=False";
        private string connectionString = "Data Source=NHU-PHAM\\SQLEXPRESS;Initial Catalog=CuaHangHoa;Integrated Security=True";
        public DataTable LoadNCC()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MaNCC,TenNCC FROM NhaCungCap where TrangThai=1";
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
        public DataTable LoadNCCAll()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MaNCC,TenNCC,DiaChi,SoDienThoai,Email FROM NhaCungCap where TrangThai = 1";
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
        public bool AddNCC(NhaCungCapDTO ncc)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO NhaCungCap (TenNCC, DiaChi, SoDienThoai, Email, TrangThai) VALUES(@tenncc, @diachi, @sdt, @email, 1)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenncc", ncc.TenNCC);
                    cmd.Parameters.AddWithValue("@diachi", ncc.DiaChi);
                    cmd.Parameters.AddWithValue("@sdt", ncc.SDT);
                    cmd.Parameters.AddWithValue("@email", ncc.Email);
                    int count = (int)cmd.ExecuteNonQuery();
                    return count > 0;
                }
            }
        }
        public bool EditNCC(NhaCungCapDTO ncc) {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "update NhaCungCap SET TenNCC =@tenncc ,DiaChi=@diachi,SoDienThoai =@sdt,Email=@email where MaNCC=@mancc";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenncc", ncc.TenNCC);
                    cmd.Parameters.AddWithValue("@mancc", ncc.MaNCC);
                    cmd.Parameters.AddWithValue("@diachi", ncc.DiaChi);
                    cmd.Parameters.AddWithValue("@sdt", ncc.SDT);
                    cmd.Parameters.AddWithValue("@email", ncc.Email);
                    int count = (int)cmd.ExecuteNonQuery();
                    return count > 0;
                }
            }

        }
        public bool CancelNCC(NhaCungCapDTO ncc)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "update NhaCungCap set TrangThai = 0 where MaNCC = @mancc";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mancc", ncc.MaNCC);
                    int count = cmd.ExecuteNonQuery();
                    return count > 0;
                }
            }
        }
        public DataTable SearchNCC(NhaCungCapDTO ncc)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select MaNCC,TenNCC,DiaChi,SoDienThoai,Email from NhaCungCap where TenNCC like @tenncc and TrangThai=1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenncc", "%" + ncc.TenNCC + "%");
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
    public class CTHDNDAO
    {
        //private string connectionString = "Data Source=DESKTOP-4EFMBF6;Initial Catalog=CuaHangHoa;Integrated Security=True;Encrypt=False";
        private string connectionString = "Data Source=NHU-PHAM\\SQLEXPRESS;Initial Catalog=CuaHangHoa;Integrated Security=True";
        public bool AddCTHDN(CTHDNDTO cthdn)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO ChiTietNhapHang (MaNH, MaHoa, SoLuong, GiaNhap,NgayNhap) VALUES(@mahdn, @mahoa, @soluong, @dongia,@ngaynhap)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mahdn", cthdn.MaHDN);
                    cmd.Parameters.AddWithValue("@mahoa", cthdn.MaHoa);
                    cmd.Parameters.AddWithValue("@soluong", cthdn.SoLuong);
                    cmd.Parameters.AddWithValue("@dongia", cthdn.DonGia);
                    cmd.Parameters.AddWithValue("@ngaynhap", cthdn.NgayNhap);
                    int count = (int)cmd.ExecuteNonQuery();
                    return count > 0;
                }
            }
        }
        public DataTable LoadCTHDNInput(NhapHangDTO nh)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Select * from ChiTietNhapHang where MaNH=@madhn";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@madhn", nh.MaHDN);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
    public class NhapHangDAO
    {
        //private string connectionString = "Data Source=DESKTOP-4EFMBF6;Initial Catalog=CuaHangHoa;Integrated Security=True;Encrypt=False";
        private string connectionString = "Data Source=NHU-PHAM\\SQLEXPRESS;Initial Catalog=CuaHangHoa;Integrated Security=True";
        public bool AddHDN(NhapHangDTO NH)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO NhapHang VALUES(@mancc,@manv,@ngaynhap,@tongtien,'Thành Công')";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mancc", NH.MaNCC);
                    cmd.Parameters.AddWithValue("@manv", NH.MaNV);
                    cmd.Parameters.AddWithValue("@ngaynhap", NH.NgayNhap);
                    cmd.Parameters.AddWithValue("@tongtien", NH.TongTien);
                    int count = (int)cmd.ExecuteNonQuery();
                    return count > 0;
                }
            }
        }
        public int GetMAHDN()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT top 1 MaNH from NhapHang order by MaNH DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    int maHDN = result != DBNull.Value ? Convert.ToInt32(result) : 0; // Trả về 0 nếu là DBNull

                    return maHDN;
                }
            }
        }
        public DataTable LoadHDN()
        {
            string query = "SELECT * FROM NhapHang";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public bool CancelHDN(NhapHangDTO nh)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "update NhapHang set TrangThai = N'Đã hủy' where MaNH = @manh";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@manh", nh.MaHDN);

                    int count = cmd.ExecuteNonQuery();
                    return count > 0;
                }
            }
        }
        public double GetTotal(string loaiLoc, DateTime ngay)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "";

                if (loaiLoc == "Ngày")
                {
                    query = "SELECT SUM(TongTien) FROM NhapHang WHERE CAST(NgayNhap AS DATE) = @ngay and TrangThai like N'Thành Công'";
                }
                else if (loaiLoc == "Tháng")
                {
                    query = "SELECT SUM(TongTien) FROM NhapHang WHERE MONTH(NgayNhap) = @thang AND YEAR(NgayNhap) = @nam and TrangThai like N'Thành Công'";
                }
                else if (loaiLoc == "Năm")
                {
                    query = "SELECT SUM(TongTien) FROM NhapHang WHERE YEAR(NgayNhap) = @nam and TrangThai like N'Thành Công'";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (loaiLoc == "Ngày")
                        cmd.Parameters.AddWithValue("@ngay", ngay.Date);
                    else if (loaiLoc == "Tháng")
                    {
                        cmd.Parameters.AddWithValue("@thang", ngay.Month);
                        cmd.Parameters.AddWithValue("@nam", ngay.Year);
                    }
                    else if (loaiLoc == "Năm")
                    {
                        cmd.Parameters.AddWithValue("@nam", ngay.Year);
                    }
                    object result = cmd.ExecuteScalar();
                    double totalPrice = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                    return totalPrice;
                }
            }

        }
    }
} 

