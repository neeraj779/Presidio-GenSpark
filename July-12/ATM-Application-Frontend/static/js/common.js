const withdrawTips = [
  "Just hang in there... we're conjuring some magic! ✨🪄",
  "Your money is on its way! 🚚💨",
  "Your transaction is in progress... almost there! ⏳",
  "Processing your request... we appreciate your patience! 🙏",
  "Your money is being sorted... get ready! 💰🗄️",
  "We are almost done, thank you for waiting! 😊",
];

const depositTips = [
  "Hang tight... we're securing your deposit! 🔒💰",
  "Your funds are being added... please wait! 🛠️",
  "We are processing your deposit... almost done! ⏳",
  "Counting your cash... please hold on! 💵🧮",
  "Securing your deposit... thanks for your patience! 😊",
  "Your deposit is in progress... just a moment! 💸",
  "Verifying your funds... hang in there! 🔍💰",
  "Your money is being credited... almost there! 💳",
  "We are adding your deposit... thank you for waiting! 🙏",
];

function showInitialSwal(type) {
  let tips = type === "withdraw" ? withdrawTips : depositTips;

  let tipIndex = 0;
  setInterval(function () {
    tipIndex = (tipIndex + 1) % tips.length;
    $("#tip-text").text(tips[tipIndex]);
  }, 1000);
  initialSwal = Swal.fire({
    title: "Processing your request &#128515;...",
    html: '<span id="tip-text">' + tips[tipIndex] + "</span>",
    imageUrl: "/assets/gif/money.webp",
    imageWidth: 300,
    imageHeight: 270,
    imageAlt: "Loading",
    allowOutsideClick: false,
    didOpen: () => {
      Swal.showLoading();
    },
  });
}

function performTransaction(amount, type) {
  let cardNumber = localStorage.getItem("cardNumber");
  let pin = localStorage.getItem("pin");

  let withdrawMsg = `Please collect your cash.`;
  let depositMsg = `Your funds have been added.`;
  let successMsg = type === "withdraw" ? withdrawMsg : depositMsg;

  const requestBody = {
    authDetails: {
      cardNumber: cardNumber,
      pin: pin,
    },
    amount: amount,
  };

  setTimeout(() => {
    fetch(`http://localhost:5236/api/Transaction/${type}`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(requestBody),
    })
      .then((response) => {
        if (!response.ok) {
          return response.json().then((data) => {
            let error = new Error(data.message || "Something went wrong");
            error.status = response.status;
            throw error;
          });
        }
        return response.json();
      })
      .then((data) => {
        Swal.close();
        Swal.fire({
          title: `Yoo! you have successfully ${type} the amount. 🎉`,
          text: successMsg,
          color: "#716add",
          imageUrl: "/assets/gif/moneyOut.webp",
          imageWidth: 400,
          imageHeight: 200,
          imageAlt: "Custom image",
          allowOutsideClick: false,
          confirmButtonText: '<i class="fa fa-thumbs-up"></i> Great!',
        });
      })
      .catch((error) => {
        Swal.close();
        Swal.fire({
          icon: "info",
          title: "Hmm 🤔... something seems off!",
          text: error,
        });
      });
  }, 4000);
}
