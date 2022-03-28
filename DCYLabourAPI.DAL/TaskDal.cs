using DCYLabourAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DCYLabourAPI.DAL
{
    public class TaskDal
    {
        /// <summary>
        /// 添加任务，返回该任务ID
        /// </summary>
        /// <param name="tinf"></param>
        /// <returns></returns>
        public int AddTask(TaskInfo tinf)
        {
            int res = SqlHelper.ExecuteNonQuery("insert into LabourTaskInf(TaskName,TaskStartTime,TaskTUid,TaskClass,TaskGroup,TaskStuCapID,TaskStus,TaskDetail,Fandi,Zhengdi,Celiang,CuoShi,CuoShiShiFei,CuoShiShaChong,CuoShiJiaoGuan,CuoShiMieChong,CuoShiGuangZhao,CuoShiPenSa,ZuoWuCeLiang,TaskCon)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20)",
                new SqlParameter("@p1",tinf.TaskName),
                new SqlParameter("@p2",tinf.TaskStartTime),
                new SqlParameter("@p3",tinf.TaskTUid),
                new SqlParameter("@p4",tinf.TaskClass),
                new SqlParameter("@p5",tinf.TaskGroup),
                new SqlParameter("@p6",tinf.TaskStuCapID),
                new SqlParameter("@p7",tinf.TaskStus),
                new SqlParameter("@p8",tinf.TaskDetail),
                new SqlParameter("@p9",tinf.Fandi),
                new SqlParameter("@p10",tinf.Zhengdi),
                new SqlParameter("@p11",tinf.Celiang),
                new SqlParameter("@p12",tinf.CuoShi),
                new SqlParameter("@p13",tinf.CuoShiShiFei),
                new SqlParameter("@p14",tinf.CuoShiShaChong),
                new SqlParameter("@p15",tinf.CuoShiJiaoGuan),
                new SqlParameter("@p16",tinf.CuoShiMieChong),
                new SqlParameter("@p17",tinf.CuoShiGuangZhao),
                new SqlParameter("@p18",tinf.CuoShiPenSa),
                new SqlParameter("@p19",tinf.ZuoWuCeLiang),
                new SqlParameter("@p20",tinf.TaskCon));
            DataTable dt = SqlHelper.ExecuteTable("select * from LabourTaskInf where TaskName=@para1 and TaskTUid=@para2 and TaskGroup=@para3 and TaskStuCapID=@para4 and TaskStus=@para5 and TaskDetail=@para6",
                new SqlParameter("@para1",tinf.TaskName),
                new SqlParameter("@para2",tinf.TaskTUid),
                new SqlParameter("@para3",tinf.TaskGroup),
                new SqlParameter("@para4",tinf.TaskStuCapID),
                new SqlParameter("@para5",tinf.TaskStus),
                new SqlParameter("@para6",tinf.TaskDetail));
            return int.Parse(dt.Rows[0]["TaskID"].ToString());
        }

        public DataTable GetTaskByTUid(string uid,int userkind)
        {
            if (userkind == 0 || userkind==1)
                return SqlHelper.ExecuteTable("select * from LabourTaskInf");
            else
                return SqlHelper.ExecuteTable("select * from LabourTaskInf where TaskTUid=@para1",
                    new SqlParameter("@para1",uid));
        }

        public int DeleteTask(int taskID)
        {
            return SqlHelper.ExecuteNonQuery("delete from LabourTaskInf where taskID=@para1",
                new SqlParameter("@para1",taskID));
        }

        public int UpdateTask(TaskInfo tinf)
        {
            return SqlHelper.ExecuteNonQuery("update LabourTaskInf set TaskName=@p1,TaskStartTime=@p2,TaskTUid=@p3,TaskClass=@p4,TaskGroup=@p5,TaskStuCapID=@p6,TaskStus=@p7,TaskDetail=@p8,Fandi=@p9,Zhengdi=@p10,Celiang=@p11,CuoShi=@p12,CuoShiShiFei=@p13,CuoShiShaChong=@p14,CuoShiJiaoGuan=@p15,CuoShiMieChong=@p16,CuoShiGuangZhao=@p17,CuoShiPenSa=@p18,ZuoWuCeLiang=@p19",
                new SqlParameter("@p1", tinf.TaskName),
                new SqlParameter("@p2", tinf.TaskStartTime),
                new SqlParameter("@p3", tinf.TaskTUid),
                new SqlParameter("@p4", tinf.TaskClass),
                new SqlParameter("@p5", tinf.TaskGroup),
                new SqlParameter("@p6", tinf.TaskStuCapID),
                new SqlParameter("@p7", tinf.TaskStus),
                new SqlParameter("@p8", tinf.TaskDetail),
                new SqlParameter("@p9", tinf.Fandi),
                new SqlParameter("@p10", tinf.Zhengdi),
                new SqlParameter("@p11", tinf.Celiang),
                new SqlParameter("@p12", tinf.CuoShi),
                new SqlParameter("@p13", tinf.CuoShiShiFei),
                new SqlParameter("@p14", tinf.CuoShiShaChong),
                new SqlParameter("@p15", tinf.CuoShiJiaoGuan),
                new SqlParameter("@p16", tinf.CuoShiMieChong),
                new SqlParameter("@p17", tinf.CuoShiGuangZhao),
                new SqlParameter("@p18", tinf.CuoShiPenSa),
                new SqlParameter("@p19", tinf.ZuoWuCeLiang));
        }
    }
}
