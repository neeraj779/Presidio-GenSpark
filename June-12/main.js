// Custom Higher Order Function - 1
function checkingEvenNumbers(num) {
  return num % 2 == 0; //boolean
}

function filteringEvenNumbers(numbers, callbackFunc) {
  let numberArray = [];
  for (let value of numbers) {
    if (callbackFunc(value)) numberArray.push(value);
  }
  return numberArray;
}

let arrayOfNumbers = [22, 45, 99, 3, 8, 44];
console.log(filteringEvenNumbers(arrayOfNumbers, checkingEvenNumbers));

// Custom Higher Order Function - 2
function checkingOddNumbers(num) {
  return num & 1;
}

function filteringOddNumbers(numbers, callbackFunc) {
  let numberArray = [];
  for (let value of numbers) {
    if (callbackFunc(value)) numberArray.push(value);
  }
  return numberArray;
}

arrayOfNumbers = [22, 45, 99, 3, 8, 44];
console.log(filteringOddNumbers(arrayOfNumbers, checkingOddNumbers));

// Funtion which returns another function
function filteringEvenNumbersOuter(numbers, callbackFunc) {
  let numberArray = [];
  for (let value of numbers) {
    if (callbackFunc(value)) numberArray.push(value);
  }
  return () => console.log(numberArray);
}

arrayOfNumbers = [22, 45, 99, 3, 8, 44];
let evenNumbers = filteringEvenNumbersOuter(
  arrayOfNumbers,
  checkingEvenNumbers
);
evenNumbers();

// inbuilt higher order function
// 1. Reduce
let arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
let sum = arr.reduce((a, b) => a + b);

console.log(sum);

// 2. ForEach
arr.forEach((value, index) => console.log(value, index));

// 3. Sort
let arr2 = [7, 3, 5, 1];
arr2.sort((a, b) => a - b); // ascending order
console.log(arr2);
arr2.sort((a, b) => b - a); // descending order
console.log(arr2);
