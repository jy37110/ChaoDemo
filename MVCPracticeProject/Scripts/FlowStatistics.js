
$(document).ready(function () {
    postOrders();
});

function postOrders() {
    var postData = {
        msg: "flow"
    };
    $.ajax({
        type: "POST",
        url: "/Home/FlowStatistics",
        data: postData,
        success: function () {
        },
        dataType: "json",
        traditional: true
    });
}