let USERSDB = [
  {
    username: "user",
    password: "user@123",
  },
];

document
  .getElementById("loginForm")
  .addEventListener("submit", function (event) {
    event.preventDefault();

    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;
    validateCredentials(username, password);
  });

function validateCredentials(username, password) {
  let isUserValid = false;
  let statusDiv = document.getElementById("status");

  USERSDB.forEach((user) => {
    if (user.username === username && user.password === password) {
      isUserValid = true;
    }
  });

  if (isUserValid) {
    statusDiv.innerText = "Login successful";
  } else {
    statusDiv.innerText = "Username or password is incorrect";
  }
}
