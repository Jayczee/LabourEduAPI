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

        public DataTable GetTeacher(string uid)
        {
            return SqlHelper.ExecuteTable("select * from TeacherInf where TUid=@para1",
                new SqlParameter("@para1",uid));
        }

        public DataTable GetClassByTUid(string uid)
        {
            object obj = SqlHelper.ExecuteScalar("select UserKind from UserInf where Uid=@para1",
                new SqlParameter("@para1",uid));
            int res = Convert.ToInt32(obj);
            if (res == 0 || res == 1)
                return SqlHelper.ExecuteTable("select * from ClassInf");
            else
                return SqlHelper.ExecuteTable("select * from ClassInf where CTUid=@para1",
                    new SqlParameter("@para1",uid));
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

        public int UpdateClass(ClassInf inf)
        {
            return SqlHelper.ExecuteNonQuery("update ClassInf set CNo=@para1,CName=@para2,CTUid=@para3 where CID=@para4",
                new SqlParameter("@para1",inf.CNo),
                new SqlParameter("@para2",inf.CName),
                new SqlParameter("@para3",inf.CTUid),
                new SqlParameter("@para4",inf.CID));
        }

        public DataTable GetAllTeacher()
        {
            return SqlHelper.ExecuteTable("select * from TeacherInf");
        }

        public int DeleteUser(int cid)
        {
            return SqlHelper.ExecuteNonQuery("delete from ClassInf where CID=@para1",
                new SqlParameter("@para1",cid));
        }

        public int AddClass(ClassInf inf)
        {
            DataTable dt = SqlHelper.ExecuteTable("select * from ClassInf where CNo=@para1 or CName =@para2",
                new SqlParameter("@para1",inf.CNo),
                new SqlParameter("@para2",inf.CName));
            if (dt.Rows.Count > 0)
                return 0;
            return SqlHelper.ExecuteNonQuery("insert into ClassInf(CNo,CName,CTUid)",
                new SqlParameter("@para1",inf.CNo),
                new SqlParameter("@para2",inf.CName),
                new SqlParameter("@para3",inf.CTUid));
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
