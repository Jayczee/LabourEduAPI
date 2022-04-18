using DCYLabourAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DCYLabourAPI.DAL;
using System.Data;

namespace DCYLabourAPI.BLL
{
    public class FilesBll
    {
        FilesDal fdal = new();
        public List<FileInf> GetFiles(string uid)
        {
            DataTable dt = fdal.GetFiles(uid);
            if (dt.Rows.Count == 0)
                return null;
            else
            {
                List<FileInf> list = new List<FileInf>();
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    FileInf file = new FileInf();
                    file.FID = int.Parse(dt.Rows[i]["FID"].ToString());
                    file.FileName = dt.Rows[i]["FileName"].ToString();
                    file.FileLocation = dt.Rows[i]["FileLocation"].ToString();
                    file.FileDate = dt.Rows[i]["FileDate"].ToString();
                    file.FileTUid = dt.Rows[i]["FileTUid"].ToString();
                    file.FileLength = dt.Rows[i]["FileLength"].ToString();
                    list.Add(file);
                }
                return list;
            }
        }

        public int DeleteFile(int fid)
        {
            return fdal.DeleteFile(fid);
        }

        public int AddFile(FileInf finf)
        {
            return fdal.AddFile(finf);
        }
    }
}
