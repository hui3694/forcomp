using System;

namespace DTcms.Model
{
    /// <summary>
    /// QQ在线客服配置实体类
    /// <summary>
    [Serializable]
    public class qqonline_config
    {
        int _status = 0;
        int _xline = 0;
        int _yline = 0;
        int _position = 2;
        string _pattern = string.Empty;
        string _code = string.Empty;
        string _remark = string.Empty;

        /// <summary>
        /// 状态 0开启、1关闭
        /// </summary>
        public int status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// X坐标
        /// </summary>
        public int xline
        {
            set { _xline = value; }
            get { return _xline; }
        }
        /// <summary>
        /// Y坐标
        /// </summary>
        public int yline
        {
            set { _yline = value; }
            get { return _yline; }
        }
        /// <summary>
        /// 位置 0左、1上、2右、3下、4中
        /// </summary>
        public int position
        {
            set { _position = value; }
            get { return _position; }
        }
        /// <summary>
        /// 样式
        /// </summary>
        public string pattern
        {
            set { _pattern = value; }
            get { return _pattern; }
        }
        /// <summary>
        /// 二维码、仅部分样式支持
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 描述(支持HTML)、仅部分样式支持
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
    }
}
