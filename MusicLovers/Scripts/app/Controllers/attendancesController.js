var AttendancesController = function (attendanceService) {
    var button;

    var fail = function() {
        alert("Something went wrong..");
    };

    var done = function () {
        console.log(button.text());
        console.log(button.hasClass("btn-info"));
        var text = button.text() === "Going" ? "Going?" : "Going";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };

    var toggleAttendance = function (e) {

        button = $(e.target);

        var gigId = button.attr("data-gig-id");

        if (button.hasClass("btn-default"))
            attendanceService.create(gigId, done, fail);
        else
            attendanceService.delete(gigId, done, fail);

    };

    // Main fucntion
    var init = function (container) {
        $(container).on("click", ".js-toggle-attendance", toggleAttendance);
    };

    return {
        init: init
    };
}(AttendanceServices);