using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class assess
    {
        public assess() { }

        private int _id = 0;
        private int _user_id = 0;
        private int _pm_id = 0;
        private int _value = 0;
        private string _remark = string.Empty;
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
        public int pm_id
        {
           set { _pm_id = value; }
           get { return _pm_id; }
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
        public DateTime time
        {
           set { _time = value; }
           get { return _time; }
        }

        #endregion
    }
}
