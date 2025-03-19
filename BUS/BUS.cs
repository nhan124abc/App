using DAO;
using DTO;
using System;
using System.Collections.Generic;
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
    }
}
