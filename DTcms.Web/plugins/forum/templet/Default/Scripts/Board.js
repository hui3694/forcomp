$(document).ready(function () {

    $(".mypop").ExPanel();

    $(".manage_action").click(function () {
        var url = $(this).attr("href");
        var formObj = $("form[name='moderate']")[0];
        formObj.action = url;
        formObj.submit();
        return false;
    });

    ManageTopic();

    function ManageTopic() {
        var len = $("[name='tids']:checkbox:enabled:checked").length;
        if (len > 0) {
            $("#manageTopicCount").html(len);
            $("#manageTopic").show();
            $("#manageTopic").css("left", $("#manageTopic").parent().offset().left + ($("#manageTopic").parent().width() - $("#manageTopic").outerWidth(false)) / 2 + "px");
        }
        else {
            $("#manageTopic").hide();
        }       
    }

    $("[name='tids']:checkbox:enabled").click(function () {
        if (!$(this)[0].checked)
            $(".select_all").checked(false);
        else if ($("[name='tids']:checkbox:checked").length == $("[name='tids']:checkbox:enabled").length)
            $(".select_all").checked(true);

        ManageTopic();
    });

    $(".select_all_cancel").click(function () {
        $(".select_all").checked(false);
        $("[name='tids']:checkbox:checked").checked(false);
        $("#manageTopic").hide();
    });

    $(".select_all").change(function () {
        var selected = $(this)[0].checked;
        $(".select_all").checked(selected);
        $("[name='tids']:checkbox:enabled").checked(selected);
        ManageTopic();
    });
});
