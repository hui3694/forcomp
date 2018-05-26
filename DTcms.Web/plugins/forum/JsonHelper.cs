using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTcms.Web.Plugin.Forum
{
    public class JsonHelper
    {
        /// <summary>
        /// 输出Json列表
        /// </summary>
        /// <param name="response"></param>
        public static void WriteJson(HttpContext context, object response)
        {
            string jsonpCallback = context.Request["callback"],
                   json = JsonConvert.SerializeObject(response);
            if (String.IsNullOrWhiteSpace(jsonpCallback))
            {
                context.Response.AddHeader("Content-Type", "text/html");//此处关键 text/html 和 text/plain 不同小心
                context.Response.Write(json);
            }
            else
            {
                context.Response.AddHeader("Content-Type", "application/javascript");
                context.Response.Write(String.Format("{0}({1});", jsonpCallback, json));
            }
            context.Response.End();
        }
    }
}