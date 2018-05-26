using System;
using System.Collections.Generic;
using System.Text;
using DTcms.Common;

namespace DTcms.DAL
{
    class qqonline_config
    {
        private static object lockHelper = new object();

        public qqonline_config()
        {
        }

        #region 扩展设置参数
        /// <summary>
        ///  读取站点配置文件
        /// </summary>
        public Model.qqonline_config loadConfig(string configFilePath)
        {
            return (Model.qqonline_config)SerializationHelper.Load(typeof(Model.qqonline_config), configFilePath);
        }

        /// <summary>
        /// 写入站点配置文件
        /// </summary>
        public Model.qqonline_config saveConifg(Model.qqonline_config model, string configFilePath)
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
