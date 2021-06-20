const sum = require('../04SumOfNumbers.js');
const assert = require('chai').assert;

describe('Sum tests', () => {
    it('Should return the sum of all elements', () => {
        let input = [1, 2, 3, -2];
        let expected = 4;
        let actual = sum(input);

        assert.equal(actual,expected);
    });
});