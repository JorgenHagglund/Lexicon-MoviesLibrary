$(function () {
    // Script runs at DOM completion
    $("tbody>tr")
        .css("cursor", "pointer")      // Set cursor to a hand when on the table row
        .on({
            "mouseover": function () {
                $(this).addClass("jh-highlight");
                $("> *", this).addClass("jh-highlight");
            },
            "mouseout": function () {
                $(this).removeClass("jh-highlight");
                $("> *", this).removeClass("jh-highlight");
            }
        });
    console.log("Events connected");
});
