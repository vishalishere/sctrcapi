var createEvent = function () {
    var data = {
        StartDate: (new Date()).toJSON(),
        EndDate: (new Date()).toJSON(),
        Group: 'FDF Karlebo'
    };
    //Create html and set it as the popup thingie
    $.ajax({
        beforeSend: function () {
        },
        url: "/api/Events",
        type: "POST",
        data: data
    }).done(function (resData) {
    }).fail(function () {
    });
};

var createActivity = function () {
    var eventid = 1;
    var data = {
        EventId: eventid,
        Description: 'En demo actibity',
        Location: 'Foran hytten'
    };
    //Create html and set it as the popup thingie
    $.ajax({
        beforeSend: function () {
        },
        url: "/api/Activities",
        type: "POST",
        data: data
    }).done(function (resData) {
    }).fail(function () {
    });
};

$('#createEvent').click(function () {
    createEvent();
});