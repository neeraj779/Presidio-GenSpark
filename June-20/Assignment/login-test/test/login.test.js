const { JSDOM } = require("jsdom");
const fs = require("fs");
const path = require("path");

function setupDOM() {
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

  return dom;
}

test("Test successful login", () => {
  const dom = setupDOM();

  dom.window.document.getElementById("username").value = "user";
  dom.window.document.getElementById("password").value = "user@123";

  dom.window.document
    .getElementById("loginForm")
    .dispatchEvent(new dom.window.Event("submit"));

  expect(dom.window.document.getElementById("status").innerText).toBe(
    "Login successful"
  );
});

test("Test unsuccessful login", () => {
  const dom = setupDOM();

  dom.window.document.getElementById("username").value = "user";
  dom.window.document.getElementById("password").value = "user@1234";

  dom.window.document
    .getElementById("loginForm")
    .dispatchEvent(new dom.window.Event("submit"));

  expect(dom.window.document.getElementById("status").innerText).toBe(
    "Username or password is incorrect"
  );
});
