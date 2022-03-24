using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYLabourAPI.Model
{
    public class Student
    {
        private int sID = -1;
        private string sName="";
        private string sSex = "";
        private string sCardNum = "";
        private int sCNo = -1;
        private int sYear = -1;

        public int SID { get => sID; set => sID = value; }
        public string SName { get => sName; set => sName = value; }
        public string SSex { get => sSex; set => sSex = value; }
        public string SCardNum { get => sCardNum; set => sCardNum = value; }
        public int SCNo { get => sCNo; set => sCNo = value; }
        public int SYear { get => sYear; set => sYear = value; }
    }
}
