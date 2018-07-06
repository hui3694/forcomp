using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class user_pm
    {
        public user_pm() { }

        private int _id = 0;
        private int _user_id = 0;
        private string _name = string.Empty;
        private int _sex = 0;
        private string _origin = string.Empty;
        private string _phone = string.Empty;
        private string _comname = string.Empty;
        private string _job = string.Empty;
        private int _year = 0;
        private string _jobimg = string.Empty;
        private string _img = string.Empty;
        private int _status = 0;
        private DateTime _add_time = DateTime.Now;
        private DateTime _pass_time = DateTime.Now;

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
        /// 名称
        /// </summary>
        public string name
        {
           set { _name = value; }
           get { return _name; }
        }
        public int sex
        {
           set { _sex = value; }
           get { return _sex; }
        }
        public string origin
        {
           set { _origin = value; }
           get { return _origin; }
        }
        public string phone
        {
           set { _phone = value; }
           get { return _phone; }
        }
        public string comname
        {
           set { _comname = value; }
           get { return _comname; }
        }
        public string job
        {
           set { _job = value; }
           get { return _job; }
        }
        public int year
        {
           set { _year = value; }
           get { return _year; }
        }
        public string jobimg
        {
           set { _jobimg = value; }
           get { return _jobimg; }
        }
        public string img
        {
           set { _img = value; }
           get { return _img; }
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
        /// 添加时间
        /// </summary>
        public DateTime add_time
        {
           set { _add_time = value; }
           get { return _add_time; }
        }
        public DateTime pass_time
        {
           set { _pass_time = value; }
           get { return _pass_time; }
        }

        #endregion
    }
}
