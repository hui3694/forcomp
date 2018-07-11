using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_weixin_response_content
    {
        public dt_weixin_response_content() { }

        private int _id = 0;
        private int _account_id = 0;
        private string _openid = string.Empty;
        private string _request_type = string.Empty;
        private string _request_content = string.Empty;
        private string _response_type = string.Empty;
        private string _reponse_content = string.Empty;
        private string _create_time = string.Empty;
        private string _xml_content = string.Empty;
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
        public string openid
        {
           set { _openid = value; }
           get { return _openid; }
        }
        public string request_type
        {
           set { _request_type = value; }
           get { return _request_type; }
        }
        public string request_content
        {
           set { _request_content = value; }
           get { return _request_content; }
        }
        public string response_type
        {
           set { _response_type = value; }
           get { return _response_type; }
        }
        public string reponse_content
        {
           set { _reponse_content = value; }
           get { return _reponse_content; }
        }
        public string create_time
        {
           set { _create_time = value; }
           get { return _create_time; }
        }
        public string xml_content
        {
           set { _xml_content = value; }
           get { return _xml_content; }
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
