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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}