(function ($) {
    "use strict";

    $.extend($.validator.messages, {
        required: "Vui lòng nhập dữ liệu.",
        email: "Email không đúng định dạng.",
        number: "Vui lòng nhập một số hợp lệ.",
        date: "Vui lòng nhập ngày hợp lệ.",
        min: $.validator.format("Giá trị phải lớn hơn hoặc bằng {0}."),
        max: $.validator.format("Giá trị phải nhỏ hơn hoặc bằng {0}.")
    });

    // jQuery Validate dùng range cho số; ô ngày cần so sánh theo dạng yyyy-MM-dd.
    $.validator.addMethod("birthDateRange", function (value, element) {
        return this.optional(element) ||
            (/^\d{4}-\d{2}-\d{2}$/.test(value) && value >= element.min && value <= element.max);
    });

    $(function () {
        $("#Name").rules("add", {
            normalizer: function (value) { return value.trim(); }
        });

        var birthday = $("#DateOfBorth");
        birthday.rules("remove", "range min max");
        birthday.rules("add", {
            birthDateRange: true,
            messages: {
                birthDateRange: birthday.attr("data-val-range")
            }
        });
    });
})(jQuery);
