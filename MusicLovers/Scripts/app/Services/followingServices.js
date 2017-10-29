var FollowingServices = function () {
    var createFollowing = function(followId, done, fail) {
        $.post("/api/followings", { followeeId: followId})
            .done(done)
            .fail(fail);
    };
    var deleteFollowing = function(followId, done, fail) {
        $.ajax({
                url: "/api/followings/" + followId,
                method: "DELETE"
            })
            .done(done)
            .fail(fail);
    };

    return {
        create: createFollowing,
        delete: deleteFollowing
    };
}();