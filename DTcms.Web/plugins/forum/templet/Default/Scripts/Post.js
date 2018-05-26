
var form_submit = false;
function nsubmit() {
    if (form_submit)
        return true;
    alert("正在装载页面，请稍后...");
    return false;
}
function allow_submit() {
    form_submit = true;
}

var attachments = {
    add: function (key, obj) {
        this[key] = obj;
    },
    get: function (key) {
        return this[key];
    },
    contains: function (key) { return this.get(key) == null ? false : true },
    remove: function (key) { delete this[key] }
};

$(document).ready(function () {

    var isPost = false;//当页是否为高级编辑页

    if (window.location.href.indexOf("forum/post") != -1) {
        isPost = true;
    }

    //------------------------

    $(".manage_action").click(function () {
        var url = $(this).attr("href");
        var formObj = $("form[id='moderate']")[0];
        formObj.action = url;
        formObj.submit();
        return false;
    });

    ManageTopic();

    function ManageTopic() {
        var len = $("[name='rids']:checkbox:enabled:checked").length;
        if (len > 0) {
            $("#manageTopicCount").html(len);
            $("#manageTopic").show();
            $("#manageTopic").css("left", $("#manageTopic").parent().offset().left + ($("#manageTopic").parent().width() - $("#manageTopic").outerWidth(false)) / 2 + "px");
        }
        else {
            $("#manageTopic").hide();
        }
    }

    $("[name='rids']:checkbox:enabled").click(function () {
        if (!$(this)[0].checked)
            $(".select_all").checked(false);
        else if ($("[name='rids']:checkbox:checked").length == $("[name='rids']:checkbox:enabled").length)
            $(".select_all").checked(true);

        ManageTopic();
    });

    $(".select_all_cancel").click(function () {
        $(".select_all").checked(false);
        $("[name='rids']:checkbox:checked").checked(false);
        $("#manageTopic").hide();
    });

    $(".select_all").change(function () {
        var selected = $(this)[0].checked;
        $(".select_all").checked(selected);
        $("[name='rids']:checkbox:enabled").checked(selected);
        ManageTopic();
    });

    //人物信息
    GetUserInfo();

    function GetUserInfo() {

        var userIds = "0";

        $(".user_info").each(function () {
            userIds += "," + $(this).attr("data-userId");
        });

        $.ajax({

            success: function (responseText, statusText) {
                if (responseText.error) {
                    easyDialog.open({ container: { header: '提示', content: responseText.description, noFn: true } });
                    return;
                }
                else {

                    for (var i = 0; i < responseText.length; i++) {

                        $(".user_info").each(function () {

                            if ($(this).attr("data-userId") == responseText[i].UserId) {

                                var _html = $(this).html();

                                _html = _html.replace(new RegExp("<!--UserId-->", "g"), responseText[i].UserId);
                                _html = _html.replace(new RegExp("<!--Nickname-->", "g"), responseText[i].Nickname);
                                _html = _html.replace(new RegExp("<!--LoginTime-->", "g"), responseText[i].LoginTime);
                                _html = _html.replace(new RegExp("<!--LoginIp-->", "g"), responseText[i].LoginIp);
                                _html = _html.replace(new RegExp("<!--RegTime-->", "g"), responseText[i].RegTime);
                                _html = _html.replace(new RegExp("<!--Hometown-->", "g"), responseText[i].Hometown);
                                _html = _html.replace(new RegExp("<!--RegIp-->", "g"), responseText[i].RegIp);
                                _html = _html.replace(new RegExp("<!--Nonlocal-->", "g"), responseText[i].Nonlocal);
                                _html = _html.replace(new RegExp("<!--Credit-->", "g"), responseText[i].Credit);
                                _html = _html.replace(new RegExp("<!--Gender-->", "g"), ChangeSex(responseText[i].Gender));
                                _html = _html.replace(new RegExp("<!--PostDigestCount-->", "g"), responseText[i].PostDigestCount);
                                _html = _html.replace(new RegExp("<!--TopicCount-->", "g"), responseText[i].TopicCount);
                                _html = _html.replace(new RegExp("<!--PostCount-->", "g"), responseText[i].PostCount);
                                _html = _html.replace(new RegExp("<!--Medal-->", "g"), responseText[i].Medal);

                                $(this).html(_html);
                            }
                        });


                        $(".signatures").each(function () {

                            if ($(this).attr("data-userId") == responseText[i].UserId) {
                                $(this).html(responseText[i].Signature);
                            }
                        });
                    }

                    $(".xz").each(function () {

                        var vals = $(this).attr("data-medal");

                        try {

                            if (vals != "") {

                                var words = vals.split(',');

                                var _html = "<ul>";

                                for (var i = 0; i < words.length; i++) {

                                    if (words[i] != "0") {

                                        var model = $("#Medal" + words[i]);
                                        var Name = model.attr("data-name");
                                        var Description = model.attr("data-description");
                                        var Url = model.attr("data-url");
                                        var Available = model.attr("data-available");
                                        var Image = model.val();

                                        if (Available == "1") {
                                            _html += "<li><img src='" + Image + "' alt='" + Name + "' title='" + Name + "' /></li>";
                                        }
                                    }
                                }

                                _html += "</ul>";

                                $(this).html(_html);

                            }

                        } catch (e) {

                        }

                    });

                    PageJs();
                }

            },
            error: function () {
                easyDialog.open({ container: { header: '提示', content: "服务器通讯失败", noFn: true } });
            },
            complete: function () {
            },
            url: "/plugins/forum/handler/submit_ajax.ashx?action=users&user_ids=" + userIds,
            type: 'post',
            dataType: 'json'
        });

    }

    function ChangeSex(_sex) {

        if (_sex == -1) {
            return "保密";
        }
        else if (_sex == 1) {
            return "男";
        }
        else if (_sex == 0) {
            return "女";
        }
    }

    //------------------------

    //实例化编辑器
    var editor = null;

    if (!isPost) {
        editor = UM.getEditor('postEditor', {
            toolbar: [
                    ' undo redo | emotion italic underline strikethrough | forecolor backcolor | removeformat |',
                    ' horizontal | selectall bold | fontfamily fontsize',
                    'link unlink | fullscreen'
            ]
        });
    }
    else {

        editor = UM.getEditor('postEditor', {
            toolbar: [
                    ' undo redo | emotion italic underline strikethrough | image video | forecolor backcolor | removeformat |',
                    ' horizontal | selectall bold | fontfamily fontsize',
                    'link unlink | fullscreen'
            ]
        });

    }

    $(".editor_loading").remove();

    function updateseccode() {
        var rand = Math.random();
        $('#VC').val('');
        $('#vcimg').attr("src", "/plugins/forum/handler/verify_code.ashx?key=topic&_=" + rand);
    }
    updateseccode();
    $('#Username').focus();

    $('#vcimg').click(function () {
        updateseccode();
        $('#VC').focus();
    });
    $('#vcimgc').click(function () {
        updateseccode();
        $('#VC').focus();
        return false;
    });


    if (isPost) {

        var add_attachment = function (options) {

            //options:aid,isimage,name,description,cost
            var att = { aid: options.aid, isimage: options.isimage, turl: "/plugins/forum/handler/attachment.ashx?site=main&action=down&aid=" + options.aid + "&thumb=1", description: options.description, name: options.name, cost: options.cost };
            attachments.add(att.aid, att);

            var template_data = $.extend({}, att, { turl: "/plugins/forum/handler/attachment.ashx?site=main&action=down&aid=" + options.aid + "&thumb=2" });
            var template = $("#attathmentRowTemplate").tmpl(template_data).appendTo("#attachment");

            (function (el, n) {
                $("[data-pop-id]", el).ExPanel();

                $("a[data-attachment-act=\"remove\"]", el).click(function () {
                    $(this).parents("tr").remove();


                    //删除				

                    $.get("/plugins/forum/handler/attachment.ashx?site=main&action=delete&aid=" + n.aid);

                    attachments.remove(n);

                    return false;
                });
                //$("a[data-attachment-act=\"insert\"]", el).click(function () {

                //    //无需过于复杂
                //    //editor.execCommand('insertHtml', "<img contenteditable=\"false\" src=\"" + n.turl + "\" aid=\"" + n.aid + "\" title=\"\" />" + n.name);

                //    editor.execCommand('insertHtml', n.name);

                //    if (false) {

                //        if (editor.viewMode == "wysiwyg") {
                //            //var att = attachments.get(aid);
                //            //if (!att)
                //            //    return;
                //            if (n.isimage) {
                //                editor.insertHtml("<img contenteditable=\"false\" src=\"" + n.turl + "\" aid=\"" + n.aid + "\" title=\"\" />");
                //            }
                //            else {
                //                editor.insertHtml("<span class=\"attachment\" contenteditable=\"false\" aid=\"" + n.aid + "\" />" + n.name + "</span>");
                //            }
                //        }
                //        else {
                //            editor.insertHtml("[attach]" + n.aid + "[/attach]");
                //        }
                //    }

                //    return false;
                //});
            })(template, att);
        };

        var urlVal = "action=uploadimage&board_id=" + $("#board_id").val() + "&topic_id=" + $("#topic_id").val() + "&post_id=" + $("#post_id").val();

        set_attachment(add_attachment);

        var settings = {
            file_post_name: "file",
            upload_url: "/plugins/forum/handler/upload_ajax.ashx?" + urlVal,
            flash_url: "/plugins/forum/templet/Default/scripts/jquery.swfupload/flash/swfupload.swf",
            post_params: { "upload_sign": "Fr8Yw9Inb7dqIhPTBPxSmH12X2gtMOcJgrggqaXl/rw=" },
            file_types: "*.jpg;*.png;*.gif;*.zip;*.rar",
            file_types_description: "Allowed Files",
            file_size_limit: 0,
            file_upload_limit: 0,
            file_queue_limit: 0,

            button_image_url: "/plugins/forum/templet/Default/images/upload_button.png",
            button_width: "99",
            button_height: "25",
            button_placeholder_id: "spanSWFUploadButton",
            button_cursor: SWFUpload.CURSOR.HAND,
            button_action: SWFUpload.BUTTON_ACTION.SELECT_FILES,
            button_window_mode: SWFUpload.WINDOW_MODE.TRANSPARENT,

            minimum_flash_version: "9.0.28",
            swfupload_pre_load_handler: function () { },
            swfupload_load_failed_handler: function () {
                var bt = $("#spanSWFUploadButton");
                bt.empty();
                bt.append("您当前所使用的浏览器，无法进行附件上传。");
            },

            swfupload_loaded_handler: function () { },
            file_dialog_start_handler: function () { },
            file_dialog_complete_handler: function (numFilesSelected, numFilesQueued) {
                if (numFilesSelected <= 0) return;
                this.startUpload();
            },
            file_queued_handler: function (file) {
                var self = this;

                var template =
                "<div class=\"attachment_item\" id=\"{id}\">" +
                "<div class=\"attachment_file\">{file.name}</div>" +
                "<div class=\"attachment_action\">" +
                    "<div class=\"attachment_cancel\" />" +
                "</div>" +
                "<div class=\"progress\"><div class=\"progress_bar\"></div></div>" +
                "</div>";
                template = template.replace("{id}", file.id);
                template = template.replace("{file.name}", file.name);

                $("#attachment_queue").append(template);

                var item = $("#" + file.id);
                var cancel = $(".attachment_cancel", item);
                cancel.click(function () {
                    self.cancelUpload(file.id);
                });
            },
            upload_start_handler: function (file) {
            },
            upload_progress_handler: function (file, bytesLoaded, bytesTotal) {
                var percent = Math.ceil((bytesLoaded / bytesTotal) * 100);
                var info = $("#" + file.id + " .progress_bar");
                info.width(percent + "%");
            },
            upload_success_handler: function (file, serverData) {
                $("#" + file.id).remove();
                var v = JSON.parse(serverData);
                if (v.error) {
                    alert(v.description);
                    return;
                }
                add_attachment({ aid: v.aid, isimage: v.isimage, name: file.name, description: "", cost: "" });
            },
            upload_complete_handler: function (file) { },
            queue_complete_handler: function (numFilesUploaded) { },
            upload_error_handler: function (file, errorCode, message) {
                $("#" + file.id).remove();

                switch (errorCode) {
                    case SWFUpload.UPLOAD_ERROR.HTTP_ERROR:
                        alert("上传错误:" + message);
                        break;
                    case SWFUpload.UPLOAD_ERROR.UPLOAD_FAILED:
                        alert("上传失败.");
                        break;
                    case SWFUpload.UPLOAD_ERROR.IO_ERROR:
                        alert("服务器(IO)错误");
                        break;
                    case SWFUpload.UPLOAD_ERROR.SECURITY_ERROR:
                        alert("安全信息错误");
                        break;
                    case SWFUpload.UPLOAD_ERROR.UPLOAD_LIMIT_EXCEEDED:
                        alert("超出上传限制.");
                        break;
                    case SWFUpload.UPLOAD_ERROR.FILE_VALIDATION_FAILED:
                        alert("验证失败.");
                        break;
                    case SWFUpload.UPLOAD_ERROR.FILE_CANCELLED:
                        //取消
                        break;
                    case SWFUpload.UPLOAD_ERROR.UPLOAD_STOPPED:
                        alert("上传已经停止");
                        break;
                    default:
                        alert("未知错误:" + errorCode);
                        break;
                }
            },
            file_queue_error_handler: function (file, errorCode, message) {
                switch (errorCode) {
                    case SWFUpload.QUEUE_ERROR.QUEUE_LIMIT_EXCEEDED:
                        alert("同时进行上传的文件不能过多.");
                        brea;
                    case SWFUpload.QUEUE_ERROR.FILE_EXCEEDS_SIZE_LIMIT:
                        alert("文件过大.");
                        break;
                    case SWFUpload.QUEUE_ERROR.ZERO_BYTE_FILE:
                        alert("不能上传 0 字节文件.");
                        break;
                    case SWFUpload.QUEUE_ERROR.INVALID_FILETYPE:
                        alert("不支持的文件类型.");
                        break;
                    default:
                        alert("未知错误");
                        break;
                }
            },
            debug_handler: function () { }
        };
        var swfu = new SWFUpload(settings);

    }

    //提交
    $("#post").ajaxForm({
        beforeSerialize: function ($form, options) {

            $("#textarea_message").val(editor.getContent());
        },
        beforeSubmit: function (formData, jqForm, options) {

            if (isPost) {

                if (swfu.testExternalInterface() && swfu.getStats().files_queued > 0) {
                    alert("附件正在上传中...");
                    return false;
                }
            }

            easyDialog.open({ container: { content: '正在提交。。。' } });
            return true;
        },
        success: function (responseText, statusText) {

            if (!responseText.error) {

                //top.location.href = responseText.turl;
                window.top.location.replace(responseText.turl);

                return;
            }
            easyDialog.open({ container: { header: '提示', content: responseText.description, noFn: true } });

        },
        error: function () {
            easyDialog.open({ container: { header: '提示', content: "服务器通讯失败", noFn: true } });
        },
        complete: function () {
        },
        url: "/plugins/forum/handler/submit_ajax.ashx?action=" + $("#action").val(),
        type: 'post',
        dataType: 'json'
    });

    allow_submit();


    //--原本写在页面上-------

    function PageJs() {

        //$(".post_main img").lazyload();

        $('.UserInfoPanelEx').UserInfoPanel();

        $(".mypop").ExPanel();



        $('.att').hover(function () {
            var $this = $(this);

            var cY =
            (
                document.documentElement.scrollTop
                +
                $(this).position().top
                +
                $(this).outerHeight(true)
                +
                $this.find('.post_attachs').outerHeight(true)
                >
                document.documentElement.scrollHeight
            )
            ?
            $(this).position().top - $this.find('.post_attachs').outerHeight(true)
            :
            $(this).position().top + $(this).outerHeight(true)

            $this.find('.attachment_tip').show().css({
                left: $this.offset().left,
                top: cY/*$this.find('.post_attachs').offset().top + $this.find('.post_attachs').outerHeight(true)*/
            });
        }, function () {
            $(this).find('.attachment_tip').hide();
        });


        //暂无用
        return;

        Shadowbox.init({ skipSetup: true });

        $('img[data-zoomfile]').click(function () {
            Shadowbox.open({
                content: $(this).data('zoomfile'),
                title: $(this).attr('alt'),
                player: "img",
                type: "img",
                //gallery: $(this).attr('rel'),
                options: { handleOversize: "drag", displayNav: true, overlayOpacity: 0.9, showOverlay: true }
            });
            return false;
        });

        //$(".attimg").ET();
        //$(".att").ExPanel();



        $('.attimg').hover(function () {
            var $this = $(this);
            $this.find('.attachment_tip').show().css({
                left: $this.offset().left,
                top: $this.find('.post_attachs').offset().top
            });
        }, function () {
            $(this).find('.attachment_tip').hide();
        });

    }
});


