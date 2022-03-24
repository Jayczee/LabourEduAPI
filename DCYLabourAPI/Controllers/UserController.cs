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
        public HttpRes<User> UserLogin(string uid,string pwd)
        {
            User user = ubll.UserLogin(uid, pwd);
            if(user==null || user.Id < 0)
            {
                return new HttpRes<User>(0,"用户名或密码错误",null);
            }
            else
            {
                return new HttpRes<User>(1,"登陆成功",user);
            }
        }

        [HttpPost]
        public HttpRes<string> UserReg([FromBody]UserRegInf regInf)
        {
            int res = ubll.UserReg(regInf);
            switch (res)
            {
                case 0: return new HttpRes<string>(6,"注册失败，uid已存在",null);
                case 1: return new HttpRes<string>(7, "注册成功", null);
                case 2: return new HttpRes<string>(8, "注册失败，未知错误", null);
            }
            return new HttpRes<string>(8, "注册失败，未知错误", null);
        }

        [HttpPut]
        public HttpRes<string> UserUpdate([FromBody]User user)
        {
            int res = ubll.UserUpdate(user);
            if (res == 0)
                return new HttpRes<string>(9, "新密码不能与原密码形同", null);
            else
                return new HttpRes<string>(10,"密码更改成功",null);
        }

        
    }
}
