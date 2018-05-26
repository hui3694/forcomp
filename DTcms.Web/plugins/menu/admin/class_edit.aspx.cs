using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using DTcms.Web.UI;

namespace DTcms.Web.Plugin.Menu.admin
{
    public partial class class_edit : Web.UI.ManagePage
    {
        private int id = 0;
        private string backUrl = string.Empty;
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型

        protected void Page_Load(object sender, EventArgs e)
        {
            this.backUrl = DTRequest.GetQueryString("backurl");
            string _action = DTRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.id = DTRequest.GetQueryInt("id");
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.plugin_menu_class().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //检查权限
                ChkAdminLevel("plugin_menu_class", DTEnums.ActionEnum.Show.ToString());

                if (action == DTEnums.ActionEnum.Edit.ToString())
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作
        private void ShowInfo(int _id)
        {
            BLL.plugin_menu_class bll = new BLL.plugin_menu_class();
            Model.plugin_menu_class model = bll.GetModel(_id);
            txtTitle.Text = model.title;
            txtColor.Text = model.color;
            txtSort.Text = model.sort_id.ToString();
            rblHide.SelectedValue = model.is_lock.ToString();
        }
        #endregion

        #region 增加操作
        private bool DoAdd()
        {
            BLL.plugin_menu_class bll = new BLL.plugin_menu_class();
            Model.plugin_menu_class model = new Model.plugin_menu_class();
            model.title = txtTitle.Text;
            model.color = txtColor.Text;
            model.is_lock = Utils.StrToInt(rblHide.SelectedValue, 0);
            model.sort_id = Utils.StrToInt(txtSort.Text.Trim(), 99);

            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "添加菜单类别内容:" + model.title); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作
        private bool DoEdit(int _id)
        {
            BLL.plugin_menu_class bll = new BLL.plugin_menu_class();
            Model.plugin_menu_class model = bll.GetModel(_id);

            model.title = txtTitle.Text;
            model.color = txtColor.Text;
            model.is_lock = Utils.StrToInt(rblHide.SelectedValue, 0);
            model.sort_id = Utils.StrToInt(txtSort.Text.Trim(), 99);

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改菜单类别内容:" + model.title);
                return true;
            }
            return false;
        }
        #endregion

        //保存操作
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("plugin_menu_class", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改菜单类别信息成功！", "class_list.aspx" + backUrl);
            }
            else //添加
            {
                ChkAdminLevel("plugin_menu", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加菜单类别信息成功！", "class_list.aspx" + backUrl);
            }
        }
    }
}