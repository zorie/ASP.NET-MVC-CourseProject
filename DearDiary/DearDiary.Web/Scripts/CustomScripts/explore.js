$(function () {
    $(".is-checked").change(function (e) {
        $(this);

        if ($(this).attr("type") == "radio" && !$(this).is(":checked")) {
            return;
        }
        $("#explore-form").submit();
    })

})