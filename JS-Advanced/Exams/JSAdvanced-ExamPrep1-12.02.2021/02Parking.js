class Parking {
    constructor(capacity, vehicles = []) {
        this.capacity = Number(capacity);
        this.vehicles = vehicles;
    }



    addCar(carModel, carNumber) {
        if (this.vehicles.length === this.capacity) {
            throw new Error("Not enough parking space.")
        }
        let car = {
            carModel,
            carNumber,
            payed: false
        }
        this.vehicles.push(car);
        return `The ${carModel}, with a registration number ${carNumber}, parked.`;
    }

    removeCar(carNumber) {
        let carToRemove = this.vehicles.find(v => v.carNumber === carNumber);
        if (carToRemove === undefined) {
            throw new Error("The car, you're looking for, is not found.");
        }
        if (carToRemove.payed === false) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`);
        }
        let index = this.vehicles.indexOf(carToRemove);
        this.vehicles.splice(index, 1);
        return `${carNumber} left the parking lot.`;
    }

    pay(carNumber) {
        let carToPay = this.vehicles.find(v => v.carNumber === carNumber);
        if (carToPay === undefined) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        }
        if (carToPay.payed === true) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`);
        }
        carToPay.payed = true;
        return `${carNumber}'s driver successfully payed for his stay.`;
    }

    getStatistics(carNumber) {
        if (carNumber === undefined) {
            let result = [];
            result.push(`The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.`);

            for (const car of this.vehicles.sort((a, b) => a.carModel.localeCompare(b.carModel))) {
                let payed = car.payed ? 'Has payed' : 'Not payed';
                result.push(`${car.carModel} == ${car.carNumber} - ${payed}`)
            }
            return result.join('\n');
        } else {
            let car = this.vehicles.find(v => v.carNumber === carNumber);
            let payed = car.payed ? 'Has payed' : 'Not payed';
            return `${car.carModel} == ${car.carNumber} - ${payed}`;
        }
    }
}

const parking = new Parking(12);

console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.getStatistics());

console.log(parking.pay("TX3691CA"));
console.log(parking.removeCar("TX3691CA"));
