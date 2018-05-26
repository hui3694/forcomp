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
    public partial class medal_list : Web.UI.ManagePage
	{

        protected string keywords = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_forum_medal", DTEnums.ActionEnum.View.ToString()); //检查权限
                //Model.manager model = GetAdminInfo(); //取得当前管理员信息
                RptBind();//添加where子句和order子句
            }
        }
        
        #region 数据绑定=================================
        private void RptBind()
        {

            BLL.Forum_Medal bll = new BLL.Forum_Medal();
            this.rptList.DataSource = bll.GetList(25,"1=1"," id asc ");
            this.rptList.DataBind();

        }
        #endregion         

        
        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("plugin_forum_medal", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.Forum_Medal bll = new BLL.Forum_Medal();
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
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除dt_Forum_Medal" 
            	+ sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("medal_list.aspx", "keywords={0}", this.keywords));
        }
    }
}