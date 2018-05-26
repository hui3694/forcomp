using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTcms.Web.Plugin.Forum
{
    public class Utils :DTcms.Common.Utils
    {
        #region 编辑器状态
        /// <summary>
        /// 编辑器状态
        /// </summary>
        /// <param name="State">标识</param>
        /// <returns></returns>
        public static string GetStateString(DTEnums.ResultState State)
        {
            switch (State)
            {
                case DTEnums.ResultState.Success:
                    return "SUCCESS";
                case DTEnums.ResultState.InvalidParam:
                    return "参数不正确";
                case DTEnums.ResultState.PathNotFound:
                    return "路径不存在";
                case DTEnums.ResultState.AuthorizError:
                    return "文件系统权限不足";
                case DTEnums.ResultState.IOError:
                    return "文件系统读取错误";
                case DTEnums.ResultState.FileAccessError:
                    return "文件访问出错，请检查写入权限";
                case DTEnums.ResultState.SizeLimitExceed:
                    return "文件大小超出服务器限制";
                case DTEnums.ResultState.TypeNotAllow:
                    return "不允许的文件格式";
                case DTEnums.ResultState.NetworkError:
                    return "网络错误";
            }
            return "未知错误";
        }
        #endregion

        #region 合并数组
        /// 合并数组
        /// </summary>
        /// <param name="First">第一个数组</param>
        /// <param name="Second">第二个数组</param>
        /// <returns>合并后的数组(第一个数组+第二个数组，长度为两个数组的长度)</returns>
        public static string[] MergerArray(string[] First, string[] Second)
        {
            string[] result = new string[First.Length + Second.Length];
            First.CopyTo(result, 0);
            Second.CopyTo(result, First.Length);
            return result;
        }
        #endregion
    }
}