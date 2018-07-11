using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_weixin_request_content
    {
        public dt_weixin_request_content() { }

        private int _id = 0;
        private int _account_id = 0;
        private int _rule_id = 0;
        private string _title = string.Empty;
        private string _content = string.Empty;
        private string _link_url = string.Empty;
        private string _img_url = string.Empty;
        private string _media_id = string.Empty;
        private string _media_url = string.Empty;
        private string _meida_hd_url = string.Empty;
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
        public int rule_id
        {
           set { _rule_id = value; }
           get { return _rule_id; }
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
        /// 内容
        /// </summary>
        public string content
        {
           set { _content = value; }
           get { return _content; }
        }
        /// <summary>
        /// 键接地址
        /// </summary>
        public string link_url
        {
           set { _link_url = value; }
           get { return _link_url; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string img_url
        {
           set { _img_url = value; }
           get { return _img_url; }
        }
        public string media_id
        {
           set { _media_id = value; }
           get { return _media_id; }
        }
        public string media_url
        {
           set { _media_url = value; }
           get { return _media_url; }
        }
        public string meida_hd_url
        {
           set { _meida_hd_url = value; }
           get { return _meida_hd_url; }
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
