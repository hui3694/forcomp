using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_user_attach_log
    {
        public dt_user_attach_log() { }

        private int _id = 0;
        private int _user_id = 0;
        private string _user_name = string.Empty;
        private int _attach_id = 0;
        private string _file_name = string.Empty;
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
        public int attach_id
        {
           set { _attach_id = value; }
           get { return _attach_id; }
        }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string file_name
        {
           set { _file_name = value; }
           get { return _file_name; }
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
