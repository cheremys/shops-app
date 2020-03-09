$("#buttonsContainer :button").on("click", function (event) {

    let recipient = $(this).data("whatever");

    if (recipient === "appConsultant") {
        getPartialView("Home/AppConsultant").then(function (content) {
            showModal(content);
        });
    }
    else if (recipient === "addConsultant") {
        getPartialView("Home/CreateConsultant").then(function (content) {
            showModal(content);
        });
    }
    else if (recipient === "addShop") {
        getPartialView("Home/CreateShop").then(function (content) {
            showModal(content);
        });
    }
});

function showModal(content) {
    let modal = $("#modal").modal();
    modal.find(".modal-content").empty().append(content);
}

function getPartialView(url) {
    return $.ajax({
        type: 'GET',
        url: url,
        cache: false
    });
}