using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using DTcms.Common;

namespace DTcms.Web.Plugin.Forum.admin
{
        //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class user_extended_list : Web.UI.ManagePage
    {
        //页面属性
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;
        protected int group_id;
        protected System.Data.DataTable tdGroup = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = DTRequest.GetQueryString("keywords");
            this.group_id = DTRequest.GetQueryInt("GroupId", 0);

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_forum_userextended", DTEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind();
                RptBind(" 1=1 " + CombSqlTxt(this.group_id, keywords), " OnlineUpdateTime desc ");//添加where子句和order子句
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.Forum_UserExtended bll = new BLL.Forum_UserExtended();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("user_extended_list.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 绑定类别=================================
        private void TreeBind()
        {
            BLL.Forum_Group bll = new BLL.Forum_Group();
            tdGroup = bll.GetList(20, "1=1", "[Type] asc").Tables[0];
            this.ddlGroupId.Items.Clear();
            this.ddlGroupId.Items.Add(new ListItem("所有分组", ""));
            foreach (DataRow dr in tdGroup.Rows)
            {
                this.ddlGroupId.Items.Add(new ListItem(dr["Name"].ToString().Trim(), dr["id"].ToString().Trim()));
            }

            if (this.group_id != 0)
            {
                this.ddlGroupId.SelectedValue = this.group_id.ToString();
            }
        }
        #endregion

        protected string GetGroupName(string _id)
        {
            string _name = "";

            foreach (DataRow dr in tdGroup.Rows)
            {
                if (dr["id"].ToString() == _id)
                {
                    _name = dr["Name"].ToString().Trim();

                    break;
                }
            }

            return _name;
        }

        //筛选类别
        protected void ddlGroupId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("user_extended_list.aspx", "keywords={0}&page={1}&GroupId={2}", this.keywords, "1", ddlGroupId.SelectedValue));
        }

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _group_id, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");

            if (_group_id > 0)
            {
                strTemp.Append(" and GroupId=" + _group_id);
            }

            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (Nickname like  '%" + _keywords + "%' or QQ like '%" + _keywords + "%' or MSN like '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("Forum_UserExtended_page_size", "DTcmsPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("user_extended_list.aspx", "keywords={0}", txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("Forum_UserExtended_page_size", "DTcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("user_extended_list.aspx", "keywords={0}", this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("plugin_forum_userextended", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.Forum_UserExtended bll = new BLL.Forum_UserExtended();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除dt_Forum_UserExtended"
                + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("user_extended_list.aspx", "keywords={0}", this.keywords));
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            new BLL.Forum_UserExtended().SysUserAdd();

            JscriptMsg("操作成功！", "user_extended_list.aspx");
        }
    }
}