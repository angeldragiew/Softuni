let createCalculator = require('../07AddSubtract.js');
let assert = require('chai').assert;

describe('Tests for CreateCalculator', function () {
    it('Returned object from createCalculator should have add,substract,get', () => {
        let calc = createCalculator();
        let actual = calc.hasOwnProperty('add') &&
            calc.hasOwnProperty('subtract') &&
            calc.hasOwnProperty('get');

        let expected = true;

        assert.equal(actual, expected);
    });

    it('createCalc add function should add given number to internal sum', () => {
        let calc = createCalculator();
        calc.add(10);
        let actual = calc.get();
        let expected = 10;

        assert.equal(actual, expected);
    });

    it('createCalc add function should parse given number and add it to internal sum', () => {
        let calc = createCalculator();
        calc.add('5');
        let actual = calc.get();
        let expected = 5;

        assert.equal(actual, expected);
    });

    it('createCalc subtract function should subtract given number from internal sum', () => {
        let calc = createCalculator();
        calc.subtract(10);
        let actual = calc.get();
        let expected = -10;

        assert.equal(actual, expected);
    });

    it('createCalc subtract function should parse given number and subtract it from internal sum', () => {
        let calc = createCalculator();
        calc.add('-10');
        let actual = calc.get();
        let expected = -10;

        assert.equal(actual, expected);
    });

    it('createCalc get function should return internal sum', () => {
        let calc = createCalculator();
        let actual = calc.get();
        let expected = 0;

        assert.equal(actual, expected);
    });

});