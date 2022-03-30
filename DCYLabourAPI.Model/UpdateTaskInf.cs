using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYLabourAPI.Model
{
    public class UpdateTaskInf
    {
        private int _taskid = -1;
        private int _key = -1;
        private string _value = "";

        public int TaskFinishID{ get => _taskid; set => _taskid = value; }
        public int Key { get => _key; set => _key = value; }
        public string Value { get => _value; set => _value = value; }
    }
}
