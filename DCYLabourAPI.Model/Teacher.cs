using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYLabourAPI.Model
{
    public class Teacher
    {
        private int _teacherID = -1;
        private string _tname = "";
        private string _tUid = "";
        private string _tBirth = "";
        private string _tCardNum = "";
        private string _tPhoneNum = "";
        private string _tSex = "";

        public int TeacherID { get => _teacherID; set => _teacherID = value; }
        public string Tname { get => _tname; set => _tname = value; }
        public string TUid { get => _tUid; set => _tUid = value; }
        public string TBirth { get => _tBirth; set => _tBirth = value; }
        public string TCardNum { get => _tCardNum; set => _tCardNum = value; }
        public string TPhoneNum { get => _tPhoneNum; set => _tPhoneNum = value; }
        public string TSex { get => _tSex; set => _tSex = value; }
    }
}
