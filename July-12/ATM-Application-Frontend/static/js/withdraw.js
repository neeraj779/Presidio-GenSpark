$(document).on("click", "#withdraw-button", function (event) {
  event.preventDefault();

  let amount = $("#amount").val();

  if (validateAmount(amount, "withdraw") === false) return;
  showInitialSwal("withdraw");

  performTransaction(amount, "withdraw");
});
