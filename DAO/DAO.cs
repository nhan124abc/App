﻿
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
        private string connectionString = "Data Source=NHU-PHAM\\SQLEXPRESS;Initial Catalog=CuaHangBanHoa;Integrated Security=True";
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
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                string query = "SELECT COUNT(*) FROM NhanVien WHERE TenTK=@Username AND MK=@Password AND ChucVu=N'Quản Lý'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@Password", user.Password);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }

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


    }
        public class HoaDAO
        {
        //private string connectionString = "Data Source=DESKTOP-4EFMBF6;Initial Catalog=CuaHangHoa;Integrated Security=True;Encrypt=False";
        private string connectionString = "Data Source=NHU-PHAM\\SQLEXPRESS;Initial Catalog=CuaHangBanHoa;Integrated Security=True";
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

