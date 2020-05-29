jQuery(function ($) {
    $("input[name='cep']").change(function () {
        var cep_code = $(this).val();
        if (cep_code.length <= 0) return;
        $.get("https://ws.apicep.com/busca-cep/api/cep.json", { code: cep_code }, function (result) {
            if (result.status == 404) {
                alert(result.message || "Ops! Nós não conseguimos encontrar este CEP.");
                return;
            }
            $("input[name='estado']").val(result.state);
            $("input[name='cidade']").val(result.city);
            $("input[name='bairro']").val(result.district);
            $("input[name='logradouro']").val(result.address);
        });
    });
});