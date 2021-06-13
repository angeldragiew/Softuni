function solve(input) {
    let products = {};

    for (const row of input) {
        let [productName, price] = row.split(' : ')
        let group = productName[0];

        if (!products.hasOwnProperty(group)) {
            products[group] = {};
        }
        products[group][productName] = price;
    }

    let result = [];
    for (const group of Object.keys(products).sort((a, b) => a.localeCompare(b))) {
        result.push(group);
        for (const [key, value] of Object.entries(products[group]).sort((a, b) => a[0].localeCompare(b[0]))) {
            result.push(`  ${key}: ${value}`);
        }
    }

    return result.join('\n')
}


// solve(['Appricot : 20.4',
//     'Fridge : 1500',
//     'TV : 1499',
//     'Deodorant : 10',
//     'Boiler : 300',
//     'Apple : 1.25',
//     'Anti-Bug Spray : 15',
//     'T-Shirt : 10']
// );

console.log(solve(['Banana : 2',
    'Rubic\'s Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']
));