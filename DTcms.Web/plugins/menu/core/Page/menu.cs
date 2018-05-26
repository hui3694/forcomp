using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using DTcms.Web.UI;

namespace DTcms.Web.Plugin.Menu
{
    public class menu
    {
        /// <summary>
        /// 返回菜单列表
        /// </summary>
        /// <param name="parent_id">父类ID</param>
        /// <returns></returns>
        public DataTable get_menu_list(int class_id, int parent_id)
        {
            string strWhere = "is_lock=0 and parent_id=" + parent_id;
            if (class_id > 0)
            {
                strWhere += " and class_id = " + class_id;
            }
            return new BLL.plugin_menu().GetList(0, strWhere, "sort_id asc,id asc").Tables[0];
        }
        /// <summary>
        /// 返回菜单列表
        /// </summary>
        /// <param name="top">数量</param>
        /// <param name="parent_id">父类ID</param>
        /// <returns></returns>
        public DataTable get_menu_list(int top, int class_id, int parent_id)
        {
            string strWhere = "is_lock=0 and parent_id=" + parent_id;
            if (class_id > 0)
            {
                strWhere += " and class_id = " + class_id;
            }
            return new BLL.plugin_menu().GetList(top, strWhere, "sort_id asc,id asc").Tables[0];
        }
        /// <summary>
        /// 返回菜单列表
        /// </summary>
        /// <param name="top">数量</param>
        /// <param name="parent_id">父类ID</param>
        /// <returns></returns>
        public DataTable get_menu_list(int top, int class_id, int parent_id, string _strWhere)
        {
            string strWhere = "is_lock=0 and parent_id=" + parent_id;
            if (class_id > 0)
            {
                strWhere += " and class_id = " + class_id;
            }
            if (null != _strWhere && _strWhere.Length > 0)
            {
                strWhere += " and " + _strWhere;
            }
            return new BLL.plugin_menu().GetList(top, strWhere, "sort_id asc,id asc").Tables[0];
        }
        /// <summary>
        /// 返回菜单列表
        /// </summary>
        /// <param name="top">数量</param>
        /// <param name="parent_id">父类ID</param>
        /// <returns></returns>
        public DataTable get_menu_list(int top, int class_id, int parent_id, string _strWhere, string filedOrder)
        {
            //条件
            string strWhere = "is_lock=0 and parent_id=" + parent_id;
            if (class_id > 0)
            {
                strWhere += " and class_id = " + class_id;
            }
            if (null != _strWhere && _strWhere.Length > 0)
            {
                strWhere += " and " + _strWhere;
            }
            //排序
            if (null == filedOrder || filedOrder.Length == 0)
            {
                filedOrder = "sort_id asc,id asc";
            }
            return new BLL.plugin_menu().GetList(top, strWhere, "sort_id asc,id asc").Tables[0];
        }
    }
}