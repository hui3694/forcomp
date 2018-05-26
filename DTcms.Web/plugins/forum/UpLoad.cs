using DTcms.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DTcms.Web.Plugin.Forum
{
    public class UpLoad : DTcms.Web.UI.UpLoad
    {


        /// <summary>
        /// 检查是否为合法的上传文件
        /// </summary>
        /// <param name="fileExtension">扩展名</param>
        /// <param name="allowExtensions">允许上传的扩展名</param>
        /// <returns></returns>
        public bool CheckFileExt(string fileExtension, string[] allowExtensions)
        {
            fileExtension = fileExtension.ToLower();
            //检查危险文件
            string[] excExt = { ".vbs", ".asp", ".aspx", ".ashx", ".asa", ".asmx", ".asax", ".php", ".jsp", ".htm", ".html" };
            if (excExt.Select(x => x.ToLower()).Contains(fileExtension))
            {
                return false;
            }
            //检查合法文件
            string[] allowExt = (this.siteConfig.fileextension + "," + this.siteConfig.videoextension + "," + this.siteConfig.fileextension).Split(',');//imgextension
            if (allowExtensions.Select(x => x.ToLower()).Contains(fileExtension))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查文件大小
        /// </summary>
        /// <param name="size">文件大小(B)</param>
        /// <param name="sizeLimit">允许上传大小</param>
        /// <returns></returns>
        private bool CheckFileSize(int size, int sizeLimit)
        {
            return size < sizeLimit * 1024;
        }

        /// <summary>
        /// 文件上传方法
        /// </summary>
        /// <param name="postedFile">文件流</param>
        /// <param name="allowExtensions">文件类型</param>
        /// <param name="maxSize">允许文件最大尺寸</param>
        /// <param name="isThumbnail">是否生成缩略图</param>
        /// <param name="isWater">是否打水印</param>
        /// <returns></returns>
        public Model.upLoad fileSaveAs(HttpPostedFile postedFile, string[] allowExtensions, int maxSize, bool isThumbnail, bool isWater, int width, int height)
        {
            Model.upLoad model = new Model.upLoad();
            try
            {
                model.ext = Utils.GetFileExt(postedFile.FileName); //文件扩展名，不包含“.”
                model.size = postedFile.ContentLength; //获得文件大小，以字节为单位
                model.name = Path.GetFileName(postedFile.FileName);
                string newFileName = Utils.GetRamCode() + "." + model.ext; //随机生成新的文件名
                string newThumbnailFileName = "thumb_" + newFileName; //随机生成缩略图文件名
                string upLoadPath = GetUpLoadPath(); //上传目录相对路径
                string fullUpLoadPath = Utils.GetMapPath(upLoadPath); //上传目录的物理路径

                model.path = upLoadPath + newFileName; //上传后的路径
                model.thumb = upLoadPath + newThumbnailFileName; //上传后的缩略图路径

                //检查文件扩展名是否合法
                if (CheckFileExt(model.ext, allowExtensions))
                {
                    //检查文件大小是否合法
                    if (CheckFileSize(model.size, maxSize))
                    {
                        //检查上传的物理路径是否存在，不存在则创建
                        if (!Directory.Exists(fullUpLoadPath))
                        {
                            Directory.CreateDirectory(fullUpLoadPath);
                        }
                        //保存文件
                        postedFile.SaveAs(fullUpLoadPath + newFileName);
                        //如果是图片，检查图片是否超出最大尺寸，是则裁剪
                        if (IsImage(model.ext) && (this.siteConfig.imgmaxheight > 0 || this.siteConfig.imgmaxwidth > 0))
                        {
                            Thumbnail.MakeThumbnailImage(fullUpLoadPath + newFileName, fullUpLoadPath + newFileName, this.siteConfig.imgmaxwidth, this.siteConfig.imgmaxheight);
                        }
                        //如果是图片，检查是否需要生成缩略图，是则生成
                        if (isThumbnail && IsImage(model.ext) && this.siteConfig.thumbnailwidth > 0 && this.siteConfig.thumbnailheight > 0)
                        {
                            Thumbnail.MakeThumbnailImage(fullUpLoadPath + newFileName, fullUpLoadPath + newThumbnailFileName, width, height, "HW");//this.siteConfig.thumbnailmode
                        }
                        else
                        {
                            model.thumb = "";
                        }
                        //如果是图片，检查是否需要打水印
                        if (isWater && IsWaterMark(model.ext))
                        {
                            switch (this.siteConfig.watermarktype)
                            {
                                case 1:
                                    WaterMark.AddImageSignText(model.path, model.path,
                                        this.siteConfig.watermarktext, this.siteConfig.watermarkposition,
                                        this.siteConfig.watermarkimgquality, this.siteConfig.watermarkfont, this.siteConfig.watermarkfontsize);
                                    break;
                                case 2:
                                    WaterMark.AddImageSignPic(model.path, model.path,
                                        this.siteConfig.watermarkpic, this.siteConfig.watermarkposition,
                                        this.siteConfig.watermarkimgquality, this.siteConfig.watermarktransparency);
                                    break;
                            }
                        }
                        model.status = 1;
                        model.msg = "上传文件成功！";
                    }
                    else
                    {
                        model.status = -1;
                        model.msg = "文件超过限制的大小！";
                    }
                }
                else
                {
                    model.status = -2;
                    model.msg = "不允许上传" + model.ext + "类型的文件！";
                }
            }
            catch (Exception ex)
            {
                model.status = -3;
                model.msg = ex.Message;
                //LogHelper.WriteLog(ex.ToString());
            }
            return model;
        }

    }
}