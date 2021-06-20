function subSum(arr, start, end) {
    if (Array.isArray(arr) === false) {
        return NaN;
    }
    if (start < 0) {
        start = 0;
    }
    if (end >= arr.length) {
        end = arr.length - 1;
    }

    let sum = arr.slice(start, end+1).reduce((acc, el) => acc + Number(el), 0);
    return sum;
}

console.log(subSum('text', 0, 2));