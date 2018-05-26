using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using DTcms.Common;
using DTcms.Web.UI;

namespace DTcms.Web.Plugin.Forum.admin
{
    //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class post_list : Web.UI.ManagePage
    {
        //页面属性
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;

        protected int subTableId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = DTRequest.GetQueryString("keywords");

            this.subTableId = DTRequest.GetQueryInt("subTableId");

            this.pageSize = GetPageSize(10); //每页数量

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_forum_post", DTEnums.ActionEnum.View.ToString()); //检查权限

                SubTableBind();

                RptBind(" First=0 " + CombSqlTxt(keywords), " id desc ");//添加where子句和order子句

            }
        }

        #region 绑定分表

        protected void SubTableBind()
        {

            BLL.Forum_PostSubTable bll = new BLL.Forum_PostSubTable();
            System.Data.DataTable tdSubTable = bll.GetList(20, "1=1", "[id] asc").Tables[0];

            this.ddlSubTable.Items.Clear();

            int AvailId = 0;

            foreach (DataRow dr in tdSubTable.Rows)
            {
                this.ddlSubTable.Items.Add(new ListItem(dr["Name"].ToString().Trim(), dr["id"].ToString().Trim()));

                if (dr["Avail"].ToString() == "1")
                {
                    AvailId = Convert.ToInt32(dr["id"].ToString());
                }
            }

            if (subTableId == 0)
            {
                subTableId = AvailId;
            }

            ddlSubTable.SelectedValue = subTableId.ToString();
        }

        #endregion

        BasePage basePage = new DTcms.Web.UI.BasePage();

        protected string GetTopicUrl(string TopicId)
        {
            return basePage.linkurl("forum_topic", TopicId, 1);
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {

            this.page = DTRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.Forum_Post bll = new BLL.Forum_Post(subTableId);
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, 0, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("Post_list.aspx", "keywords={0}&page={1}&subTableId={2}", this.keywords, "__id__", this.subTableId.ToString());
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        //筛选类别
        protected void ddlSubTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("Post_list.aspx", "keywords={0}&page={1}&subTableId={2}", this.keywords, "1", ddlSubTable.SelectedValue));
        }

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and  CONVERT(NVARCHAR(MAX),Message) like '%" + _keywords + "%' ");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("Forum_Post_page_size", "DTcmsPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("Post_list.aspx", "keywords={0}&subTableId={1}", txtKeywords.Text, this.subTableId.ToString()));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("Forum_Post_page_size", "DTcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("Post_list.aspx", "keywords={0}&subTableId={1}", this.keywords, this.subTableId.ToString()));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("plugin_forum_post", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.Forum_Post bll = new BLL.Forum_Post(subTableId);
            BLL.Forum_Topic bllTopic = new BLL.Forum_Topic();

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int topicId = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidTopicId")).Value);

                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    //调用与前台一样的方法
                    bllTopic.DeleterReply(id.ToString(), topicId);

                    sucCount += 1;

                }
            }
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除dt_Forum_Post_"
                + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("Post_list.aspx", "keywords={0}&subTableId={1}", this.keywords, this.subTableId.ToString()));
        }
    }
}