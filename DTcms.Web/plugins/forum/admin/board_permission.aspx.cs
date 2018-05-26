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
    public partial class board_permission : Web.UI.ManagePage
    {
        //页面属性
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string board_id = string.Empty;
        protected string board_name = string.Empty;

        public System.Data.DataTable dtPer = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.board_id = DTRequest.GetQueryString("board_id");
            this.board_name = DTRequest.GetQueryString("board_name");

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_forum_board", DTEnums.ActionEnum.View.ToString()); //检查权限
                //Model.manager model = GetAdminInfo(); //取得当前管理员信息
                RptBind("" + CombSqlTxt(board_id), "");//添加where子句和order子句

                Global.GetBoardPermissionList(true);
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);

            BLL.Forum_Group bll = new BLL.Forum_Group();

            dtPer = new BLL.Forum_BoardPermission().GetList(" BoardId=" + this.board_id + " ").Tables[0];

            System.Data.DataTable dt = bll.GetList(100, " 1=1 ", " [Type] Asc ").Tables[0];

            dt.Rows.Add("0", "游客组", "0", "0", "0", "0", "0", "", "", "", "0");

            this.rptList.DataSource = dt;// bll.GetList(100, " 1=1 ", " [Type] Asc ");
            this.rptList.DataBind();

        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                //strTemp.Append(" and (user_name like  '%" + _keywords + "%' or real_name like '%" + _keywords + "%' or email like '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion


        protected string CheckChoose(string GroupId, string Val)
        {

            bool bol = false;

            string key = board_id + "|" + GroupId;

            bol = BLL.Forum_BoardPermission.CheckPermission(key, Val);

            if (bol)
            {
                return "checked=\"checked\"";
            }
            else
            {
                return "";
            }
        }

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            ChkAdminLevel("plugin_forum_board", DTEnums.ActionEnum.Edit.ToString()); //检查权限

            BLL.Forum_Group bll = new BLL.Forum_Group();
            BLL.Forum_BoardPermission bllBPer = new BLL.Forum_BoardPermission();

            int _board_id = Convert.ToInt32(Request.Form["board_id"]);

            List<Model.Forum_Group> listGroup = bll.GetModelList(" 1=1 ");

            Model.Forum_Group modelGroup = new Model.Forum_Group();

            modelGroup.Id=0;
            modelGroup.Name="游客组";

            listGroup.Add(modelGroup);

            foreach (Model.Forum_Group item in listGroup)
            {

                Model.Forum_BoardPermission model = bllBPer.GetModel(" BoardId=" + _board_id + " and  GroupId=" + item.Id + " ");

                bool isNew = false;

                if (model == null)
                {
                    model = new Model.Forum_BoardPermission();
                    isNew = true;
                }
                model.BoardId = _board_id;
                model.GroupId = item.Id;
                model.VisitBoard = DTRequest.GetFormIntValue("VisitBoard_" + item.Id, 0);
                model.VisitTopic = DTRequest.GetFormIntValue("VisitTopic_" + item.Id, 0);
                model.PostTopic = DTRequest.GetFormIntValue("PostTopic_" + item.Id, 0);
                model.PostReply = DTRequest.GetFormIntValue("PostReply_" + item.Id, 0);
                model.UploadAttachment = DTRequest.GetFormIntValue("UploadAttachment_" + item.Id, 0);
                model.ViewAttachment = DTRequest.GetFormIntValue("ViewAttachment_" + item.Id, 0);
                model.UpdateMyselfTopic = DTRequest.GetFormIntValue("UpdateMyselfTopic_" + item.Id, 0);
                model.UpdateMyselfReply = DTRequest.GetFormIntValue("UpdateMyselfReply_" + item.Id, 0);
                model.DeleteMyselfTopic = DTRequest.GetFormIntValue("DeleteMyselfTopic_" + item.Id, 0);
                model.DeleteMyselfReply = DTRequest.GetFormIntValue("DeleteMyselfReply_" + item.Id, 0);

                if (isNew)
                {
                    bllBPer.Add(model);
                }
                else
                {
                    bllBPer.Update(model);
                }

            }

            //重新加载
            Global.GetBoardPermissionList(true);

            JscriptMsg("保存信息成功！", "board_list.aspx");



        }
    }
}