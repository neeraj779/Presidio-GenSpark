let currentPage = 1;
const quotesPerPage = 5;
let totalQuotes = 0;
let totalPages = 0;
let allQuotes = [];

async function fetchAllQuotes() {
  try {
    let response = await fetch("https://dummyjson.com/quotes");
    let data = await response.json();

    if (!data || !data.total) {
      throw new Error("Failed to fetch total count");
    }

    const totalQuotes = data.total;

    response = await fetch(`https://dummyjson.com/quotes?limit=${totalQuotes}`);
    data = await response.json();

    if (!data || !data.quotes) {
      throw new Error("Failed to fetch quotes");
    }

    allQuotes = data.quotes;
    totalPages = Math.ceil(totalQuotes / quotesPerPage);

    console.log(allQuotes);
    console.log(totalQuotes);
    displayQuotes(getCurrentPageQuotes());
  } catch (error) {
    console.error("Error fetching quotes:", error);
  }
}

function displayQuotes(quotes) {
  const container = document.getElementById("quotes-container");
  container.innerHTML = "";
  quotes.forEach((quote) => {
    const quoteCard = document.createElement("div");
    quoteCard.classList.add("quote-card");
    quoteCard.innerHTML = `
      <p><strong>${quote.author}</strong></p>
      <p>${quote.quote}</p>
    `;
    container.appendChild(quoteCard);
  });

  updatePaginationButtons();
}

function updatePaginationButtons() {
  document
    .getElementById("prev-btn")
    .classList.toggle("disabled-btn", currentPage === 1);
  document
    .getElementById("next-btn")
    .classList.toggle("disabled-btn", currentPage === totalPages);
}

function getCurrentPageQuotes() {
  const startIndex = (currentPage - 1) * quotesPerPage;
  const endIndex = startIndex + quotesPerPage;
  return allQuotes.slice(startIndex, endIndex);
}

function nextPage() {
  if (currentPage < totalPages) {
    currentPage++;
    displayQuotes(getCurrentPageQuotes());
  }
}

function prevPage() {
  if (currentPage > 1) {
    currentPage--;
    displayQuotes(getCurrentPageQuotes());
  }
}

function searchByAuthor() {
  const searchValue = document
    .getElementById("author-search")
    .value.trim()
    .toLowerCase();
  if (searchValue === "") {
    displayQuotes(getCurrentPageQuotes());
    return;
  }
  const filteredQuotes = allQuotes.filter((quote) =>
    quote.author.toLowerCase().includes(searchValue)
  );
  currentPage = 1;
  displayQuotes(filteredQuotes);
}

function sortQuotesByAuthor(ascending = true) {
  allQuotes.sort((a, b) => {
    const authorA = a.author.toLowerCase();
    const authorB = b.author.toLowerCase();
    if (ascending) {
      return authorA.localeCompare(authorB);
    } else {
      return authorB.localeCompare(authorA);
    }
  });
}

function sortAndDisplay(ascending) {
  sortQuotesByAuthor(ascending);
  currentPage = 1;
  displayQuotes(getCurrentPageQuotes());
}

fetchAllQuotes();
