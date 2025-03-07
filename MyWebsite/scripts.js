let currentInput = "";
let exchangeRates = {};

// Function to append values to the display
function appendToDisplay(value) {
    currentInput += value;
    document.getElementById('display').value = currentInput;
}

// Function to append decimal point (either period or comma)
function appendToDecimal() {
    if (!currentInput.includes('.') && !currentInput.includes(',')) {
        currentInput += '.';
        document.getElementById('display').value = currentInput;
    }
}

// Function to toggle the sign of the current number
function toggleSign() {
    if (currentInput.startsWith('-')) {
        currentInput = currentInput.substring(1);
    } else {
        currentInput = '-' + currentInput;
    }
    document.getElementById('display').value = currentInput;
}

// Function to clear the display
function clearDisplay() {
    currentInput = "";
    document.getElementById('display').value = currentInput;
}

// Function to calculate the result of the arithmetic expression
function calculate() {
    try {
        let result = eval(currentInput);
        document.getElementById('display').value = result;
        currentInput = result.toString();
    } catch (error) {
        document.getElementById('display').value = "Error";
        currentInput = "";
    }
}

// Function to calculate the square of the current number
function square() {
    let num = parseFloat(currentInput);
    if (isNaN(num)) {
        document.getElementById('display').value = "Error";
        currentInput = "";
        return;
    }
    currentInput = (num * num).toString();
    document.getElementById('display').value = currentInput;
}

// Function to calculate the reciprocal (1/x) of the current number
function reciprocal() {
    let num = parseFloat(currentInput);
    if (isNaN(num) || num === 0) {
        document.getElementById('display').value = "Error";
        currentInput = "";
        return;
    }
    currentInput = (1 / num).toString();
    document.getElementById('display').value = currentInput;
}

// Function to fetch currency exchange rates from the NBP API
function fetchExchangeRates() {
    const fixedDate = '2025-02-03';

    // Fetch Rates
    $.getJSON(`https://api.nbp.pl/api/exchangerates/rates/a/gbp/${fixedDate}/?format=json`, function (data) {
        exchangeRates.GBP = data.rates[0].mid;
    });

    $.getJSON(`https://api.nbp.pl/api/exchangerates/rates/a/eur/${fixedDate}/?format=json`, function (data) {
        exchangeRates.EUR = data.rates[0].mid;
    });

    $.getJSON(`https://api.nbp.pl/api/exchangerates/rates/a/usd/${fixedDate}/?format=json`, function (data) {
        exchangeRates.USD = data.rates[0].mid;
    });
}

// Function to convert PLN to selected currency
function convertCurrency(currency) {
    let plnAmount = parseFloat(currentInput.replace(',', '.'));

    if (isNaN(plnAmount)) {
        document.getElementById('result').innerText = "Please enter a valid number";
        document.getElementById('amount').style.display = "none";
        return;
    }

    if (!exchangeRates[currency]) {
        document.getElementById('result').innerText = "Error fetching exchange rate.";
        document.getElementById('amount').style.display = "none";
        return;
    }

    let conversionRate = exchangeRates[currency];
    let convertedAmount = plnAmount / conversionRate;

    document.getElementById('result').innerText = `${plnAmount} PLN = ${convertedAmount.toFixed(2)} ${currency}`;
    document.getElementById('amount').style.display = "block";
}


// Function to fetch and display rates
function fetchAndDisplayRates() {
    document.getElementById('rates').style.display = 'none';

    const fixedDate = '2025-02-03';

    // Fetch Rates
    $.getJSON(`https://api.nbp.pl/api/exchangerates/rates/a/gbp/${fixedDate}/?format=json`, function (data) {
        const gbpRate = data.rates[0].mid;
        document.getElementById('gbp-rate').innerText = `GBP: ${gbpRate} PLN`;
    });

    $.getJSON(`https://api.nbp.pl/api/exchangerates/rates/a/eur/${fixedDate}/?format=json`, function (data) {
        const eurRate = data.rates[0].mid;
        document.getElementById('eur-rate').innerText = `EUR: ${eurRate} PLN`;
    });

    $.getJSON(`https://api.nbp.pl/api/exchangerates/rates/a/usd/${fixedDate}/?format=json`, function (data) {
        const usdRate = data.rates[0].mid;
        document.getElementById('usd-rate').innerText = `USD: ${usdRate} PLN`;
    });

    document.getElementById('rates').style.display = 'block';
}

// Add event listener to the button for fetching exchange rates
document.querySelector('.btn-full').addEventListener('click', fetchAndDisplayRates);

// Call the fetchExchangeRates function when the page loads
$(document).ready(function () {
    fetchExchangeRates();
});
