function calc() {
    let num1Element = document.getElementById('num1');
    let num2Element = document.getElementById('num2');

    let num1 = Number(num1Element.value);
    let num2 = Number(num2Element.value);

    let sumElement = document.getElementById('sum');
    sumElement.value = num1 + num2;
}
