using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Web;
using System.Web.SessionState;
using DTcms.Common;
using DTcms.Search;

namespace DTcms.Web.tools
{
    /// <summary>
    /// lucene 的摘要说明
    /// </summary>
    public class lucene : IHttpHandler, IRequiresSessionState
    {
        Model.manager adminInfo = null;
        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
        public void ProcessRequest(HttpContext context)
        {
            adminInfo = new Web.UI.ManagePage().GetAdminInfo();
            if (null == adminInfo)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"尚未登录或已超时，请登录后操作！\"}");
                return;
            }

            string action = DTRequest.GetQueryString("action");
            switch (action)
            {
                case "create_index":   //创建索引
                    CreateSearchIndex(context);
                    break;
                case "get_dic_count":  //获取词库总数
                    get_dic_count(context);
                    break;
                case "get_dic_attr":  //获取关键词属性
                    get_dic_attr(context);
                    break;
                case "add_dic_word":  //添加词语
                    add_dic_word(context);
                    break;
                case "add_dic_word_all":  //批量添加词语
                    add_dic_word_all(context);
                    break;
                case "edit_dic_word":  //修改词语
                    edit_dic_word(context);
                    break;
                case "del_dic_word":  //删除词语
                    del_dic_word(context);
                    break;
                case "create_dictionaries":  //重建词库
                    create_dictionaries(context);
                    break;
                case "get_search_prompt":  //获取搜索列表
                    get_search_prompt(context);
                    break;
            }
        }

        #region 索引数据
        /// <summary>
        /// 索引数据
        /// </summary>
        private void CreateSearchIndex(HttpContext context)
        {
            //检查权限
            if (!new BLL.manager_role().Exists(adminInfo.role_id, "lucene_index", DTEnums.ActionEnum.Build.ToString()))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"您没有确认订单的权限！\"}");
                return;
            }
            bool hasnew = false;
            int is_create = DTRequest.GetQueryInt("create");
            int is_lock = is_create;
            string strWhere = "status=0";
            BLL.article bll = new BLL.article();
            BLL.channel chl = new BLL.channel();
            BLL.luceneconfig xml = new BLL.luceneconfig();
            List<Model.luceneconfig> list = xml.Load();
            foreach (Model.luceneconfig model in list)
            {
                if (!chl.Exists(model.name))
                {
                    continue;
                }
                if (is_create == 0)
                {
                    strWhere += " and id >" + model.id.ToString();
                }
                if (model.status == 1)
                {
                    DataTable dt = bll.GetList(model.name, 1000, strWhere, "id asc").Tables[0];
                    int _count = dt.Rows.Count;
                    if (_count > 0)
                    {
                        int count = 0;
                        hasnew = true;
                        LuceneHelper.CreateIndex(LuceneHelper.INDEX_DIR, is_lock);
                        LuceneHelper.MaxMergeFactor = 301;
                        LuceneHelper.MinMergeDocs = 301;
                        string _maxid = dt.Rows[_count - 1]["ID"].ToString();
                        SearchItem item = null;
                        if (is_lock > 0)
                        {
                            is_lock = 0;
                        }
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            item = new SearchItem();
                            item.id = Utils.StrToInt(dt.Rows[j]["id"].ToString(), 0);
                            item.site_id = Utils.StrToInt(dt.Rows[j]["site_id"].ToString(), 0);
                            item.channel_id = Utils.StrToInt(dt.Rows[j]["channel_id"].ToString(), 0);
                            item.category_id = Utils.StrToInt(dt.Rows[j]["category_id"].ToString(), 0);
                            item.title = dt.Rows[j]["title"].ToString();
                            //if (dt.Columns.Contains("sub_title"))
                            //{
                            //    item.sub_title = dt.Rows[j]["sub_title"].ToString();
                            //}
                            //else
                            //{
                            //    item.sub_title = "";
                            //}
                            item.call_index = dt.Rows[j]["call_index"].ToString();
                            item.tags = dt.Rows[j]["tags"].ToString();
                            item.img_url = dt.Rows[j]["img_url"].ToString();
                            //item.zhaiyao = dt.Rows[j]["zhaiyao"].ToString();
                            item.zhaiyao = Utils.DropHTML(dt.Rows[j]["content"].ToString());
                            //if (dt.Columns.Contains("market_price"))
                            //{
                            //    item.market_price = Utils.StrToDecimal(dt.Rows[j]["market_price"].ToString(), 0);
                            //}
                            //else
                            //{
                            //    item.market_price = 0;
                            //}
                            //if (dt.Columns.Contains("sell_price"))
                            //{
                            //    item.sell_price = Utils.StrToInt(dt.Rows[j]["sell_price"].ToString(), 0);
                            //}
                            //else
                            //{
                            //    item.sell_price = 0;
                            //}
                            //item.is_top = Utils.StrToInt(dt.Rows[j]["is_top"].ToString(), 0);
                            //item.is_red = Utils.StrToInt(dt.Rows[j]["is_red"].ToString(), 0);
                            //item.is_hot = Utils.StrToInt(dt.Rows[j]["is_hot"].ToString(), 0);
                            item.add_time = DateTime.Parse(dt.Rows[j]["add_time"].ToString());
                            item.update_time = Utils.StrToDateTime(dt.Rows[j]["update_time"].ToString(), item.add_time);
                            LuceneHelper.IndexString(LuceneHelper.INDEX_DIR, item).ToString();
                            count++;
                            if (count % 300 == 0)
                            {
                                LuceneHelper.CloseWithoutOptimize();
                                LuceneHelper.CreateIndex(LuceneHelper.INDEX_DIR, 0);
                                LuceneHelper.MaxMergeFactor = 301;
                                LuceneHelper.MinMergeDocs = 301;
                            }
                        }
                        xml.Update("Lucene/" + model.name + "/lastid", _maxid);
                        xml.Update("Lucene/" + model.name + "/lasttime", System.DateTime.Now.ToString());
                        xml.Save();
                        LuceneHelper.Close();
                    }
                }
            }
            if (hasnew)
            {
                JsonHelper.WriteJson(context, new
                {
                    status = 2,
                    msg = "再去追加一次吧"
                });
            }
            else
            {
                JsonHelper.WriteJson(context, new
                {
                    status = 1,
                    msg = "索引更新完成"
                });
            }
        } 
        #endregion

        #region 获取词库总数
        private void get_dic_count(HttpContext context)
        {
            JsonHelper.WriteJson(context, new
            {
                status = 1,
                count = new PanguHelper().Count()
            });

        }
        #endregion

        #region 获取关键词属性
        private void get_dic_attr(HttpContext context)
        {
            string key = DTRequest.GetFormString("k");
            if (string.IsNullOrEmpty(key))
            {
                context.Response.Write("{\"status\":0 }");
                return;
            }
            int pos = 0;
            double frequency = new PanguHelper().GetWordAttr(key, out pos);
            if (pos == -1)
            {
                context.Response.Write("{\"status\": 0 }");
                return;
            }
            else
            {
                JsonHelper.WriteJson(context, new
                {
                    status = 1,
                    key = key,
                    frequency = frequency,
                    pos = pos
                });
            }

        }
        #endregion

        #region 添加词语到词库
        private void add_dic_word(HttpContext context)
        {
            //检查权限
            if (!new BLL.manager_role().Exists(adminInfo.role_id, "lucene_pangu", DTEnums.ActionEnum.Add.ToString()))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"您没有操作权限！\"}");
                return;
            }
            int pos = DTRequest.GetFormInt("p");
            int frequency = DTRequest.GetFormInt("f");
            string key = DTRequest.GetFormString("k");

            if (string.IsNullOrEmpty(key))
            {
                context.Response.Write("{\"status\":0 ,\"msg\":\"关键词不能为空！\"}");
                return;
            }

            PanguHelper dic = new PanguHelper();
            if (dic.InsertWord(key, (double)frequency, pos))
            {
                dic.Save(DateTime.Now.ToString("yyMMddhh"));
                context.Response.Write("{\"status\":1 ,\"msg\":\"添加成功！\"}");
            }
            else
            {
                context.Response.Write("{\"status\":0 ,\"msg\":\"添加失败！\"}");
            }
        }
        #endregion

        #region 批量添加词语到词库
        private void add_dic_word_all(HttpContext context)
        {
            //检查权限
            if (!new BLL.manager_role().Exists(adminInfo.role_id, "lucene_pangu", DTEnums.ActionEnum.Add.ToString()))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"您没有操作权限！\"}");
                return;
            }

            int pos = DTRequest.GetFormInt("p");
            int frequency = DTRequest.GetFormInt("f");
            string key = DTRequest.GetFormString("k");

            int sucCount = 0;
            int errorCount = 0;

            if (string.IsNullOrEmpty(key))
            {
                context.Response.Write("{\"status\":0 ,\"msg\":\"关键词不能为空！\"}");
                return;
            }

            key = Regex.Replace(key, @"\W+", ",");
            string[] valArr = key.Split(',');
            PanguHelper dic = new PanguHelper();
            if (valArr.Length > 0)
            {
                foreach (string k in valArr)
                {
                    if (dic.InsertWord(k, (double)frequency, pos))
                    {
                        sucCount++;
                    }
                    else
                    {
                        errorCount++;
                    }
                }
                dic.Save(DateTime.Now.ToString("yyMMddhh"));
                context.Response.Write("{\"status\":1 ,\"msg\":\"" + string.Format("添加成功{0}条，失败{1}条！", sucCount, errorCount) + "\"}");
                return;
            }
            context.Response.Write("{\"status\":0 ,\"msg\":\"添加失败！\"}");
        }
        #endregion

        #region 修改词语到词库
        private void edit_dic_word(HttpContext context)
        {
            //检查权限
            if (!new BLL.manager_role().Exists(adminInfo.role_id, "lucene_pangu", DTEnums.ActionEnum.Edit.ToString()))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"您没有操作权限！\"}");
                return;
            }

            int pos = DTRequest.GetFormInt("p");
            int frequency = DTRequest.GetFormInt("f");
            string key = DTRequest.GetFormString("k");

            if (string.IsNullOrEmpty(key))
            {
                context.Response.Write("{\"status\":0 ,\"msg\":\"关键词不能为空！\"}");
                return;
            }
            PanguHelper dic = new PanguHelper();
            if (dic.UpdateWord(key, (double)frequency, pos))
            {
                dic.Save(DateTime.Now.ToString("yyMMddhh"));
                context.Response.Write("{\"status\":1 ,\"msg\":\"修改成功！\"}");
                return;
            }
            context.Response.Write("{\"status\":0 ,\"msg\":\"修改失败！\"}");
        }
        #endregion

        #region 删除词库词语
        private void del_dic_word(HttpContext context)
        {
            //检查权限
            if (!new BLL.manager_role().Exists(adminInfo.role_id, "lucene_pangu", DTEnums.ActionEnum.Delete.ToString()))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"您没有操作权限！\"}");
                return;
            }

            string key = DTRequest.GetFormString("k");
            if (string.IsNullOrEmpty(key))
            {
                context.Response.Write("{\"status\":0 ,\"msg\":\"关键词不能为空！\"}");
                return;
            }
            PanguHelper dic = new PanguHelper();
            if (dic.DeleteWord(key))
            {
                dic.Save(DateTime.Now.ToString("yyMMddhh"));
                context.Response.Write("{\"status\":1 ,\"msg\":\"删除成功！\"}");
            }
            else
            {
                context.Response.Write("{\"status\":0 ,\"msg\":\"删除失败！\"}");
            }
        }
        #endregion

        #region 重建词库
        private void create_dictionaries(HttpContext context)
        {
            //检查权限
            if (!new BLL.manager_role().Exists(adminInfo.role_id, "lucene_pangu", DTEnums.ActionEnum.Delete.ToString()))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"您没有操作权限！\"}");
                return;
            }
            new PanguHelper().DeleteAll();
            context.Response.Write("{\"status\":1 ,\"msg\":\"重建词库成功！\"}");
        }
        #endregion

        #region 获取搜索关键词提醒
        private void get_search_prompt(HttpContext context)
        {
            string key = DTRequest.GetFormString("k");
            if (string.IsNullOrEmpty(key))
            {
                context.Response.Write("{\"status\":0 ,\"msg\":\"关键词不能为空！\"}");
                return;
            }
            int count = 0;
            JsonHelper.WriteJson(context, new
            {
                status = 1,
                list = new PanguHelper().SearchWord(key, 50, out count),
                count = count
            });

        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 查找匹配的URL
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="call_index">调用名称</param>
        /// <param name="id">ID</param>
        /// <returns></returns>
        private string get_url_rewrite(int channel_id, string call_index, int id)
        {
            if (channel_id == 0)
            {
                return string.Empty;
            }
            string querystring = id.ToString();
            string channel_name = new BLL.channel().GetChannelName(channel_id);
            if (string.IsNullOrEmpty(channel_name))
            {
                return string.Empty;
            }
            if (!string.IsNullOrEmpty(call_index))
            {
                querystring = call_index;
            }
            BLL.url_rewrite bll = new BLL.url_rewrite();
            Model.url_rewrite model = bll.GetInfo(channel_name, "detail");
            if (model != null)
            {
                return new Web.UI.BasePage().linkurl(model.name, querystring);
            }
            return string.Empty;
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