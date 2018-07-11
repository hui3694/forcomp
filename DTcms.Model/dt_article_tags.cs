using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_article_tags
    {
        public dt_article_tags() { }

        private int _id = 0;
        private string _title = string.Empty;
        private int _is_red = 0;
        private int _sort_id = 0;
        private DateTime _add_time = DateTime.Now;
        private int _site_id = 0;
        private string _call_index = string.Empty;
        private string _seo_title = string.Empty;
        private string _seo_keywords = string.Empty;
        private string _seo_description = string.Empty;
        private int _click = 0;
        private string _content = string.Empty;

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
        /// 是否推荐
        /// </summary>
        public int is_red
        {
           set { _is_red = value; }
           get { return _is_red; }
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
        /// <summary>
        /// 站点ID
        /// </summary>
        public int site_id
        {
           set { _site_id = value; }
           get { return _site_id; }
        }
        /// <summary>
        /// 调用名称
        /// </summary>
        public string call_index
        {
           set { _call_index = value; }
           get { return _call_index; }
        }
        /// <summary>
        /// SEO 标题
        /// </summary>
        public string seo_title
        {
           set { _seo_title = value; }
           get { return _seo_title; }
        }
        /// <summary>
        /// SEO 关键词
        /// </summary>
        public string seo_keywords
        {
           set { _seo_keywords = value; }
           get { return _seo_keywords; }
        }
        /// <summary>
        /// SEO 描述
        /// </summary>
        public string seo_description
        {
           set { _seo_description = value; }
           get { return _seo_description; }
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
        /// 内容
        /// </summary>
        public string content
        {
           set { _content = value; }
           get { return _content; }
        }

        #endregion
    }
}
