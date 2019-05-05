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
              //  debugger;
                ListarItens(data.Resultado);
            }
        }

    });
}

function ListarItens(idPedido) {
    var url = "/ItensCardapioViewModels/ListarItens";
    $.ajax({
        url: url,
        type: "GET",
        data: { id: idPedido },
        dataType: "html",
        success: function (data) {
            var divItens = $("#divItens");
            divItens.empty();
            divItens.show();
            divItens.html(data);
        }
    });
}

function SalvarItens() {
    var quantidade = $("#Quantidade").val();
    var id_produto = $("#Id_Produto").val();
    var id_pedido = $("#idPedido").val();

    var url = "/ItensCardapioViewModels/Create";

    $.ajax({
        url: url,
        data: { Quantidade: quantidade, Id_Produto: id_produto, Id_Cardapio: id_pedido },
        type: "GET",
        dataType: "json",
        success: function (data) {
            if (data.Resultado != null) {
                ListarItens(id_pedido);
            }
        }
    });
}