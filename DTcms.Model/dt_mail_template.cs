using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_mail_template
    {
        public dt_mail_template() { }

        private int _id = 0;
        private string _title = string.Empty;
        private string _call_index = string.Empty;
        private string _maill_title = string.Empty;
        private string _content = string.Empty;
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
        /// 邮件标题
        /// </summary>
        public string maill_title
        {
           set { _maill_title = value; }
           get { return _maill_title; }
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
