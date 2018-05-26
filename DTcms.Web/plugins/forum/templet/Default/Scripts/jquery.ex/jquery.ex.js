
(function ($) {
    $.fn.CheckBoxEx = function () {
        var class_name_arr = new Array("cb3_null", "cb3_allow", "cb3_ban");
        return this.each(function () {
            var c = $(this);

            (function (c) {

                var state = c.get(0).selectedIndex;

                var dv = $("<div />").addClass("cb3")
                .addClass(class_name_arr[state])
                .insertAfter(c);

                dv.bind("onselectstart", function (event) {
                    event.returnValue = false;
                    return false;
                });

                dv.click(function () {
                    $(this).removeClass(class_name_arr[state]);
                    state = (state + 1) % 3;
                    $(this).addClass(class_name_arr[state]);
                    c.get(0).selectedIndex = state;
                });
            })(c);

            //c.hide();

        });
    }
})(jQuery);

(function ($) {
    $.fn.ET = function () {

        return this.each(function () {
            $(this).mouseover(function (e) {
                var el = e.srcElement ? e.srcElement : e.target;
                if (!el) return;

                var content = "#" + $(this).attr("data-pop-id");
                $(content).hover(function (over) {
                    $(this).show();
                },
                function (out) {
                    $(this).hide();
                });

                var cX = $(this).position().left;

                //var cY = ($(this).position().top - $(content).outerHeight(true) - document.documentElement.scrollTop < 0) ? $(this).position().top + $(this).outerHeight(true) : $(this).position().top - $(content).outerHeight(true);
                var cY = $(this).position().top ;


                $(content).css({ left: cX, top: cY });
                $(content).show();

            });

            $(this).mouseout(function () {
                var content = "#" + $(this).attr("data-pop-id");
                $(content).hide();

            });
        });
    };

    $.fn.ExPanel = function () {

        return this.each(function () {
            $(this).mouseover(function (e) {
                var el = e.srcElement ? e.srcElement : e.target;
                if (!el) return;

                var content = "#" + $(this).attr("data-pop-id");
                $(content).hover(function (over) {
                    $(this).show();
                },
                function (out) {
                    $(this).hide();
                });

                var cX =
                (
                    $(this).position().left
                    +
                    $(content).outerWidth(true)
                    >
                    document.documentElement.scrollLeft + +document.body.scrollLeft
                    +
                    document.documentElement.clientWidth
                )
                ?
                $(this).position().left - $(content).outerWidth(true) + $(this).outerWidth(true)
                :
                $(this).position().left
                ;

                var cY =
                (
                    $(this).position().top
                    +
                    $(this).outerHeight(true)
                    +
                    $(content).outerHeight(true)
                    >
                    document.documentElement.scrollTop + document.body.scrollTop
                    +
                    document.documentElement.clientHeight
                )
                ?
                $(this).position().top - $(content).outerHeight(true)
                :
                $(this).position().top + $(this).outerHeight(true)
                ;


                $(content).css({ left: cX, top: cY });
                $(content).show();

            });

            $(this).mouseout(function () {
                var content = "#" + $(this).attr("data-pop-id");
                $(content).hide();

            });
        });
    };

    $.fn.UserInfoPanel = function () {

        var currentText = null;

        return this.each(function () {
            $(this).hover(
				function (over) {
				    var id = $(this).attr("data-exid");
				    currentText = $("#" + id);
				    currentText.hover(
                            function (over) {
                                $(this).show();
                            },
                            function (out) {
                                $(this).hide();
                            }
                        );
				    currentText = $("#" + id);
				    currentText.show();
				},
				function (out) {
				    var id = $(this).attr("data-exid");
				    currentText = $("#" + id);
				    currentText.hide();
				}
			);
        }); // end this.each
    }; // end fn.linkControl
})(jQuery);

