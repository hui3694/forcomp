using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using DTcms.Web.UI;
using DTcms.Common;
using System.Data;

namespace DTcms.Web.tools
{
    /// <summary>
    /// app_ajax 的摘要说明
    /// </summary>
    public class app_ajax : IHttpHandler
    {

        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();

        public void ProcessRequest(HttpContext context)
        {
            string action = DTRequest.GetQueryString("action");

            switch (action)
            {
                case "get_news_list": //提交评论
                    get_news_list(context);
                    break;
                case "get_category_list"://获取产品栏目列表
                    get_category_list(context);
                    break;
            }

        }

        private void get_news_list(HttpContext context)
        {
            int page = DTRequest.GetInt("page",1);
            int count = 0;
            var pageSize = 3;
            int sum = new BLL.news().GetCount("");

            if ((page - 1) * pageSize > sum)
            {
                //没有更多数据
                context.Response.Write("{\"status\":0,\"msg\":\"没有更多数据\"}");
                return;
            }

            DataSet ds = new BLL.news().GetList(pageSize, page, "", "sort,time desc", out count);

            string strJson = DTcms.Common.JsonHelper.DataTableToJSON(ds.Tables[0]);

            context.Response.Write(strJson);
        }

        private void get_category_list(HttpContext context)
        {
            string strJson = "";
            strJson += "[";
            DataSet ds = new BLL.pro_category().GetList(0, "parent_id=0", "");
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                strJson += "{";
                strJson += "\"id\":\"" + dr["id"].ToString() + "\",";
                strJson += "\"title\":\"" + dr["title"].ToString() + "\",";
                strJson += "\"img\":\"" + dr["img"].ToString() + "\",";
                strJson += "\"img2\":\"" + dr["img2"].ToString() + "\",";

                strJson += "\"son\":";
                strJson += "[";
                DataSet ds2 = new BLL.pro_category().GetList(0, "parent_id=" + dr["id"], "");
                foreach(DataRow dr2 in ds2.Tables[0].Rows)
                {
                    strJson += "{";
                    strJson += "\"id\":\"" + dr2["id"].ToString() + "\",";
                    strJson += "\"title\":\"" + dr2["title"].ToString() + "\",";
                    strJson += "\"img\":\"" + dr2["img"].ToString() + "\",";
                    strJson += "\"img2\":\"" + dr2["img2"].ToString() + "\"";
                    strJson += "},";
                }
                strJson = strJson.TrimEnd(',') + "]";
                strJson +=  "},";
            }
            strJson = strJson.TrimEnd(',') + "]";
            context.Response.Write(strJson.TrimEnd(','));

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}