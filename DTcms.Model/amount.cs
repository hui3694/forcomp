using System;

namespace DTcms.Model
{
    /// <summary>
    /// 金额
    /// <summary>
    [Serializable]
    public class amount
    {
        public amount() { }

        private int _id = 0;
        private int _user_id = 0;
        private int _type = 0;
        private decimal _amount = 0M;
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
        public int type
        {
           set { _type = value; }
           get { return _type; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount
        {
           set { _amount = value; }
           get { return _amount; }
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
