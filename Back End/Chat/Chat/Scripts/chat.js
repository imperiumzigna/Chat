// Carrega as Mensagens da Base e mostra na tela.
var carrega = function () {

    var ajax = $.get("ChatApi/ReceiveAll", function (objeto) {
        // Falta adicionar iteração dos Objetos e Mensagens
        // 
        console.log(objeto);
        var n = objeto[0].Mensagens[0].Hora.toString();
        var subs =new Date(parseInt(n.substring(6))).toLocaleString();
       
        $("#conversas").append("<p>" + objeto[0].Usuario + " disse às "+ subs +":</p>");
        $("#conteudo").append("<p>" + objeto[0].Mensagens[0].Conteudo + "</p>");
    });
}


    
// Teste de busca pelo nome do usuário 
$(document).ready(function () {
    carrega();
    console.log();
}
);
