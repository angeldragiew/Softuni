function solve(numbers) {
    let sorted = [];

    let n = numbers.length;
    numbers.sort((a, b) => a - b);
    for (let i = 0; i < n; i++) {
        if (i % 2 == 0) {
            sorted.push(numbers.shift());
        } else {
            sorted.push(numbers.pop());
        }
    }

    return sorted;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));