const testNumbers = require('../testNumbers.js');
const assert = require('chai').assert;

describe('testNumbers test', () => {
    describe('sumNumbers tests', () => {
        it('Should return undefined when parameters are not numbers', () => {
            let expected = undefined;

            assert.strictEqual(testNumbers.sumNumbers('1', 2), expected);
            assert.strictEqual(testNumbers.sumNumbers(undefined, 2), expected);
            assert.strictEqual(testNumbers.sumNumbers(false, 2), expected);
            assert.strictEqual(testNumbers.sumNumbers({}, 2), expected);
            assert.strictEqual(testNumbers.sumNumbers([], 2), expected);

            assert.strictEqual(testNumbers.sumNumbers(2, '1'), expected);
            assert.strictEqual(testNumbers.sumNumbers(2, undefined), expected);
            assert.strictEqual(testNumbers.sumNumbers(2, false), expected);
            assert.strictEqual(testNumbers.sumNumbers(2, {}), expected);
            assert.strictEqual(testNumbers.sumNumbers(2, []), expected);
        });

        it('Should return sum of the numbers rounded to second digit', () => {
            assert.strictEqual(testNumbers.sumNumbers(1, 2), '3.00');
            assert.strictEqual(testNumbers.sumNumbers(15, 10), '25.00');
            assert.strictEqual(testNumbers.sumNumbers(-7, 10), '3.00');
            assert.strictEqual(testNumbers.sumNumbers(-7, -8), '-15.00');
            assert.strictEqual(testNumbers.sumNumbers(3.14, 3.14), '6.28');
            assert.strictEqual(testNumbers.sumNumbers(5.14, 1.147), '6.29');

        });
    });

    describe('numberChecker tests', () => {
        it('Should throw error if input is NaN', () => {
            assert.throw(()=>testNumbers.numberChecker('as'),'The input is not a number!');
            assert.throw(()=>testNumbers.numberChecker({}),'The input is not a number!');
        });

        it('Should return even when number is even', () => {
            let expected = 'The number is even!';
           assert.strictEqual(testNumbers.numberChecker('2'),expected);
           assert.strictEqual(testNumbers.numberChecker(2),expected);
           assert.strictEqual(testNumbers.numberChecker(false),expected);
        });

        it('Should return even when number is odd', () => {
            let expected = 'The number is odd!';
           assert.strictEqual(testNumbers.numberChecker('1'),expected);
           assert.strictEqual(testNumbers.numberChecker(1),expected);
           assert.strictEqual(testNumbers.numberChecker(true),expected);
        });
    });

    describe('averageSumArray tests', ()=>{
        it('Should return average of the array',()=>{
            assert.strictEqual(testNumbers.averageSumArray([10,20,30]),20);
            assert.strictEqual(testNumbers.averageSumArray([-10,-20,-30]),-20);
            assert.strictEqual(testNumbers.averageSumArray([-10,10]),0);
            assert.strictEqual(testNumbers.averageSumArray([0]),0);
        });
    });
});