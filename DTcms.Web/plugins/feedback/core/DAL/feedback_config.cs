using System;
using System.Collections.Generic;
using System.Text;
using DTcms.Common;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:配置文件
    /// </summary>
    public partial class feedbackconfig
    {
        private static object lockHelper = new object();
        public feedbackconfig()
        {
        }

        #region 扩展设置参数
        /// <summary>
        ///  读取站点配置文件
        /// </summary>
        public Model.feedbackconfig loadConfig(string configFilePath)
        {
            return (Model.feedbackconfig)SerializationHelper.Load(typeof(Model.feedbackconfig), configFilePath);
        }

        /// <summary>
        /// 写入站点配置文件
        /// </summary>
        public Model.feedbackconfig saveConifg(Model.feedbackconfig model, string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(model, configFilePath);
            }
            return model;
        }
        #endregion
    }
}
