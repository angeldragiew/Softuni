function solve(arr) {
    let isMagic = true;

    let firstRowSum = arr[0].reduce(((acc, x) => acc + x), 0);

    for (let i = 1; i < arr.length; i++) {
        const currRow = arr[i];
        let currRowSum = currRow.reduce(((acc, x) => acc + x), 0);
        if (currRowSum !== firstRowSum) {
            isMagic = false;
            return isMagic;
        }
    }

    for (let col = 0; col < arr[0].length; col++) {
        let colSum = 0;
        for (let row = 0; row < arr.length; row++) {
            const element = arr[row][col];
            colSum += element;
        }
        if (colSum !== firstRowSum) {
            isMagic = false;
            return isMagic;
        }
    }
    return isMagic;
}

console.log(solve([
    [4, 5, 6],
    [4, 5, 6],
    [5, 5, 5]
]));

// console.log(solve([[11, 32, 45],
// [21, 0, 1],
// [21, 1, 1]]
// ));

// console.log(solve([[1, 0, 0],
// [0, 0, 1],
// [0, 1, 0]]
// ));
