using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.users
{
    public partial class user_email : Web.UI.ManagePage
    {
        string email = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            email = DTRequest.GetString("email");
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("user_sms", DTEnums.ActionEnum.View.ToString()); //检查权限
                ShowInfo(email);
                TreeBind("is_lock=0"); //绑定类别
            }
        }

        //绑定用户组
        private void TreeBind(string strWhere)
        {
            BLL.user_groups bll = new BLL.user_groups();
            DataTable dt = bll.GetList(0, strWhere, "grade asc,id asc").Tables[0];

            this.cblGroupId.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                this.cblGroupId.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
            }
        }

        //赋值操作
        private void ShowInfo(string _email)
        {
            if (!string.IsNullOrEmpty(_email))
            {
                div_email.Visible = true;
                div_group.Visible = false;
                rblSmsType.SelectedValue = "1";
                txtEmailList.Text = _email;

            }
            else
            {
                rblSmsType.SelectedValue = "2";
                div_email.Visible = false;
                div_group.Visible = true;
            }
        }

        //返回会员组所有邮箱地址
        private List<string> GetGroupEmail(ArrayList al)
        {
            List<string> list = new List<string>();
            foreach (Object obj in al)
            {
                DataTable dt = new BLL.users().GetList(0, "group_id=" + Convert.ToInt32(obj), "reg_time desc,id desc").Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string _email = dr["email"].ToString();
                    if (!string.IsNullOrEmpty(_email))
                    {
                        list.Add(_email);
                    }
                }
            }
            return list;
        }

        //选择发送类型
        protected void rblSmsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblSmsType.SelectedValue == "1")
            {
                div_group.Visible = false;
                div_email.Visible = true;
            }
            else
            {
                div_group.Visible = true;
                div_email.Visible = false;
            }
        }

        //提交发送
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("user_sms", DTEnums.ActionEnum.Add.ToString()); //检查权限

            string emailList = txtEmailList.Text.Trim();
            string emailTitle = txtTitle.Text.Trim();
            string emailBody = txtContent.Value;
            if (emailTitle.Length == 0)
            {
                JscriptMsg("请输入邮件标题！", "");
                return;
            }
            if (emailBody.Length == 0)
            {
                JscriptMsg("请输入邮件内容！", "");
                return;
            }
            //邮箱地址
            List<string> list = null;
            //检查发送类型
            if (rblSmsType.SelectedValue == "1")
            {
                list = new List<string>();
                if (emailList.Length == 0)
                {
                    JscriptMsg("请输入邮箱地址！", "");
                    return;
                }
                string[] emailArr = emailList.Split(',');
                foreach (string _email in emailArr)
                {
                    list.Add(_email);
                }
            }
            else
            {
                ArrayList al = new ArrayList();
                for (int i = 0; i < cblGroupId.Items.Count; i++)
                {
                    if (cblGroupId.Items[i].Selected)
                    {
                        al.Add(cblGroupId.Items[i].Value);
                    }
                }
                if (al.Count < 1)
                {
                    JscriptMsg("请选择会员组别！", "");
                    return;
                }
                list = GetGroupEmail(al);
            }

            int sucCount = 0; //成功数量
            int errorCount = 0; //失败数量
            foreach (string _email in list)
            {
                if (Utils.IsValidEmail(_email))
                {
                    try
                    {
                        DTMail.sendMail(siteConfig.emailsmtp, siteConfig.emailssl,
                            siteConfig.emailusername,
                            DESEncrypt.Decrypt(siteConfig.emailpassword, siteConfig.sysencryptstring),
                            siteConfig.emailnickname,
                            siteConfig.emailfrom,
                            _email,
                            emailTitle,
                            emailBody);
                        sucCount++;
                    }
                    catch
                    {
                        errorCount++;
                    }
                }
                else
                {
                    errorCount++;
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "成功发送邮件" + sucCount + "条，失败" + errorCount + "条！"); //记录日志
            JscriptMsg("成功发送邮件" + sucCount + "条，失败" + errorCount + "条！", "user_email.aspx");
        }
    }
}