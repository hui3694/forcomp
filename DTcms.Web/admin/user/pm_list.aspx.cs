using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;
using System.Text;

namespace DTcms.Web.admin.user
{
    public partial class pm_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = DTRequest.GetQueryString("keywords");
            this.pageSize = GetPageSize(10);
            if (!IsPostBack)
            {
                //检查权限
                ChkAdminLevel("pro_pm_list", DTEnums.ActionEnum.View.ToString());
               
                //删除权限
                if (!ChkAuthority("pro_pm_list", DTEnums.ActionEnum.Delete.ToString()))
                {
                    this.delBtnPannel.Visible = false;
                }
                string return_term = "0=0";
                RptBind(return_term + CombSqlTxt(this.keywords), "status asc,add_time desc");
            }
        }

        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            DataTable dt = new BLL.user_pm().GetList(pageSize, this.page, _strWhere, _orderby, out this.totalCount).Tables[0];
            dt.Columns.Add("username", typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                string name = new BLL.user().GetModel(Convert.ToInt32(dr["user_id"])).nickname;
                dr["username"] = name;
            }
            this.rptList.DataSource = dt;
            this.rptList.DataBind();
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("pm_list.aspx", "keywords={0}&page={1}",
                this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("pro_pm_list_page_size", "DTcmsPage", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("pm_list.aspx", "keywords={0}",
                  txtKeywords.Text));
        }
        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and( name like '%" + _keywords + "%' or comName like '%" + _keywords + "%' or job like '%" + _keywords + "%')");
            }
            return strTemp.ToString();
        }
        #endregion
        #region 返回图文每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("pro_pm_list_page_size", "DTcmsPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("pm_list.aspx", "keywords={0}",
                 txtKeywords.Text));
        }


        //删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("pro_pm_list", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            BLL.user_pm bll = new BLL.user_pm();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "删除产品分类数据"); //记录日志
            JscriptMsg("删除数据成功！", Utils.CombUrlTxt("pm_list.aspx", "", ""));
        }

        protected void btnPass_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("pro_pm_list", DTEnums.ActionEnum.Audit.ToString()); //检查权限
            BLL.user_pm bll = new BLL.user_pm();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.UpdateField(id, "status=2,pass_time=getdate()");
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "审核客户经理"); //记录日志
            JscriptMsg("审核数据成功！", Utils.CombUrlTxt("pm_list.aspx", "", ""));
        }
        protected void btnUnPass_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("pro_pm_list", DTEnums.ActionEnum.Audit.ToString()); //检查权限
            BLL.user_pm bll = new BLL.user_pm();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.UpdateField(id, "status=3,pass_time=getdate()");
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "审核客户经理"); //记录日志
            JscriptMsg("审核数据成功！", Utils.CombUrlTxt("pm_list.aspx", "", ""));
        }
        protected string GetStatus(int status)
        {
            switch (status)
            {
                case 1:
                    return "<font color='green'>待审核</font>";
                case 2:
                    return "<font color='black'>审核通过</font>";
                case 3:
                    return "<font color='red'>不通过</font>";
                default:
                    return "未知";
            }
        }
    }
}