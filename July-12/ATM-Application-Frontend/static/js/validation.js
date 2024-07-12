let maxAmount = 10000;
function validateUserAmount(amount) {
  const allowedMultiples = [100, 500, 2000];
  for (let multiple of allowedMultiples) {
    if (amount % multiple === 0) {
      return true;
    }
  }
  return false;
}

function validateAmount(amount, type) {
  if (type === "deposit") maxAmount = 20000;
  if (amount === "") {
    Swal.fire({
      icon: "error",
      title: "Ah snap! looks like you forgot something 🤔",
      text: `Please enter the amount to ${type}.`,
      confirmButtonText: '<i class="fa fa-thumbs-up"></i> Okay!',
      confirmButtonAriaLabel: "Thumbs up, okay!",
    });
    return false;
  } else if (amount < 100) {
    Swal.fire({
      icon: "info",
      title: "Wait a sec 🤔",
      text: `Minimum ${type} amount is 100. You can ${type} upto ${maxAmount} at once.`,
      confirmButtonText: '<i class="fa fa-thumbs-up"></i> Okay!',
      confirmButtonAriaLabel: "Thumbs up, okay!",
    });
    return false;
  } else if (amount > maxAmount) {
    Swal.fire({
      icon: "info",
      title: "Wow! look at you rolling in 💰",
      text: `Sorry but you can't ${type} more than ${maxAmount} at once. 😅`,
      confirmButtonText: '<i class="fa fa-thumbs-up"></i> Okay!',
      confirmButtonAriaLabel: "Thumbs up, okay!",
    });
    return false;
  } else if (validateUserAmount(amount) === false) {
    Swal.fire({
      icon: "info",
      title: "Uh oh! looks like we have a problem 🤔",
      text: "Amount cannot be dispensed using 2000, 500, and 100 notes. Please enter a amount that can be dispensed using 2000, 500, and 100 notes.",
      confirmButtonText: '<i class="fa fa-thumbs-up"></i> Okay!',
      confirmButtonAriaLabel: "Thumbs up, okay!",
    });
    return false;
  }
}
