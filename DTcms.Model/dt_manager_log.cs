using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_manager_log
    {
        public dt_manager_log() { }

        private int _id = 0;
        private int _user_id = 0;
        private string _user_name = string.Empty;
        private string _action_type = string.Empty;
        private string _remark = string.Empty;
        private string _user_ip = string.Empty;
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
        /// <summary>
        /// 操作类型
        /// </summary>
        public string action_type
        {
           set { _action_type = value; }
           get { return _action_type; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string remark
        {
           set { _remark = value; }
           get { return _remark; }
        }
        /// <summary>
        /// 用户IP
        /// </summary>
        public string user_ip
        {
           set { _user_ip = value; }
           get { return _user_ip; }
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
