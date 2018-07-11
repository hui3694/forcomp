using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_advert
    {
        public dt_advert() { }

        private int _id = 0;
        private string _title = string.Empty;
        private int _type = 0;
        private decimal _price = 0M;
        private string _remark = string.Empty;
        private int _view_num = 0;
        private int _view_width = 0;
        private int _view_height = 0;
        private string _target = string.Empty;
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
        /// 标题
        /// </summary>
        public string title
        {
           set { _title = value; }
           get { return _title; }
        }
        public int type
        {
           set { _type = value; }
           get { return _type; }
        }
        public decimal price
        {
           set { _price = value; }
           get { return _price; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string remark
        {
           set { _remark = value; }
           get { return _remark; }
        }
        public int view_num
        {
           set { _view_num = value; }
           get { return _view_num; }
        }
        public int view_width
        {
           set { _view_width = value; }
           get { return _view_width; }
        }
        public int view_height
        {
           set { _view_height = value; }
           get { return _view_height; }
        }
        /// <summary>
        /// 打开方式
        /// </summary>
        public string target
        {
           set { _target = value; }
           get { return _target; }
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
