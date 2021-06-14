function extractText() {
    let listElemements = document.querySelectorAll('#items li');
    let resultElement = document.getElementById('result');

    let result = [];
    for (const el of listElemements) {
        result.push(el.textContent);
    }
    resultElement.textContent += result.join('\n');
}