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
    public partial class settings_edit : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private string id = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }

                this.id = Request.QueryString["id"].ToString();

                if (!new BLL.Forum_Settings().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_forum_settings", DTEnums.ActionEnum.View.ToString()); //检查权限

                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(string _id)
        {
            BLL.Forum_Settings bll = new BLL.Forum_Settings();
            Model.Forum_Settings model = bll.GetModel(_id);
            //编写赋值操作Begin

            txtVariable.Text = model.Variable;
            txtValue.Text = model.Value;
            txtTitle.Text = model.Title;
            ddlGroup.SelectedValue = model.Group.ToString();         
            txtDescription.Text = model.Description;
            txtSortId.Text = model.SortId.ToString();

            //编写赋值操作End
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.Forum_Settings model = new Model.Forum_Settings();
            BLL.Forum_Settings bll = new BLL.Forum_Settings();
            //编写添加操作Begin
            model.Variable = txtVariable.Text;
            model.Value = txtValue.Text;
            model.Title = txtTitle.Text;
            model.Group = Convert.ToInt32( ddlGroup.SelectedValue);
            model.Description = txtDescription.Text;
            model.SortId = Convert.ToInt32( txtSortId.Text);
            //编写添加操作End

            if (bll.Add(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加dt_Forum_Settings:"
                    + model.Variable); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(string _id)
        {
            bool result = false;
            BLL.Forum_Settings bll = new BLL.Forum_Settings();
            Model.Forum_Settings model = bll.GetModel(_id);

            //编写编辑操作Begin
            model.VariableOld = model.Variable;
            model.Variable = txtVariable.Text;
            model.Value = txtValue.Text;
            model.Title = txtTitle.Text;
            model.Group = Convert.ToInt32(ddlGroup.SelectedValue);
            model.Description = txtDescription.Text;
            model.SortId = Convert.ToInt32(txtSortId.Text);
            
            //编写编辑操作End

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改管理员:" + model.Variable); //记录日志
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
                ChkAdminLevel("plugin_forum_settings", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }

                Global.GlobalLoad(true);

                JscriptMsg("修改信息成功！", "Settings_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("plugin_forum_settings", DTEnums.ActionEnum.Add.ToString()); //检查权限


                if (new BLL.Forum_Settings().Exists(txtVariable.Text.Trim()))
                {
                    JscriptMsg("提交错误，常量名已存在！", "");
                    return;
                }

                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加信息成功！", "Settings_list.aspx");
                Global.GlobalLoad(true);
            }
        }
    }
}