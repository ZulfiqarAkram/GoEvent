var EventsController = function (attendanceService) {
    var toggleAttendance, done, fail;
    var btn;

    var init = function (container) {
        $(container).on("click", ".js-toggle-attendance", toggleAttendance);
    };

    toggleAttendance = function (e) {
        btn = $(e.target);
        var eventId = btn.attr("data-evento-id");

        if (btn.hasClass("btn-default"))
            attendanceService.createAttendance(eventId, done, fail);
        else
            attendanceService.deleteAttendance(eventId, done, fail);
    };
    done = function () {
        var text = (btn.text() == "Going" ? "Going ?" : "Going");
        btn.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };
    fail = function () {
        alert("something wrong!!!");
    };
    return {
        init: init
    }
}(AttendanceService);