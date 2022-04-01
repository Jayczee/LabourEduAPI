using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DCYLabourAPI.Model;
using DCYLabourAPI.BLL;

namespace DCYLabourAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        TaskBll tbll = new();

        [HttpPost]
        public HttpRes<TaskInfo> AddTask([FromBody] TaskInfo tinf)
        {
            int taskid = tbll.AddTask(tinf);
            tinf.TaskID = taskid;
            return new HttpRes<TaskInfo>(11, "添加劳动任务成功", tinf);
        }

        [HttpGet]
        [Route("{uid}/{userkind}")]
        public HttpRes<List<TaskInfo>> GetTaskByTUid(string uid, int userkind)
        {
            List<TaskInfo> tasklist = tbll.GetTaskByTUid(uid, userkind);
            if (tasklist == null)
                return new HttpRes<List<TaskInfo>>(12, "查询失败，该用户未发布劳动任务", null);
            else
                return new HttpRes<List<TaskInfo>>(13, "劳动任务查询成功", tasklist);
        }

        [HttpPut]
        public HttpRes<TaskInfo> UpdateTask([FromBody] TaskInfo tinf)
        {
            int res = tbll.UpdateTask(tinf);
            if (res > 0)
                return new HttpRes<TaskInfo>(14, "劳动任务更新成功", tinf);
            else
                return new HttpRes<TaskInfo>(15, "劳动任务更新失败,无此任务信息", null);
        }

        [HttpDelete]
        [Route("{taskID}")]
        public HttpRes<string> DeleteTask(int taskID)
        {
            if (tbll.DeleteTask(taskID) > 0)
                return new HttpRes<string>(16, "任务删除成功", null);
            else
                return new HttpRes<string>(17, "任务删除失败,无此任务信息", null);
        }

        [HttpGet]
        [Route("{taskID}")]
        public HttpRes<List<TaskFinishInfo>> GetFinishInfoByID(int taskID) {
            List<TaskFinishInfo> list = tbll.GetFinishInfoByID(taskID);
            if (list == null)
                return new HttpRes<List<TaskFinishInfo>>(18, "无任务完成进度信息", null);
            else
                return new HttpRes<List<TaskFinishInfo>>(19, "查询任务完成进度信息成功", list);
        }

        [HttpPost]
        [Route("{taskID}")]
        public HttpRes<int> AddFinishInfo(int taskID)
        {
            int res = tbll.AddFinishInfo(taskID);
            if (res > 0)
                return new HttpRes<int>(20, "领取任务成功", res);
            else
                return new HttpRes<int>(21,"任务已被领取，领取失败",res);
        }

        [HttpPut]
        public HttpRes<string> UpdateFinishInfo([FromBody]UpdateTaskInf upinf)
        {
            if(upinf.Key<0 || upinf.Key>36)
                return new HttpRes<string>(22, "修改项错误，无此修改项", null);
            int res = tbll.UpdateFinishInfo(upinf);
            if (res > 0)
                return new HttpRes<string>(23, "更新信息成功", null);
            else
                return new HttpRes<string>(24, "更新任务完成信息失败", null);
        }


    }
}
