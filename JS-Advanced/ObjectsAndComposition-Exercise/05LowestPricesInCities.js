function solve(input) {
    let products = {};
    for (const row of input) {
        let [town, product, price] = row.split(' | ');
        price = Number(price);
        if (products.hasOwnProperty(product)) {
            products[product][town] = price;
        } else {
            products[product] = {};
            products[product][town] = price;
        }
    }



    for (const el in products) {
        let townName = '';
        let lowestPrice = Number.MAX_SAFE_INTEGER;
        for (const town in products[el]) {
            if (products[el][town] < lowestPrice) {
                lowestPrice = products[el][town];
                townName = town;
            }
        }
        console.log(`${el} -> ${lowestPrice} (${townName})`);
    }
}


solve(['Sofia City | Audi | 100000',
    'Sofia City | BMW | 100000',
    'Sofia City | Mitsubishi | 10000',
    'Sofia City | Mercedes | 10000',
    'Sofia City | NoOffenseToCarLovers | 0',
    'Mexico City | Audi | 1000',
    'Mexico City | BMW | 99999',
    'New York City | Mitsubishi | 10000',
    'New York City | Mitsubishi | 1000',
    'Mexico City | Audi | 100000',
    'Washington City | Mercedes | 1000']
);