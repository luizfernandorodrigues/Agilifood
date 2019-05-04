function SalvarCardapio() {
   //debugger;

    var codigo = $("#Codigo").val();
    var descricao = $("#Descricao").val();
    var cadastro = $("#Cadastro").val();
    var id_fornecedor = $("#Id_Fornecedor").val();

    var token = $('input[name="__RequestVerificationToken"]').val();
    var tokenadr = $('form[action="/CardapioViewModels/Create"] input[name="__RequestVerificationToken"]').val();
    var headers = {};
    var headersadr = {};
    headers['__RequestVerificationToken'] = token;
    headersadr['__RequestVerificationToken'] = tokenadr;

    var url = "/CardapioViewModels/Create";

    $.ajax({
        url: url,
        type: "POST",
        dataType: "json",
        headers: headersadr,
        data: {
            Id: '00000000-0000-0000-0000-000000000000', Codigo: codigo, Descricao: descricao, Cadastro: cadastro, Id_Fornecedor: id_fornecedor, __RequestVerificationToken: token
        },
        success: function (data) {
            if (data.Resultado != null) {
                debugger;
                ListarItens(data.Resultado);
            }
        }

    });
}

function ListarItens(idPedido) {
    var url = "/ItensCardapioViewModels/Index";
    $.ajax({
        url: url,
        type: "GET",
        data: { id: idPedido },
        dataType: "json",
        success: function (data) {
            var divItens = $("#divItens");
            divItens.empty();
            divItens.show();
            divItens.html(data);
        }
    });
}