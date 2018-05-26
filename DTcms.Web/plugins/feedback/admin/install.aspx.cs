using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.Plugin.Feedback.admin
{
    public partial class install : Web.UI.ManagePage
    {
        protected int property = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.property = DTRequest.GetQueryInt("property");
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_feedback", DTEnums.ActionEnum.View.ToString());
                //赋值
                ShowInfo();
            }
        }

        //赋值操作
        private void ShowInfo()
        {
            BLL.feedbackconfig bll = new BLL.feedbackconfig();
            Model.feedbackconfig model = bll.loadConfig();
            rblBookMsg.SelectedValue = model.bookmsg.ToString();
            txtBookTemplet.Text = model.booktemplet;
            txtReceive.Text = model.receive;
        }

        //保存操作
        /// <summary>
        /// 保存配置信息
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("plugin_feedback", DTEnums.ActionEnum.Instal.ToString());
            BLL.feedbackconfig bll = new BLL.feedbackconfig();
            Model.feedbackconfig model = bll.loadConfig();
            try
            {
                model.bookmsg = Utils.StrToInt(rblBookMsg.SelectedValue, 0);
                model.booktemplet = txtBookTemplet.Text.Trim() ;
                model.receive = txtReceive.Text.Trim();

                bll.saveConifg(model);
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改留言插件配置信息");
                JscriptMsg("修改留言插件配置信息成功！", "index.aspx");
            }
            catch
            {
                JscriptMsg("文件写入失败，请检查文件夹权限！", "");
            }
        }

    }
}