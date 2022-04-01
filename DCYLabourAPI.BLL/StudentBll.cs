using DCYLabourAPI.Model;
using DCYLabourAPI.DAL;
using System.Data;

namespace DCYLabourAPI.BLL
{
    public class StudentBll
    {
        StudentDal sdal = new();
        public Student GetStuByCardNum(string cardnum)
        {
            DataTable dt = sdal.GetStuByCardNum(cardnum);
            if (dt == null || dt.Rows.Count <= 0)
                return null;
            Student s = new();
            s.SID = int.Parse(dt.Rows[0]["SID"].ToString());
            s.SName = dt.Rows[0]["SName"].ToString();
            s.SYear = int.Parse(dt.Rows[0]["SYear"].ToString());
            s.SCardNum = dt.Rows[0]["SCardNum"].ToString();
            s.SSex = dt.Rows[0]["SSex"].ToString();
            s.SCNo = int.Parse(dt.Rows[0]["SCNo"].ToString());
            return s;
        }

        public List<Student> GetStusByCNo(int cNo)
        {
            DataTable dt = sdal.GetStusByCNo(cNo);
            if (dt == null || dt.Rows.Count <= 0)
                return null;
            List<Student> list = new List<Student>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Student s = new();
                s.SID = int.Parse(dt.Rows[i]["SID"].ToString());
                s.SName = dt.Rows[i]["SName"].ToString();
                s.SYear = int.Parse(dt.Rows[i]["SYear"].ToString());
                s.SCardNum = dt.Rows[i]["SCardNum"].ToString();
                s.SSex = dt.Rows[i]["SSex"].ToString();
                s.SCNo = int.Parse(dt.Rows[i]["SCNo"].ToString());
                list.Add(s);
            }
            return list;
        }

        public int UpdateStu(Student s)
        {
            return sdal.UpdateStu(s);
        }

        public int AddStu(Student s)
        {
            return sdal.AddStu(s);
        }

        public int DeleteStu(int sid)
        {
            return sdal.DeleteStu(sid);
        }
    }
}
