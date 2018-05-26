using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

namespace DTcms.Web.Plugin.Images
{
    public class images
    {
        /// <summary>
        /// 根据ID查询图片
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>返回 Model</returns>
        public DataTable get_images_list(string call_index)
        {
            DataTable dt = new DataTable();
            if (null != call_index && call_index.Length>0)
            {
                Model.plugin_images_class model = new BLL.plugin_images_class().GetModel(call_index);
                if (null != model && model.is_lock == 0)
                {
                    DataTable old = new BLL.plugin_images().GetList(model.num, "is_lock=0 and class_id=" + model.id, "sort_id asc,id desc").Tables[0];
                    dt = add_class_info(old, model);
                }
            }
            return dt;
        }

        /// <summary>
        /// 根据标记名查询内容列表
        /// </summary>
        /// <param name="call_index">call_index</param>
        /// <returns>返回内容</returns>
        public DataTable get_images_list(string call_index, string _strWhere)
        {
            DataTable dt = new DataTable();
            if (null != call_index && call_index.Length > 0)
            {
                Model.plugin_images_class model = new BLL.plugin_images_class().GetModel(call_index);
                if (null != model && model.is_lock == 0)
                {
                    string strWhere = "is_lock=0 and class_id=" + model.id;
                    if (null != _strWhere && _strWhere.Length > 0)
                    {
                        strWhere += " and " + _strWhere;
                    }
                    DataTable old = new BLL.plugin_images().GetList(model.num, strWhere, "sort_id asc,id desc").Tables[0];
                    dt = add_class_info(old, model);
                }
            }
            return dt;
        }

        /// <summary>
        /// 根据标记名查询内容列表
        /// </summary>
        /// <param name="call_index">call_index</param>
        /// <returns>返回内容</returns>
        public DataTable get_images_list(string call_index, string _strWhere, string filedOrder)
        {
            DataTable dt = new DataTable();
            if (null != call_index && call_index.Length > 0)
            {
                Model.plugin_images_class model = new BLL.plugin_images_class().GetModel(call_index);
                if (null != model && model.is_lock == 0)
                {
                    string strWhere = "is_lock=0 and class_id=" + model.id;
                    if (null != _strWhere && _strWhere.Length > 0)
                    {
                        strWhere += " and " + _strWhere;
                    }
                    DataTable old = new BLL.plugin_images().GetList(model.num, strWhere, filedOrder).Tables[0];
                    dt = add_class_info(old, model);
                }
            }
            return dt;
        }

        #region 私有方法
        /// <summary>
        /// 遍历插入图片尺寸
        /// </summary>
        private DataTable add_class_info(DataTable dt, Model.plugin_images_class model)
        {
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add("height", Type.GetType("System.Int32"));
                dt.Columns.Add("width", Type.GetType("System.Int32"));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["height"] = model.height;
                    dt.Rows[i]["width"] = model.width;
                }
            }
            return dt;
        } 
        #endregion
    }
}