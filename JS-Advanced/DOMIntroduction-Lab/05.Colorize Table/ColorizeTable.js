function colorize() {
    let tdElements = document.querySelectorAll('table tr');

    let index = 0;
    for (const tr of tdElements) {
        if (index % 2 !== 0) {
            tr.style.background = 'teal';
        }
        index++;
    }
}