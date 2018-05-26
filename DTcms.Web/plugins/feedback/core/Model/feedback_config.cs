using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
    /// 设置参数实体类
    /// </summary>
    [Serializable]
    public partial class feedbackconfig
    {
        public feedbackconfig(){ }

        private int _bookmsg = 0;
        private string _booktemplet = string.Empty;
        private string _receive = string.Empty;

        /// <summary>
        /// 通知
        /// </summary>
        public int bookmsg
        {
            set { _bookmsg = value; }
            get { return _bookmsg; }
        }
        /// <summary>
        /// 通知模板别名
        /// </summary>
        public string booktemplet
        {
            set { _booktemplet = value; }
            get { return _booktemplet; }
        }
        /// <summary>
        /// 接收邮箱或手机
        /// </summary>
        public string receive
        {
            set { _receive = value; }
            get { return _receive; }
        }
    }
}
