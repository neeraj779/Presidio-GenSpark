const { JSDOM } = require("jsdom");
const fs = require("fs");
const path = require("path");

test("Test Login", () => {
  const html = fs.readFileSync(
    path.resolve(__dirname, "../login.html"),
    "utf8"
  );
  const script = fs.readFileSync(
    path.resolve(__dirname, "../script.js"),
    "utf8"
  );

  const dom = new JSDOM(html, {
    runScripts: "dangerously",
    resources: "usable",
  });
  const scriptElement = dom.window.document.createElement("script");
  scriptElement.textContent = script;
  dom.window.document.body.appendChild(scriptElement);

  //Raising the event for successful login
  dom.window.document.getElementById("username").value = "user";
  dom.window.document.getElementById("password").value = "user@123";

  dom.window.document
    .getElementById("loginForm")
    .dispatchEvent(new dom.window.Event("submit"));

  expect(dom.window.document.getElementById("status").textContent).toBe(
    "Login successful"
  );

  //Raising the event for unsuccessful login
  dom.window.document.getElementById("username").value = "user";
  dom.window.document.getElementById("password").value = "user@1234";

  dom.window.document
    .getElementById("loginForm")
    .dispatchEvent(new dom.window.Event("submit"));

  expect(dom.window.document.getElementById("status").textContent).toBe(
    "Username or password is incorrect"
  );
});
