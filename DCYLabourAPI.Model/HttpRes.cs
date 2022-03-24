namespace DCYLabourAPI.Model
{
    public class HttpRes<T>
    {
        private int resCode;//响应编号
        private string msg;//具体消息
        private T data;//响应数据

        public int ResCode { get => resCode; set => resCode = value; }
        public T Data { get => data; set => data = value; }
        public string Msg { get => msg; set => msg = value; }

        public HttpRes(int resCode, string msg, T data)
        {
            ResCode = resCode;
            
            Msg = msg;

            Data = data;
        }

        public HttpRes()
        {

        }
    }
}