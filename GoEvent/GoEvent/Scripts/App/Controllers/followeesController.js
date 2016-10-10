var FolloweesController = function (followService) {
    var btn, done, fail, toggleFollow;

    var init = function (container) {
        $(container).on("click", ".js-toggle-following", toggleFollow);
    }
    toggleFollow = function (e) {

        btn = $(e.target);
        var artistId = btn.attr("data-artist-id");

        if (btn.hasClass("btn-link"))
            followService.Follow(artistId, done, fail);
        else
            followService.UnFollow(artistId, done, fail);
    };

    done = function () {
        var text = (btn.text() == "Following" ? "Follow" : "Following");
        btn.toggleClass("btn-link").toggleClass("btn-info").text(text);
    };

    fail = function () {
        alert("something wrong.");
    };

    return {
        init: init
    }
}(FollowService);
