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
    public class StudentDal
    {
        public DataTable GetStuByCardNum(string cardnum)
        {
            return SqlHelper.ExecuteTable("select * from Student where SCardNum = @para1",
                new SqlParameter("@para1",cardnum));
        }

        public DataTable GetStusByCNo(int cNo)
        {
            return SqlHelper.ExecuteTable("select * from Student where SCNo=@para1",
                new SqlParameter("@para1",cNo));
        }

        public int AddStu(Student s)
        {
            if (s.SCardNum.Trim() != "")
            {
                DataTable dt = SqlHelper.ExecuteTable("select * from Student where SCardNum=@para1",
                    new SqlParameter("@para1",s.SCardNum));
                if (dt.Rows.Count > 0)
                    return 0;
                else
                {
                    SqlHelper.ExecuteNonQuery("insert into Student(SName,SSex,SCardNum,SCNo,SYear)values(@p1,@p2,@p3,@p4,@p5)",
                        new SqlParameter("@p1",s.SName),
                        new SqlParameter("@p2",s.SSex),
                        new SqlParameter("@p3",s.SCardNum),
                        new SqlParameter("@p4",s.SCNo),
                        new SqlParameter("@p5",s.SYear));
                    return int.Parse(SqlHelper.ExecuteScalar("select SID from student where SCardNum = @para1",
                        new SqlParameter("@para1",s.SCardNum)).ToString());
                }
            }
            else
            {
                SqlHelper.ExecuteNonQuery("insert into Student(SName,SSex,SCardNum,SCNo,SYear)values(@p1,@p2,@p3,@p4,@p5)",
                        new SqlParameter("@p1", s.SName),
                        new SqlParameter("@p2", s.SSex),
                        new SqlParameter("@p3", s.SCardNum),
                        new SqlParameter("@p4", s.SCNo),
                        new SqlParameter("@p5", s.SYear));
                return int.Parse(SqlHelper.ExecuteScalar("select SID from student where SName = @para1 and SSex=@para2 and SCNo =@para3 and SYear=@para4",
                    new SqlParameter("@para1", s.SCardNum),
                    new SqlParameter("@para2",s.SSex),
                    new SqlParameter("@para3",s.SCNo),
                    new SqlParameter("@para4",s.SYear)).ToString());
            }
        }

        public int DeleteStu(int sid)
        {
            return SqlHelper.ExecuteNonQuery("delete from Student where SID=@para1",
                new SqlParameter("@para1",sid));
        }

        public int UpdateStu(Student s)
        {
            DataTable dt = SqlHelper.ExecuteTable("select * from Student where SCardNum=@para1",
                new SqlParameter("@para1",s.SCardNum));
            if (dt.Rows.Count > 0 && int.Parse(dt.Rows[0]["SID"].ToString()) != s.SID)
            {
                return 0;
            }
            else
                return SqlHelper.ExecuteNonQuery("update Student set SName=@para1,SSex=@para2,SCardNum=@para3,SCNo=@para4,SYear=@para5 where SID=@para6",
                    new SqlParameter("@para1",s.SName),
                    new SqlParameter("@para2",s.SSex),
                    new SqlParameter("@para3",s.SCardNum),
                    new SqlParameter("@para4",s.SCNo),
                    new SqlParameter("@para5",s.SYear),
                    new SqlParameter("@para6",s.SID));
        }
    }
}
