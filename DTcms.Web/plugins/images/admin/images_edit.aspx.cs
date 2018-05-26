using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using DTcms.Web.UI;

namespace DTcms.Web.Plugin.Images.admin
{
    public partial class images_edit : Web.UI.ManagePage
    {
        private int id = 0;
        private int class_id = 0;
        private string backUrl = string.Empty;
        private string action = DTEnums.ActionEnum.Add.ToString();

        protected int contentType = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.class_id = DTRequest.GetQueryInt("class_id");
            this.backUrl = DTRequest.GetQueryString("backurl");
            string _action = DTRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.id = DTRequest.GetQueryInt("id");
                this.action = DTEnums.ActionEnum.Edit.ToString();
                if (id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.plugin_images().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //检查权限
                ChkAdminLevel("plugin_images_list", DTEnums.ActionEnum.Show.ToString());

                //绑定标记
                TreeBind();

                if (action == DTEnums.ActionEnum.Edit.ToString())
                {
                    ShowInfo(this.id);
                }
                else if (this.class_id > 0)
                {
                    this.ddlClassId.SelectedValue = this.class_id.ToString();
                }
            }
        }

        #region 绑定类别
        private void TreeBind()
        {
            BLL.plugin_images_class bll = new BLL.plugin_images_class();
            DataTable dt = bll.GetList(0, "is_lock=0", "sort_id asc,id asc").Tables[0];
            this.ddlClassId.Items.Clear();
            this.ddlClassId.Items.Add(new ListItem("选择标橱窗位", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlClassId.Items.Add(new ListItem(dr["title"].ToString().Trim(), dr["id"].ToString().Trim()));
            }
        }
        #endregion

        #region 赋值操作
        private void ShowInfo(int _id)
        {
            BLL.plugin_images bll = new BLL.plugin_images();
            Model.plugin_images model = bll.GetModel(_id);
            txtName.Text = model.title;
            txtUrl.Text = model.link_url;
            rblTarget.SelectedValue = model.target;
            txtSort.Text = model.sort_id.ToString();
            rblHide.SelectedValue = model.is_lock.ToString();
            ddlClassId.SelectedValue = model.class_id.ToString();
            txtColor.Text = model.back_color;
            txtContent.Value = model.content;
            this.contentType = model.is_type;
            ddlType.SelectedValue = this.contentType.ToString();
            txtImgUrl.Text = model.img_url;
            if (!string.IsNullOrEmpty(model.img_url))
            {
                divImg.Visible = true;
                imgUrl.ImageUrl = model.img_url;
            }
            txtIconUrl.Text = model.icon_url;
            if (!string.IsNullOrEmpty(model.icon_url))
            {
                divIcon.Visible = true;
                imgIcon.ImageUrl = model.icon_url;
            }
        }
        #endregion

        #region 增加操作
        private bool DoAdd()
        {
            BLL.plugin_images bll = new BLL.plugin_images();
            Model.plugin_images model = new Model.plugin_images();

            model.title = txtName.Text;
            model.link_url = txtUrl.Text;
            model.img_url = txtImgUrl.Text;
            model.target = rblTarget.SelectedValue;
            model.is_lock = int.Parse(rblHide.SelectedValue);
            model.sort_id = Utils.StrToInt(txtSort.Text, 99);
            model.add_time = DateTime.Now;
            model.back_color = txtColor.Text;
            model.is_type = Utils.StrToInt(ddlType.SelectedValue, 0);
            model.content = txtContent.Value;
            model.class_id = Utils.StrToInt(ddlClassId.SelectedValue, 0);
            model.img_url = txtImgUrl.Text.Trim();
            model.icon_url = txtIconUrl.Text.Trim();
            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "添加橱窗内容：" + model.title);
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作
        private bool DoEdit(int _id)
        {
            BLL.plugin_images bll = new BLL.plugin_images();
            Model.plugin_images model = bll.GetModel(_id);
            model.title = txtName.Text;
            model.link_url = txtUrl.Text;
            model.img_url = txtImgUrl.Text;
            model.target = rblTarget.SelectedValue;
            model.is_lock = int.Parse(rblHide.SelectedValue);
            model.sort_id = Utils.StrToInt(txtSort.Text, 99);
            model.back_color = txtColor.Text;
            model.is_type = Utils.StrToInt(ddlType.SelectedValue, 0);
            model.content = txtContent.Value;
            model.class_id = Utils.StrToInt(ddlClassId.SelectedValue, 0);
            model.img_url = txtImgUrl.Text.Trim();
            model.icon_url = txtIconUrl.Text.Trim();
            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改橱窗内容：" + model.title);
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
                ChkAdminLevel("plugin_images_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", string.Empty);
                    return;
                }
                JscriptMsg("修改橱窗内容信息成功！", "images_list.aspx" + backUrl);
            }
            else //添加
            {
                ChkAdminLevel("plugin_images_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", string.Empty);
                    return;
                }
                JscriptMsg("添加橱窗内容信息成功！", "images_list.aspx" + backUrl);
            }
        }
    }
}