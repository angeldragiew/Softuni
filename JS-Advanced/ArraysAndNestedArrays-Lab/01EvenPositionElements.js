function solve(input) {
    const reducer = (a, x, i, arr) => {
        if(i%2==0){
            a.push(x);
        }
        return a;
    };

    let result = input.reduce(reducer,[]);
    console.log(result.join(' '));
}

function secondSolve(input){
    let result = [];
    for (let index = 0; index < input.length; index++) {
        if(index%2==0){
            result.push(input[index]);
        }   
    }
    return result.join(' ');
}

solve(['20', '30', '40', '50', '60']);
console.log(secondSolve(['20', '30', '40', '50', '60']));