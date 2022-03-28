using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYLabourAPI.Model
{
    public class TaskInfo
    {
        private int _taskID = -1;
        private string _taskName = "";
        private string _taskStartTime = "";
        private string _taskTUid= "";
        private int _taskClass = -1;
        private string _taskGroup= "";
        private string _taskStuCapID= "";
        private string _taskStus= "";
        private string _taskDetail= "";
        private int _fandi = 0;
        private int _zhengdi = 0;
        private int _celiang = 0;
        private int _cuoShi = 0;
        private float _cuoShiShiFei = 0.0f;
        private float _cuoShiShaChong = 0.0f;
        private int _cuoShiJiaoGuan = 0;
        private int _cuoShiMieChong = 0;
        private int _cuoShiGuangZhao = 0;
        private int _cuoShiPenSa = 0;
        private int _zuoWuCeLiang = 0;
        private int _taskCon = 0;

        public int TaskID { get => _taskID; set => _taskID = value; }
        public string TaskName { get => _taskName; set => _taskName = value; }
        public string TaskStartTime { get => _taskStartTime; set => _taskStartTime = value; }
        public string TaskTUid { get => _taskTUid; set => _taskTUid = value; }
        public int TaskClass { get => _taskClass; set => _taskClass = value; }
        public string TaskGroup { get => _taskGroup; set => _taskGroup = value; }
        public string TaskStuCapID { get => _taskStuCapID; set => _taskStuCapID = value; }
        public string TaskStus { get => _taskStus; set => _taskStus = value; }
        public string TaskDetail { get => _taskDetail; set => _taskDetail = value; }
        public int Fandi { get => _fandi; set => _fandi = value; }
        public int Zhengdi { get => _zhengdi; set => _zhengdi = value; }
        public int Celiang { get => _celiang; set => _celiang = value; }
        public int CuoShi { get => _cuoShi; set => _cuoShi = value; }
        public float CuoShiShiFei { get => _cuoShiShiFei; set => _cuoShiShiFei = value; }
        public float CuoShiShaChong { get => _cuoShiShaChong; set => _cuoShiShaChong = value; }
        public int CuoShiJiaoGuan { get => _cuoShiJiaoGuan; set => _cuoShiJiaoGuan = value; }
        public int CuoShiMieChong { get => _cuoShiMieChong; set => _cuoShiMieChong = value; }
        public int CuoShiGuangZhao { get => _cuoShiGuangZhao; set => _cuoShiGuangZhao = value; }
        public int CuoShiPenSa { get => _cuoShiPenSa; set => _cuoShiPenSa = value; }
        public int ZuoWuCeLiang { get => _zuoWuCeLiang; set => _zuoWuCeLiang = value; }
        public int TaskCon { get => _taskCon; set => _taskCon = value; }
    }
}
