const assert = require('chai').assert;
const expect = require('chai').expect;
const mathEnforcer = require('../04MathEnforcer.js');

describe('mathEnforcer', () => {
    describe('addFive tests', () => {
        it('Should return undefined when argument is not a number', () => {
            assert.isUndefined(mathEnforcer.addFive(false));
            assert.isUndefined(mathEnforcer.addFive(null));
            assert.isUndefined(mathEnforcer.addFive([1, 2]));
            assert.isUndefined(mathEnforcer.addFive({}));
        });

        it('Should return number with added five to it', () => {
            assert.strictEqual(mathEnforcer.addFive(5), 10);
            assert.strictEqual(mathEnforcer.addFive(-10), -5);
            expect(mathEnforcer.addFive(5.14)).to.be.closeTo(10.14, 0.01);
        });
    });

    describe('subtractTen tests', () => {
        it('Should return undefined when argument is not a number', () => {
            assert.isUndefined(mathEnforcer.subtractTen(false));
            assert.isUndefined(mathEnforcer.subtractTen(null));
            assert.isUndefined(mathEnforcer.subtractTen([1, 2]));
            assert.isUndefined(mathEnforcer.subtractTen({}));
        });

        it('Should subtract 10 from number and return the result', () => {
            assert.strictEqual(mathEnforcer.subtractTen(20), 10);
            assert.strictEqual(mathEnforcer.subtractTen(-2), -12);
            expect(mathEnforcer.subtractTen(10.15)).to.be.closeTo(0.15, 0.01);

        });
    });

    describe('sum tests', () => {
        it('Should return undefined when some of arguments is not a number', () => {
            assert.isUndefined(mathEnforcer.sum(null, 1));
            assert.isUndefined(mathEnforcer.sum(1, null));
            assert.isUndefined(mathEnforcer.sum([1, 2], 2));
            assert.isUndefined(mathEnforcer.sum({}, 3));
            assert.isUndefined(mathEnforcer.sum(1, false));
        });

        it('Should return the sum of numbers', () => {
            assert.strictEqual(mathEnforcer.sum(2, 8), 10);
            assert.strictEqual(mathEnforcer.sum(-5, -10), -15);
            expect(mathEnforcer.sum(3.14, 3.14)).to.be.closeTo(6.28, 0.01);
        });
    });
});