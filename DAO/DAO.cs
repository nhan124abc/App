using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
