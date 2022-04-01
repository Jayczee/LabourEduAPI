using DCYLabourAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DCYLabourAPI.DAL;
using System.Data;

namespace DCYLabourAPI.BLL
{
    public class TaskBll
    {
        TaskDal tdal = new();
        public int AddTask(TaskInfo tinf)
        {
            return tdal.AddTask(tinf);
        }

        public List<TaskInfo> GetTaskByTUid(string uid,int userkind)
        {
            DataTable dt = tdal.GetTaskByTUid(uid,userkind);
            if (dt.Rows.Count == 0)
                return null; 
            else
            {
                List<TaskInfo> list = new();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TaskInfo task = new TaskInfo();
                    task.TaskID = int.Parse(dt.Rows[i]["TaskID"].ToString());
                    task.TaskName = dt.Rows[i]["TaskName"].ToString();
                    task.TaskStartTime = dt.Rows[i]["TaskStartTime"].ToString();
                    task.TaskTUid = dt.Rows[i]["TaskTUid"].ToString();
                    task.TaskClass = int.Parse(dt.Rows[i]["TaskClass"].ToString());
                    task.TaskGroup = dt.Rows[i]["TaskGroup"].ToString();
                    task.TaskStuCapID = dt.Rows[i]["TaskStuCapID"].ToString();
                    task.TaskStus = dt.Rows[i]["TaskStus"].ToString();
                    task.TaskDetail = dt.Rows[i]["TaskDetail"].ToString();
                    task.Fandi = int.Parse(dt.Rows[i]["Fandi"].ToString());
                    task.Zhengdi = int.Parse(dt.Rows[i]["Zhengdi"].ToString());
                    task.Celiang = int.Parse(dt.Rows[i]["Celiang"].ToString());
                    task.CuoShi = int.Parse(dt.Rows[i]["CuoShi"].ToString());
                    task.CuoShiShiFei = float.Parse(dt.Rows[i]["CuoShiShiFei"].ToString());
                    task.CuoShiShaChong = float.Parse(dt.Rows[i]["CuoShiShaChong"].ToString());
                    task.CuoShiJiaoGuan = int.Parse(dt.Rows[i]["CuoShiJiaoGuan"].ToString());
                    task.CuoShiMieChong = int.Parse(dt.Rows[i]["CuoShiMieChong"].ToString());
                    task.CuoShiGuangZhao = int.Parse(dt.Rows[i]["CuoShiGuangZhao"].ToString());
                    task.CuoShiPenSa = int.Parse(dt.Rows[i]["CuoShiPenSa"].ToString());
                    task.ZuoWuCeLiang = int.Parse(dt.Rows[i]["ZuoWuCeLiang"].ToString());
                    task.TaskCon = int.Parse(dt.Rows[i]["TaskCon"].ToString());
                    list.Add(task);
                }
                return list;
            }

        }

        public int AddFinishInfo(int taskID)
        {
            return tdal.AddFinishInfo(taskID);
        }

        public List<TaskFinishInfo> GetFinishInfoByID(int taskID)
        {
            DataTable dt = tdal.GetFinishInfoByID(taskID);
            if (dt.Rows.Count == 0)
                return null;
            else
            {
                List<TaskFinishInfo> list = new();
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    TaskFinishInfo tfinf = new TaskFinishInfo();
                    tfinf.TaskFinishID = int.Parse(dt.Rows[i]["TaskFinishID"].ToString());
                    tfinf.TaskID = int.Parse(dt.Rows[i]["TaskID"].ToString());
                    tfinf.FanDiTime = dt.Rows[i]["FanDiTime"].ToString();
                    tfinf.ChuCao = dt.Rows[i]["ChuCao"].ToString();
                    tfinf.DiKuaiW = dt.Rows[i]["DiKuaiW"].ToString();
                    tfinf.DiKuaiH = dt.Rows[i]["DiKuaiH"].ToString();
                    tfinf.DiKuaiArea = dt.Rows[i]["DiKuaiArea"].ToString();
                    tfinf.FanDiPicURL= dt.Rows[i]["FanDiPicURL"].ToString();
                    tfinf.ZhengDiTime = dt.Rows[i]["ZhengDiTime"].ToString();
                    tfinf.LongGui = dt.Rows[i]["LongGui"].ToString();
                    tfinf.LongGou1 = dt.Rows[i]["LongGou1"].ToString();
                    tfinf.LongGou2 = dt.Rows[i]["LongGou2"].ToString();
                    tfinf.LongGou3 = dt.Rows[i]["LongGou3"].ToString();
                    tfinf.LongGou4 = dt.Rows[i]["LongGou4"].ToString();
                    tfinf.LongGou5 = dt.Rows[i]["LongGou5"].ToString();
                    tfinf.CeLiangTime = dt.Rows[i]["CeLiangTime"].ToString();
                    tfinf.HuanJingTemp = dt.Rows[i]["HuanJingTemp"].ToString();
                    tfinf.HuanJingWet = dt.Rows[i]["HuanJingWet"].ToString();
                    tfinf.TuRangTemp = dt.Rows[i]["TuRangTemp"].ToString();
                    tfinf.TuRangWet = dt.Rows[i]["TuRangWet"].ToString();
                    tfinf.TuRangLight = dt.Rows[i]["TuRangLight"].ToString();
                    tfinf.TuRangPH = dt.Rows[i]["TuRangPH"].ToString();
                    tfinf.CeLiangPicURL = dt.Rows[i]["CeLiangPicURL"].ToString();
                    tfinf.CuoShiTime = dt.Rows[i]["CuoShiTime"].ToString();
                    tfinf.CuoShiShiFei = float.Parse(dt.Rows[i]["CuoShiShiFei"].ToString()==""?"0": dt.Rows[i]["CuoShiShiFei"].ToString());
                    tfinf.CuoShiShaChong = float.Parse(dt.Rows[i]["CuoShiShaChong"].ToString() == "" ? "0" : dt.Rows[i]["CuoShiShaChong"].ToString());
                    tfinf.CuoShiJiaoGuan = int.Parse(dt.Rows[i]["CuoShiJiaoGuan"].ToString() == "" ? "0" : dt.Rows[i]["CuoShiJiaoGuan"].ToString());
                    tfinf.CuoShiGuangZhao = int.Parse(dt.Rows[i]["CuoShiGuangZhao"].ToString() == "" ? "0" : dt.Rows[i]["CuoShiGuangZhao"].ToString());
                    tfinf.CuoShiMieChong = int.Parse(dt.Rows[i]["CuoShiMieChong"].ToString() == "" ? "0" : dt.Rows[i]["CuoShiMieChong"].ToString());
                    tfinf.CuoShiPenSa = int.Parse(dt.Rows[i]["CuoShiPenSa"].ToString() == "" ? "0" : dt.Rows[i]["CuoShiPenSa"].ToString());
                    tfinf.CuoShiPicURL = dt.Rows[i]["CuoShiPicURL"].ToString();
                    tfinf.ZuoWuTime = dt.Rows[i]["ZuoWuTime"].ToString();
                    tfinf.ZuoWuJieDuan = dt.Rows[i]["ZuoWuJieDuan"].ToString();
                    tfinf.ZuoWuYanSe = dt.Rows[i]["ZuoWuYanSe"].ToString();
                    tfinf.ZuoWuH = dt.Rows[i]["ZuoWuH"].ToString();
                    tfinf.ZuoWuNum1 = int.Parse(dt.Rows[i]["ZuoWuNum1"].ToString() == "" ? "0" : dt.Rows[i]["ZuoWuNum1"].ToString());
                    tfinf.ZuoWuNum2 = int.Parse(dt.Rows[i]["ZuoWuNum2"].ToString() == "" ? "0" : dt.Rows[i]["ZuoWuNum2"].ToString());
                    tfinf.ZuoWuShouHuo = dt.Rows[i]["ZuoWuShouHuo"].ToString();
                    tfinf.ZuoWuPicURL = dt.Rows[i]["ZuoWuPicURL"].ToString();
                    list.Add(tfinf);
                }
                return list;
            }
        }

     
        public int UpdateFinishInfo(UpdateTaskInf upinf)
        {
            return tdal.UpdateFinishInfo(upinf);
        }

        public int DeleteTask(int taskID)
        {
            return tdal.DeleteTask(taskID);
        }

        public int UpdateTask(TaskInfo tinf)
        {
            return tdal.UpdateTask(tinf);
        }
    }
}
