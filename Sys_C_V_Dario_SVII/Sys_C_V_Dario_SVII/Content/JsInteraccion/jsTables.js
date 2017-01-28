function fn_ListarTabla(_case, filtro, action, controller , content ) {
    $.ajax({
        type: 'POST',
        data: { _case: _case, filtro: filtro },
        datatype: 'html',
        url: controller + action , /*'/' + controller + '/' + action,*/
        success: function (page) {
            $("#" + content).html(page);
        }
    });
}
function fn_ListarTablaFiltrar(_data, _url, content) {
    $.ajax({
        type: 'POST',
        data: _data,
        datatype: 'html',
        url: _url, /*'/' + controller + '/' + action,*/
        success: function (page) {
            $("#" + content).html(page);
        }
    });
}