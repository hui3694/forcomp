using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using DTcms.Search;

namespace DTcms.Web.admin.lucene
{
    public partial class pangu : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("lucene_pangu", DTEnums.ActionEnum.View.ToString()); //检查权限

                //绑定数据
                TreeBind();
            }
        }

        /// <summary>
        /// 输出词性
        /// </summary>
        private void TreeBind()
        {
            int pos = 0x40000000;
            for (int i = 0; i < 31; i++)
            {
                if (pos == 1)
                {
                    pos = 0;
                }
                PosCtrl.Items.Add(new ListItem(Utility.GetChsPos(pos), pos.ToString()));
                pos >>= 1;
            }
        }
    }
}