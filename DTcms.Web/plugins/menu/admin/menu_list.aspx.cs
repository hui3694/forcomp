using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.Plugin.Menu.admin
{
    public partial class menu_list : Web.UI.ManagePage
    {
        protected int class_id = 0;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.class_id = DTRequest.GetQueryInt("class_id", 1);
            this.keywords = DTRequest.GetQueryString("keywords");

            if (!Page.IsPostBack)
            {
                //检查权限
                ChkAdminLevel("plugin_menu_list", DTEnums.ActionEnum.Show.ToString());

                //绑定类别
                TreeBind();

                //绑定数据
                DataTable dt = new BLL.plugin_menu().GetList(0, 0, CombSqlTxt(this.keywords, this.class_id), "sort_id asc,id asc");
                dt.Columns.Add("class_title", Type.GetType("System.String"));
                dt.Columns.Add("class_color", Type.GetType("System.String"));
                if (dt.Rows.Count > 0)
                {
                    int cid = 0;
                    Model.plugin_menu_class cmodel;
                    BLL.plugin_menu_class bll = new BLL.plugin_menu_class();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cid = int.Parse(dt.Rows[i]["class_id"].ToString());
                        cmodel = bll.GetModel(cid);
                        if (null != cmodel)
                        {
                            dt.Rows[i]["class_title"] = cmodel.title;
                            dt.Rows[i]["class_color"] = cmodel.color;
                        }
                    }
                }
                this.rptList.DataSource = dt;
                this.rptList.DataBind();

                this.ddlClass.SelectedValue = this.class_id.ToString();
                this.txtKeywords.Text = Utils.Htmls(this.keywords);
            }
        }

        //组合SQL查询语句
        protected string CombSqlTxt(string _keywords, int _class_id)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            strTemp.Append("class_id=" + class_id.ToString());
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and title like  '%" + _keywords + "%'");
            }
            return strTemp.ToString();
        }

        //绑定类别
        private void TreeBind()
        {
            BLL.plugin_menu_class bll = new BLL.plugin_menu_class();
            DataTable dt = bll.GetList(0, "", "sort_id asc, id desc").Tables[0];

            this.ddlClass.Items.Clear();

            string Id, Title;
            foreach (DataRow dr in dt.Rows)
            {
                Id = dr["id"].ToString();
                Title = dr["title"].ToString().Trim();
                this.ddlClass.Items.Add(new ListItem(Title, Id));
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //检查权限
            ChkAdminLevel("plugin_menu_list", DTEnums.ActionEnum.Delete.ToString());
            BLL.plugin_menu bll = new BLL.plugin_menu();
            int sucCount = 0;
            int errorCount = 0;
            Repeater rptList = new Repeater();
            rptList = this.rptList;
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount++;
                    }
                    else
                    {
                        errorCount++;
                    }
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "删除菜单内容成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("成功删除 " + sucCount + " 条,失败 " + errorCount + " 条！", Utils.CombUrlTxt("menu_list.aspx", "keywords={0}&class_id={1}", this.keywords, this.class_id.ToString()));
        }

        /// <summary>
        /// 关键词查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("menu_list.aspx", "keywords={0}&class_id={1}", txtKeywords.Text, this.class_id.ToString()));
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

        //筛选类别
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("menu_list.aspx", "class_id={0}", ddlClass.SelectedValue));
        }

        /// <summary>
        /// 保存排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("plugin_menu_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.plugin_menu bll = new BLL.plugin_menu();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "sort_id=" + sortId.ToString());
            }
            AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改菜单排序！"); //记录日志
            JscriptMsg("保存排序成功！", Utils.CombUrlTxt("menu_list.aspx", "keywords={0}&class_id={1}", this.keywords, this.class_id.ToString()));
        }
    }
}