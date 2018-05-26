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
    public partial class menu_edit : Web.UI.ManagePage
    {
        private int id = 0;
        private int class_id = 0;
        private string backUrl = string.Empty;
        private string action = DTEnums.ActionEnum.Add.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = DTRequest.GetQueryInt("id");
            this.class_id = DTRequest.GetQueryInt("class_id");
            this.backUrl = DTRequest.GetQueryString("backurl");
            string _action = DTRequest.GetQueryString("action");

            if (this.class_id == 0 || !new BLL.plugin_menu_class().Exists(this.class_id))
            {
                JscriptMsg("传输参数不正确！", "back");
                return;
            }
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.plugin_menu().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //检查权限
                ChkAdminLevel("plugin_menu_list", DTEnums.ActionEnum.Show.ToString());

                //绑定类别
                TreeBind();

                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else
                {
                    ddlParentId.SelectedValue = this.id.ToString();
                }
            }
        }

        #region 赋值操作
        private void ShowInfo(int _id)
        {
            BLL.plugin_menu bll = new BLL.plugin_menu();
            Model.plugin_menu model = bll.GetModel(_id);
            txtName.Text = model.title;
            txtUrl.Text = model.link_url;
            ddlParentId.SelectedValue = model.parent_id.ToString();
            txtSort.Text = model.sort_id.ToString();
            rblHide.SelectedValue = model.is_lock.ToString();
            rblMode.SelectedValue = model.target;
            txtCssTxt.Text = model.css_txt;
            txtImgUrl.Text = model.img_url;
            if (!string.IsNullOrEmpty(model.img_url))
            {
                ImgDiv.Visible = true;
                ImgUrl.ImageUrl = model.img_url;
            }
        }
        #endregion

        #region 绑定类别
        private void TreeBind()
        {
            BLL.plugin_menu bll = new BLL.plugin_menu();
            DataTable dt = bll.GetList(0, 0, "class_id=" + this.class_id, "sort_id asc,id asc");
            this.ddlParentId.Items.Clear();
            this.ddlParentId.Items.Add(new ListItem("无父级分类", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion

        #region 增加操作
        private bool DoAdd()
        {
            BLL.plugin_menu bll = new BLL.plugin_menu();
            Model.plugin_menu model = new Model.plugin_menu();
            model.class_id = this.class_id;
            model.title = txtName.Text;
            model.link_url = txtUrl.Text;
            model.parent_id = int.Parse(ddlParentId.SelectedValue);
            model.target = rblMode.SelectedValue;
            model.is_lock = int.Parse(rblHide.SelectedValue);
            model.sort_id = Utils.StrToInt(txtSort.Text, 99);
            model.css_txt = txtCssTxt.Text;
            model.img_url = txtImgUrl.Text.Trim();
            model.add_time = DateTime.Now;

            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "添加菜单内容:" + model.title); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作
        private bool DoEdit(int _id)
        {
            BLL.plugin_menu bll = new BLL.plugin_menu();
            Model.plugin_menu model = bll.GetModel(_id);

            model.title = txtName.Text;
            model.link_url = txtUrl.Text;
            int parentId = int.Parse(ddlParentId.SelectedValue);
            if (parentId != model.id)
            {
                model.parent_id = parentId;
            }
            model.target = rblMode.SelectedValue;
            model.is_lock = int.Parse(rblHide.SelectedValue);
            model.sort_id = Utils.StrToInt(txtSort.Text, 99);
            model.css_txt = txtCssTxt.Text;
            model.img_url = txtImgUrl.Text.Trim();

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改菜单内容:" + model.title); //记录日志
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
                ChkAdminLevel("plugin_menu_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改菜单信息成功！", "menu_list.aspx" + backUrl);
            }
            else //添加
            {
                ChkAdminLevel("plugin_menu_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加菜单信息成功！", "menu_list.aspx" + backUrl);
            }
        }
    }
}