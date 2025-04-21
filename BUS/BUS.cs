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
        public int ValidateLogin(UserDTO user)
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

        public int ValidateAdmin(UserDTO user)
        {
            return userDAO.CheckAdmin(user);
        }

<<<<<<< HEAD

        public bool ValidateAddEmployee(UserDTO user)
        {
=======
        public bool ValidateAddEmployee(UserDTO user) 
        { 
>>>>>>> 714c52903e7353aa6da1ffba2c7a4cd07aacf19a
            return userDAO.AddEmployee(user);
        }
        public bool ValidateDeleteEmployee(UserDTO user)
        {
            return userDAO.DeleteEmployee(user);
        }
        public DataTable ValidateSearchEmployee(UserDTO user)
        {
            return userDAO.SearchEmployee(user);
        }

    }
    public class HoaBUS
    {
        private HoaDAO hoaDAO = new HoaDAO();
        public DataTable LoadDataFlower()
        {
            return hoaDAO.LoadDataFlower();
        }
        public DataTable LoadDataFlowerInput(HoaDTO hoa)
        {
            return hoaDAO.LoadDataFlowerinput(hoa);
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
        public int GetMaHoa(string hoa)
        {
            return hoaDAO.GetMaHoa(hoa);
        }
        public bool ValidateCheckFlower(string hoa)
        {
            return hoaDAO.CheckFlower(hoa);
        }
        public DataTable ValidateSearch(HoaDTO hoa)
        {
            return hoaDAO.SearchFlower(hoa);
        }
    }
    public class KHBUS
    {
        private KHDAO khDAO = new KHDAO();
        public DataTable LoadDataKH()
        {
            return khDAO.LoadKH();
        }
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
        public bool ValidateEditKH(KHDTO kh)
        {
            return khDAO.EditKH(kh);
        }
        public DataTable ValadateSearchKH(KHDTO kh)
        {
            return khDAO.SearchKH(kh);
        }

        //public bool ValidateDeleteKH(KHDTO kh)
        //{
        //    return khDAO.DeleteKH(kh);
        //}
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
        public DataTable LoadDataHDBan()
        {
            return hdDAO.LoadHD();
        }
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
        public DataTable LoadCTHDInput(CTHDDTO cthd)
        {
            return cthdDAO.LoadCTHDInput(cthd);
        }

    }
    public class NCCBUS
    {
        private NhaCungCapDAO nccDAO = new NhaCungCapDAO();
        public DataTable LoadDataNCC()
        {
            return nccDAO.LoadNCC();
        }
        //public bool ValidateAddNCC(NhaCungCapDTO ncc)
        //{
        //    return nccDAO.AddNCC(ncc);
        //}
        //public bool ValidateEditNCC(NhaCungCapDTO ncc)
        //{
        //    return nccDAO.EditNCC(ncc);
        //}
        //public bool ValidateDeleteNCC(NhaCungCapDTO ncc)
        //{
        //    return nccDAO.DeleteNCC(ncc);
        //}
    }
    public class NhapHangBUS
    {
        private NhapHangDAO nhDAO = new NhapHangDAO();
        public bool ValidateAddNhapHang(NhapHangDTO nh)
        {
            return nhDAO.AddHDN(nh);
        }
        public int ValidateGetMaHDN()
        {
            return nhDAO.GetMAHDN();
        }
        //public DataTable LoadDataNhapHang()
        //{
        //    return nhDAO.LoadNhapHang();
        //}
    }
    public class CTHDNBUS
    {
        private CTHDNDAO cthdnDAO = new CTHDNDAO();
        public bool ValidateAddCTHDN(CTHDNDTO cthdn)
        {
            return cthdnDAO.AddCTHDN(cthdn);
        }
        //public DataTable LoadDataCTHDN()
        //{
        //    return cthdnDAO.LoadCTHDN();
        //}
    }
}
