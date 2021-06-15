function solve() {
  let inputElement = document.getElementById('input');
  let text = inputElement.value;

  let sentences = text.split('.').filter(s => s !== '').map(s => s + '.');

  let paragraphCount = Math.ceil(sentences.length / 3);

  let outputElement = document.getElementById('output');
  for (let i = 0; i < paragraphCount; i++) {
    let currParagraph = sentences.splice(0, 3).join('');
    outputElement.innerHTML += `<p>${currParagraph}</p>`;
  }
}