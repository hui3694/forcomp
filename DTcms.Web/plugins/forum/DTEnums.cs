using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTcms.Web.Plugin.Forum
{
    public class DTEnums : DTcms.Common.DTEnums
    {
        /// <summary>
        /// 编辑器状态
        /// </summary>
        public enum ResultState
        {
            /// <summary>
            /// 成功
            /// </summary>
            Success,
            /// <summary>
            /// 参数不正确
            /// </summary>
            InvalidParam,
            /// <summary>
            /// 路径不存在
            /// </summary>
            AuthorizError,
            /// <summary>
            /// 文件系统权限不足
            /// </summary>
            IOError,
            /// <summary>
            /// 文件系统读取错误
            /// </summary>
            PathNotFound,
            /// <summary>
            /// 文件访问出错，请检查写入权限
            /// </summary>
            FileAccessError,
            /// <summary>
            /// 文件大小超出服务器限制
            /// </summary>
            SizeLimitExceed,
            /// <summary>
            /// 不允许的文件格式
            /// </summary>
            TypeNotAllow,
            /// <summary>
            /// 网络错误
            /// </summary>
            NetworkError
        }
    }
}