function solve(arr) {
    const reducer = (a, x, i) => {
        if (i % 2 != 0) {
            a.push(x);
        }
        return a;
    };

    return arr.reduce(reducer, []).map(x => x * 2).reverse().join(' ');
}

console.log(solve([10, 15, 20, 25]));