function solve(input){
    let max = Number.MIN_SAFE_INTEGER;
    input.forEach(row => {   
       let currMax = Math.max(...row);
       if(currMax>max){
           max = currMax;
       }
    });

    return max;
}

console.log(solve([[20, 50, 10],
    [8, 33, 145]]
   ));

   console.log(solve([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]
   ));