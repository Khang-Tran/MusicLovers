var GigServices = function () {
    var dialogNoCallback = function () {
        bootbox.hideAll();
    };

    var dialogYesCallback = function (gigId, done, fail) {
        $.ajax({
            url: "/api/gigs/" + gigId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    };

    var dialogDetails = function () {
        return {
            dialogTitle: 'Confirm',
            dialogMessage: "Are you sure want to delete this gig"
        };
    };

    var noButtonDetails = function () {
        return {
            label: "No",
            className: 'btn-default'
        };

    }();

    var yesButtonDetails = function () {
        return {
            label: "Yes",
            className: 'btn-danger'
        };

    }();

    var cancelDialog = function (gigId, done, fail) {
            bootbox.dialog({
                title: dialogDetails.dialogTitle,
                message: "Are you sure want to delete this gig",
                buttons: {
                    no: {
                        label: noButtonDetails.label,
                        className: noButtonDetails.className,
                        callback: function() { dialogNoCallback(); }
        },
                yes: {
                    label: yesButtonDetails.label,
                    className: yesButtonDetails.className,
                    callback: function() { dialogYesCallback(gigId, done, fail); }
                }
            }

        });
    };
    return {
        cancel: cancelDialog
    };
}();