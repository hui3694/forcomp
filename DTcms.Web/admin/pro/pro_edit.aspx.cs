using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.pro
{
    public partial class pro_edit : Web.UI.ManagePage
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = DTRequest.GetQueryInt("id");

        
                if (!new BLL.product().Exists(this.id))
                {
                    JscriptMsg("类别不存在或已被删除！", "back");
                    return;
                }
            if (!Page.IsPostBack)
            {
                //浏览权限
                ChkAdminLevel("pro_list", DTEnums.ActionEnum.View.ToString());

                //编辑权限
                if (!ChkAuthority("pro_list", "Edit"))
                {
                    this.btnSubmit.Visible = false;
                }

                TreeBind(); //绑定类别

                ShowInfo(this.id);
            }
        }

        //类别绑定
        private void TreeBind()
        {
            DataTable dt = new BLL.pro_category().GetList(0, "parent_id=0", "sort").Tables[0];
            this.ddlCategoryId.Items.Clear();
            this.ddlCategoryId.Items.Add(new ListItem("请选择类别...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                string Title = dr["title"].ToString().Trim();
                this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                DataTable dt2 = new BLL.pro_category().GetList(0, "parent_id=" + Id, "sort").Tables[0];
                foreach (DataRow dr2 in dt2.Rows)
                {
                    this.ddlCategoryId.Items.Add(new ListItem("　├ " + dr2["title"].ToString(), dr2["id"].ToString()));
                }
            }
        }

        private void ShowInfo(int id)
        {
            Model.product model = new BLL.product().GetModel(id);
            ddlCategoryId.SelectedValue = model.category.ToString();
            txtSort.Text = model.sort.ToString();
            txtTitle.Text = model.title;
            txtCity.Text = model.city;
            txtLon.Text = model.lon;
            txtLat.Text = model.lat;
            txtAddr.Text = model.addr;
            txtCont.Text = model.cont;
            txtAddTime.Text=model.add_time.ToString("yyyy-MM-dd HH:mm:ss");
            txtPassTime.Text=model.pass_time.ToString("yyyy-MM-dd HH:mm:ss");

        }


        #region 修改操作
        private bool DoEdit(int _id)
        {
            try
            {
                BLL.pro_category bll = new BLL.pro_category();
                Model.pro_category model = bll.GetModel(_id);

                model.title = txtTitle.Text;
               


                if (bll.Update(model))
                {
                    AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改产品栏目分类:" + model.title); //记录日志
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

            ChkAdminLevel("pro_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
            if (!DoEdit(this.id))
            {

                JscriptMsg("保存过程中发生错误！", "");
                return;
            }
            JscriptMsg("修改类别成功！", "pro_list.aspx");

        }


    }
}