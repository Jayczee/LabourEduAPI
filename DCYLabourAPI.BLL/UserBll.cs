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

        public int DeleteUser(string uid)
        {
            return udal.DeleteUser(uid);
        }

        public Teacher GetTeacher(string uid)
        {
            DataTable dt = udal.GetTeacher(uid);
            if (dt.Rows.Count == 0)
                return null;
            else
            {
                Teacher t = new();
                t.TeacherID = int.Parse(dt.Rows[0]["TeacherID"].ToString());
                t.TUid = dt.Rows[0]["TUid"].ToString();
                t.TCardNum = dt.Rows[0]["TCardNum"].ToString();
                t.TPhoneNum = dt.Rows[0]["TPhoneNum"].ToString();
                t.TSex = dt.Rows[0]["TSex"].ToString();
                return t;
            }
        }

        public List<ClassInf> GetClassByTUid(string uid)
        {
            DataTable dt = udal.GetClassByTUid(uid);
            if (dt.Rows.Count == 0)
                return null;
            else
            {
                List<ClassInf> list = new List<ClassInf>();
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    ClassInf inf = new();
                    inf.CID = int.Parse(dt.Rows[i]["CID"].ToString());
                    inf.CNo = int.Parse(dt.Rows[i]["CNo"].ToString());
                    inf.CName = dt.Rows[i]["CName"].ToString();
                    inf.CTUid=dt.Rows[i]["CTUid"].ToString() ;
                    list.Add(inf);
                }
                return list;
            }
        }

        public int AddClass(ClassInf inf)
        {
            return udal.AddClass(inf);
        }

        public int UpdateClass(ClassInf inf)
        {
            return udal.UpdateClass(inf);
        }

        public int DeleteClass(int cid)
        {
            return udal.DeleteUser(cid);
        }

        public List<Teacher> GetAllTeacher()
        {
            DataTable dt = udal.GetAllTeacher();
            if (dt.Rows.Count == 0)
                return null;
            else
            {
                List<Teacher> list = new();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Teacher t = new();
                    t.TeacherID = int.Parse(dt.Rows[i]["TeacherID"].ToString());
                    t.Tname = dt.Rows[i]["TName"].ToString();
                    t.TUid = dt.Rows[i]["TUid"].ToString();
                    t.TBirth = dt.Rows[i]["TBirth"].ToString();
                    t.TCardNum = dt.Rows[i]["TCardNum"].ToString();
                    t.TPhoneNum = dt.Rows[i]["TPhoneNum"].ToString();
                    t.TSex = dt.Rows[i]["TSex"].ToString();
                    list.Add(t);
                }
                return list;
            }
        }
    }   
}
