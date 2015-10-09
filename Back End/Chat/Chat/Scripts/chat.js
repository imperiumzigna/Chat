// Carrega as Mensagens da Base e mostra na tela.
var debug;
var selected;

var ajax = function () {
    $.get("ChatApi/Receive", function (resultado) {
        debug = resultado;
        if (resultado.length > 0) {
            for (var i = 0; i < resultado.length; i++) {

                if ($("#" + resultado[i].NomeConversa).length == 0) {
                    $("#conversas").append("<div id=\"" + resultado[i].NomeConversa + "\">" + resultado[i].NomeConversa + "</div>");
                    $("#" + resultado[i].NomeConversa).append("<div id=\"" + resultado[i].NomeConversa + "mensagens\"></div>");
                    //$("#"+resultado[i].NomeConversa).click(
                    //    function() {
                    //        selected = $("#" + resultado[i].NomeConversa).id;
                    //    }
                    //    );
                }

                if ($("#" + resultado[i].MensagemId + "mensagem").length == 0) {
                    $("#" + resultado[i].NomeConversa + "mensagens").append("<div id=\"" + resultado[i].MensagemId + "mensagem\">" + resultado[i].Autor + " disse às " + resultado[i].Hora + ":" + resultado[i].Conteudo + "</div>");
                }
            }
        }
    });
<<<<<<< HEAD
};

$("#enviar").click(
    function () {
        var dados = { conv: selected, mensagem: $("#mensagem").val() };
        $.post("ChatApi/Send", dados);
        $("#mensagem").input.value = "";
    }
    );

//Fazer requisição à cada 1 segundo
setInterval(ajax, 1000);
=======
}
// Commit Teste -> a deletar 
// Falta receber o nome do usuário a que se deseja enviar a mensagem 
var enviar = function () {
    var ajax = $.post("ChatApi/Send", {
        user: "",
        mensagem: ""
    });
}
    
// Teste de busca pelo nome do usuário 
$(document).ready(function () {
    carrega();
    console.log();
}
);
>>>>>>> origin/master
