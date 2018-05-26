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
    public partial class moderator_list : Web.UI.ManagePage
    {
        //页面属性
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int board_id = 0;
        protected System.Data.DataTable tdGroup;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.board_id = DTRequest.GetInt("board_id", 0);


            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_forum_moderator", DTEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind();
                RptBind(" BoardId=" + board_id + " ", " id asc ");//添加where子句和order子句
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);

            BLL.Forum_Moderator bll = new BLL.Forum_Moderator();
            this.rptList.DataSource = bll.GetList(25, _strWhere, _orderby);
            this.rptList.DataBind();


        }
        #endregion


        #region 绑定类别=================================
        private void TreeBind()
        {
            BLL.Forum_Group bll = new BLL.Forum_Group();
            tdGroup = bll.GetList(20, "1=1", "[Type] asc").Tables[0];
            this.ddlGroupId.Items.Clear();
            this.ddlGroupId.Items.Add(new ListItem("所有分组", ""));
            foreach (DataRow dr in tdGroup.Rows)
            {
                this.ddlGroupId.Items.Add(new ListItem(dr["Name"].ToString().Trim(), dr["id"].ToString().Trim()));
            }
        }
        #endregion

        protected string GetGroupName(string _id)
        {
            string _name = "";

            foreach (DataRow dr in tdGroup.Rows)
            {
                if (dr["id"].ToString() == _id)
                {
                    _name = dr["Name"].ToString().Trim();

                    break;
                }
            }

            return _name;
        }




        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("plugin_forum_moderator", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.Forum_Moderator bll = new BLL.Forum_Moderator();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }

            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除dt_Forum_Moderator"
                + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("moderator_list.aspx", "board_id={0}", this.board_id.ToString()));
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            ChkAdminLevel("plugin_forum_moderator", DTEnums.ActionEnum.Add.ToString()); //检查权限

            Model.Forum_Moderator model = new Model.Forum_Moderator();
            BLL.Forum_Moderator bll = new BLL.Forum_Moderator();

            DTcms.Model.users modelUser = new DTcms.BLL.users().GetModel(txtUsername.Text.Replace("'", ""));
            

            if (modelUser != null)
            {
                Model.Forum_UserExtended modelExtended = new BLL.Forum_UserExtended().GetModel(modelUser.id);

                if (modelExtended != null)
                {
                    //编写添加操作Begin

                    model.BoardId = this.board_id;
                    model.GroupId = Convert.ToInt32(ddlGroupId.SelectedValue);
                    model.UserId = modelUser.id;
                    model.Username = modelUser.user_name;
                    model.Nickname = modelUser.nick_name;
                    //编写添加操作End                    

                    bll.Add(model);

                    modelExtended.GroupId = Convert.ToInt32(ddlGroupId.SelectedValue);

                    new BLL.Forum_UserExtended().Update(modelExtended);

                    JscriptMsg("添加信息成功！", Utils.CombUrlTxt("moderator_list.aspx", "board_id={0}", this.board_id.ToString()));


                }
                else
                {
                    JscriptMsg("该会员未从DTcms中同步！", "");
                    return;
                }

            }
            else
            {
                JscriptMsg("会员不存在！", "");
                return;
            }
        }
    }
}