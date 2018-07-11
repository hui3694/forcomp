using System;

namespace DTcms.Model
{
    /// <summary>
    /// 模型层
    /// <summary>
    [Serializable]
    public class dt_channel_field
    {
        public dt_channel_field() { }

        private int _id = 0;
        private int _channel_id = 0;
        private int _field_id = 0;

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
        public int field_id
        {
           set { _field_id = value; }
           get { return _field_id; }
        }

        #endregion
    }
}
