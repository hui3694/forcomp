using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class news_commend
    {
        public news_commend() { }

        private int _id = 0;
        private int _user_id = 0;
        private string _name = string.Empty;
        private string _avatar = string.Empty;
        private string _cont = string.Empty;
        private int _ispn = 0;
        private int _news_id = 0;
        private int _ishide = 0;
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
        /// <summary>
        /// 名称
        /// </summary>
        public string name
        {
           set { _name = value; }
           get { return _name; }
        }
        public string avatar
        {
           set { _avatar = value; }
           get { return _avatar; }
        }
        public string cont
        {
           set { _cont = value; }
           get { return _cont; }
        }
        public int ispn
        {
           set { _ispn = value; }
           get { return _ispn; }
        }
        public int news_id
        {
           set { _news_id = value; }
           get { return _news_id; }
        }
        public int ishide
        {
           set { _ishide = value; }
           get { return _ishide; }
        }
        public DateTime time
        {
           set { _time = value; }
           get { return _time; }
        }

        #endregion
    }
}
