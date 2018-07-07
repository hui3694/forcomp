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
                case "get_news_commend":
                    get_news_commend(context);
                    break;
                case "post_news_commend":
                    post_news_commend(context);
                    break;
                case "update_user":
                    update_user(context);
                    break;
                case "product_add":
                    product_add(context);
                    break;
                case "get_pro_list":
                    get_pro_list(context);
                    break;
                case "get_pro_model":
                    get_pro_model(context);
                    break;
                case "get_pro_city":
                    get_pro_city(context);
                    break;
                case "get_proUser_comment":
                    get_proUser_comment(context);
                    break;
                case "get_user_view_list":
                    get_user_view_list(context);
                    break;
                case "register_pm":
                    register_pm(context);
                    break;
                case "pm_exis":
                    pm_exis(context);
                    break;
            }

        }

        #region news
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
            string[] arr = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                arr[i] = Convert.ToDateTime(dt.Rows[i]["time"].ToString()).ToString("yyyy-MM-dd HH:mm");
            }
            dt.Columns.Remove("time");
            dt.Columns.Add("time",typeof(string));

            foreach (DataRow dr in dt.Rows)
            {
                dr["view"] = new BLL.news_view().GetCount("news_id="+dr["id"].ToString()+" and isPN=2 and type=1");
                dr["collect"] = new BLL.news_commend().GetCount("news_id=" + dr["id"].ToString());
                dr["zan"] = new BLL.news_view().GetCount("news_id=" + dr["id"].ToString() + " and isPN=2 and type=2");
                dr["time"] = arr[dt.Rows.IndexOf(dr)];
            }
            

            string strJson = DTcms.Common.JsonHelper.DataTableToJSON(ds.Tables[0]);
            

            context.Response.Write(strJson);
        }
        private void get_news_model(HttpContext context)
        {
            int id = DTRequest.GetInt("id", 0);
            int uid = DTRequest.GetInt("uid", 0);
            DataTable dt = new BLL.news().GetList(1, "id=" + id, "").Tables[0];
            if (dt.Rows.Count > 0)
            {
                string time = Convert.ToDateTime(dt.Rows[0]["time"]).ToString("yyyy-MM-dd HH:mm");
                dt.Columns.Remove("time");
                dt.Columns.Add("time", typeof(string));
                dt.Columns.Add("isCollect", typeof(int));
                dt.Rows[0]["time"] = time;
                if (uid != 0)
                {
                    dt.Rows[0]["isCollect"] = new BLL.news_view().GetCount("user_id=" + uid + " and isPN=2 and type=2 and news_id=" + dt.Rows[0]["id"].ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    dt.Rows[0]["isCollect"] = 0;
                }

                context.Response.Write(JsonHelper.DataTableToJSON(dt).TrimEnd(']').TrimStart('['));
            }

        }
        #endregion
        
        #region product
        private void get_category_list(HttpContext context)
        {
            string city = DTRequest.GetString("city");

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
                    int num = new BLL.product().GetCount("status=2 and city='" + city + "' and category=" + dr2["id"].ToString());
                    strJson += "{";
                    strJson += "\"id\":\"" + dr2["id"].ToString() + "\",";
                    strJson += "\"title\":\"" + dr2["title"].ToString() + "\",";
                    strJson += "\"img\":\"" + dr2["img"].ToString() + "\",";
                    strJson += "\"img2\":\"" + dr2["img2"].ToString() + "\",";
                    strJson += "\"num\":" + num;
                    strJson += "},";
                }
                strJson = strJson.TrimEnd(',') + "]";
                strJson +=  "},";
            }
            strJson = strJson.TrimEnd(',') + "]";
            context.Response.Write(strJson.TrimEnd(','));

        }

        private void get_pro_list(HttpContext context)
        {
            int page = DTRequest.GetInt("page", 1);
            int category = DTRequest.GetInt("category", 0);
            int uid = DTRequest.GetInt("uid", 0);
            string keywords = DTRequest.GetString("keywords");
            string city = DTRequest.GetString("city");

            int count = 0;
            int pageSize = 8;
            int sum = new BLL.product().GetCount("status=2 and city='" + city + "' and category=" + (category==0? "category":category.ToString()));

            if ((page - 1) * pageSize >= sum)
            {
                //没有更多数据
                context.Response.Write("{\"status\":0,\"msg\":\"没有更多数据\"}");
                return;
            }

            DataSet ds = new BLL.product().GetList(pageSize, page, "city='" + city + "' and category=" + (category == 0 ? "category" : category.ToString()) + " and title like '%" + keywords + "%'", "pass_time desc", out count);
            DataTable dt = ds.Tables[0];
            dt.Columns.Add("zan", typeof(int));
            dt.Columns.Add("collect", typeof(int));
            dt.Columns.Add("view", typeof(int));

            foreach (DataRow dr in dt.Rows)
            {
                dr["view"] = new BLL.news_view().GetCount("news_id=" + dr["id"].ToString() + " and isPN=1 and type=1");
                dr["collect"] = new BLL.news_commend().GetCount("news_id=" + dr["id"].ToString());
                dr["zan"] = new BLL.news_view().GetCount("news_id=" + dr["id"].ToString() + " and isPN=1 and type=2");
            }


            string strJson = DTcms.Common.JsonHelper.DataTableToJSON(ds.Tables[0]);


            context.Response.Write(strJson);
        }

        private void product_add(HttpContext context)
        {
            int cateogry = DTRequest.GetInt("category", 0);
            string title = DTRequest.GetString("title");
            string cont = DTRequest.GetString("cont");
            string lat = DTRequest.GetString("lat");
            string lon = DTRequest.GetString("lon");
            string city = DTRequest.GetString("city");
            string addr = DTRequest.GetString("addr");
            string openid = DTRequest.GetString("openid");

            Model.product model = new Model.product();
            Model.user user = new BLL.user().GetModel(openid);
            if (user!=null)
            {
                model.user_id = user.id;
            }else
            {
                context.Response.Write("{\"status\":0,\"msg\":\"提交失败！\"}");
                return;
            }
            model.category = cateogry;
            model.title = title;
            model.cont = cont;
            model.lat = lat;
            model.lon = lon;
            model.city = city;
            model.addr = addr;
            model.status = 1;



            if (new BLL.product().Add(model) > 0)
            {
                context.Response.Write("{\"status\":1,\"msg\":\"提交成功！\"}");
            }else
            {
                context.Response.Write("{\"status\":0,\"msg\":\"提交失败！\"}");
            }

        }

        private void get_pro_model(HttpContext context)
        {
            int id = DTRequest.GetInt("id", 0);
            int uid = DTRequest.GetInt("uid", 0);
            DataTable dt = new BLL.product().GetList(1, "id=" + id, "").Tables[0];
            if (dt.Rows.Count > 0)
            {
                string pass_time = Convert.ToDateTime(dt.Rows[0]["pass_time"]).ToString("yyyy-MM-dd HH:mm");
                string add_time = Convert.ToDateTime(dt.Rows[0]["add_time"]).ToString("yyyy-MM-dd HH:mm");
                dt.Columns.Remove("pass_time");
                dt.Columns.Add("pass_time", typeof(string));
                dt.Columns.Remove("add_time");
                dt.Columns.Add("add_time", typeof(string));
                dt.Columns.Add("isCollect", typeof(int));
                dt.Rows[0]["pass_time"] = pass_time;
                dt.Rows[0]["add_time"] = add_time;
                if (uid != 0)
                {
                    dt.Rows[0]["isCollect"] = new BLL.news_view().GetCount("user_id=" + uid + " and isPN=2 and type=2 and news_id=" + dt.Rows[0]["id"].ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    dt.Rows[0]["isCollect"] = 0;
                }

                context.Response.Write(JsonHelper.DataTableToJSON(dt).TrimEnd(']').TrimStart('['));
            }

        }

        private void get_pro_city(HttpContext context)
        {
            DataSet cityList = new BLL.product().GetCityList();
            DataTable dt = cityList.Tables[0];
            context.Response.Write(JsonHelper.DataTableToJSON(dt));
        }

        private void get_proUser_comment(HttpContext context)
        {
            int user_id = DTRequest.GetInt("uid", 0);
            //select * from fg_news_commend where news_id in(select id from fg_product where user_id=1) and isPN=1 order by time desc
            DataTable dt = new BLL.product().GetUserComment(user_id).Tables[0];
            string[] arr = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                arr[i] = Convert.ToDateTime(dt.Rows[i]["time"].ToString()).ToString("yyyy-MM-dd HH:mm");
            }
            dt.Columns.Remove("time");
            dt.Columns.Add("time", typeof(string));

            dt.Columns.Add("phone", typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                dr["time"] = arr[dt.Rows.IndexOf(dr)];
                Model.user user = new BLL.user().GetModel(Convert.ToInt32(dr["user_id"]));
                dr["phone"] = user.phone;
            }
            context.Response.Write(JsonHelper.DataTableToJSON(dt));
        }
        #endregion

        #region user
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
        private void update_user(HttpContext context)
        {
            string openid = DTRequest.GetString("openid");
            string name = DTRequest.GetString("name");
            int sex = DTRequest.GetInt("sex", 0);
            string phone = DTRequest.GetString("phone");
            string email = DTRequest.GetString("email");
            Model.user model = new BLL.user().GetModel(openid);
            model.nickname = name;
            model.sex = sex;
            model.phone = phone;
            model.email = email;
            if (new BLL.user().Update(model))
            {
                context.Response.Write("{\"status\":1,\"msg\":\"修改成功！\"}");
            }
            else
            {
                context.Response.Write("{\"status\":0,\"msg\":\"修改失败！\"}");
            }
        }
        
        private void register_pm(HttpContext context)
        {
            int uid = DTRequest.GetInt("uid", 0);
            string name = DTRequest.GetString("name");
            string birthday = DTRequest.GetString("birthday");
            int sex = DTRequest.GetInt("sex", 0);
            string origin = DTRequest.GetString("origin");
            string phone = DTRequest.GetString("phone");
            string comName = DTRequest.GetString("comName");
            string job = DTRequest.GetString("job");
            int year = DTRequest.GetInt("year",0);
            string jobImg = DTRequest.GetString("jobImg");
            string img = DTRequest.GetString("img");

            if (uid == 0)
            {
                context.Response.Write("{\"status\":0,\"msg\":\"未登录，请登录后重新提交！\"}");
                return;
            }
            if (name == "")
            {
                context.Response.Write("{\"status\":0,\"msg\":\"请输入姓名！\"}");
                return;
            }
            if (sex == 0)
            {
                context.Response.Write("{\"status\":0,\"msg\":\"请选择性别！\"}");
                return;
            }
            if (origin == "")
            {
                context.Response.Write("{\"status\":0,\"msg\":\"请输入籍贯！\"}");
                return;
            }
            if (phone == "")
            {
                context.Response.Write("{\"status\":0,\"msg\":\"请输入电话号码！\"}");
                return;
            }
            if (comName == "")
            {
                context.Response.Write("{\"status\":0,\"msg\":\"请输入公司名称！\"}");
                return;
            }
            if (job == "")
            {
                context.Response.Write("{\"status\":0,\"msg\":\"请输入所在岗位！\"}");
                return;
            }
            if (jobImg == "" || jobImg == "undefined" || img == "" || img == "undefined")
            {
                context.Response.Write("{\"status\":0,\"msg\":\"请上传工牌照片和生活照！\"}");
                return;
            }

            Model.user_pm model = new Model.user_pm();
            model.user_id = uid;
            model.name = name;
            model.sex = sex;
            model.origin = origin;
            model.phone = phone;
            model.comname = comName;
            model.job = job;
            model.year = year;
            model.jobimg = jobImg;
            model.img = img;
            model.status = 1;
            model.add_time = DateTime.Now;

            if (new BLL.user_pm().Add(model) > 0)
            {
                context.Response.Write("{\"status\":1,\"msg\":\"提交成功！\"}");
            }else
            {
                context.Response.Write("{\"status\":0,\"msg\":\"提交失败，请重新提交！\"}");
            }
        }

        private void pm_exis(HttpContext context)
        {
            int uid = DTRequest.GetInt("uid", 0);
            if (uid == 0)
            {
                context.Response.Write("{\"status\":0,\"msg\":\"未登录，请先登录！\"}");
            }
            if(new BLL.user_pm().GetCount("user_id=" + uid) > 0)
            {
                int val = Convert.ToInt32(new BLL.user_pm().GetList(0, "user_id=" + uid, "").Tables[0].Rows[0]["status"]);
                if (val == 1)
                {
                    context.Response.Write("{\"status\":1,\"msg\":\"审核中，请耐心等待！\",\"val\":" + val + "}");
                }else if (val == 2)
                {
                    context.Response.Write("{\"status\":2,\"msg\":\"审核已通过！\",\"val\":" + val + "}");
                }else
                {
                    context.Response.Write("{\"status\":1,\"msg\":\"审核未通过！\",\"val\":" + val + "}");
                }
            }
        }

        //收藏列表,点赞列表
        private void get_user_view_list(HttpContext context)
        {
            int uid = DTRequest.GetInt("uid", 0);
            int isPN = DTRequest.GetInt("isPN", 0);
            int type = DTRequest.GetInt("type", 0);
            DataTable dt = new BLL.news_view().GetList(0, "type=" + type + " and isPN=" + isPN + " and user_id=" + uid, "time desc").Tables[0];
            dt.Columns.Add("title", typeof(string));
            dt.Columns.Add("cont", typeof(string));
            dt.Columns.Add("day", typeof(string));
            
            foreach(DataRow dr in dt.Rows)
            {
                string title, cont;
                if (isPN == 1)
                {
                    Model.product model = new BLL.product().GetModel(Convert.ToInt32(dr["news_id"]));
                    title = model.title;
                    if (model.cont.Length > 60){
                        cont = model.cont.Substring(0, 60) + "...";
                    }else{
                        cont = model.cont;
                    }
                    
                }else
                {
                    Model.news model = new BLL.news().GetModel(Convert.ToInt32(dr["news_id"]));
                    title = model.title;
                    if (model.zhaiyao.Length > 60){
                        cont = model.zhaiyao.Substring(0, 60) + "...";
                    }else{
                        cont = model.zhaiyao;
                    }
                }
                dr["title"] = title;
                dr["cont"] = cont;
                //时间隔计算
                DateTime t1 = DateTime.Now;
                DateTime t2 = Convert.ToDateTime(dr["time"]);
                TimeSpan ts = t1.Subtract(t2);
                if (ts.Days > 3)
                {
                    dr["day"] = Convert.ToDateTime(dr["time"]).ToString("yyyy-MM-dd");
                }else if (ts.Days > 0)
                {
                    dr["day"] = ts.Days + "天前";
                }else if (ts.Hours > 0)
                {
                    dr["day"] = ts.Hours + "小时前";
                }else if (ts.Minutes > 0)
                {
                    dr["day"] = ts.Minutes + "分钟前";
                }else if (ts.Seconds > 0)
                {
                    dr["day"] = ts.Seconds + "秒前";
                }
                else
                {
                    dr["day"] = "未知";
                }

            }
            context.Response.Write(JsonHelper.DataTableToJSON(dt));
        }
        #endregion

        #region register
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

            if (new BLL.user().GetCount("openid='" + openid + "'") ==0 && new BLL.user().Add(model) > 0) {
                string ret = JsonHelper.DataTableToJSON(new BLL.user().GetList(1, "openid='" + openid + "'", "").Tables[0]);
                ret = ret.TrimEnd(']').TrimStart('[');
                context.Response.Write(ret);
            }else
            {
                string ret = JsonHelper.DataTableToJSON(new BLL.user().GetList(1, "openid='" + openid + "'", "").Tables[0]);
                ret = ret.TrimEnd(']').TrimStart('[');
                context.Response.Write(ret);
            }
        }
        #endregion

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

            if(uid==0 || new BLL.news_view().GetCount("user_id="+uid+" and isPN="+isPN+" and type="+type+" and news_id="+newsId)==0)
            {
                new BLL.news_view().Add(model);
                if (model.type==2)
                {
                    context.Response.Write("{\"status\":1,\"msg\":\"收藏成功！\"}");
                }
                else
                {
                    context.Response.Write("{\"status\":1,\"msg\":\"浏览量+1\"}");
                }
                
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
                return "{\"status\":1,\"msg\":\"更新浏览时间\"}";
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
                return "{\"status\":1,\"msg\":\"取消收藏成功\"}";
            }
            else
            {
                return "{\"status\":0}";
            }
            
        }
        #endregion


        #region 评论
        private void get_news_commend(HttpContext context)
        {
            int news_id = DTRequest.GetInt("id", 0);
            DataTable dt = new BLL.news_commend().GetList(0, "news_id=" + news_id, "time").Tables[0];

            string[] arr = new string[dt.Rows.Count];
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                arr[i]= Convert.ToDateTime(dt.Rows[i]["time"].ToString()).ToString("yyyy-MM-dd HH:mm");
            }
            dt.Columns.Remove("time");
            dt.Columns.Add("time");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["time"] = arr[i];
            }

            context.Response.Write(JsonHelper.DataTableToJSON(dt));
        }

        private void post_news_commend(HttpContext context)
        {
            int uid = DTRequest.GetInt("uid", 0);
            string name = DTRequest.GetString("name");
            string avatar = DTRequest.GetString("avatar");
            int isPN = DTRequest.GetInt("isPN", 0);
            int news_id = DTRequest.GetInt("news_id", 0);
            string cont = DTRequest.GetString("cont");

            Model.news_commend model = new Model.news_commend();
            model.user_id = uid;
            model.name = name;
            model.avatar = avatar;
            model.ispn = isPN;
            model.news_id = news_id;
            model.ishide = 0;
            model.time = DateTime.Now;
            model.cont = cont;

            if (isPN == 1 && new BLL.user().GetCount("id="+uid+" and phone!=''")==0)
            {//判断为产品，需要填写手机号
                context.Response.Write("{\"status\":0,\"msg\":\"请先在个人信息中补充联系电话！\"}");
                return;
            }

            if(new BLL.news_commend().Add(model) > 0)
            {
                context.Response.Write("{\"status\":1,\"msg\":\"提交成功！\"}");
            }else
            {
                context.Response.Write("{\"status\":0,\"msg\":\"提交失败！\"}");
            }

        }

        #endregion

        #region 其他
        /// <summary>
        /// 积分记录
        /// </summary>
        /// <param name="context"></param>
        private void point_log(HttpContext context)
        {
            //type:1签到，2发表评论，3每天分享3个50人以上群或分享资讯到朋友圈，4联系产品经理
            int type = DTRequest.GetInt("type", 0);
            int uid = DTRequest.GetInt("uid", 0);
            int val = DTRequest.GetInt("val", 0);

            string remark = DTRequest.GetString("remark");
            Model.point model = new Model.point();
            model.user_id = uid;
            model.value = val;
            model.remark = remark;
            model.add_time = DateTime.Now;
            new BLL.point().Add(model);

        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}