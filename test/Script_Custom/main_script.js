
function sendNewData() {
    var obj = {
        affiliateName: $("#affiliateName").val(),
        impressions: $("#impressions").val(),
        compaignName: $("#compaignName").val(),
        clicks: $("#clicks").val(),
        conversions: $("#conversions").val(),
        date: $("#date").val()
    };

    $.ajax({
        url: '/Home/CreateNew',
        contentType: 'application/json; charset=utf-8',
        type: 'POST',
        dataType: 'json',
        data: obj
    })
        .success(function (result) {
            alert("New data added to the DevTest table" + result);
        })
        .error(function (error) {
            alert("Cannot insert data into DevTest table" + error);
        });
}

function getAllMessages() {
    var tbl = $('#messagesTable');
    $.ajax({
        url: '/Home/GetMessages',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html'
    }).success(function (result) {
        tbl.empty().append(result);
    }).error(function () {

    });
}