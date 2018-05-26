﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.Plugin.Link.admin
{
    public partial class index : DTcms.Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected int site_id = 0;

        protected int property = 0;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.site_id = DTRequest.GetQueryInt("site_id");
            this.property = DTRequest.GetQueryInt("property");
            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_link", DTEnums.ActionEnum.View.ToString()); //检查权限
                SiteBind(); //绑定网点
                string strWhere = "id>0";
                if (this.site_id > 0)
                {
                    DTcms.Model.channel_site model = new DTcms.BLL.channel_site().GetModel(this.site_id);
                    if (null != model)
                    {
                        strWhere = "site_path='" + model.build_path + "'";
                        this.ddlSiteId.SelectedValue = this.site_id.ToString();
                    }
                }
                if (this.property > 0)
                {
                    this.ddlProperty.SelectedValue = this.property.ToString();
                }
                RptBind(strWhere + CombSqlTxt(this.property, this.keywords), "sort_id asc,add_time desc");
            }
        }

        #region 数据绑定
        private void SiteBind()
        {
            DTcms.BLL.channel_site bll = new DTcms.BLL.channel_site();
            DataTable dt = bll.GetList(0, "is_mobile=0", "sort_id asc,id desc").Tables[0];

            this.ddlSiteId.Items.Clear();
            this.ddlSiteId.Items.Add(new ListItem("所有站点", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlSiteId.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
            }
        }
        #endregion

        #region 数据绑定
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            BLL.plugin_link bll = new BLL.plugin_link();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("index.aspx", "site_id={0}&property={1}&keywords={2}&page={3}", this.site_id.ToString(), this.property.ToString(), this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句
        protected string CombSqlTxt(int _property, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_property > 0)
            {
                strTemp.Append(" and is_image=");
                strTemp.Append((--_property).ToString());
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and title like '%" + _keywords + "%'");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("link_page_size", "DTcmsPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //网点筛选
        protected void ddlSiteId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("index.aspx", "site_id={0}&property={1}&keywords={2}", ddlSiteId.SelectedValue, this.property.ToString(), txtKeywords.Text));
        }

        //筛选属性
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("index.aspx", "site_id={0}&property={1}&keywords={2}", this.site_id.ToString(), ddlProperty.SelectedValue, txtKeywords.Text));
        }

        //设置操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ChkAdminLevel("plugin_link", DTEnums.ActionEnum.Edit.ToString()); //检查权限
            int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("hidId")).Value);
            BLL.plugin_link bll = new BLL.plugin_link();
            Model.plugin_link model = bll.GetModel(id);
            switch (e.CommandName.ToLower())
            {
                case "lbtnisred":
                    if (model.is_red == 1)
                        bll.UpdateField(id, "is_red=0");
                    else
                        bll.UpdateField(id, "is_red=1");
                    break;
            }
            this.RptBind("id>0" + CombSqlTxt(this.property, this.keywords), "sort_id asc,add_time desc");
        }

        //关健字查询
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("index.aspx", "site_id={0}&property={1}&keywords={2}", this.site_id.ToString(), this.property.ToString(), txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("link_page_size", "DTcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("index.aspx", "site_id={0}&property={1}&keywords={2}", this.site_id.ToString(), this.property.ToString(), this.keywords));
        }

        //保存排序
        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("plugin_link", DTEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.plugin_link bll = new BLL.plugin_link();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "sort_id=" + sortId.ToString());
            }
            AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改友情链接插件排序:"); //记录日志
            JscriptMsg("保存排序成功！", Utils.CombUrlTxt("index.aspx", "site_id={0}&property={1}&keywords={2}", this.site_id.ToString(), this.property.ToString(), this.keywords));
        }

        //批量审核
        protected void lbtnUnLock_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("plugin_link", DTEnums.ActionEnum.Audit.ToString()); //检查权限
            BLL.plugin_link bll = new BLL.plugin_link();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.UpdateField(id, "is_lock=0");
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Audit.ToString(), "审核友情链接"); //记录日志
            JscriptMsg("批量审核成功！", Utils.CombUrlTxt("index.aspx", "site_id={0}&property={1}&keywords={2}", this.site_id.ToString(), this.property.ToString(), this.keywords));
        }

        //批量删除
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("plugin_link", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.plugin_link bll = new BLL.plugin_link();
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
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除友情链接成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("index.aspx", "site_id={0}&property={1}&keywords={2}", this.site_id.ToString(), this.property.ToString(), this.keywords));
        }

    }
}