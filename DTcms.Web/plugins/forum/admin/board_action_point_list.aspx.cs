using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using DTcms.Common;

namespace DTcms.Web.Plugin.Forum.admin
{
        //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class board_action_point_list : Web.UI.ManagePage
    {
        //页面属性
        protected int board_id;
        protected string board_name;
        protected System.Data.DataTable dtBoardActionPoint;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.board_id = DTRequest.GetInt("board_id", 0);

            if (board_id == 0)
            {
                board_name = "所有版块";
            }
            else
            {
                board_name = new BLL.Forum_Board().GetModel(board_id).Name;
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_forum_boardactionpoint", DTEnums.ActionEnum.View.ToString()); //检查权限

                RptBind();//添加where子句和order子句
            }
        }

        #region 数据绑定=================================
        private void RptBind()
        {
            //实际表数据
            dtBoardActionPoint = new BLL.Forum_BoardActionPoint().GetList("BoardId=" + board_id).Tables[0];

            this.rptList.DataSource = Global.GetActionList();
            this.rptList.DataBind();

        }
        #endregion

        //美化列表
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                //动作Key
                int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("hidId")).Value);

                TextBox txtPoint = (TextBox)e.Item.FindControl("txtPoint");

                CheckBox chkId = (CheckBox)e.Item.FindControl("chkId");

                System.Data.DataRow[] drs = dtBoardActionPoint.Select("ActionId=" + id + " and BoardId=" + board_id);

                if (drs.Length != 0)
                {
                    txtPoint.Text = drs[0]["Point"].ToString();

                    if (drs[0]["Enable"].ToString()=="1")
                    {
                        chkId.Checked = true;
                    }
                    else
                    {
                        chkId.Checked = false;
                    }
                }
                else
                {
                    txtPoint.Text = "0";
                }
            }
        }

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            ChkAdminLevel("plugin_forum_boardactionpoint", DTEnums.ActionEnum.Add.ToString()); //检查权限

            BLL.Forum_BoardActionPoint bll = new BLL.Forum_BoardActionPoint();
            Repeater rptList = new Repeater();
            rptList = this.rptList;
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);

                int intPoint;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtPoint")).Text.Trim(), out intPoint))
                {
                    intPoint = 0;
                }

                int intEnable = 0;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    intEnable = 1;
                }

                bool bol = bll.UpdateField("ActionId=" + id + " and BoardId=" + board_id, "Enable=" + intEnable + " , Point=" + intPoint.ToString());

                if (bol == false)
                {
                    Model.Forum_BoardActionPoint model = new Model.Forum_BoardActionPoint();

                    model.ActionId = id;
                    model.BoardId = board_id;
                    model.Enable = intEnable;
                    model.Point = intPoint;

                    bll.Add(model);
                }

                //同步所有版块
                if (Convert.ToInt32(ddlSYN.SelectedValue)==1)
                {
                    bll.UpdateField("ActionId=" + id , " Point=" + intPoint.ToString());
                }
            }

            JscriptMsg("操作成功！", "board_action_point_list.aspx?board_id=" + this.board_id);
        }
    }
}