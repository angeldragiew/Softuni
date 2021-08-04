function solve(input) {
    let carCompany = new Map();

    for (const carInfo of input) {
        let [brand, model, producedCars] = carInfo.split(' | ');
        producedCars = Number(producedCars);

        if (!carCompany.has(brand)) {
            carCompany.set(brand, new Map());
        }

        let models = carCompany.get(brand);

        if (!models.has(model)) {
            models.set(model, 0);
        }
        models.set(model, models.get(model) + producedCars);
    }

    let result = [];

    for (const [brand, models] of carCompany) {
        result.push(brand);
        for (const [model, producedCars] of models) {
            result.push(`###${model} -> ${producedCars}`);
        }
    }
    return result.join('\n');
}

console.log(solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
));