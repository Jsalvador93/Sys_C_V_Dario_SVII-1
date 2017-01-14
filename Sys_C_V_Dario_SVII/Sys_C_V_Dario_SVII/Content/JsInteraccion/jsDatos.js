function fn_Alerta(controller, action, _data, content, _idmodal , time) {
    $.ajax({
        type: "POST",
        data: _data,
        datatype: "html",
        url: controller + action,
        success: function (page) {
            $("#" + content).html(page);
            $("#" + _idmodal).modal("show");
            setTimeout(function () {
                $("#" + _idmodal).modal("hide");
            }, time);
        }
    });
}
function fn_Detalles(controller, action, _data, content, _idmodal) {
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
}

function fillcbo(idcbo, val, dscp) {
    $("#" + idcbo).append("<option value = '" + val + "'> " + dscp + "</option>");
}

