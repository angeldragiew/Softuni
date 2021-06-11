function solve(input) {
    let obj = {};
    for (let i = 0; i < input.length; i+=2) {
        let food = input[i];
        let calories = Number(input[i+1]);
        
        obj[food]=calories;
    }

    return obj;
}


console.log(solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));