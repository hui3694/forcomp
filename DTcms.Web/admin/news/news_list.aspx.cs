using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.news
{
    public partial class news_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;
        protected string prolistview = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10);

            this.prolistview = Utils.GetCookie("news_list_view");
            if (string.IsNullOrEmpty(this.prolistview))
            {
                this.prolistview = "Txt";
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("news_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                //添加权限
                if (!ChkAuthority("news_list", DTEnums.ActionEnum.Add.ToString()))
                {
                    this.addBtnPannel.Visible = false;
                }
                //删除权限
                if (!ChkAuthority("news_list", DTEnums.ActionEnum.Delete.ToString()))
                {
                    this.delBtnPannel.Visible = false;
                }
                string return_term = "0=0";
                
                RptBind(return_term + CombSqlTxt(this.keywords), "sort asc,time desc,id desc");
            }
        }

        #region 数据绑定
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            //图表或列表显示
            BLL.news bll = new BLL.news();
            switch (this.prolistview)
            {
                case "Txt":
                    this.rptList2.Visible = false;
                    this.rptList1.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
                    this.rptList1.DataBind();
                    break;
                default:
                    this.rptList1.Visible = false;
                    this.rptList2.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
                    this.rptList2.DataBind();
                    break;
            }
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("news_list.aspx", "keywords={0}&page={1}",
                this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and title like '%" + _keywords + "%'");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回图文每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("news_list_page_size", "DTcmsPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion


        //设置操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ChkAdminLevel("news_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
            int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("hidId")).Value);
            BLL.news bll = new BLL.news();
            Model.news model = bll.GetModel(id);
            switch (e.CommandName)
            {
                case "lbtnIsMsg":
                    if (model.is_msg == 1)
                        bll.UpdateField(id, "is_msg=0");
                    else
                        bll.UpdateField(id, "is_msg=1");
                    break;
                case "lbtnIsHide":
                    if (model.is_hide == 1)
                        bll.UpdateField(id, "is_hide=0");
                    else
                        bll.UpdateField(id, "is_hide=1");
                    break;
            }
            this.RptBind("id>0" + CombSqlTxt(this.keywords), "sort asc,time desc,id desc");
        }

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("news_list.aspx", "keywords={0}",
                 txtKeywords.Text));
        }

        //筛选类别
        protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("news_list.aspx", "keywords={0}",
                 txtKeywords.Text));
        }

        //筛选属性
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("news_list.aspx", "keywords={0}",
                 txtKeywords.Text));
        }

        //设置文字列表显示
        protected void lbtnViewTxt_Click(object sender, EventArgs e)
        {
            Utils.WriteCookie("news_list_view", "Txt", 14400);
            Response.Redirect(Utils.CombUrlTxt("news_list.aspx", "keywords={0}&page={1}",
                this.keywords, this.page.ToString()));
        }

        //设置图文列表显示
        protected void lbtnViewImg_Click(object sender, EventArgs e)
        {
            Utils.WriteCookie("news_list_view", "Img", 14400);
            Response.Redirect(Utils.CombUrlTxt("news_list.aspx", "keywords={0}&page={1}",
                this.keywords, this.page.ToString()));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("news_list_page_size", "DTcmsPage", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("news_list.aspx", "keywords={0}",
                  txtKeywords.Text));
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("news_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.news bll = new BLL.news();
            Repeater rptList = new Repeater();
            if (this.rptList1.Visible == true)
            {
                rptList = this.rptList1;
            }else
            {
                rptList = this.rptList2;
            }

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "sort=" + sortId.ToString());
            }
            AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "保存资讯内容排序"); //记录日志
            JscriptMsg("保存排序成功！", Utils.CombUrlTxt("news_list.aspx", "keywords={0}",
                this.keywords));
        }
    
        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("news_list", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0; //成功数量
            int errorCount = 0; //失败数量
            BLL.news bll = new BLL.news();
            Repeater rptList = new Repeater();
            if (this.rptList1.Visible == true)
            {
                rptList = this.rptList1;
            }
            else
            {
                rptList = this.rptList2;
            }
       
            //循环删除
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount++;
                    }
                    else
                    {
                        errorCount++;
                    }
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "删除资讯成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("news_list.aspx", "keywords={0}",
                this.keywords));
        }

    }
}