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
    public partial class user_medal_list : Web.UI.ManagePage
    {

        public Model.Forum_UserExtended model = null;
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("plugin_forum_userextended", DTEnums.ActionEnum.View.ToString()); //检查权限
            //Model.manager model = GetAdminInfo(); //取得当前管理员信息
            if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
            {
                JscriptMsg("传输参数不正确！", "back");
                return;
            }
            if (!new BLL.Forum_UserExtended().Exists(this.id))
            {
                JscriptMsg("记录不存在或已被删除！", "back");
                return;
            }

            if (!Page.IsPostBack)
            {

                model = new BLL.Forum_UserExtended().GetModel(id);
                hfTurl.Value = Request.UrlReferrer.ToString();
                RptBind();//添加where子句和order子句
            }
        }

        #region 数据绑定=================================
        private void RptBind()
        {
            BLL.Forum_Medal bll = new BLL.Forum_Medal();
            this.rptList.DataSource = bll.GetList(25, "1=1", " id asc ");
            this.rptList.DataBind();
        }
        #endregion

        //打勾
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {

                HiddenField hidId = (HiddenField)e.Item.FindControl("hidId");

                CheckBox chkId = (CheckBox)e.Item.FindControl("chkId");

                if (!string.IsNullOrEmpty(model.Medal))
                {
                    string[] ids = model.Medal.Split(',');

                    foreach (string item in ids)
                    {
                        if (item == hidId.Value)
                        {
                            chkId.Checked = true;

                            break;
                        }
                    }
                }
            }
        }

        //提交
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("plugin_forum_userextended", DTEnums.ActionEnum.Delete.ToString()); //检查权限


            BLL.Forum_UserExtended bll = new BLL.Forum_UserExtended();

            model = new BLL.Forum_UserExtended().GetModel(this.id);

            string ids = "0";

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");

                if (cb.Checked)
                {
                    ids += "," + id.ToString();
                }
            }

            model.Medal = ids;

            bll.Update(model);

            AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改管理员:" + model.Nickname); //记录日志

            JscriptMsg("修改信息成功！", hfTurl.Value);


        }
    }
}