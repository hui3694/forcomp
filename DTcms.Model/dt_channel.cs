using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_channel
    {
        public dt_channel() { }

        private int _id = 0;
        private int _site_id = 0;
        private string _name = string.Empty;
        private string _title = string.Empty;
        private int _is_albums = 0;
        private int _is_attach = 0;
        private int _is_spec = 0;
        private int _sort_id = 0;
        private string _seo_title = string.Empty;
        private string _seo_keywords = string.Empty;
        private string _seo_description = string.Empty;
        private int _is_type = 0;
        private int _is_attribute = 0;
        private int _is_comment = 0;
        private int _height = 0;
        private int _width = 0;
        private int _is_recycle = 0;

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
        /// 站点ID
        /// </summary>
        public int site_id
        {
           set { _site_id = value; }
           get { return _site_id; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string name
        {
           set { _name = value; }
           get { return _name; }
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
        /// 启用图片列表
        /// </summary>
        public int is_albums
        {
           set { _is_albums = value; }
           get { return _is_albums; }
        }
        public int is_attach
        {
           set { _is_attach = value; }
           get { return _is_attach; }
        }
        public int is_spec
        {
           set { _is_spec = value; }
           get { return _is_spec; }
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
        public int is_type
        {
           set { _is_type = value; }
           get { return _is_type; }
        }
        public int is_attribute
        {
           set { _is_attribute = value; }
           get { return _is_attribute; }
        }
        /// <summary>
        /// 启用留言
        /// </summary>
        public int is_comment
        {
           set { _is_comment = value; }
           get { return _is_comment; }
        }
        /// <summary>
        /// 高
        /// </summary>
        public int height
        {
           set { _height = value; }
           get { return _height; }
        }
        /// <summary>
        /// 宽度
        /// </summary>
        public int width
        {
           set { _width = value; }
           get { return _width; }
        }
        /// <summary>
        /// 启用回收站
        /// </summary>
        public int is_recycle
        {
           set { _is_recycle = value; }
           get { return _is_recycle; }
        }

        #endregion
    }
}
