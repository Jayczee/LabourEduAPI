using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DCYLabourAPI.Model;
using System.Data;
using DCYLabourAPI.DAL;

namespace DCYLabourAPI.BLL
{
    public class UserBll
    {
        UserDal udal = new();
        public User UserLogin(string uid,string pwd)
        {
            DataTable dt = udal.UserLogin(uid, pwd);
            if (dt == null || dt.Rows.Count <= 0)
                return null;
            User user = new();
            user.Id=int.Parse(dt.Rows[0]["Id"].ToString());
            user.Uid=dt.Rows[0]["Uid"].ToString();
            user.Pwd=dt.Rows[0]["Pwd"].ToString();
            user.Userkind= int.Parse(dt.Rows[0]["UserKind"].ToString());
            return user;
        }

        public int UserReg(UserRegInf regInf)
        {
            if (udal.CheckUser(regInf.Uid))
                return 0;
            if (udal.UserReg(regInf))
                return 1;
            return 2;
        }

        public int UserUpdate(User user)
        {
            return udal.UserUpdate(user);
        }
    }
}
