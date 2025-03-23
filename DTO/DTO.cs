using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string TenNV { get; set; }
        public string ChucVu { get; set; }
        public int MaNV { get; set; }
        public int GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
    }
    public class  HoaDTO
    {
        public int MaHoa { get; set; }
        public string TenHoa { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public string MauSac { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
    }
    
}
