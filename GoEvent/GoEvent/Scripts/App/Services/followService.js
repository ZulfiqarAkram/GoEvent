var FollowService = function () {
    var Follow = function (artistId, done, fail) {
        $.post("/api/followings", { FolloweeId: artistId })
            .done(done)
            .fail(fail);
    };
    var UnFollow = function (artistId, done, fail) {
        $.ajax({
            url: "/api/followings/" + artistId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    };

    return {
        Follow: Follow,
        UnFollow: UnFollow
    };
}();