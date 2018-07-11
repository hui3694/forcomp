using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_weixin_request_rule
    {
        public dt_weixin_request_rule() { }

        private int _id = 0;
        private int _account_id = 0;
        private string _name = string.Empty;
        private string _keywords = string.Empty;
        private int _request_type = 0;
        private int _response_type = 0;
        private int _is_like_query = 0;
        private int _is_default = 0;
        private int _sort_id = 0;
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
        public int account_id
        {
           set { _account_id = value; }
           get { return _account_id; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string name
        {
           set { _name = value; }
           get { return _name; }
        }
        public string keywords
        {
           set { _keywords = value; }
           get { return _keywords; }
        }
        public int request_type
        {
           set { _request_type = value; }
           get { return _request_type; }
        }
        public int response_type
        {
           set { _response_type = value; }
           get { return _response_type; }
        }
        public int is_like_query
        {
           set { _is_like_query = value; }
           get { return _is_like_query; }
        }
        /// <summary>
        /// 是否默认
        /// </summary>
        public int is_default
        {
           set { _is_default = value; }
           get { return _is_default; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort_id
        {
           set { _sort_id = value; }
           get { return _sort_id; }
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
