// Function to check JWT token in local storage
function checkAuth() {
  const cardNo = localStorage.getItem("cardNumber");
  const pin = localStorage.getItem("pin");
  const logoutButton = document.getElementById("logout-button");

  if (cardNo && pin) {
    logoutButton.style.display = "block";
  } else {
    window.location.href = ".././templates/login.html";
  }
}

function handleLogout() {
  localStorage.removeItem("cardNo");
  localStorage.removeItem("pin");
  window.location.href = ".././templates/login.html";
}

window.onload = function () {
  checkAuth();
};
