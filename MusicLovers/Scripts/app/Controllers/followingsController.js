var FollowingController = function (followingServices) {
    var button;
    var done = function() {
        var text = button.text() === "Following" ? "Follow?" : "Following";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };
    var fail = function() {
        alert("Something went wrong..");
    };

    var toggleFollowing = function(e) {
        button = $(e.target);
        var followId = button.attr("data-user-id");
        if (button.hasClass("btn-default"))
            followingServices.create(followId, done, fail);
        else
            followingServices.delete(followId, done, fail);
    };

    var init = function (container) {
        $(container).on("click", ".js-toggle-following", toggleFollowing);
    };

    return {
        init: init
    };
}(FollowingServices);

