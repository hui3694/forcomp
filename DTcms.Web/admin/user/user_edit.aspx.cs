using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.user
{
    public partial class user_edit : Web.UI.ManagePage
    {
        private int id = 0;
        protected Model.user model;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = DTRequest.GetQueryInt("id");


            if (!new BLL.user().Exists(this.id))
            {
                JscriptMsg("类别不存在或已被删除！", "back");
                return;
            }
            if (!Page.IsPostBack)
            {
                //浏览权限
                ChkAdminLevel("user_list", DTEnums.ActionEnum.View.ToString());
                //编辑权限
                if (!ChkAuthority("user_list", "Edit"))
                {
                    this.btnSubmit.Visible = false;
                }

                ShowInfo(this.id);
            }
        }

        private void ShowInfo(int id)
        {
            model = new BLL.user().GetModel(id);
            txtName.Text = model.nickname;
            txtOpenid.Text = model.openid;
            imgAvatar.ImageUrl = model.avatar;
            rblStatus.SelectedValue = model.status.ToString();
            rblSex.SelectedValue = model.sex.ToString();
            txtPoint.Text = model.point.ToString();
            txtParent.Text = model.parent_id.ToString();
            lblLevel.Text = model.level == 1 ? "产品经理" : "普通会员";
            txtPhone.Text = model.phone;
            txtEmail.Text = model.email;
            txtLoginTime.Text = model.login_time.ToString("yyyy-MM-dd HH:mm:ss");
            txtRegTime.Text = model.reg_time.ToString("yyyy-MM-dd HH:mm:ss");
        }


        #region 修改操作
        private bool DoEdit(int _id)
        {
            try
            {
                BLL.user bll = new BLL.user();
                Model.user model = bll.GetModel(_id);
                model.nickname = txtName.Text;
                model.status = Convert.ToInt32(rblStatus.SelectedValue);
                model.sex = Convert.ToInt32(rblSex.SelectedValue);
                model.point = Convert.ToInt32(txtPoint.Text);
                model.parent_id = Convert.ToInt32(txtParent.Text);
                model.phone = txtPhone.Text;
                model.email = txtEmail.Text;
                model.login_time = Convert.ToDateTime(txtLoginTime.Text);
                model.reg_time = Convert.ToDateTime(txtRegTime.Text);
                if (bll.Update(model))
                {
                    AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改产品经理信息"); //记录日志
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        //保存类别
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("user_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
            if (!DoEdit(this.id))
            {

                JscriptMsg("保存过程中发生错误！", "");
                return;
            }
            JscriptMsg("修改产品成功！", "user_list.aspx");
        }
    }
}