function solve(arr, rotations) {
    rotations%=arr.length;
    for (let i = 0; i < rotations; i++) {
        let currElement = arr.pop();
        arr.unshift(currElement);
    }
    return arr.join(' ');
}

console.log(solve(['1',
    '2',
    '3',
    '4'],
    2
));

console.log(solve(['Banana',
    'Orange',
    'Coconut',
    'Apple'],
    15
));