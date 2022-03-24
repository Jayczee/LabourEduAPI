using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYLabourAPI.Model
{
    public class UserRegInf
    {
        private string uid = "";
        private string pwd = "";
        private int userKind = -1;
        private string tName = "";
        private string tBirth = "";
        private string tPhoneNum = "";
        private string tSex = "";

        public string Uid { get => uid; set => uid = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public int UserKind { get => userKind; set => userKind = value; }
        public string TName { get => tName; set => tName = value; }
        public string TBirth { get => tBirth; set => tBirth = value; }
        public string TPhoneNum { get => tPhoneNum; set => tPhoneNum = value; }
        public string TSex { get => tSex; set => tSex = value; }
    }
}
