function solve(input) {
    const { model, power, color, carriage, wheelsize } = input;
    let createdCar = {
        model: model,
    }

    if (power <= 90) {
        createdCar.engine = { power: 90, volume: 1800 };;
    } else if (power <= 120) {
        createdCar.engine = { power: 120, volume: 2400 };;
    } else {
        createdCar.engine = { power: 200, volume: 3500 };;
    }

    createdCar.carriage = {
        type: carriage,
        color: color
    };

    createdCar.wheels = wheelsize % 2 != 0 ?
        new Array(4).fill(wheelsize) :
        new Array(4).fill(wheelsize-1);


    return createdCar;
}



console.log(solve({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}

));