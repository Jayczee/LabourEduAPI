using Microsoft.AspNetCore.Http;
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
    }
}
