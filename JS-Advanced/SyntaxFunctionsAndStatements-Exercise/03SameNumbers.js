function solve(number) {
    let numbersArray = String(number).split('').map(x => +x);

    let areSame = true;
    for (let i = 0; i < numbersArray.length - 1; i++) {
        if (numbersArray[i] !== numbersArray[i + 1]) {
            areSame = false;
            break;
        }
    }

    console.log(areSame);
    console.log(numbersArray.reduce((a, b) => a + b, 0));
}

solve(2222222);
solve(1234);