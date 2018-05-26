﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.Plugin.Lable.admin
{
    public partial class edit : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        protected int contentType = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
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
                if (!new BLL.plugin_lable().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_lable", DTEnums.ActionEnum.View.ToString());
                if (action == DTEnums.ActionEnum.Edit.ToString())
                {
                    ShowInfo(this.id);
                }
                else
                {
                    txtName.Attributes.Add("ajaxurl", "../tools/ajax.ashx?action=validate");
                }
            }
        }

        //赋值操作
        private void ShowInfo(int _id)
        {
            BLL.plugin_lable bll = new BLL.plugin_lable();
            Model.plugin_lable model = bll.GetModel(_id);
            txtTitle.Text = model.title;
            txtName.Text = model.call_index;
            txtName.Attributes.Add("ajaxurl", "../tools/ajax.ashx?action=validate&old_name=" + Utils.UrlEncode(model.call_index));
            txtName.Focus();
            txtSort.Text = model.sort_id.ToString();
            rblHide.SelectedValue = model.is_lock.ToString();
            ddlType.SelectedValue = model.type.ToString();            
            txtContent.Value = model.content;

            contentType = model.type;
        }

        //增加操作
        private bool DoAdd()
        {
            BLL.plugin_lable bll = new BLL.plugin_lable();
            Model.plugin_lable model = new Model.plugin_lable();
            model.title = txtTitle.Text;
            model.call_index = txtName.Text;
            model.is_lock = int.Parse(rblHide.SelectedValue);
            model.sort_id = int.Parse(txtSort.Text);
            model.type = Utils.StrToInt(ddlType.SelectedValue, 0);
            model.content = txtContent.Value;
            model.add_time = DateTime.Now;
            Model.manager adminModel = GetAdminInfo();
            model.user_name = adminModel.real_name;
            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "添加标签内容:" + model.title);
                return true;
            }
            return false;
        }

        //修改操作
        private bool DoEdit(int _id)
        {
            BLL.plugin_lable bll = new BLL.plugin_lable();
            Model.plugin_lable model = bll.GetModel(_id);
            model.title = txtTitle.Text;
            model.call_index = txtName.Text;
            model.is_lock = int.Parse(rblHide.SelectedValue);
            model.sort_id = int.Parse(txtSort.Text);
            model.type = int.Parse(ddlType.SelectedValue);
            model.content = txtContent.Value;
            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改标签内容:" + model.title);
                return true;
            }
            return false;
        }

        //保存操作
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString())
            {
                ChkAdminLevel("plugin_lable", DTEnums.ActionEnum.Edit.ToString());
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改标签信息成功！", "index.aspx");
            }
            else
            {
                ChkAdminLevel("plugin_lable", DTEnums.ActionEnum.Add.ToString());
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加标签信息成功！", "index.aspx");
            }
        }
    }
}