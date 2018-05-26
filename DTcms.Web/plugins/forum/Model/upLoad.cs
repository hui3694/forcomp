using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTcms.Web.Plugin.Forum.Model
{/// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class upLoad
    {


        public int size { set; get; }
        public int status { set; get; }
        public string msg { set; get; }
        public string name { set; get; }
        public string path { set; get; }
        public string thumb { set; get; }
        public string ext { set; get; }

    }
}