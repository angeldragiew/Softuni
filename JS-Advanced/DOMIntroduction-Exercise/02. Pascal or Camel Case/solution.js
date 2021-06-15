function solve() {
  let textElement = document.getElementById('text');
  let namingConventionElement = document.getElementById('naming-convention');

  let words = textElement.value.split(' ').map(x => x.toLowerCase());
  let result = '';
  if (namingConventionElement.value === 'Pascal Case') {
    result = words.map(x => x.charAt(0).toUpperCase() + x.slice(1)).join('');
  } else if (namingConventionElement.value === 'Camel Case') {
    result = words[0] + words.slice(1).map(x => x.charAt(0).toUpperCase() + x.slice(1)).join('');
  } else {
    result = "Error!";
  }

  let resultElement = document.getElementById('result');
  resultElement.textContent = result;
}