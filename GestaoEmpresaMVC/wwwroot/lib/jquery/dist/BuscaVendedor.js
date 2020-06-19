jQuery(function ($) {
    $("input[id='idProduto']").change(function () {
        var id_produto = $(this).val();        
        $.get("Product", { Id: id_produto }, function (result) {
            if (result.status == 404) {
                alert("Ops! Nós não conseguimos encontrar este CEP.");
                return;
            }
            $("input[id='produto']").val(result.Id);
            $("input[id='preco']").val(result.ProductPrice);
            $("input[id='quantidade']").val(result.ProductQuantity);
        });
    });
});