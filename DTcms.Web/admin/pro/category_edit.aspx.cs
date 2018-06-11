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
    public partial class category_edit : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        protected DateTime dtime;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            this.id = DTRequest.GetQueryInt("id");

            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.pro_category().Exists(this.id))
                {
                    JscriptMsg("类别不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //浏览权限
                ChkAdminLevel("pro_category", DTEnums.ActionEnum.View.ToString());

                //编辑权限
                if (!ChkAuthority("pro_category", this.action))
                {
                    this.btnSubmit.Visible = false;
                }

                TreeBind(); //绑定类别
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else
                {
                    if (this.id > 0)
                    {
                        this.ddlParentId.SelectedValue = this.id.ToString();
                    }
                }
            }
        }

        //类别绑定
        private void TreeBind()
        {
            DataSet ds = new BLL.pro_category().GetList(0, "parent_id=0", "sort,id");
            this.ddlParentId.Items.Add(new ListItem("请选择分类",""));
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                this.ddlParentId.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
            }
        }

        private void ShowInfo(int id)
        {
            Model.pro_category model = new BLL.pro_category().GetModel(id);
            ddlParentId.SelectedValue = model.parent_id.ToString();
            txtSortId.Text = model.sort.ToString();
            txtTitle.Text = model.title;
            txtImgUrl.Text = model.img;
            txtImgUrl2.Text = model.img2;
            if (!string.IsNullOrEmpty(model.img))
            {
                ImgDiv.Visible = true;
                ImgUrl.ImageUrl = model.img;
            }
            if (!string.IsNullOrEmpty(model.img2))
            {
                ImgDiv2.Visible = true;
                ImgUrl2.ImageUrl = model.img2;
            }

            if (model.is_sys == 1)
            {
                div_parent.Visible = false;
                
            }else
            {
                div_img2.Visible = false;
            }
        }

        #region 增加操作
        private bool DoAdd()
        {
            try
            {
                Model.pro_category model = new Model.pro_category();
                BLL.pro_category bll = new BLL.pro_category();
                model.title = txtTitle.Text;
                model.img = txtImgUrl.Text;
                model.parent_id = Convert.ToInt32(ddlParentId.SelectedValue);
                model.sort = Convert.ToInt32(txtSortId.Text);
                model.is_sys = 0;

                if (bll.Add(model) > 0)
                {
                    AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加产品栏目分类:" + model.title); //记录日志
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

        #region 修改操作
        private bool DoEdit(int _id)
        {
            try
            {
                BLL.pro_category bll = new BLL.pro_category();
                Model.pro_category model = bll.GetModel(_id);

                model.title = txtTitle.Text;
                model.img = txtImgUrl.Text;
                model.img2 = txtImgUrl2.Text;
                if (model.is_sys != 1)
                {
                    model.parent_id = Convert.ToInt32(ddlParentId.SelectedValue);
                }
                model.sort = Convert.ToInt32(txtSortId.Text);
                

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
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("pro_category", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {

                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改类别成功！", "category_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("pro_category", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加类别成功！", "category_list.aspx");
            }
        }
    }
}