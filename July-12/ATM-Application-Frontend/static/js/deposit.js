$(document).on("click", "#deposit-button", function (event) {
  event.preventDefault();

  let amount = $("#amount").val();

  if (validateAmount(amount, "deposit") === false) return;
  showInitialSwal("deposit");

  performTransaction(amount, "Deposit");
});
