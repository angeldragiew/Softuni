function solve(num) {
    let size = num;
    if (num === undefined) {
        size = 5;
    }


    for (let i = 0; i < size; i++) {
        let result = '*';
        for (let z = 1; z < size; z++) {
            result += ' *';
        }
        console.log(result);
    }
}

solve();