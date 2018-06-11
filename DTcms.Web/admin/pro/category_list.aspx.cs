using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;

namespace DTcms.Web.admin.pro
{
    public partial class category_list : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //检查权限
                ChkAdminLevel("pro_category", DTEnums.ActionEnum.View.ToString());

                //添加权限
                if (!ChkAuthority("pro_category", DTEnums.ActionEnum.Add.ToString()))
                {
                    this.addBtnPannel.Visible = false;
                }
                //修改权限
                if (!ChkAuthority("pro_category", DTEnums.ActionEnum.Edit.ToString()))
                {
                    this.editBtnPannel.Visible = false;
                }
                //删除权限
                if (!ChkAuthority("pro_category", DTEnums.ActionEnum.Delete.ToString()))
                {
                    this.delBtnPannel.Visible = false;
                }
                RptBind();
            }
        }

        private void RptBind()
        {
            BLL.pro_category bll = new BLL.pro_category();
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("title");
            dt.Columns.Add("img");
            dt.Columns.Add("img2");
            dt.Columns.Add("parent_id");
            dt.Columns.Add("sort");
            dt.Columns.Add("is_sys");
            DataSet ds1 = bll.GetList(0, "parent_id=0", "sort,id");
            foreach(DataRow dr in ds1.Tables[0].Rows)
            {
                dt.ImportRow(dr);
                DataSet ds2 = new BLL.pro_category().GetList(0, "parent_id=" + dr["id"].ToString(), "sort,id");
                foreach(DataRow dr2 in ds2.Tables[0].Rows)
                {
                    dt.ImportRow(dr2);
                }
            }
            rptList.DataSource = dt;
            rptList.DataBind();
        }


        //美化列表
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
                HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
                string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
                string LitImg1 = "<span class=\"folder-open\"></span>";
                string LitImg2 = "<span class=\"folder-line\"></span>";

                int classLayer = Convert.ToInt32(hidLayer.Value);
                if (classLayer == 1)
                {
                    LitFirst.Text = LitImg1;
                }
                else
                {
                    LitFirst.Text = string.Format(LitStyle, (classLayer - 2) * 24, LitImg2, LitImg1);
                }
            }
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("pro_category", DTEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.pro_category bll = new BLL.pro_category();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "sort=" + sortId.ToString());
            }
            AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "保存产品分类排序"); //记录日志
            JscriptMsg("保存排序成功！", Utils.CombUrlTxt("category_list.aspx", "", ""));
        }

        //删除类别
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("pro_category", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            BLL.pro_category bll = new BLL.pro_category();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "删除产品分类数据"); //记录日志
            JscriptMsg("删除数据成功！", Utils.CombUrlTxt("category_list.aspx","",""));
        }
    }
}