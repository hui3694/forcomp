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
                case "get_openid":  //获取openid
                    get_openid(context);
                    break;
                case "register":
                    register(context);
                    break;
                case "news_view":
                    news_view(context);
                    break;
                case "get_news_model":
                    get_news_model(context);
                    break;

            }

        }

        private void get_news_list(HttpContext context)
        {
            int page = DTRequest.GetInt("page",1);
            string keywords = DTRequest.GetString("keywords");

            int count = 0;
            int pageSize = 4;
            int sum = new BLL.news().GetCount("");

            if ((page - 1) * pageSize > sum)
            {
                //没有更多数据
                context.Response.Write("{\"status\":0,\"msg\":\"没有更多数据\"}");
                return;
            }

            DataSet ds = new BLL.news().GetList(pageSize, page, "title like '%" + keywords + "%'", "sort,time desc", out count);
            DataTable dt = ds.Tables[0];
            dt.Columns.Add("zan", typeof(int));
            dt.Columns.Add("collect", typeof(int));
            dt.Columns.Add("view", typeof(int));

            foreach (DataRow dr in dt.Rows)
            {
                dr["zan"] = new BLL.news_view().GetCount("isPN=2 and type=1");
                dr["collect"] = 0;
                dr["view"] = new BLL.news_view().GetCount("isPN=2 and type=2");
            }
            

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

        private void get_openid(HttpContext context)
        {
            string appid = DTRequest.GetString("appid");
            string secre = DTRequest.GetString("secre");
            string code = DTRequest.GetString("code");

            System.Net.WebRequest wReq = System.Net.WebRequest.Create("https://api.weixin.qq.com/sns/jscode2session?appid=" + appid + "&secret=" + secre + "&js_code=" + code+ "&grant_type=authorization_code");
            // Get the response instance. 
            System.Net.WebResponse wResp = wReq.GetResponse();
            System.IO.Stream respStream = wResp.GetResponseStream();
            // Dim reader As StreamReader = New StreamReader(respStream) 
            using (System.IO.StreamReader reader = new System.IO.StreamReader(respStream, System.Text.Encoding.GetEncoding("utf-8")))
            {
                context.Response.Write(reader.ReadToEnd());
            }
        }

        private void register(HttpContext context)
        {
            string avatar = DTRequest.GetString("avatar");
            string nickname = DTRequest.GetString("nickname");
            string openid = DTRequest.GetString("openid");
            int parent_id = DTRequest.GetInt("parent_id",0);
            int gender = DTRequest.GetInt("gender",0);
            string country = DTRequest.GetString("country");
            string province = DTRequest.GetString("province");
            string city = DTRequest.GetString("city");

            Model.user model = new Model.user();
            model.avatar = avatar;
            model.nickname = nickname;
            model.openid = openid;
            model.parent_id = parent_id;
            model.sex = gender;

            if(new BLL.user().Add(model) > 0){
                context.Response.Write("{\"status\":1}");
            }else
            {
                context.Response.Write("{\"status\":0}");
            }
        }

        #region 浏览/点赞
        private void news_view(HttpContext context)
        {
            int uid = DTRequest.GetInt("uid", 0);
            int isPN = DTRequest.GetInt("isPN", 0);
            int type = DTRequest.GetInt("type", 0);
            int newsId = DTRequest.GetInt("id", 0);

            Model.news_view model = new Model.news_view();
            model.user_id = uid;
            model.ispn = isPN;
            model.type = type;
            model.news_id = newsId;
            model.time = DateTime.Now;

            if(!new BLL.news_view().Exists("user_id="+uid+" and isPN="+isPN+" and type="+type))
            {
                new BLL.news_view().Add(model);
                context.Response.Write("{\"status\":1}");
            }
            else
            {//更新浏览时间，取消收藏
                if (type == 1)
                {
                    context.Response.Write(news_view_update(model));
                }
                else
                {
                    context.Response.Write(news_collect_cancel(model));
                }
                
            }
        }

        //更新浏览记录处理
        private string news_view_update(Model.news_view model)
        {

            int id = Convert.ToInt32(new BLL.news_view().GetList(0, "user_id=" + model.user_id + " and isPN=" + model.ispn + " and type=" + model.type, "").Tables[0].Rows[0]["id"]);
            model.id = id;
            if(new BLL.news_view().Update(model))
            {
                return "{\"status\":1}";
            }else
            {
                return "{\"status\":0}";
            }
            

        }

        //取消收藏处理
        private string news_collect_cancel(Model.news_view model)
        {
            int id = Convert.ToInt32(new BLL.news_view().GetList(0, "user_id=" + model.user_id + " and isPN=" + model.ispn + " and type=" + model.type, "").Tables[0].Rows[0]["id"]);
            if(new BLL.news_view().Delete(id))
            {
                return "{\"status\":1}";
            }else
            {
                return "{\"status\":0}";
            }
            
        }
        #endregion

        private void get_news_model(HttpContext context)
        {
            int id = DTRequest.GetInt("id", 0);
            DataTable dt= new BLL.news().GetList(1,"id="+id,"").Tables[0];
            if (dt.Rows.Count>0)
            {
                string time= Convert.ToDateTime(dt.Rows[0]["time"]).ToString("yyyy-MM-dd HH:mm"); 
                dt.Columns.Remove("time");
                dt.Columns.Add("time", typeof(string));
                dt.Rows[0]["time"] = time;
                
                context.Response.Write(JsonHelper.DataTableToJSON(dt).TrimEnd(']').TrimStart('['));
            }
            
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