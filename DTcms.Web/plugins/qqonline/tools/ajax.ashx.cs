 using System;
using System.Xml;
using System.Text;
using System.Data;
using System.Web;
using DTcms.Common;

namespace DTcms.Web.Plugin.QQOnline.tools
{
    public class ajax : IHttpHandler
    {
        DTcms.Model.siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig();

        public void ProcessRequest(HttpContext context)
        {
            Model.qqonline_config config = new BLL.qqonline_config().loadConfig();
            if(config.status==1){
                context.Response.Write("{ \"msg\":\"在线客服功能未开启！\", \"status\":0 }");
                return;
            }
            DataTable dt = new BLL.plugin_qqonline().GetList(0, "is_lock=0", "sort_id asc,id desc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Remove("id");
                dt.Columns.Remove("is_lock");
                dt.Columns.Remove("sort_id");
                dt.Columns.Remove("add_time");
                dt.Columns["qq"].ColumnName = "q";
                dt.Columns["img_url"].ColumnName = "i";
                dt.Columns["link_url"].ColumnName = "u";
                dt.Columns["username"].ColumnName = "n";
                dt.Columns["color"].ColumnName = "c";
            }
            JsonHelper.WriteJson(context, new
            {
                status=1,
                path = siteConfig.webpath,
                code = config.code,
                position = config.position,
                remark = config.remark,
                skin =config.pattern,
                list = dt
            });
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
