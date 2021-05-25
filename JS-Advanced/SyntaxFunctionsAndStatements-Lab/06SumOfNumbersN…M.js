function solve(firstNum, secondNum) {
    let num1 = Number(firstNum);
    let num2 = Number(secondNum);

    let result = 0;
    for (let i = num1; i <= num2; i++) {
        result += i;
    }

    console.log(result);
}

solve('1', '5');