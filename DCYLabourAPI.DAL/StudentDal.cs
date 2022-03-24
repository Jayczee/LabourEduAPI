using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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
    }
}
