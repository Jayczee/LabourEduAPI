using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYLabourAPI.Model
{
    public class ClassInf
    {
        private int _cID = -1;
        private int _cNo = -1;
        private string _cName = "";
        private string _cTUid = "";

        public int CID { get => _cID; set => _cID = value; }
        public int CNo { get => _cNo; set => _cNo = value; }
        public string CName { get => _cName; set => _cName = value; }
        public string CTUid { get => _cTUid; set => _cTUid = value; }
    }
}
