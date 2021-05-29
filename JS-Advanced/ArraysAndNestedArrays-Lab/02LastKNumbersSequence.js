function solve(n, k){
    let result = [1];
    for (let i = 0; i < n-1; i++) {
       let numsToSum = result.slice(-k);
        
       let sum = numsToSum.reduce((a,x)=>a+x, 0);

       result.push(sum);
    }
    return result;
}

console.log(solve(6, 3));