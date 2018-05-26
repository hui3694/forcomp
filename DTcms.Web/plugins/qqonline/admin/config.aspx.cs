using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.Plugin.QQOnline.admin
{
    public partial class config : Web.UI.ManagePage
    {
        protected int property = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.property = DTRequest.GetQueryInt("property");

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_qqonline_config", DTEnums.ActionEnum.View.ToString()); //检查权限
                //赋值
                ShowInfo();
            }
        }

        #region 赋值操作
        private void ShowInfo()
        {
            BLL.qqonline_config bll = new BLL.qqonline_config();
            Model.qqonline_config model = bll.loadConfig();

            if (model.status == 0)
            {
                cbStatus.Checked = true;
            }
            txtImgUrl.Text = model.code;
            if (!string.IsNullOrEmpty(model.code))
            {
                ImgDiv.Visible = true;
                ImgUrl.ImageUrl = model.code;
            }
            rblPosition.SelectedValue = model.position.ToString();
            txtRemark.Text = model.remark;
            hidPattern.Value = model.pattern;
            
            //遍历样式
            DataTable dt = new DataTable();
            dt.Columns.Add("lock", Type.GetType("System.Int32"));
            dt.Columns.Add("pattern", Type.GetType("System.String"));
            dt.Columns.Add("img_url", Type.GetType("System.String"));
            string curPath = Utils.GetMapPath(@"../skin/qqskin/");
            DirectoryInfo dirInfo = new DirectoryInfo(curPath);
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                string path = Path.Combine(curPath,dir.Name,"skin.png");
                if (File.Exists(path))
                {
                    DataRow dr = dt.NewRow();
                    dr["pattern"] = dir.Name;
                    dr["img_url"] = "../skin/qqskin/" + dir.Name + "/skin.png";
                    if (model.pattern == dir.Name)
                    {
                        dr["lock"] = 1;
                    }
                    else
                    {
                        dr["lock"] = 0;
                    }
                    dt.Rows.Add(dr);
                }
            }
            this.rptList1.DataSource = dt;
            this.rptList1.DataBind();
        }
        #endregion

        #region 保存操作
        /// <summary>
        /// 保存配置信息
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("plugin_qqonline_config", DTEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.qqonline_config bll = new BLL.qqonline_config();
            Model.qqonline_config model = bll.loadConfig();
            try
            {
                model.status = 1;
                if (cbStatus.Checked == true)
                {
                    model.status = 0;
                }
                model.code = txtImgUrl.Text.Trim();
                model.position = Utils.StrToInt(rblPosition.SelectedValue, 0);
                model.remark = txtRemark.Text.Trim();
                model.pattern = hidPattern.Value.Trim() ;

                bll.saveConifg(model);
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改QQ在线客服配置信息"); //记录日志
                JscriptMsg("修改QQ在线客服配置信息成功！", "config.aspx");
            }
            catch
            {
                JscriptMsg("文件写入失败，请检查文件夹权限！", "");
            }
        }
        #endregion
    }
}