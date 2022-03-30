using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DCYLabourAPI.Model;

namespace DCYLabourAPI.DAL
{
    public class UserDal
    {
        public DataTable UserLogin(string uid, string pwd)
        {
            return SqlHelper.ExecuteTable("select * from UserInf where Uid=@para1 and pwd=@para2",
                new SqlParameter("@para1",uid),
                new SqlParameter("@para2",pwd));
        }

        public bool CheckUser(string uid)
        {
            DataTable dt = SqlHelper.ExecuteTable("select * from user where Uid=@para1",
                new SqlParameter("@para1",uid));
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

        public bool UserReg(UserRegInf regInf)
        {
            int res = SqlHelper.ExecuteNonQuery("insert into UserInf(Uid,Pwd,UserKind)values(@para1,@para2,@para3)",
                new SqlParameter("@para1",regInf.Uid),
                new SqlParameter("@para2",regInf.Pwd),
                new SqlParameter("@para3",regInf.UserKind));
            int res2 = SqlHelper.ExecuteNonQuery("insert into TeacherInf(TName,TUid,TBirth,TPhoneNum,TSex)values(@para1,@para2,@para3,@para4,@para5)",
                new SqlParameter("@para1",regInf.TName),
                new SqlParameter("@para2", regInf.Uid),
                new SqlParameter("@para3", regInf.TBirth),
                new SqlParameter("@para4", regInf.TPhoneNum),
                new SqlParameter("@para5", regInf.TSex));
            if (res > 0 && res2 > 0)
                return true;
            return false;
        }

        public int DeleteUser(string uid)
        {
            int sum = 0;
            sum += SqlHelper.ExecuteNonQuery("delete from UserInf where Uid=@para1",
                new SqlParameter("@para1",uid));
            sum += SqlHelper.ExecuteNonQuery("delete from TeacherInf where TUid=@para1",
                new SqlParameter("@para1",uid));
            return sum;
        }

        public int UserUpdate(User user)
        {
            DataTable dt = SqlHelper.ExecuteTable("select * from UserInf where Uid=@para1",
                new SqlParameter("@para1",user.Uid));
            if (dt.Rows.Count > 0 && dt.Rows[0]["Pwd"].ToString() == user.Pwd)
                return 0;
            else
                return SqlHelper.ExecuteNonQuery("update UserInf set Pwd=@para2 where Uid=@para1",
                    new SqlParameter("@para1",user.Uid),
                    new SqlParameter("@para2",user.Pwd)) ;
        }
    }
}
