function fn_Detalles(controller, action, _data, content , _idmodal) {
    $.ajax({
        type: "POST",
        data: _data,
        datatype: "html",
        url: controller + action,
        success: function (page) {
            $("#" + content).html(page);
            $("#" + _idmodal).modal("show");
        }
    });
    return;
}