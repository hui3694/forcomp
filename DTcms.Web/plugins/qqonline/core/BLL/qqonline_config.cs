using System;
using System.Collections.Generic;
using DTcms.Common;

namespace DTcms.BLL
{
    /// 配置文件
    /// </summary>
    public partial class qqonline_config
    {
        
        private const string cacheName = "dt_plugin_qqonline_config_cache";
        private readonly string configPath;
        private readonly DAL.qqonline_config dal;

        public qqonline_config()
        {
            configPath = Utils.GetMapPath("../config/qqonline.config");
            dal = new DAL.qqonline_config();
        }

        /// <summary>
        ///  读取配置文件
        /// </summary>
        public Model.qqonline_config loadConfig()
        {
           
            Model.qqonline_config model = CacheHelper.Get<Model.qqonline_config>(cacheName);
            if (model == null)
            {
                CacheHelper.Insert(cacheName, dal.loadConfig(configPath), configPath);
                model = CacheHelper.Get<Model.qqonline_config>(cacheName);
            }
            return model;
        }

        /// <summary>
        ///  保存配置文件
        /// </summary>
        public Model.qqonline_config saveConifg(Model.qqonline_config model)
        {
            return dal.saveConifg(model, configPath);
        }
    }
}
