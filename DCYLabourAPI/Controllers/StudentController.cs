using Microsoft.AspNetCore.Mvc;
using DCYLabourAPI.BLL;
using DCYLabourAPI.Model;

namespace DCYLabourAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentBll sbll = new();
        [HttpGet]
        [Route("{CardNum}")]
        public HttpRes<Student> GetStuByCardNum(string CardNum)
        {
            Student s = sbll.GetStuByCardNum(CardNum);
            if (s == null)
                return new HttpRes<Student>(2, "卡号有误或无此学生信息", null);
            else
                return new HttpRes<Student>(3, "查询成功", s);
        }

        [HttpGet]
        [Route("{CNo}")]
        public HttpRes<List<Student>> GetStusByCNo(int CNo)
        {
            List<Student> list = sbll.GetStusByCNo(CNo);
            if (list == null)
                return new HttpRes<List<Student>>(4, "班级编号有误，查询失败或该班无学生信息", null);
            else
                return new HttpRes<List<Student>>(5, "查询成功", list);
        }

        [HttpPost]
        public HttpRes<Student> AddStu([FromBody]Student s)
        {
            int res = sbll.AddStu(s);
            if (res > 0)
            {
                s.SID = res;
                return new HttpRes<Student>(37,"添加学生信息成功",s);
            }
            else
            {
                return new HttpRes<Student>(38, "添加学生信息失败，卡号已存在", null);
            }
        }

        [HttpPut]
        public HttpRes<string> UpdateStu([FromBody]Student s)
        {
            int res = sbll.UpdateStu(s);
            if (res > 0)
                return new HttpRes<string>(39, "更新学生信息成功", null);
            else
                return new HttpRes<string>(40,"更新学生信息失败，该卡号已存在或学生信息已被删除",null);
        }

        [HttpDelete]
        [Route("{sid}")]
        public HttpRes<string> DeleteStu(int sid)
        {
            int res = sbll.DeleteStu(sid);
            if (res > 0)
                return new HttpRes<string>(41, "删除学生信息成功", null);
            else
                return new HttpRes<string>(42,"删除学生信息失败，该学生信息不存在",null);
        }

    }
}
