using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.Plugin.QQOnline.admin
{
    public partial class online_edit : Web.UI.ManagePage
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
                if (!new BLL.plugin_qqonline().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //检查权限
                ChkAdminLevel("plugin_qqonline_list", DTEnums.ActionEnum.Show.ToString());
                //绑定头像
                BindPic();
                if (action == DTEnums.ActionEnum.Edit.ToString())
                {
                    ShowInfo(this.id);
                }
            }
        }
        //绑定头像
        private void BindPic()
        {
            string ext;
            string curPath = Utils.GetMapPath(@"../skin/qqface/");
            DirectoryInfo dirInfo = new DirectoryInfo(curPath);
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                ext = Utils.GetFileExt(file.Name);
                if (ext == ".gif" || ext == ".png" || ext == ".jpg")
                {
                    rblPicList.Items.Add(new ListItem(file.Name, file.Name));
                }
            }
        }
        //赋值操作
        private void ShowInfo(int _id)
        {
            BLL.plugin_qqonline bll = new BLL.plugin_qqonline();
            Model.plugin_qqonline model = bll.GetModel(_id);
            txtUserName.Text = model.username;
            txtQQ.Text = model.qq;
            txtColor.Text = model.color;
            if (model.is_lock == 0)
            {
                cbStatus.Checked = true;
            }
            else
            {
                cbStatus.Checked = false;
            }
            txtSort.Text = model.sort_id.ToString();
            txtUrl.Text = model.link_url;
            rblPicList.SelectedValue = model.img_url;
        }
        //增加操作
        private bool DoAdd()
        {
            BLL.plugin_qqonline bll = new BLL.plugin_qqonline();
            Model.plugin_qqonline model = new Model.plugin_qqonline();
            model.username = txtUserName.Text.Trim();
            model.qq = txtQQ.Text.Trim();
            model.color = txtColor.Text;
            if (cbStatus.Checked == false)
            {
                model.is_lock = 1;
            }
            model.sort_id = Utils.StrToInt(txtSort.Text.Trim(), 99);
            model.link_url = txtUrl.Text.Trim();
            model.img_url = rblPicList.SelectedValue;
            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "添加QQ在线客服:" + model.username);
                return true;
            }
            return false;
        }

        #region 修改操作
        private bool DoEdit(int _id)
        {
            BLL.plugin_qqonline bll = new BLL.plugin_qqonline();
            Model.plugin_qqonline model = bll.GetModel(_id);
            model.username = txtUserName.Text.Trim();
            model.qq = txtQQ.Text.Trim();
            model.color = txtColor.Text;
            model.is_lock = 0;
            if (cbStatus.Checked == false)
            {
                model.is_lock = 1;
            }
            model.sort_id = Utils.StrToInt(txtSort.Text.Trim(), 99);
            model.link_url = txtUrl.Text.Trim();
            model.img_url = rblPicList.SelectedValue;
            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改QQ在线客服:" + model.username);
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
                ChkAdminLevel("plugin_qqonline_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改菜单类别信息成功！", "online_list.aspx" + backUrl);
            }
            else //添加
            {
                ChkAdminLevel("plugin_qqonline_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加菜单类别信息成功！", "online_list.aspx" + backUrl);
            }
        }
    }
}