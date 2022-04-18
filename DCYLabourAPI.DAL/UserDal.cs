using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
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
            DataTable dt = SqlHelper.ExecuteTable("select * from UserInf where Uid=@para1",
                new SqlParameter("@para1",uid));
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

        public int UserReg(UserRegInf regInf)
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
            int id = int.Parse(SqlHelper.ExecuteScalar("select TeacherID from TeacherInf where TUid=@para1",
                new SqlParameter("@para1", regInf.Uid)).ToString());
            if (res > 0 && res2 > 0)
                return id;
            return -1;
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
            int res= SqlHelper.ExecuteNonQuery("insert into ClassInf(CNo,CName,CTUid)values(@para1,@para2,@para3)",
                new SqlParameter("@para1",inf.CNo),
                new SqlParameter("@para2",inf.CName),
                new SqlParameter("@para3",inf.CTUid));
            if (res > 0)
                return int.Parse(SqlHelper.ExecuteScalar("select CID from ClassInf where CNo=@para1 and CName=@para2",
                    new SqlParameter("@para1", inf.CNo),
                    new SqlParameter("@para2", inf.CName)).ToString());
            return 0;
        }

        public int UpdateCard(string uid, string card)
        {
            object obj = SqlHelper.ExecuteScalar("select * from TeacherInf where TCardNum=@para1",
                new SqlParameter("@para1",card));
            if (obj == null)
            {
                obj= SqlHelper.ExecuteScalar("select * from Student where SCardNum=@para1",
                new SqlParameter("@para1", card));
                if (obj != null)
                    return -1;
            }else
                return -1;
            return SqlHelper.ExecuteNonQuery("update TeacherInf set TCardNum=@para1 where TUid=@para2",
                new SqlParameter("@para1",card),
                new SqlParameter("@para2",uid)) ;
        }

        public int UpdateTeacher(Teacher inf)
        {
            return SqlHelper.ExecuteNonQuery("update TeacherInf set TName=@para1,TCardNum=@para2,TBirth=@para3,TPhoneNum=@para4,TSex=@para5 where TUid=@para5",
                new SqlParameter("@para1",inf.Tname),
                new SqlParameter("@para2",inf.TCardNum),
                new SqlParameter("@para3",inf.TBirth),
                new SqlParameter("@para4",inf.TPhoneNum),
                new SqlParameter("@para5",inf.TUid));
        }

        public int ResetPwd(string uid)
        {
            return SqlHelper.ExecuteNonQuery("update UserInf set Pwd='123456' where Uid=@para1",
                new SqlParameter("@para1",uid));
        }

        public int GetUserKind(string uid)
        {
            object obj = SqlHelper.ExecuteScalar("select UserKind from UserInf where Uid=@para1",
                new SqlParameter("@para1",uid));
            if (obj == null)
                return -1;
            else
                return int.Parse(obj.ToString());
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
