using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class news
    {
        public news() { }

        private int _id = 0;
        private string _title = string.Empty;
        private string _zhaiyao = string.Empty;
        private string _cont = string.Empty;
        private string _img = string.Empty;
        private int _sort = 0;
        private int _click = 0;
        private int _is_msg = 0;
        private int _is_hide = 0;
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
        /// 标题
        /// </summary>
        public string title
        {
           set { _title = value; }
           get { return _title; }
        }
        /// <summary>
        /// 摘要
        /// </summary>
        public string zhaiyao
        {
           set { _zhaiyao = value; }
           get { return _zhaiyao; }
        }
        public string cont
        {
           set { _cont = value; }
           get { return _cont; }
        }
        public string img
        {
           set { _img = value; }
           get { return _img; }
        }
        public int sort
        {
           set { _sort = value; }
           get { return _sort; }
        }
        /// <summary>
        /// 点击
        /// </summary>
        public int click
        {
           set { _click = value; }
           get { return _click; }
        }
        /// <summary>
        /// 是否允许评论
        /// </summary>
        public int is_msg
        {
           set { _is_msg = value; }
           get { return _is_msg; }
        }
        public int is_hide
        {
           set { _is_hide = value; }
           get { return _is_hide; }
        }
        public DateTime time
        {
           set { _time = value; }
           get { return _time; }
        }

        #endregion
    }
}
