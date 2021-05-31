function solve(arr) {
    let maxValue = Number.MIN_SAFE_INTEGER;
    let result = [];
    result = arr.filter((el) => {
        if (el >= maxValue) {
            maxValue = el;
            return el;
        }
    })

    return result;
}

function solve(arr) {
    let maxValue = Number.MIN_SAFE_INTEGER;

    function reducer(a, x) {
        if (x >= maxValue) {
            maxValue = x;
            a.push(x);
        }
        return a;
    }
    let result = arr.reduce(reducer, []);

    return result;
}

console.log(solve([-12,2, 123, -123]));

console.log(solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
));

console.log(solve([1,
    2,
    3,
    4]
));

console.log(solve([20,
    3,
    2,
    15,
    6,
    1]
));