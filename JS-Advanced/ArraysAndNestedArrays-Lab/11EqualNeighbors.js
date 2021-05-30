function solve(input) {
    let neighborsCount = 0;
    let rowLength = input.length;
    let colLength = input[0].length;
    for (let row = 0; row < input.length; row++) {
        for (let col = 0; col < input[0].length; col++) {
            neighborsCount += checkForEqualNeighbor(row, col);
        }
    }
    return neighborsCount / 2;

    function checkForEqualNeighbor(row, col) {
        let up = row - 1 >= 0 ? input[row - 1][col] : undefined;
        let down = row + 1 < input.length ? input[row + 1][col] : undefined;
        let left = col - 1 >= 0 ? input[row][col - 1] : undefined;
        let right = col + 1 < input[0].length ? input[row][col + 1] : undefined;

        let element = input[row][col];

        let neighbors = 0;
        if (up === element) {
            neighbors++;
        }
        if (down === element) {
            neighbors++;
        }
        if (left === element) {
            neighbors++;
        }
        if (right === element) {
            neighbors++;
        }

        return neighbors;
    }
}


console.log(solve(
    [[2, 2, 5, 7, 4],
    [4, 0, 5, 3, 4],
    [2, 5, 5, 4, 2]]
));
console.log(solve([['2', '3', '4', '7', '0'],
['4', '0', '5', '3', '4'],
['2', '3', '5', '4', '2'],
['9', '8', '7', '5', '4']]
));

console.log(solve([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]
));
