function solve(first, second, third) {
    let numbers = [first, second, third];

    let largest = Math.max(...numbers);

    console.log(`The largest number is ${largest}.`);
}

solve(5, -3, 16);