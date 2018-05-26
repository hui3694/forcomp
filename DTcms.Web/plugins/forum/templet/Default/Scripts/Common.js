
$(function () {

    $.fn.extend({
        btns: function (state) {
            var self = $(this);
            if (!state) {
                var loadingText = self.data("loading-text");
                var text = self.text();
                self.data("text", text);
            }
            else {
                var loadingText = self.data("loading-text");
                var text = self.data("text");
                if (state == 'loading') {
                    self.text(loadingText);
                    self.attr("disabled", "disabled");
                }
                if (state == "reset") {
                    self.text(text);
                    self.removeAttr("disabled");
                }
            }
        }
    });

    $.fn.checked = function (state) {
        return this.each(function () {
            this.checked = state;
        });
    }

    String.prototype.replaceAll = function stringReplaceAll(AFindText, ARepText) {
        var raRegExp = new RegExp(AFindText.replace(/([\(\)\[\]\{\}\^\$\+\-\*\?\.\"\'\|\/\\])/g, "\\$1"), "ig");
        return this.replace(raRegExp, ARepText);
    }
});

function search(key, url) {

    if (key.replace(" ", "") == "") {

        alert("请输入关键字");

        return;

    }

    //key = key.replace(/\s+/g, "");//删除所有空格;
    //url = url.replace("_key_", key);

    url = url + "?keys=" + key;

    location.href = url;
}