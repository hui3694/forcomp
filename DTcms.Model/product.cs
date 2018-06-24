using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class product
    {
        public product() { }

        private int _id = 0;
        private int _category = 0;
        private string _title = string.Empty;
        private string _img = string.Empty;
        private string _cont = string.Empty;
        private string _lat = string.Empty;
        private string _lon = string.Empty;
        private string _city = string.Empty;
        private string _addr = string.Empty;
        private int _user_id = 0;
        private int _status = 0;
        private DateTime _pass_time = DateTime.Now;
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
        /// 分类
        /// </summary>
        public int category
        {
           set { _category = value; }
           get { return _category; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string title
        {
           set { _title = value; }
           get { return _title; }
        }
        public string img
        {
           set { _img = value; }
           get { return _img; }
        }
        public string cont
        {
           set { _cont = value; }
           get { return _cont; }
        }
        public string lat
        {
           set { _lat = value; }
           get { return _lat; }
        }
        public string lon
        {
           set { _lon = value; }
           get { return _lon; }
        }
        public string city
        {
           set { _city = value; }
           get { return _city; }
        }
        public string addr
        {
           set { _addr = value; }
           get { return _addr; }
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
        /// 状态
        /// </summary>
        public int status
        {
           set { _status = value; }
           get { return _status; }
        }
        public DateTime pass_time
        {
           set { _pass_time = value; }
           get { return _pass_time; }
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
