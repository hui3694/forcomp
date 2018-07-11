using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class call_pm
    {
        public call_pm() { }

        private int _id = 0;
        private int _user_id = 0;
        private int _call_id = 0;
        private DateTime _time = DateTime.Now;

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
        public int call_id
        {
           set { _call_id = value; }
           get { return _call_id; }
        }
        public DateTime time
        {
           set { _time = value; }
           get { return _time; }
        }

        #endregion
    }
}
