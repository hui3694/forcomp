using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_weixin_account
    {
        public dt_weixin_account() { }

        private int _id = 0;
        private string _name = string.Empty;
        private string _originalid = string.Empty;
        private string _wxcode = string.Empty;
        private string _token = string.Empty;
        private string _appid = string.Empty;
        private string _appsecret = string.Empty;
        private int _is_push = 0;
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
        /// <summary>
        /// 名称
        /// </summary>
        public string name
        {
           set { _name = value; }
           get { return _name; }
        }
        public string originalid
        {
           set { _originalid = value; }
           get { return _originalid; }
        }
        public string wxcode
        {
           set { _wxcode = value; }
           get { return _wxcode; }
        }
        public string token
        {
           set { _token = value; }
           get { return _token; }
        }
        public string appid
        {
           set { _appid = value; }
           get { return _appid; }
        }
        public string appsecret
        {
           set { _appsecret = value; }
           get { return _appsecret; }
        }
        public int is_push
        {
           set { _is_push = value; }
           get { return _is_push; }
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
