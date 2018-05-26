$(document).ready(function () {

    $.each($('select[name="color"] option'), function (i, n) {
        $(this).css({ color: $(this).val(), background: $(this).val() });
    });

    $("#reson").change(function () {
        var me = $(this);
        var c = $("form textarea");
        c.val(me.val())
        c.text(me.val());
    });

    var options = {
        beforeSubmit: function (formData, jqForm, options) {
            easyDialog.open({ container: { content: '正在提交。。。' } });
            return true;
        },
        success: function (responseText, statusText) {
            if (responseText.error) {
                easyDialog.open({ container: { header: '提示', content: responseText.description, noFn: true } });
                return;
            }
            top.location.href = responseText.url;
        },
        error: function () {
            easyDialog.open({ container: { header: '提示', content: "服务器通讯失败", noFn: true } });
        },
        complete: function () {
        },
        url: "/plugins/forum/handler/submit_ajax.ashx?action=" + $("#action").val(),
        type: 'post',
        dataType: 'json'
    };
    $("#post").ajaxForm(options);
});