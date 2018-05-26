using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.Caching;
using System.Web.UI.WebControls;
using DTcms.Common;
using DTcms.Web.UI;

namespace DTcms.Web.admin.settings
{
    public partial class sys_cache : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("system_cache", DTEnums.ActionEnum.View.ToString());

                //清空权限
                if (!ChkAuthority("system_cache", DTEnums.ActionEnum.DelAll.ToString()))
                {
                    this.delBtnPannel.Visible = false;
                }

                bindCache();
            }
        }

        /// <summary>
        /// 输出缓存列表
        /// </summary>
        private void bindCache()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("i", Type.GetType("System.Int32"));
            dt.Columns.Add("name", Type.GetType("System.String"));
            dt.Columns.Add("b", Type.GetType("System.String"));
            int i = 0;
            string cacheKey = siteConfig.cachekey;
            IDictionaryEnumerator enumerator = HttpRuntime.Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (Left(enumerator.Key.ToString(), cacheKey.Length) == cacheKey)
                {
                    i++;
                    DataRow row = dt.NewRow();
                    row["i"] = i;
                    row["name"] = enumerator.Key.ToString();
                    row["b"] = enumerator.Value.ToString().Length.ToString();
                    dt.Rows.Add(row);
                }
            }
            this.rptList.DataSource = dt;
            this.rptList.DataBind();
        }

        //删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("system_cache", DTEnums.ActionEnum.DelAll.ToString());

            string key = siteConfig.cachekey;
            Cache cache = HttpRuntime.Cache;
            IDictionaryEnumerator enumerator = HttpRuntime.Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (Left(enumerator.Key.ToString(), key.Length) == key)
                {
                    cache.Remove(enumerator.Key.ToString());
                }
            }
            JscriptMsg("清除缓存成功！", "sys_cache.aspx");
        }

        #region 私有方法
        /// <summary>
        /// 从左边截取
        /// </summary>
        /// <param name="sSource">原字符串</param>
        /// <param name="iLength">长度</param>
        /// <returns></returns>
        public static string Left(string sSource, int iLength)
        {
            return sSource.Substring(0, (iLength > sSource.Length) ? sSource.Length : iLength);
        }
        #endregion
    }
}