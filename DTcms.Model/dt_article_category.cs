using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_article_category
    {
        public dt_article_category() { }

        private int _id = 0;
        private int _channel_id = 0;
        private string _title = string.Empty;
        private string _call_index = string.Empty;
        private int _parent_id = 0;
        private string _class_list = string.Empty;
        private int _class_layer = 0;
        private int _sort_id = 0;
        private string _link_url = string.Empty;
        private string _img_url = string.Empty;
        private string _content = string.Empty;
        private string _seo_title = string.Empty;
        private string _seo_keywords = string.Empty;
        private string _seo_description = string.Empty;
        private int _site_id = 0;
        private int _is_page = 0;
        private int _is_lock = 0;

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
        /// 频道ID
        /// </summary>
        public int channel_id
        {
           set { _channel_id = value; }
           get { return _channel_id; }
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
        /// 调用名称
        /// </summary>
        public string call_index
        {
           set { _call_index = value; }
           get { return _call_index; }
        }
        /// <summary>
        /// 父类ID
        /// </summary>
        public int parent_id
        {
           set { _parent_id = value; }
           get { return _parent_id; }
        }
        /// <summary>
        /// 分类列表
        /// </summary>
        public string class_list
        {
           set { _class_list = value; }
           get { return _class_list; }
        }
        /// <summary>
        /// 深度
        /// </summary>
        public int class_layer
        {
           set { _class_layer = value; }
           get { return _class_layer; }
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
        /// <summary>
        /// 内容
        /// </summary>
        public string content
        {
           set { _content = value; }
           get { return _content; }
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
        /// 站点ID
        /// </summary>
        public int site_id
        {
           set { _site_id = value; }
           get { return _site_id; }
        }
        public int is_page
        {
           set { _is_page = value; }
           get { return _is_page; }
        }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public int is_lock
        {
           set { _is_lock = value; }
           get { return _is_lock; }
        }

        #endregion
    }
}
