$().ready(function () {
    $(".moneyMask").maskMoney({ thousands: '.', decimal: ',', allowZero: true, prefix: 'R$ ' });
});
   