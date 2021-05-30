function solve(input) {
    let firstDiagonalSum = 0;
    let secDiagonalSum = 0;

    let firstDiagonalIndex = 0;
    let secDiagonalIndex = input[0].length - 1;

    input.forEach(row => {
        firstDiagonalSum += row[firstDiagonalIndex++];
        secDiagonalSum += row[secDiagonalIndex--];
    });

    return `${firstDiagonalSum} ${secDiagonalSum}`;
}

console.log(solve([[20, 40],
[10, 60]]
));