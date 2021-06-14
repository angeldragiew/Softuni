function extract(content) {
    let givenText = document.getElementById(content).textContent;
    let regex = /\(([^)]+)\)/g;

    let text = givenText.match(regex).map(x=>x.slice(1, x.length-1)).join('; ');

    return text;
}