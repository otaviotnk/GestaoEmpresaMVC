jQuery(function ($) {
    $("input[id='cep']").change(function () {
        var cep_code = $(this).val();
        if (cep_code.length <= 0) return;
        $.get("https://ws.apicep.com/busca-cep/api/cep.json", { code: cep_code }, function (result) {
            if (result.status == 404) {
                alert(result.message || "Ops! Nós não conseguimos encontrar este CEP.");
                return;
            }
            $("input[id='estado']").val(result.state);
            $("input[id='cidade']").val(result.city);
            $("input[id='bairro']").val(result.district);
            $("input[id='logradouro']").val(result.address);
        });
    });
});