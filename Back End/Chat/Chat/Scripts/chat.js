// Carrega as Mensagens da Base e mostra na tela.
var carrega = function () {

    var ajax = $.get("ChatApi/ReceiveAll", function (objeto) {
        
        $("#conversas").append("<p>" + objeto[0].Usuario + " diz:</p>");
        $("#conteudo").append("<p>" + objeto[0].Mensagens[0].Conteudo + "</p>");
    });
    
    //ajax.done(function (data) {
    //    console.log(data);

    //    return data;
    //});

    //ajax.done(function receive(result) {
        
    //    for (var i = 0; i < result.lenght; i++) {
    //        $("#conversas").append(result[i].Usuario.value);
    //        console.log(result[i].Usuario);
    //        for (var j = 0; j < result[i].Mensagens.lenght; j++) {
    //            $("#conteudo").append(result[i].Mensagens[j].Usuario + ' diz às ' + new Date(conversas[i].Mensagens[j].Hora));
    //            console.log(result[i].Mensagens[j]);
    //        }
    //    }
    //    console.log(result);

    //   return result
    //});
   
}

// Teste de busca pelo nome do usuário 
$(document).ready(
carrega());
