const assert = require('chai').assert;
const pizzUni = require('../03PizzaPlace.js');

describe("Tests …", () => {
    describe('makeAnOrder tests', () => {
        it('Should throw when obj has no orderedPizza', () => {
            let obj = {
                orderedDrink: 'Drink'
            }

            assert.throw(() => pizzUni.makeAnOrder(obj), 'You must order at least 1 Pizza to finish the order.');
        });

        it('Should return result with ordered pizza only if there is no drink', () => {
            let obj = {
                orderedPizza: 'Margarita'
            }

            let expected = `You just ordered ${obj.orderedPizza}`;
            let actual = pizzUni.makeAnOrder(obj);

            assert.strictEqual(actual, expected);
        });

        it('Should return result with ordered pizza and drink', () => {
            let obj = {
                orderedPizza: 'Margarita',
                orderedDrink: 'Coca-Cola'
            }

            let expected = `You just ordered ${obj.orderedPizza} and ${obj.orderedDrink}.`;
            let actual = pizzUni.makeAnOrder(obj);

            assert.strictEqual(actual, expected);
        });
    });

    describe('getRemainingWork tests', () => {
        it('Should return pizzas that are still preparing', () => {
            let pizza1 = {
                pizzaName: 'Margarita',
                status: 'preparing'
            };
            let pizza2 = {
                pizzaName: 'Margarita',
                status: 'ready'
            };
            let pizza3 = {
                pizzaName: 'Margarita',
                status: 'preparing'
            };
            let pizza4 = {
                pizzaName: 'Margarita',
                status: 'ready'
            };
            let arr = [pizza1, pizza2, pizza3, pizza4];
            let actual = pizzUni.getRemainingWork(arr);
            let expected = `The following pizzas are still preparing: ${pizza1.pizzaName}, ${pizza3.pizzaName}.`;

            assert.strictEqual(actual, expected);
        });
    });

    describe('getRemainingWork tests', () => {
        it('Should return nothing cuz there is no job', () => {
            let pizza1 = {
                pizzaName: 'Margarita',
                status: 'ready'
            };
            let pizza2 = {
                pizzaName: 'Margarita',
                status: 'ready'
            };
            let pizza3 = {
                pizzaName: 'Margarita',
                status: 'ready'
            };
            let pizza4 = {
                pizzaName: 'Margarita',
                status: 'ready'
            };
            let arr = [pizza1, pizza2, pizza3, pizza4];
            let actual = pizzUni.getRemainingWork(arr);
            let expected = 'All orders are complete!';

            assert.strictEqual(actual, expected);
        });
    });

    describe('getRemainingWork tests', () => {
        it('Should return sum with 10% discount if ordertype is carry out', () => {
            let totalSum = 100;
            let typeOfOrder = 'Carry Out';

            let expected = 90;
            let actual = pizzUni.orderType(totalSum, typeOfOrder);
            assert.strictEqual(actual, expected);
        });

        it('Should return sum if ordertype is Delivery', () => {
            let totalSum = 100;
            let typeOfOrder = 'Delivery';

            let expected = 100;
            let actual = pizzUni.orderType(totalSum, typeOfOrder);
            assert.strictEqual(actual, expected);
        });
    });

});
