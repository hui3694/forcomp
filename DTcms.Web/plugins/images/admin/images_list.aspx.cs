using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.Plugin.Images.admin
{
    public partial class images_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected int class_id;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.class_id = DTRequest.GetQueryInt("class_id");
            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_images_list", DTEnums.ActionEnum.Show.ToString());
                //绑定类别
                TreeBind();
                //绑定数据
                RptBind(CombSqlTxt(this.class_id, keywords), "class_id asc,sort_id asc,id desc");
            }
        }

        //绑定类别
        private void TreeBind()
        {
            BLL.plugin_images_class bll = new BLL.plugin_images_class();
            DataTable dt = bll.GetList(0, "is_lock=0", "sort_id asc,id asc").Tables[0];
            this.ddlClassID.Items.Clear();
            this.ddlClassID.Items.Add(new ListItem("所有橱窗位", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlClassID.Items.Add(new ListItem(dr["title"].ToString().Trim(), dr["id"].ToString().Trim()));
            }
        }

        //绑定数据
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryIntValue("page", 1);
            this.txtKeywords.Text = Utils.Htmls(this.keywords);
            this.ddlClassID.SelectedValue = this.class_id.ToString();

            DataTable dt = new BLL.plugin_images().GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount).Tables[0];
            dt.Columns.Add("class_title", Type.GetType("System.String"));
            if (dt.Rows.Count > 0)
            {
                int cid = 0;
                Model.plugin_images_class cmodel;
                BLL.plugin_images_class bll = new BLL.plugin_images_class();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cid = int.Parse(dt.Rows[i]["class_id"].ToString());
                    cmodel = bll.GetModel(cid);
                    if (null != cmodel)
                    {
                        dt.Rows[i]["class_title"] = cmodel.title;
                    }
                }
            }
            this.rptList.DataSource = dt;
            this.rptList.DataBind();
            //绑定页码
            this.txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("images_list.aspx", "keywords={0}&class_id={1}&page={2}", keywords, this.class_id.ToString(), "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        //组合SQL查询语句
        protected string CombSqlTxt(int _class_id, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (_class_id > 0)
            {
                strTemp.Append("class_id=" + _class_id);
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                if (_class_id > 0)
                {
                    strTemp.Append(" and ");
                }
                strTemp.Append("title like  '%" + _keywords + "%'");
            }
            return strTemp.ToString();
        }

        //返回每页数量
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("plugin_images_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //检查权限
            ChkAdminLevel("plugin_images_list", DTEnums.ActionEnum.Delete.ToString());
            BLL.plugin_images bll = new BLL.plugin_images();
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
            AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "删除橱窗内容成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("成功删除 " + sucCount + " 条,失败 " + errorCount + " 条！", Utils.CombUrlTxt("images_list.aspx", "keywords={0}&class_id={1}", this.keywords, this.class_id.ToString()));
        }

        /// <summary>
        /// 关键词查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("images_list.aspx", "keywords={0}&class_id={1}", txtKeywords.Text, this.class_id.ToString()));
        }

        //筛选类别
        protected void ddlClassID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("images_list.aspx", "keywords={0}&class_id={1}", this.keywords, this.ddlClassID.SelectedValue));
        }

        /// <summary>
        /// 每页显示总数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("plugin_images_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("images_list.aspx", "keywords={0}&class_id={1}", this.keywords, this.class_id.ToString()));
        }

        /// <summary>
        /// 保存排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("plugin_images_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.plugin_images bll = new BLL.plugin_images();
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
            JscriptMsg("保存排序成功！", Utils.CombUrlTxt("images_list.aspx", "keywords={0}&class_id={1}", this.keywords, this.class_id.ToString()));
        }
    }
}