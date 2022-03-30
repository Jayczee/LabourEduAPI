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

        public int AddFinishInfo(int taskID)
        {
            object obj = SqlHelper.ExecuteScalar("select TaskCon from LabourTaskInf where TaskID=@para1",
                new SqlParameter("@para1",taskID));
            if ((int)obj == 0)
            {
                SqlHelper.ExecuteNonQuery("update LabourTaskInf set TaskCon=@para1 where TaskID=@para2",
                    new SqlParameter("@para1", 1),
                    new SqlParameter("@para2", taskID));
                SqlHelper.ExecuteNonQuery("insert into TaskFinishInfo(TaskID)values(@para1)",
                    new SqlParameter("@para1", taskID));
                return (int)SqlHelper.ExecuteScalar("select TaskFinishID from TaskFinishInfo where TaskID=@para1",
                    new SqlParameter("@para1", taskID));
            }
            else
                return -1;
        }

        public DataTable GetFinishInfoByID(int taskID)
        {
            return SqlHelper.ExecuteTable("select * from TaskFinishInfo where TaskID = @para1",
                new SqlParameter("@para1",taskID));
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

        public int UpdateFinishInfo(UpdateTaskInf upinf)
        {
            string key="";
            switch (upinf.Key)
            {
                case 0: key = "FanDiTime";break;
                case 1: key = "ChuCao";  break;
                case 2: key = "DiKuaiW";  break;
                case 3: key = "DiKuaiH";  break;
                case 4: key = "DiKuaiArea";  break;
                case 5: key = "FanDiPicURL";  break;
                case 6: key = "ZhengDiTime";  break;
                case 7: key = "LongGui";  break;
                case 8: key = "LongGou1";  break;
                case 9: key = "LongGou2";  break;
                case 10: key = "LongGou3";  break;
                case 11: key = "LongGou4";  break;
                case 12: key = "LongGou5";  break;
                case 13: key = "CeLiangTime";  break;
                case 14: key = "HuanJingTemp";  break;
                case 15: key = "HuanJingWet";  break;
                case 16: key = "TuRangTemp";  break;
                case 17: key = "TuRangWet";  break;
                case 18: key = "TuRangLight";  break;
                case 19: key = "TuRangPH";  break;
                case 20: key = "CeLiangPicURL";  break;
                case 21: key = "CuoShiTime"; break;
                case 22: key = "CuoShiShiFei";break;
                case 23: key = "CuoShiShaChong"; break;
                case 24: key = "CuoShiJiaoGuan"; break;
                case 25: key = "CuoShiGuangZhao"; break;
                case 26: key = "CuoShiMieChong"; break;
                case 27: key = "CuoShiPenSa"; break;
                case 28: key = "CuoShiPicURL";  break;
                case 29: key = "ZuoWuTime";  break;
                case 30: key = "ZuoWuJieDuan";  break;
                case 31: key = "ZuoWuYanSe";  break;
                case 32: key = "ZuoWuH";  break;
                case 33: key = "ZuoWuNum1"; break;
                case 34: key = "ZuoWuNum2"; break;
                case 35: key = "ZuoWuShouHuo";  break;
                case 36: key = "ZuoWuPicURL";  break;
            }
            string s = String.Format("update TaskFinishInfo set {0}=@para1 where TaskFinishID=@para2",key);
            return SqlHelper.ExecuteNonQuery(s,
                new SqlParameter("@para1",upinf.Value),
                new SqlParameter("@para2",upinf.TaskFinishID));
        }
    }
}
