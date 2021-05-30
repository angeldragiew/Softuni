function solve(pies, firstPie, secondPie) {
    let startIndex = pies.findIndex(x => x === firstPie);
    let endIndex = pies.findIndex(x => x === secondPie);

    return pies.slice(startIndex, endIndex + 1);
}

console.log(solve(['Pumpkin Pie',
    'Key Lime Pie',
    'Cherry Pie',
    'Lemon Meringue Pie',
    'Sugar Cream Pie'],
    'Key Lime Pie',
    'Lemon Meringue Pie'
));