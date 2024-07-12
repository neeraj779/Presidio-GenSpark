document
  .getElementById("loginForm")
  .addEventListener("submit", function (event) {
    event.preventDefault();

    const cardNumber = document.getElementById("cardNumber").value;
    const pin = document.getElementById("pin").value;

    fetch("http://localhost:5236/api/Authentication/AuthenticateCard", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ cardNumber, pin }),
    })
      .then((response) => {
        response.json().then((data) => {
          if (response.status === 200) {
            localStorage.setItem("cardNumber", cardNumber);
            localStorage.setItem("pin", pin);
            window.location.href = "../index.html";
          } else {
            document.getElementById("error").style.display = "block";
            document.getElementById("error").innerText = "Invalid card number or pin"
          }
        });
      })
      .catch((e) => {
        console.error("Error:", e);
        document.getElementById("error").style.display = "block";
      });
  });
