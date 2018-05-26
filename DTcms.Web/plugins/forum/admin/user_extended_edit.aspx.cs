using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.Plugin.Forum.admin
{
        //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------
    public partial class user_extended_edit : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        public DTcms.Model.users modelUser = null;
        public string medalHtml = "无勋章";

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.Forum_UserExtended().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_forum_userextended", DTEnums.ActionEnum.View.ToString()); //检查权限

                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    TreeBind();
                    ShowInfo(this.id);
                }
            }
        }



        #region 绑定类别
        private void TreeBind()
        {
            BLL.Forum_Group bll = new BLL.Forum_Group();
            DataTable dt = bll.GetList(10, "1=1", " Type asc").Tables[0];

            this.ddlGroupId.Items.Clear();
            this.ddlGroupId.Items.Add(new ListItem("请选择组别...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlGroupId.Items.Add(new ListItem(dr["Name"].ToString(), dr["id"].ToString()));
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.Forum_UserExtended bll = new BLL.Forum_UserExtended();
            Model.Forum_UserExtended model = bll.GetModel(_id);

            modelUser = new DTcms.BLL.users().GetModel(model.UserId);

            //编写赋值操作Begin

            //txtUserId.Text = model.UserId;
            //txtQQ.Text = model.QQ;
            //txtMSN.Text = model.MSN;
            rblGender.SelectedValue = model.Gender.ToString();
            //txtBirthday.Text = model.Birthday;
            //txtBio.Text = model.Bio;
            //txtAddress.Text = model.Address;
            //txtSite.Text = model.Site;
            //txtSignature.Text = model.Signature;
            txtNickname.Text = model.Nickname;
            //txtLastPostDateTime.Text = model.LastPostDateTime;
            ddlGroupId.SelectedValue = model.GroupId.ToString();
            //txtLastActivity.Text = model.LastActivity;
            //txtTopicCount.Text = model.TopicCount;
            //txtPostCount.Text = model.PostCount;
            //txtPostDigestCount.Text = model.PostDigestCount;
            //txtMedal.Text = model.Medal;
            //txtOnlineTime.Text = model.OnlineTime;
            //txtOnlineUpdateTime.Text = model.OnlineUpdateTime;
            //txtVerify.Text = model.Verify;
            //txtHometown.Text = model.Hometown;
            //txtNonlocal.Text = model.Nonlocal;
            //txtSpecialty.Text = model.Specialty;
            txtCredit.Text = model.Credit.ToString();

            if (!string.IsNullOrEmpty(model.Medal))
            {
                List<Model.Forum_Medal> modelList = new BLL.Forum_Medal().GetModelList(" id in (" + model.Medal + ") ");

                medalHtml = "";

                foreach (Model.Forum_Medal item in modelList)
                {
                    medalHtml += "<img <img src='" + item.Image + "' style=' max-width:100px; margin:8px 8px 0px 0px;vertical-align: top;' />";
                }
            }


            //编写赋值操作End
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.Forum_UserExtended model = new Model.Forum_UserExtended();
            BLL.Forum_UserExtended bll = new BLL.Forum_UserExtended();
            //编写添加操作Begin
            //model.UserId = txtUserId.Text;
            //model.QQ = txtQQ.Text;
            //model.MSN = txtMSN.Text;
            //model.Gender = txtGender.Text;
            //model.Birthday = txtBirthday.Text;
            //model.Bio = txtBio.Text;
            //model.Address = txtAddress.Text;
            //model.Site = txtSite.Text;
            //model.Signature = txtSignature.Text;
            //model.Nickname = txtNickname.Text;
            //model.LastPostDateTime = txtLastPostDateTime.Text;
            //model.GroupId = txtGroupId.Text;
            //model.LastActivity = txtLastActivity.Text;
            //model.TopicCount = txtTopicCount.Text;
            //model.PostCount = txtPostCount.Text;
            //model.PostDigestCount = txtPostDigestCount.Text;
            //model.Medal = txtMedal.Text;
            //model.OnlineTime = txtOnlineTime.Text;
            //model.OnlineUpdateTime = txtOnlineUpdateTime.Text;
            //model.Verify = txtVerify.Text;
            //model.Hometown = txtHometown.Text;
            //model.Nonlocal = txtNonlocal.Text;
            //model.Specialty = txtSpecialty.Text;
            //model.Credit = txtCredit.Text;
            //编写添加操作End

            if (bll.Add(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加dt_Forum_UserExtended:"
                    + model.Nickname); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.Forum_UserExtended bll = new BLL.Forum_UserExtended();
            Model.Forum_UserExtended model = bll.GetModel(_id);

            //编写编辑操作Begin
            //model.UserId = txtUserId.Text;
            //model.QQ = txtQQ.Text;
            //model.MSN = txtMSN.Text;
            model.Gender = Convert.ToInt32(rblGender.SelectedValue);
            //model.Birthday = txtBirthday.Text;
            //model.Bio = txtBio.Text;
            //model.Address = txtAddress.Text;
            //model.Site = txtSite.Text;
            //model.Signature = txtSignature.Text;
            //model.Nickname = txtNickname.Text;
            //model.LastPostDateTime = txtLastPostDateTime.Text;
            model.GroupId = Convert.ToInt32(ddlGroupId.SelectedValue);
            //model.LastActivity = txtLastActivity.Text;
            //model.TopicCount = txtTopicCount.Text;
            //model.PostCount = txtPostCount.Text;
            //model.PostDigestCount = txtPostDigestCount.Text;
            //model.Medal = txtMedal.Text;
            //model.OnlineTime = txtOnlineTime.Text;
            //model.OnlineUpdateTime = txtOnlineUpdateTime.Text;
            //model.Verify = txtVerify.Text;
            //model.Hometown = txtHometown.Text;
            //model.Nonlocal = txtNonlocal.Text;
            //model.Specialty = txtSpecialty.Text;
            model.Credit = Convert.ToInt32(txtCredit.Text);
            //编写编辑操作End

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改管理员:" + model.Nickname); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("plugin_forum_userextended", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改信息成功！", "user_extended_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("Forum_UserExtended_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加信息成功！", "user_extended_list.aspx");
            }
        }
    }
}