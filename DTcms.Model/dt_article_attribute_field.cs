using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_article_attribute_field
    {
        public dt_article_attribute_field() { }

        private int _id = 0;
        private string _name = string.Empty;
        private string _title = string.Empty;
        private string _control_type = string.Empty;
        private string _data_type = string.Empty;
        private int _data_length = 0;
        private int _data_place = 0;
        private string _item_option = string.Empty;
        private string _default_value = string.Empty;
        private int _is_required = 0;
        private int _is_password = 0;
        private int _is_html = 0;
        private int _editor_type = 0;
        private string _valid_tip_msg = string.Empty;
        private string _valid_error_msg = string.Empty;
        private string _valid_pattern = string.Empty;
        private int _sort_id = 0;
        private int _is_sys = 0;

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
        public string control_type
        {
           set { _control_type = value; }
           get { return _control_type; }
        }
        public string data_type
        {
           set { _data_type = value; }
           get { return _data_type; }
        }
        public int data_length
        {
           set { _data_length = value; }
           get { return _data_length; }
        }
        public int data_place
        {
           set { _data_place = value; }
           get { return _data_place; }
        }
        public string item_option
        {
           set { _item_option = value; }
           get { return _item_option; }
        }
        public string default_value
        {
           set { _default_value = value; }
           get { return _default_value; }
        }
        public int is_required
        {
           set { _is_required = value; }
           get { return _is_required; }
        }
        public int is_password
        {
           set { _is_password = value; }
           get { return _is_password; }
        }
        public int is_html
        {
           set { _is_html = value; }
           get { return _is_html; }
        }
        public int editor_type
        {
           set { _editor_type = value; }
           get { return _editor_type; }
        }
        public string valid_tip_msg
        {
           set { _valid_tip_msg = value; }
           get { return _valid_tip_msg; }
        }
        public string valid_error_msg
        {
           set { _valid_error_msg = value; }
           get { return _valid_error_msg; }
        }
        public string valid_pattern
        {
           set { _valid_pattern = value; }
           get { return _valid_pattern; }
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
        /// 是否集成
        /// </summary>
        public int is_sys
        {
           set { _is_sys = value; }
           get { return _is_sys; }
        }

        #endregion
    }
}
