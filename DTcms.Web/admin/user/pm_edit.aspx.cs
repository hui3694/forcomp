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
    public partial class pm_edit : Web.UI.ManagePage
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = DTRequest.GetQueryInt("id");


            if (!new BLL.user_pm().Exists(this.id))
            {
                JscriptMsg("类别不存在或已被删除！", "back");
                return;
            }
            if (!Page.IsPostBack)
            {
                //浏览权限
                ChkAdminLevel("pro_pm_list", DTEnums.ActionEnum.View.ToString());
                //编辑权限
                if (!ChkAuthority("pro_pm_list", "Edit"))
                {
                    this.btnSubmit.Visible = false;
                }

                ShowInfo(this.id);
            }
        }

        private void ShowInfo(int id)
        {
            Model.user_pm model = new BLL.user_pm().GetModel(id);
            if (model.status != 1)
            {
                btnPass.Visible = false;
                btnPass2.Visible = false;
            }
            txtName.Text = model.name;
            rblSex.SelectedValue = model.sex.ToString();
            txtOrigin.Text = model.origin;
            txtPhone.Text = model.phone;
            txtComName.Text = model.comname;
            txtJob.Text = model.job;
            txtYear.Text = model.year.ToString();
            jobImg.Text = model.jobimg;
            txtImg.Text = model.img;
            txtAddTime.Text = model.add_time.ToString("yyyy-MM-dd HH:mm:ss");
            txtPassTime.Text = model.pass_time.ToString("yyyy-MM-dd HH:mm:ss");
        }


        #region 修改操作
        private bool DoEdit(int _id)
        {
            try
            {
                BLL.user_pm bll = new BLL.user_pm();
                Model.user_pm model = bll.GetModel(_id);
                model.name = txtName.Text;
                model.sex = Convert.ToInt32(rblSex.SelectedValue);
                model.origin = txtOrigin.Text;
                model.phone = txtPhone.Text;
                model.comname = txtComName.Text;
                model.job = txtJob.Text;
                model.year = Convert.ToInt32(txtYear.Text);
                model.jobimg = jobImg.Text;
                model.img = txtImg.Text;
                model.add_time = Convert.ToDateTime(txtAddTime.Text);
                model.pass_time = Convert.ToDateTime(txtPassTime.Text);


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
            ChkAdminLevel("pro_pm_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
            if (!DoEdit(this.id))
            {

                JscriptMsg("保存过程中发生错误！", "");
                return;
            }
            JscriptMsg("修改产品成功！", "pm_list.aspx");
        }

        protected void btnPass_Click(object sender, EventArgs e)
        {
            new BLL.user_pm().UpdateField(id, "status=2,pass_time=getdate()");
            JscriptMsg("审核产品经理完成！", "pm_list.aspx");
        }

        protected void btnPass2_Click(object sender, EventArgs e)
        {
            new BLL.user_pm().UpdateField(id, "status=3,pass_time=getdate()");
            JscriptMsg("审核产品经理完成！", "pm_list.aspx");
        }
    }
}