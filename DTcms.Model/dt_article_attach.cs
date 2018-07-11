using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_article_attach
    {
        public dt_article_attach() { }

        private int _id = 0;
        private int _article_id = 0;
        private string _file_name = string.Empty;
        private string _file_path = string.Empty;
        private int _file_size = 0;
        private string _file_ext = string.Empty;
        private int _down_num = 0;
        private int _point = 0;
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
        /// 新闻ID
        /// </summary>
        public int article_id
        {
           set { _article_id = value; }
           get { return _article_id; }
        }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string file_name
        {
           set { _file_name = value; }
           get { return _file_name; }
        }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string file_path
        {
           set { _file_path = value; }
           get { return _file_path; }
        }
        /// <summary>
        /// 文件大小
        /// </summary>
        public int file_size
        {
           set { _file_size = value; }
           get { return _file_size; }
        }
        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string file_ext
        {
           set { _file_ext = value; }
           get { return _file_ext; }
        }
        /// <summary>
        /// 下载次数
        /// </summary>
        public int down_num
        {
           set { _down_num = value; }
           get { return _down_num; }
        }
        /// <summary>
        /// 积分
        /// </summary>
        public int point
        {
           set { _point = value; }
           get { return _point; }
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
