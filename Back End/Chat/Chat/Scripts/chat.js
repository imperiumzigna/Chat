
var carrega = function carregaMensagens() {

    var ajax = $.get("ChatApi/ReceiveAll");
    ajax.done(function receive(result) {
        console.log(result);
        for (var i = 0; i < result.lenght; i++) {
            $("#conversas").append(result[i].Usuario);
            console.log(result[i].Usuario);
            for (var j = 0; j < result[i].Mensagens.lenght; j++) {
                $("#conteudo").append(result[i].Mensagens[j].Usuario + ' diz às ' + new Date(conversas[i].Mensagens[j].Hora));
                console.log(result[i].Mensagens[j]);
            }
        }
    });
}

// Teste de busca pelo nome do usuário 
$(document).ready(
    function () {
        $("#buscar").submit(function () {
        alert($("#inpt_search").val());
        });
    });