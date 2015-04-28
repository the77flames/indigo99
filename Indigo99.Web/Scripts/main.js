$(function () {

    var uri = 'api/CategoryManagementServiceRESTAPI/get?section=0&count=20/';

    $.getJSON(uri)
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<tr><td>' + (key + 1) + '</td><td>' + item.Name + '</td><td>' + item.ThumbNailImagePath + '</td><td>' + item.SectionId + '</td></tr>')
                    .appendTo($('#cars tbody'));
            });
        });
});
