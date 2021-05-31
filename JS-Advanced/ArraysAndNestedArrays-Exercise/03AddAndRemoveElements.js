function solve(input) {
    let arr = [];

    for (let i = 0; i < input.length; i++) {
        const command = input[i];

        if (command === 'add') {
            arr.push(i + 1);
        } else {
            arr.pop();
        }
    }

    if (arr.length === 0) {
        return 'Empty';
    } else {
        return arr.join('\n');
    }
}

// console.log(solve(['add',
//     'add',
//     'add',
//     'add']
// ));

// console.log(solve(['add',
//     'add',
//     'remove',
//     'add',
//     'add']
// ));

console.log(solve(['remove',
    'remove',
    'remove']
));