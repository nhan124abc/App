using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class UserBUS
    {
        private UserDAO userDAO = new UserDAO();
        public bool ValidateLogin(UserDTO user)
        {
            return userDAO.CheckLogin(user);
        }
        public bool ValidateEditNV(UserDTO user)
        {
            return userDAO.EditNV(user);
        }
        public DataTable LoadNV()
        {
            return userDAO.LoadNV();
        }
       
         
    }
    public class HoaBUS
    {
        private HoaDAO hoaDAO = new HoaDAO();
        public DataTable LoadDataFlower()
        {
            return hoaDAO.LoadDataFlower();
        }
    }
}
