/* tangbin - http://www.planeArt.cn - MIT Licensed */
(function ($) {
    // tipWrap: 	提示消息的容器
    // maxNumber: 	最大输入字符
    $.fn.artTxtCount = function (tipWrap, maxNumber, ta, tb) {

        //var out = false;

        // 统计字数
        var count = function () {
            var val = $(this).val().length;

            //if (val == 0) disabled.off();
            if (val <= maxNumber) {
                //var oout = out;
                //if (out) out = false;
                //if (oout != out)
                //    if (changec) changec(true);
                tipWrap.html(ta.replace("{0}", maxNumber - val));
            } else {
                //var oout = out;
                //if (!out) out = true;
                //if (oout != out)
                //    if (changec) changec(false);
                tipWrap.html(tb.replace("{0}", val - maxNumber));
            };
        };
        $(this).bind('keyup change', count).trigger('keyup');

        return this;
    };
})(jQuery);