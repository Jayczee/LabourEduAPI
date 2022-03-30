using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYLabourAPI.Model
{
    public class TaskFinishInfo
    {
        private int _taskFinishID = -1;
        private int _taskID = -1;
        private string _fanDiTime = "";
        private string _chuCao = "";
        private string _diKuaiW = "";
        private string _diKuaiH = "";
        private string _diKuaiArea = "";
        private string _fandiPicURL = "";
        private string _zhengDiTime = "";
        private string _longGui = "";
        private string _longGou1 = "";
        private string _longGou2 = "";
        private string _longGou3 = "";
        private string _longGou4 = "";
        private string _longGou5 = "";
        private string _ceLiangTime = "";
        private string _huanJingTemp = "";
        private string _huanJingWet = "";
        private string _tuRangTemp = "";
        private string _tuRangWet = "";
        private string _tuRangLight = "";
        private string _tuRangPH = "";
        private string _ceLiangPicURL = "";
        private string _cuoShiTime = "";
        private float _cuoShiShiFei = 0.0f;
        private float _cuoShiShaChong=0.0f;
        private int _cuoShiJiaoGuan = 0;
        private int _cuoShiGuangZhao = 0;
        private int _cuoShiMieChong = 0;
        private int _cuoShiPenSa = 0;
        private string _cuoShiPicURL = "";
        private string _zuoWuTime = "";
        private string _zuoWuJieDuan = "";
        private string _zuoWuYanSe = "";
        private string _zuoWuH = "";
        private int _zuoWuNum1 = 0;
        private int _zuoWunUM2 = 0;
        private string _zuoWuShouHuo = "";
        private string _zuoWuPicURL = "";

        public int TaskFinishID { get => _taskFinishID; set => _taskFinishID = value; }
        public int TaskID { get => _taskID; set => _taskID = value; }
        public string FanDiTime { get => _fanDiTime; set => _fanDiTime = value; }
        public string ChuCao { get => _chuCao; set => _chuCao = value; }
        public string DiKuaiW { get => _diKuaiW; set => _diKuaiW = value; }
        public string DiKuaiH { get => _diKuaiH; set => _diKuaiH = value; }
        public string DiKuaiArea { get => _diKuaiArea; set => _diKuaiArea = value; }
        public string FanDiPicURL { get => _fandiPicURL; set => _fandiPicURL = value; }
        public string ZhengDiTime { get => _zhengDiTime; set => _zhengDiTime = value; }
        public string LongGui { get => _longGui; set => _longGui = value; }
        public string LongGou1 { get => _longGou1; set => _longGou1 = value; }
        public string LongGou2 { get => _longGou2; set => _longGou2 = value; }
        public string LongGou3 { get => _longGou3; set => _longGou3 = value; }
        public string LongGou4 { get => _longGou4; set => _longGou4 = value; }
        public string LongGou5 { get => _longGou5; set => _longGou5 = value; }
        public string CeLiangTime { get => _ceLiangTime; set => _ceLiangTime = value; }
        public string HuanJingTemp { get => _huanJingTemp; set => _huanJingTemp = value; }
        public string HuanJingWet { get => _huanJingWet; set => _huanJingWet = value; }
        public string TuRangTemp { get => _tuRangTemp; set => _tuRangTemp = value; }
        public string TuRangWet { get => _tuRangWet; set => _tuRangWet = value; }
        public string TuRangLight { get => _tuRangLight; set => _tuRangLight = value; }
        public string TuRangPH { get => _tuRangPH; set => _tuRangPH = value; }
        public string CeLiangPicURL { get => _ceLiangPicURL; set => _ceLiangPicURL = value; }
        public string CuoShiTime { get => _cuoShiTime; set => _cuoShiTime = value; }
        public float CuoShiShiFei { get => _cuoShiShiFei; set => _cuoShiShiFei = value; }
        public float CuoShiShaChong { get => _cuoShiShaChong; set => _cuoShiShaChong = value; }
        public int CuoShiJiaoGuan { get => _cuoShiJiaoGuan; set => _cuoShiJiaoGuan = value; }
        public int CuoShiGuangZhao { get => _cuoShiGuangZhao; set => _cuoShiGuangZhao = value; }
        public int CuoShiMieChong { get => _cuoShiMieChong; set => _cuoShiMieChong = value; }
        public int CuoShiPenSa { get => _cuoShiPenSa; set => _cuoShiPenSa = value; }
        public string CuoShiPicURL { get => _cuoShiPicURL; set => _cuoShiPicURL = value; }
        public string ZuoWuTime { get => _zuoWuTime; set => _zuoWuTime = value; }
        public string ZuoWuJieDuan { get => _zuoWuJieDuan; set => _zuoWuJieDuan = value; }
        public string ZuoWuYanSe { get => _zuoWuYanSe; set => _zuoWuYanSe = value; }
        public string ZuoWuH { get => _zuoWuH; set => _zuoWuH = value; }
        public int ZuoWuNum1 { get => _zuoWuNum1; set => _zuoWuNum1 = value; }
        public int ZuoWuNum2 { get => _zuoWunUM2; set => _zuoWunUM2 = value; }
        public string ZuoWuShouHuo { get => _zuoWuShouHuo; set => _zuoWuShouHuo = value; }
        public string ZuoWuPicURL { get => _zuoWuPicURL; set => _zuoWuPicURL = value; }
    }
}
