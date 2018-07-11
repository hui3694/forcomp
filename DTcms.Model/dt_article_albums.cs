using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_article_albums
    {
        public dt_article_albums() { }

        private int _id = 0;
        private int _article_id = 0;
        private string _thumb_path = string.Empty;
        private string _original_path = string.Empty;
        private string _remark = string.Empty;
        private DateTime _add_time = DateTime.Now;
        private int _sort_id = 0;

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
        /// 缩略图路径
        /// </summary>
        public string thumb_path
        {
           set { _thumb_path = value; }
           get { return _thumb_path; }
        }
        /// <summary>
        /// 原图片路径
        /// </summary>
        public string original_path
        {
           set { _original_path = value; }
           get { return _original_path; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string remark
        {
           set { _remark = value; }
           get { return _remark; }
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
        /// 排序
        /// </summary>
        public int sort_id
        {
           set { _sort_id = value; }
           get { return _sort_id; }
        }

        #endregion
    }
}
