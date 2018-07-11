using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_user_code
    {
        public dt_user_code() { }

        private int _id = 0;
        private int _user_id = 0;
        private string _user_name = string.Empty;
        private string _type = string.Empty;
        private string _str_code = string.Empty;
        private int _count = 0;
        private int _status = 0;
        private string _user_ip = string.Empty;
        private DateTime _eff_time = DateTime.Now;
        private DateTime _add_time = DateTime.Now;

        #region Model

        /// <summary>
        /// ID号
        /// </summary>
        public int id
        {
           set { _id = value; }
           get { return _id; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int user_id
        {
           set { _user_id = value; }
           get { return _user_id; }
        }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string user_name
        {
           set { _user_name = value; }
           get { return _user_name; }
        }
        public string type
        {
           set { _type = value; }
           get { return _type; }
        }
        public string str_code
        {
           set { _str_code = value; }
           get { return _str_code; }
        }
        public int count
        {
           set { _count = value; }
           get { return _count; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int status
        {
           set { _status = value; }
           get { return _status; }
        }
        /// <summary>
        /// 用户IP
        /// </summary>
        public string user_ip
        {
           set { _user_ip = value; }
           get { return _user_ip; }
        }
        public DateTime eff_time
        {
           set { _eff_time = value; }
           get { return _eff_time; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime add_time
        {
           set { _add_time = value; }
           get { return _add_time; }
        }

        #endregion
    }
}
