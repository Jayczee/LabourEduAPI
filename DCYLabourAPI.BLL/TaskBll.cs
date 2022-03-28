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
