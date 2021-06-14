function sumTable() {
    let costTdElements = Array.from(document.querySelectorAll('td:nth-child(2)'));
    let sumElement = document.getElementById('sum');

    let [cost1, cost2, cost3] = costTdElements;

    sumElement.textContent =
        Number(cost1.textContent) +
        Number(cost2.textContent) +
        Number(cost3.textContent);
}