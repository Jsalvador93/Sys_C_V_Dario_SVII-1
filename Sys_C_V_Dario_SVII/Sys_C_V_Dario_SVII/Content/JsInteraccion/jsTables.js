function ListarTabla(_case, filtro, action, controller , content ) {
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