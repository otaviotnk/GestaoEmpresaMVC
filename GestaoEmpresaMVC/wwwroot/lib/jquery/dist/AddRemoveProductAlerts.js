
var form = document.querySelector('form');
form.addEventListener('submit', function (e) {
    e.preventDefault();

    var url = this.action;
    var formData = new FormData(this);
    var ajax = new XMLHttpRequest();
    ajax.open("POST", url, true);
    ajax.onload = function () {

        if (ajax.status == 200) {
            var res = JSON.parse(ajax.response);

            if (res == true) {
                $('#return').html("Cadastrado com Sucesso!").css('color', 'green');
            }
            if (res == false) {
                $('#return').html("Ocorreu um Erro na Solicitação").css('color', 'red');
            }
        }
    };
    ajax.send(formData);
});