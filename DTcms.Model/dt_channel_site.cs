using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_channel_site
    {
        public dt_channel_site() { }

        private int _id = 0;
        private string _title = string.Empty;
        private string _build_path = string.Empty;
        private string _templet_path = string.Empty;
        private string _domain = string.Empty;
        private string _name = string.Empty;
        private string _logo = string.Empty;
        private string _company = string.Empty;
        private string _address = string.Empty;
        private string _tel = string.Empty;
        private string _fax = string.Empty;
        private string _email = string.Empty;
        private string _crod = string.Empty;
        private string _copyright = string.Empty;
        private string _seo_title = string.Empty;
        private string _seo_keyword = string.Empty;
        private string _seo_description = string.Empty;
        private int _is_mobile = 0;
        private int _is_default = 0;
        private int _sort_id = 0;
        private int _inherit_id = 0;
        private int _bdsend = 0;
        private string _bdtoken = string.Empty;

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
        public string build_path
        {
           set { _build_path = value; }
           get { return _build_path; }
        }
        public string templet_path
        {
           set { _templet_path = value; }
           get { return _templet_path; }
        }
        /// <summary>
        /// 域名
        /// </summary>
        public string domain
        {
           set { _domain = value; }
           get { return _domain; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string name
        {
           set { _name = value; }
           get { return _name; }
        }
        public string logo
        {
           set { _logo = value; }
           get { return _logo; }
        }
        public string company
        {
           set { _company = value; }
           get { return _company; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string address
        {
           set { _address = value; }
           get { return _address; }
        }
        public string tel
        {
           set { _tel = value; }
           get { return _tel; }
        }
        public string fax
        {
           set { _fax = value; }
           get { return _fax; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email
        {
           set { _email = value; }
           get { return _email; }
        }
        public string crod
        {
           set { _crod = value; }
           get { return _crod; }
        }
        public string copyright
        {
           set { _copyright = value; }
           get { return _copyright; }
        }
        /// <summary>
        /// SEO 标题
        /// </summary>
        public string seo_title
        {
           set { _seo_title = value; }
           get { return _seo_title; }
        }
        public string seo_keyword
        {
           set { _seo_keyword = value; }
           get { return _seo_keyword; }
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
        /// 移动设备
        /// </summary>
        public int is_mobile
        {
           set { _is_mobile = value; }
           get { return _is_mobile; }
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
        public int inherit_id
        {
           set { _inherit_id = value; }
           get { return _inherit_id; }
        }
        public int bdsend
        {
           set { _bdsend = value; }
           get { return _bdsend; }
        }
        public string bdtoken
        {
           set { _bdtoken = value; }
           get { return _bdtoken; }
        }

        #endregion
    }
}
