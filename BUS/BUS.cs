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
            return hoaDAO.EditFlower(fl);
        }

        public int GetMaHoa(int mahoa)
        {
            return hoaDAO.GetMaHoa(mahoa);
        }
    }
    public class KHBUS
    {
        private KHDAO khDAO = new KHDAO();
        public DataTable LoadDataKHInput(KHDTO kh)
        {
           return khDAO.LoadDataKH(kh);
        }
        public bool ValidateAddKH(KHDTO kh)
        {
            return khDAO.AddKH(kh);
        }
        public int ValidateGetMaKH(KHDTO kh)
        {
            return khDAO.GetMaKH(kh);
        }
    }
    public class HDBanBUS
    {   
        private DONHANGDAO hdDAO = new DONHANGDAO();
        public bool ValidateAddHDBan(HDBanDTO hd)
        {
            return hdDAO.AddHD(hd);
        }
        public int ValidateGetMaHD()
        {
            return hdDAO.GetMAHD();
        }
        //public DataTable LoadDataHDBan()
        //{
        //    return hdDAO.LoadDataHDBan();
        //}
        //public bool ValidateEditHDBan(HDBanDTO hd)
        //{
        //    return hdDAO.EditHDBan(hd);
        //}
        //public bool ValidateDeleteHDBan(HDBanDTO hd)
        //{
        //    return hdDAO.DeleteHDBan(hd);
        //}
    }
    public class CTHDBUS
    {
        private CTHDDAO cthdDAO = new CTHDDAO();
        public bool ValidateAddCTHD(CTHDDTO cthd)
        {
            return cthdDAO.AddCTHD(cthd);
        }
        //public DataTable LoadDataCTHD()
        //{
        //    return cthdDAO.LoadDataCTHD();
        //}
        //public bool ValidateEditCTHD(CTHDDTO cthd)
        //{
        //    return cthdDAO.EditCTHD(cthd);
        //}
        //public bool ValidateDeleteCTHD(CTHDDTO cthd)
        //{
        //    return cthdDAO.DeleteCTHD(cthd);
        //}

    }
}
