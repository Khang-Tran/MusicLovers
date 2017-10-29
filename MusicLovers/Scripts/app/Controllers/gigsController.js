var GigsController = function (gigServices) {
    console.log("in controller");
    var link;

    var done = function() {
        link.parents("li").fadeOut(function () {
            $(this).remove();
        });
    };

    var fail = function() {
        alert("Something went wrong..");
    };


    var cancelDialog = function (e) {
        link = $(e.target);
        var gigId = link.attr("data-gig-id");
 
        gigServices.cancel(gigId, done, fail);
    };
    var init = function (container) {
        console.log("in init");
        $(".js-cancel-gig").on("click", cancelDialog);
    };
    return {
        init: init
    };
}(GigServices);