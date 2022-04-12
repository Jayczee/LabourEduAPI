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

        public TaskFinishInfo GetFinishInfoByID(int taskID)
        {
            DataTable dt = tdal.GetFinishInfoByID(taskID);
            if (dt.Rows.Count == 0)
                return null;
            else
            {
                TaskFinishInfo tfinf = new TaskFinishInfo();
                tfinf.TaskFinishID = int.Parse(dt.Rows[0]["TaskFinishID"].ToString());
                tfinf.TaskID = int.Parse(dt.Rows[0]["TaskID"].ToString());
                tfinf.FanDiTime = dt.Rows[0]["FanDiTime"].ToString();
                tfinf.ChuCao = dt.Rows[0]["ChuCao"].ToString();
                tfinf.DiKuaiW = dt.Rows[0]["DiKuaiW"].ToString();
                tfinf.DiKuaiH = dt.Rows[0]["DiKuaiH"].ToString();
                tfinf.DiKuaiArea = dt.Rows[0]["DiKuaiArea"].ToString();
                tfinf.FanDiPicURL = dt.Rows[0]["FanDiPicURL"].ToString();
                tfinf.ZhengDiTime = dt.Rows[0]["ZhengDiTime"].ToString();
                tfinf.LongGui = dt.Rows[0]["LongGui"].ToString();
                tfinf.LongGou1 = dt.Rows[0]["LongGou1"].ToString();
                tfinf.LongGou2 = dt.Rows[0]["LongGou2"].ToString();
                tfinf.LongGou3 = dt.Rows[0]["LongGou3"].ToString();
                tfinf.LongGou4 = dt.Rows[0]["LongGou4"].ToString();
                tfinf.LongGou5 = dt.Rows[0]["LongGou5"].ToString();
                tfinf.ZhengDiPicURL = dt.Rows[0]["ZhengDiPicURL"].ToString();
                tfinf.CeLiangTime = dt.Rows[0]["CeLiangTime"].ToString();
                tfinf.HuanJingTemp = dt.Rows[0]["HuanJingTemp"].ToString();
                tfinf.HuanJingWet = dt.Rows[0]["HuanJingWet"].ToString();
                tfinf.TuRangTemp = dt.Rows[0]["TuRangTemp"].ToString();
                tfinf.TuRangWet = dt.Rows[0]["TuRangWet"].ToString();
                tfinf.TuRangLight = dt.Rows[0]["TuRangLight"].ToString();
                tfinf.TuRangPH = dt.Rows[0]["TuRangPH"].ToString();
                tfinf.CeLiangPicURL = dt.Rows[0]["CeLiangPicURL"].ToString();
                tfinf.CuoShiTime = dt.Rows[0]["CuoShiTime"].ToString();
                tfinf.CuoShiShiFei = float.Parse(dt.Rows[0]["CuoShiShiFei"].ToString() == "" ? "0" : dt.Rows[0]["CuoShiShiFei"].ToString());
                tfinf.CuoShiShaChong = float.Parse(dt.Rows[0]["CuoShiShaChong"].ToString() == "" ? "0" : dt.Rows[0]["CuoShiShaChong"].ToString());
                tfinf.CuoShiJiaoGuan = int.Parse(dt.Rows[0]["CuoShiJiaoGuan"].ToString() == "" ? "0" : dt.Rows[0]["CuoShiJiaoGuan"].ToString());
                tfinf.CuoShiGuangZhao = int.Parse(dt.Rows[0]["CuoShiGuangZhao"].ToString() == "" ? "0" : dt.Rows[0]["CuoShiGuangZhao"].ToString());
                tfinf.CuoShiMieChong = int.Parse(dt.Rows[0]["CuoShiMieChong"].ToString() == "" ? "0" : dt.Rows[0]["CuoShiMieChong"].ToString());
                tfinf.CuoShiPenSa = int.Parse(dt.Rows[0]["CuoShiPenSa"].ToString() == "" ? "0" : dt.Rows[0]["CuoShiPenSa"].ToString());
                tfinf.CuoShiPicURL = dt.Rows[0]["CuoShiPicURL"].ToString();
                tfinf.ZuoWuTime = dt.Rows[0]["ZuoWuTime"].ToString();
                tfinf.ZuoWuJieDuan = dt.Rows[0]["ZuoWuJieDuan"].ToString();
                tfinf.ZuoWuYanSe = dt.Rows[0]["ZuoWuYanSe"].ToString();
                tfinf.ZuoWuH = dt.Rows[0]["ZuoWuH"].ToString();
                tfinf.ZuoWuNum1 = int.Parse(dt.Rows[0]["ZuoWuNum1"].ToString() == "" ? "0" : dt.Rows[0]["ZuoWuNum1"].ToString());
                tfinf.ZuoWuNum2 = int.Parse(dt.Rows[0]["ZuoWuNum2"].ToString() == "" ? "0" : dt.Rows[0]["ZuoWuNum2"].ToString());
                tfinf.ZuoWuShouHuo = dt.Rows[0]["ZuoWuShouHuo"].ToString();
                tfinf.ZuoWuPicURL = dt.Rows[0]["ZuoWuPicURL"].ToString();
                tfinf.StuPresent = dt.Rows[0]["StuPresent"].ToString();
                return tfinf;
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
