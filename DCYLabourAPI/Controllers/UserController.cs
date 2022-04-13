using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DCYLabourAPI.Model;
using DCYLabourAPI.BLL;

namespace DCYLabourAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserBll ubll = new();


        [HttpGet]
        [Route("{uid}/{pwd}")]
        public HttpRes<User> UserLogin(string uid, string pwd)
        {
            User user = ubll.UserLogin(uid, pwd);
            if (user == null || user.Id < 0)
            {
                return new HttpRes<User>(0, "用户名或密码错误", null);
            }
            else
            {
                return new HttpRes<User>(1, "登陆成功", user);
            }
        }

        [HttpPost]
        public HttpRes<string> UserReg([FromBody] UserRegInf regInf)
        {
            int res = ubll.UserReg(regInf);
            switch (res)
            {
                case 0: return new HttpRes<string>(6, "注册失败，uid已存在", null);
                case 1: return new HttpRes<string>(7, "注册成功", null);
                case 2: return new HttpRes<string>(8, "注册失败，未知错误", null);
            }
            return new HttpRes<string>(8, "注册失败，未知错误", null);
        }

        [HttpPut]
        public HttpRes<string> UserUpdate([FromBody] User user)
        {
            int res = ubll.UserUpdate(user);
            if (res == 0)
                return new HttpRes<string>(9, "新密码不能与原密码形同", null);
            else
                return new HttpRes<string>(10, "密码更改成功", null);
        }

        [HttpDelete]
        [Route("{uid}")]
        public HttpRes<string> DeleteUser(string uid)
        {
            int res = ubll.DeleteUser(uid);
            if (res > 0)
                return new HttpRes<string>(25, "删除用户成功", null);
            else
                return new HttpRes<string>(26, "删除用户失败，无此用户信息", null);
        }

        [HttpGet]
        [Route("{TUid}")]
        public HttpRes<Teacher> GetTeacher(string TUid)
        {
            Teacher t = ubll.GetTeacher(TUid);
            if (t == null)
                return new HttpRes<Teacher>(27, "获取失败，无该教师信息", null);
            else
                return new HttpRes<Teacher>(28, "获取教师信息成功", t);
        }

        [HttpGet]
        [Route("{TUid}")]
        public HttpRes<List<ClassInf>> GetClassByTUid(string TUid)
        {
            List<ClassInf> list = ubll.GetClassByTUid(TUid);
            if (list == null)
            {
                return new HttpRes<List<ClassInf>>(29, "无班级信息", null);
            }
            else
                return new HttpRes<List<ClassInf>>(30, "获取班级信息成功", list);
        }

        [HttpPost]
        public HttpRes<string> AddClass([FromBody] ClassInf inf)
        {
            int res = ubll.AddClass(inf);
            if (res > 0)
                return new HttpRes<string>(31, "添加班级信息成功", null);
            else
                return new HttpRes<string>(32, "添加班级信息失败，班级信息已存在", null);
        }

        [HttpPut]
        public HttpRes<string> UpdateClass([FromBody] ClassInf inf)
        {
            int res = ubll.UpdateClass(inf);
            if (res > 0)
                return new HttpRes<string>(33, "更新班级信息成功", null);
            else
                return new HttpRes<string>(34, "更新班级信息失败,无此班级信息", null);
        }


        [HttpDelete]
        [Route("{cid}")]
        public HttpRes<string> DeleteClass(int cid)
        {
            int res = ubll.DeleteClass(cid);
            if (res > 0)
                return new HttpRes<string>(35, "删除班级信息成功", null);
            else
                return new HttpRes<string>(36, "删除班级信息失败，无此班级信息", null);
        }

        [HttpGet]
        public HttpRes<List<Teacher>> GetAllTeacher()
        {
            List<Teacher> list = ubll.GetAllTeacher();
            if (list == null)
                return new HttpRes<List<Teacher>>(41, "无教师信息", null);
            else
                return new HttpRes<List<Teacher>>(42, "获取教师信息成功", list);
        }

        [HttpGet]
        [Route("{uid}")]
        public HttpRes<int> GetUserKind(string uid)
        {
            int userkind = ubll.GetUserKind(uid);
            if (userkind != -1)
                return new HttpRes<int>(43, "查询成功", userkind);
            else
                return new HttpRes<int>(44, "无信息", -1);
        }

        [HttpGet]
        [Route("{uid}")]
        public HttpRes<string> ResetPwd(string uid)
        {
            int res = ubll.ResetPwd(uid);
            if (res > 0)
                return new HttpRes<string>(45, "重置密码成功", null);
            else
                return new HttpRes<string>(44, "无该用户信息，重置密码失败", null);

        }
    }
}
