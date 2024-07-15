const tileDisplay = document.querySelector(".tile-container");
const keyBoard = document.querySelector(".key-container");
const messageDisplay = document.querySelector(".message-container");

const wordList = [
  "about", "after", "again", "basic", "break", "cause", "chair", "clean", "comes", "cross",
  "doubt", "early", "earth", "empty", "equal", "faith", "fight", "final", "floor", "force",
  "found", "front", "fruit", "glass", "grant", "green", "guess", "happy", "heard", "horse",
  "house", "human", "ideas", "image", "issue", "learn", "light", "local", "lunch", "maybe",
  "month", "music", "north", "occur", "offer", "often", "peace", "place", "plant", "power",
  "price", "proud", "quiet", "ready", "river", "rough", "round", "scale", "scene", "south",
  "speak", "stage", "start", "story", "study", "teach", "tears", "thank", "think", "those",
  "touch", "train", "trees", "truck", "truth", "visit", "voice", "waste", "watch", "white"
];

const randomIndex = getRandomInt(0, wordList.length);

let wordle = wordList[randomIndex].toUpperCase();
let currentRow = 0;
let currentTile = 0;
let isGameOver = false;

const keys = [
  "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P",
  "A", "S", "D", "F", "G", "H", "J", "K", "L", "ENTER",
  "Z", "X", "C", "V", "B", "N", "M", "<<"
]; 

const guessRows = Array.from({ length: 6 }, () =>
  Array.from({ length: 5 }, () => "")
);

function initializeGame() {
  guessRows.forEach((guessRow, guessRowIndex) => {
    const rowElem = document.createElement("div");
    rowElem.setAttribute("id", `guessRow-${guessRowIndex}`);
    rowElem.classList.add("guess-row");

    guessRow.forEach((guess, guessIndex) => {
      const tileElem = document.createElement("div");
      tileElem.setAttribute(
        "id",
        `guessRow-${guessRowIndex}-tile-${guessIndex}`
      );
      tileElem.classList.add("tile");
      rowElem.appendChild(tileElem);
    });

    tileDisplay.appendChild(rowElem);
  });

  keys.forEach((key) => {
    const buttonElem = document.createElement("button");
    buttonElem.textContent = key;
    buttonElem.setAttribute("id", key);
    buttonElem.addEventListener("click", () => handleClick(key));
    keyBoard.appendChild(buttonElem);
  });
}

function getRandomInt(min, max) {
  return Math.floor(Math.random() * (max - min)) + min;
}

function handleClick(key) {
  if (!isGameOver) {
    switch (key) {
      case "<<":
        deleteLetter();
        break;
      case "ENTER":
        checkRow();
        break;
      default:
        addLetter(key);
        break;
    }
  }
}

function addLetter(letter) {
  if (currentRow < 6 && currentTile < 5) {
    const tile = document.getElementById(
      `guessRow-${currentRow}-tile-${currentTile}`
    );
    tile.textContent = letter;
    guessRows[currentRow][currentTile] = letter;
    tile.setAttribute("data", letter);
    currentTile++;
  }
}

function deleteLetter() {
  if (currentTile > 0) {
    currentTile--;
    const tile = document.getElementById(
      `guessRow-${currentRow}-tile-${currentTile}`
    );
    tile.textContent = "";
    guessRows[currentRow][currentTile] = "";
    tile.setAttribute("data", "");
  }
}

function checkRow() {
  const guess = guessRows[currentRow].join("");

  if (currentTile > 4) {
    if (guess === wordle) {
      flipTile();
      showMessage("Magnificent!");
      isGameOver = true;
      return;
    }

    flipTile();

    if (wordle === guess) {
      showMessage("Magnificent!");
      isGameOver = true;
      return;
    }

    if (currentRow >= 5) {
      isGameOver = true;
      showMessage(`Game Over! The word is ${wordle}`);
      return;
    }

    currentRow++;
    currentTile = 0;
  }
}

function showMessage(message) {
  const messageElem = document.createElement("p");
  messageElem.textContent = message;
  messageDisplay.appendChild(messageElem);
  setTimeout(() => messageDisplay.removeChild(messageElem), 2000);
}

function flipTile() {
  const rowTiles = Array.from(
    document.querySelector(`#guessRow-${currentRow}`).childNodes
  );
  let checkWordle = wordle;
  const guess = [];

  rowTiles.forEach((tile) => {
    guess.push({ letter: tile.getAttribute("data"), color: "grey" });
  });

  guess.forEach((guess, index) => {
    if (guess.letter === wordle[index]) {
      guess.color = "green";
      checkWordle = checkWordle.replace(guess.letter, "");
    }
  });

  guess.forEach((guess) => {
    if (checkWordle.includes(guess.letter)) {
      guess.color = "yellow";
      checkWordle = checkWordle.replace(guess.letter, "");
    }
  });

  rowTiles.forEach((tile, index) => {
    const dataLetter = tile.getAttribute("data");

    setTimeout(() => {
      tile.classList.add("flip");
      tile.classList.add(guess[index].color);
      addColorToKey(guess[index].letter, guess[index].color);
    }, 500 * index);
  });
}

function addColorToKey(keyLetter, color) {
  const key = document.getElementById(keyLetter);
  key.classList.add(color);
}

document.addEventListener("keydown", function (event) {
  const key = event.key.toUpperCase();
  if (keys.includes(key)) {
    handleClick(key);
  }
});

initializeGame();

