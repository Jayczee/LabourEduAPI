using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYLabourAPI.Model
{
    public class User
    {
        private int id = -1;
        private string uid = "";
        private string pwd = "";
        private int userkind = -1;

        public int Id { get => id; set => id = value; }
        public string Uid { get => uid; set => uid = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public int Userkind { get => userkind; set => userkind = value; }
    }
}
