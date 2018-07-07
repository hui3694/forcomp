using System;

namespace DTcms.Model
{
    /// <summary>
    /// 积分
    /// <summary>
    [Serializable]
    public class point
    {
        public point() { }

        private int _id = 0;
        private int _user_id = 0;
        private int _value = 0;
        private string _remark = string.Empty;
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
        /// 值
        /// </summary>
        public int value
        {
           set { _value = value; }
           get { return _value; }
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
