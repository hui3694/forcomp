using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.Plugin.Forum.admin
{
        //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class group_extended_edit : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.Forum_GroupExtended().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_forum_groupextended", DTEnums.ActionEnum.View.ToString()); //检查权限

                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.Forum_GroupExtended bll = new BLL.Forum_GroupExtended();
            Model.Forum_GroupExtended model = bll.GetModel(_id);
            //编写赋值操作Begin

            txtViewIpField.Text = model.ViewIpField.ToString();
            txtAttachmentExtension.Text = model.AttachmentExtension;
            txtDayAttachmentSize.Text = model.DayAttachmentSize.ToString();
            txtPostIntervalSecond.Text = model.PostIntervalSecond.ToString();
            rblSearch.SelectedValue = model.Search.ToString();
            rblMemberList.SelectedValue = model.MemberList.ToString();
            ddlPostCheck.SelectedValue = model.PostCheck.ToString();
            rblCost.SelectedValue = model.Cost.ToString();
            txtCostMax.Text = model.CostMax.ToString();
            ddlPostUpdateLog.Text = model.PostUpdateLog.ToString();

            //编写赋值操作End
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.Forum_GroupExtended model = new Model.Forum_GroupExtended();
            BLL.Forum_GroupExtended bll = new BLL.Forum_GroupExtended();
            //编写添加操作Begin
            //model.GroupId = txtGroupId.Text;
            //model.ViewIpField = txtViewIpField.Text;
            //model.AttachmentExtension = txtAttachmentExtension.Text;
            //model.DayAttachmentSize = txtDayAttachmentSize.Text;
            //model.PostIntervalSecond = txtPostIntervalSecond.Text;
            //model.Search = txtSearch.Text;
            //model.MemberList = txtMemberList.Text;
            //model.PostCheck = txtPostCheck.Text;
            //model.Cost = txtCost.Text;
            //model.CostMax = txtCostMax.Text;
            //model.PostUpdateLog = txtPostUpdateLog.Text;
            //编写添加操作End

            //if (bll.Add(model) > 0)
            //{
            //    AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加dt_Forum_GroupExtended:"
            //        + model.user_name); //记录日志
            //    return true;
            //}
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.Forum_GroupExtended bll = new BLL.Forum_GroupExtended();
            Model.Forum_GroupExtended model = bll.GetModel(_id);

            //编写编辑操作Begin

            model.ViewIpField = Convert.ToInt32(txtViewIpField.Text);
            model.AttachmentExtension = txtAttachmentExtension.Text;
            model.DayAttachmentSize = Convert.ToInt32(txtDayAttachmentSize.Text);
            model.PostIntervalSecond = Convert.ToInt32(txtPostIntervalSecond.Text);
            model.Search = Convert.ToInt32(rblSearch.SelectedValue);
            model.MemberList = Convert.ToInt32(rblMemberList.SelectedValue);
            model.PostCheck = Convert.ToInt32(ddlPostCheck.SelectedValue);

            model.Cost = Convert.ToInt32(rblCost.SelectedValue);
            model.CostMax = Convert.ToDecimal(txtCostMax.Text);
            model.PostUpdateLog = Convert.ToInt32(ddlPostUpdateLog.SelectedValue);
            //编写编辑操作End

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改管理员"); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("plugin_forum_groupextended", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改信息成功！", "group_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("plugin_forum_groupextended", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加信息成功！", "group_list.aspx");
            }
        }
    }
}