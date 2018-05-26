using System;
using System.Collections.Generic;
using System.Text;
using DTcms.Common;

namespace DTcms.BLL
{
    /// <summary>
    /// 配置文件
    /// </summary>
    public partial class feedbackconfig
    {
        private const string config_path = "../config/install.config";
        private readonly DAL.feedbackconfig dal;

        public feedbackconfig()
        {
            dal = new DAL.feedbackconfig();
        }

        /// <summary>
        ///  读取配置文件
        /// </summary>
        public Model.feedbackconfig loadConfig()
        {
            string cacheName = "dt_cache_feedback_config";
            Model.feedbackconfig model = CacheHelper.Get<Model.feedbackconfig>(cacheName);
            if (model == null)
            {
                CacheHelper.Insert(cacheName, dal.loadConfig(Utils.GetMapPath(config_path)), Utils.GetMapPath(config_path));
                model = CacheHelper.Get<Model.feedbackconfig>(cacheName);
            }
            return model;
        }

        /// <summary>
        ///  保存配置文件
        /// </summary>
        public Model.feedbackconfig saveConifg(Model.feedbackconfig model)
        {
            return dal.saveConifg(model, Utils.GetMapPath(config_path));
        }
    }
}
