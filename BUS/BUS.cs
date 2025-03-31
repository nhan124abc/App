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
       
        public bool ValidateAdmin(UserDTO user)
        {
            return userDAO.CheckAdmin(user);
        }

        public bool ValidateAddEmployee(UserDTO user) 
        { 
            return userDAO.AddEmployee(user);
        }
        public bool ValidateDeleteEmployee(UserDTO user)
        {
            return userDAO.DeleteEmployee(user);
        }
    }
    public class HoaBUS
    {
        private HoaDAO hoaDAO = new HoaDAO();
        public DataTable LoadDataFlower()
        {
            return hoaDAO.LoadDataFlower();
        }
        public bool AddDataFlower(HoaDTO fl)
        {
            return hoaDAO.AddFlower(fl);
        }
        public bool DeleteDataFlower(HoaDTO fl)
        {
            return hoaDAO.DeleteFlower(fl);
        }
        public bool InsertDataFlower(HoaDTO fl)
        {
            return hoaDAO.InsertFlower(fl);
        }
    }
}
