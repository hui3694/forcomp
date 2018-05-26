using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using DTcms.Common;
using DTcms.Web.UI;

namespace DTcms.Web.Plugin.Forum.handler
{
    //------------------------------------------------------
    // 插件官方地址 www.dtcms-forum.net
    // 本插件开源，支持个人对插件源码修改及非盈利性平台使用
    // 如用于商业盈利性平台，需支付授权费,具体参见官网
    // 我们承接新项目开发或插件二次开发 QQ 271478027
    //------------------------------------------------------

    /// <summary>
    /// 文件上传处理页
    /// </summary>
    public class upload_ajax : IHttpHandler, IRequiresSessionState
    {
        DTcms.Model.siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig(); //系统配置信息
        //检查用户是否登录
        Model.Forum_UserExtended modelUser;

        int board_id = 0;
        int topic_id = 0;
        int post_id = 0;

        public void ProcessRequest(HttpContext context)
        {

            //取得处事类型
            string action = DTRequest.GetQueryString("action");

            board_id = DTRequest.GetQueryInt("board_id", 0);
            topic_id = DTRequest.GetQueryInt("topic_id", 0);
            post_id = DTRequest.GetQueryInt("post_id", 0);

            switch (action)
            {

                case "config": //后台百度编辑器配置文件
                    ConfigHandler(context);
                    break;

                case "admin_uploadimage": //图片上传
                    AdminUploadHandler(context, "image");
                    break;

                case "uploadimage": //前台附件上传
                    UploadHandler(context, "image");
                    break;
                case "editorimage": //编辑器上传
                    EditorHandler(context, "image");
                    break;

            }
        }

        #region 配置文件
        private void ConfigHandler(HttpContext context)
        {

            string savePath = siteConfig.webpath + siteConfig.filepath + (siteConfig.filesave > 1 ? "/{yyyy}{mm}/{dd}/" : "/{yyyy}{mm}{dd}/");

            JsonHelper.WriteJson(context,
                new
                {
                    imageActionName = "admin_uploadimage",  //上传图片配置项
                    imageFieldName = "upfile",
                    imageMaxSize = siteConfig.imgsize * 1024,
                    imageAllowFiles = AddDot(siteConfig.fileextension).Split(','),//siteConfig.imgextension.Split(','),
                    imageInsertAlign = "none",
                    imageUrlPrefix = "",
                    imagePathFormat = savePath,
                    scrawlActionName = "admin_uploadscrawl",  //涂鸦图片上传配置项
                    scrawlFieldName = "upfile",
                    scrawlPathFormat = savePath,
                    scrawlMaxSize = siteConfig.imgsize * 1024,
                    scrawlUrlPrefix = "",
                    scrawlInsertAlign = "none",
                    snapscreenActionName = "admin_uploadimage", //截图工具上传
                    snapscreenPathFormat = savePath,
                    snapscreenUrlPrefix = "",
                    snapscreenInsertAlign = "none",
                    catcherLocalDomain = new string[] { "127.0.0.1", "localhost", "img.baidu.com" },  //抓取远程图片配置
                    catcherActionName = "catchimage",
                    catcherFieldName = "source",
                    catcherPathFormat = savePath,
                    catcherUrlPrefix = "",
                    catcherMaxSize = siteConfig.imgsize * 1024,
                    catcherAllowFiles = new string[] { ".png", ".jpg", ".jpeg", ".gif", ".bmp" },
                    videoActionName = "admin_uploadvideo",  //上传视频配置
                    videoFieldName = "upfile",
                    videoPathFormat = savePath,
                    videoUrlPrefix = "",
                    videoMaxSize = siteConfig.videosize * 1024,
                    videoAllowFiles = AddDot(siteConfig.videoextension).Split(','),
                    fileActionName = "admin_uploadfile",  //上传文件配置
                    fileFieldName = "upfile",
                    filePathFormat = savePath,
                    fileUrlPrefix = "",
                    fileMaxSize = siteConfig.attachsize * 1024,
                    fileAllowFiles = AddDot(siteConfig.fileextension).Split(','),
                    imageManagerActionName = "admin_listimage",   //列出指定目录下的图片
                    imageManagerListPath = "/",
                    imageManagerListSize = 20,
                    imageManagerUrlPrefix = "",
                    imageManagerInsertAlign = "none",
                    imageManagerAllowFiles = new string[] { ".png", ".jpg", ".jpeg", ".gif", ".bmp" },
                    fileManagerActionName = "admin_listfile",  //列出指定目录下的文件
                    fileManagerListPath = "/",
                    fileManagerUrlPrefix = "",
                    fileManagerListSize = 20,
                    fileManagerAllowFiles = Utils.MergerArray(AddDot(siteConfig.fileextension).Split(','), AddDot(siteConfig.videoextension).Split(','))
                });
        }


        #endregion

        #region 后台编辑器文件上传
        private void AdminUploadHandler(HttpContext context, string name)
        {

            //检查用户是否登录
            DTcms.Model.manager modelAdmin = new DTcms.Web.UI.ManagePage().GetAdminInfo();
            if (modelAdmin == null)
            {
                JsonHelper.WriteJson(context, new
                {
                    state = DTEnums.ResultState.NetworkError,
                    error = "对不起，用户尚未登录或已超时！"

                });

                return;
            }

            string fieldName = "upfile";
            string[] allowExtensions = null;
            int sizeLimit = 0;
            switch (name)
            {
                case "image":
                    sizeLimit = siteConfig.imgsize;
                    allowExtensions = siteConfig.fileextension.Split(',');//siteConfig.imgextension.Split(',');
                    break;
                case "scrawl":
                    sizeLimit = 2048000;
                    allowExtensions = new string[] { ".png" };
                    break;
                case "video":
                    sizeLimit = siteConfig.videosize;
                    allowExtensions = siteConfig.videoextension.Split(',');
                    break;
                case "file":
                    sizeLimit = siteConfig.attachsize;
                    allowExtensions = siteConfig.fileextension.Split(',');
                    break;
                default:
                    JsonHelper.WriteJson(context, new
                    {
                        status = "参数传输错误！"
                    });
                    return;
            }
            if (sizeLimit <= 0 || allowExtensions.Length == 0)
            {
                JsonHelper.WriteJson(context, new
                {
                    status = "参数传输错误！"
                });
                return;
            }
            if (name == "scrawl")
            {
                string uploadFileName = Utils.GetRamCode() + ".png";
                byte[] uploadFileBytes = Convert.FromBase64String(context.Request[fieldName]);

                string Url = new UpLoad().GetUpLoadPath() + uploadFileName;
                string localPath = Utils.GetMapPath(Url);
                string ErrorMessage = string.Empty;
                DTEnums.ResultState State = DTEnums.ResultState.Success;
                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(localPath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(localPath));
                    }
                    File.WriteAllBytes(localPath, uploadFileBytes);
                    State = DTEnums.ResultState.Success;
                }
                catch (Exception e)
                {
                    State = DTEnums.ResultState.FileAccessError;
                    ErrorMessage = e.Message;
                }
                JsonHelper.WriteJson(context, new
                {
                    state = Utils.GetStateString(State),
                    url = Url,
                    title = uploadFileName,
                    original = uploadFileName,
                    error = ErrorMessage
                });
            }
            else
            {
                context.Response.ContentType = "text/plain";
                HttpPostedFile _upfile = context.Request.Files[fieldName];
                Model.upLoad model = new UpLoad().fileSaveAs(_upfile, allowExtensions, sizeLimit, false, false, 0, 0);

                if (model.status > 0)
                {

                    //{"state":"SUCCESS","url":"/upload/201612/22/201612221435403316.jpg","title":"未命名-1.jpg","original":"未命名-1.jpg","error":""}

                    JsonHelper.WriteJson(context, new
                    {
                        state = Utils.GetStateString(DTEnums.ResultState.Success),
                        url = model.path,
                        title = model.name,
                        original = model.name,
                        error = ""

                    });
                }
                else if (model.status == -1)
                {
                    JsonHelper.WriteJson(context, new
                    {
                        state = DTEnums.ResultState.SizeLimitExceed,
                        error = Utils.GetStateString(DTEnums.ResultState.SizeLimitExceed)

                    });
                }
                else if (model.status == -2)
                {
                    JsonHelper.WriteJson(context, new
                    {
                        state = DTEnums.ResultState.TypeNotAllow,
                        error = Utils.GetStateString(DTEnums.ResultState.TypeNotAllow)

                    });
                }
                else if (model.status == -3)
                {
                    JsonHelper.WriteJson(context, new
                    {
                        state = DTEnums.ResultState.NetworkError,
                        error = Utils.GetStateString(DTEnums.ResultState.NetworkError)

                    });
                }
            }
        }
        #endregion

        #region 文件上传
        private void UploadHandler(HttpContext context, string name)
        {

            //检查用户是否登录


            modelUser = new Page.ForumPage().GetOnlineUser();

            if (modelUser == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }


            if (!BLL.Forum_BoardPermission.CheckPermission(board_id + "|" + modelUser.GroupId, "UploadAttachment"))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"你还没有上传附件的权限呢！\"}");
                return;
            }


            string fieldName = "file";
            string[] allowExtensions = null;
            int sizeLimit = 0;
            switch (name)
            {
                case "image":
                    sizeLimit = siteConfig.imgsize;

                    allowExtensions = siteConfig.fileextension.Split(',');//imgextension
                    break;
                case "scrawl":
                    sizeLimit = 2048000;
                    allowExtensions = new string[] { ".png" };
                    break;
                case "video":
                    sizeLimit = siteConfig.videosize;
                    allowExtensions = siteConfig.videoextension.Split(',');
                    break;
                case "file":
                    sizeLimit = siteConfig.attachsize;
                    allowExtensions = siteConfig.fileextension.Split(',');
                    break;
                default:
                    JsonHelper.WriteJson(context, new
                     {
                         status = "参数传输错误！"
                     });
                    return;
            }
            if (sizeLimit <= 0 || allowExtensions.Length == 0)
            {
                JsonHelper.WriteJson(context, new
                 {
                     status = "参数传输错误！"
                 });
                return;
            }
            if (name == "scrawl")
            {
                string uploadFileName = Utils.GetRamCode() + ".png";
                byte[] uploadFileBytes = Convert.FromBase64String(context.Request[fieldName]);

                string Url = new UpLoad().GetUpLoadPath() + uploadFileName;
                string localPath = Utils.GetMapPath(Url);
                string ErrorMessage = string.Empty;
                DTEnums.ResultState State = DTEnums.ResultState.Success;
                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(localPath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(localPath));
                    }
                    File.WriteAllBytes(localPath, uploadFileBytes);
                    State = DTEnums.ResultState.Success;
                }
                catch (Exception e)
                {
                    State = DTEnums.ResultState.FileAccessError;
                    ErrorMessage = e.Message;
                }
                JsonHelper.WriteJson(context, new
                 {
                     state = Utils.GetStateString(State),
                     url = Url,
                     title = uploadFileName,
                     original = uploadFileName,
                     error = ErrorMessage
                 });
            }
            else
            {
                context.Response.ContentType = "text/plain";
                HttpPostedFile _upfile = context.Request.Files[fieldName];
                Model.upLoad model = new UpLoad().fileSaveAs(_upfile, allowExtensions, sizeLimit, false, false, 0, 0);

                if (model.status > 0)
                {
                    //{"aid":374,"name":"27.gif","filename":"2016/11/02/4225885467939.gif","isimage":true}

                    Model.Forum_Attachment attModel = new Model.Forum_Attachment();

                    attModel.IsImage = 1;
                    attModel.Name = model.name;
                    attModel.BoardId = board_id;
                    attModel.TopicId = topic_id;
                    attModel.PostId = post_id;
                    attModel.FileName = model.path;
                    attModel.FileSize = model.size / 1024;//保存KB
                    attModel.FileType = model.ext.Replace(".", "");
                    attModel.UserId = modelUser.UserId;

                    attModel.Id = new BLL.Forum_Attachment().Add(attModel);

                    JsonHelper.WriteJson(context, new
                     {
                         aid = attModel.Id,
                         name = attModel.Name,
                         filename = attModel.FileName,
                         isimage = (attModel.IsImage == 1 ? true : false)

                     });
                }
                else
                {
                    JsonHelper.WriteJson(context, new
                     {
                         status = model.msg
                     });
                }
            }
        }
        #endregion

        #region 编辑器上传
        private void EditorHandler(HttpContext context, string name)
        {
            //检查用户是否登录
            modelUser = new Page.ForumPage().GetOnlineUser();
            if (modelUser == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }

            string fieldName = "upfile";
            string[] allowExtensions = null;
            int sizeLimit = 0;
            switch (name)
            {
                case "image":
                    sizeLimit = siteConfig.imgsize;
                    allowExtensions = siteConfig.fileextension.Split(',');
                    break;
                case "scrawl":
                    sizeLimit = 2048000;
                    allowExtensions = new string[] { ".png" };
                    break;
                case "video":
                    sizeLimit = siteConfig.videosize;
                    allowExtensions = siteConfig.videoextension.Split(',');
                    break;
                case "file":
                    sizeLimit = siteConfig.attachsize;
                    allowExtensions = siteConfig.fileextension.Split(',');
                    break;
                default:
                    JsonHelper.WriteJson(context, new
                    {
                        status = "参数传输错误！"
                    });
                    return;
            }
            if (sizeLimit <= 0 || allowExtensions.Length == 0)
            {
                JsonHelper.WriteJson(context, new
                {
                    status = "参数传输错误！"
                });
                return;
            }
            if (name == "scrawl")
            {
                string uploadFileName = Utils.GetRamCode() + ".png";
                byte[] uploadFileBytes = Convert.FromBase64String(context.Request[fieldName]);

                string Url = new UpLoad().GetUpLoadPath() + uploadFileName;
                string localPath = Utils.GetMapPath(Url);
                string ErrorMessage = string.Empty;
                DTEnums.ResultState State = DTEnums.ResultState.Success;
                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(localPath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(localPath));
                    }
                    File.WriteAllBytes(localPath, uploadFileBytes);
                    State = DTEnums.ResultState.Success;
                }
                catch (Exception e)
                {
                    State = DTEnums.ResultState.FileAccessError;
                    ErrorMessage = e.Message;
                }
                JsonHelper.WriteJson(context, new
                {
                    state = Utils.GetStateString(State),
                    url = Url,
                    title = uploadFileName,
                    original = uploadFileName,
                    error = ErrorMessage
                });
            }
            else
            {
                context.Response.ContentType = "text/plain";
                HttpPostedFile _upfile = context.Request.Files[fieldName];
                Model.upLoad model = new UpLoad().fileSaveAs(_upfile, allowExtensions, sizeLimit, false, false, 0, 0);

                if (model.status > 0)
                {
                    //{"aid":374,"name":"27.gif","filename":"2016/11/02/4225885467939.gif","isimage":true}

                    Model.Forum_Attachment attModel = new Model.Forum_Attachment();

                    attModel.IsImage = 1;
                    attModel.Name = model.name;
                    attModel.BoardId = board_id;
                    attModel.TopicId = topic_id;
                    attModel.PostId = post_id;
                    attModel.FileName = model.path;
                    attModel.FileSize = model.size / 1024; ;
                    attModel.FileType = model.ext.Replace(".", "");
                    attModel.UserId = modelUser.UserId;

                    attModel.Id = new BLL.Forum_Attachment().Add(attModel);


                    string callback = context.Request["callback"];
                    string editorId = context.Request["editorid"];

                    JsonHelper.WriteJson(context, new
                    {
                        state = "SUCCESS",
                        type = "." + model.ext,
                        size = model.size / 1024,
                        url = model.path,
                        name = model.name,
                        originalName = model.name

                    });

                }
                else
                {
                    JsonHelper.WriteJson(context, new
                    {
                        status = model.msg
                    });
                }
            }
        }
        #endregion

        #region 文件列表
        /// <summary>
        /// 读取文件列表
        /// </summary>
        /// <param name="listPath"></param>
        /// <param name="allow">类型 0图片，1文件</param>
        private void ListFileManager(HttpContext context, string listPath, int allow)
        {
            int Start = DTRequest.GetQueryIntValue("start", 0);
            int Size = DTRequest.GetQueryIntValue("size", 20);
            int Total = 0;
            DTEnums.ResultState State = DTEnums.ResultState.Success;
            String PathToList = siteConfig.webpath + siteConfig.filepath;
            String[] FileList = null;
            String[] SearchExtensions;
            if (allow > 0)
            {
                //文件
                SearchExtensions = Utils.MergerArray(siteConfig.fileextension.Split(','), siteConfig.videoextension.Split(','));
            }
            else
            {
                //图片
                SearchExtensions = new string[] { ".png", ".jpg", ".jpeg", ".gif", ".bmp" };
            }
            var buildingList = new List<String>();
            try
            {
                var localPath = Utils.GetMapPath(PathToList);
                buildingList.AddRange(Directory.GetFiles(localPath, "*", SearchOption.AllDirectories)
                    .Where(x => SearchExtensions.Contains(Path.GetExtension(x).ToLower()))
                    .Select(x => PathToList + x.Substring(localPath.Length).Replace("\\", "/")));
                Total = buildingList.Count;
                FileList = buildingList.OrderBy(x => x).Skip(Start).Take(Size).ToArray();
            }
            catch (UnauthorizedAccessException)
            {
                State = DTEnums.ResultState.AuthorizError;
            }
            catch (DirectoryNotFoundException)
            {
                State = DTEnums.ResultState.PathNotFound;
            }
            catch (IOException)
            {
                State = DTEnums.ResultState.IOError;
            }
            finally
            {
                JsonHelper.WriteJson(context, new
                {
                    state = Utils.GetStateString(State),
                    list = FileList == null ? null : FileList.Select(x => new { url = x }),
                    start = Start,
                    size = Size,
                    total = Total
                });
            }
        }
        #endregion

        //官方免费开源版需要，辅助加点
        public string AddDot(string str)
        {
            str = "." + str.Replace(",", ",.");

            return str;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}