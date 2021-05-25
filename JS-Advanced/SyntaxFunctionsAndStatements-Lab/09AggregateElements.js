function solve(array) {
    let sum = 0;
    let inverseSum = 0;
    let concatenated = '';

    for (let i = 0; i < array.length; i++) {
        sum += array[i];
        inverseSum += array[i] ** -1;
        concatenated += array[i];
    }

    console.log(sum);
    console.log(inverseSum);
    console.log(concatenated);
}

solve([2, 4, 8, 16]);