const assert = require('chai').assert;
const isOddOrEven = require('../02EvenOrOdd.js');

describe('Tests for isOddOrEven', () => {
    it('Should return undefined if argument is not a string', () => {
        let expected = undefined;

        assert.equal(isOddOrEven(123), expected);
        assert.equal(isOddOrEven(false), expected);
        assert.equal(isOddOrEven(undefined), expected);
        assert.equal(isOddOrEven({}), expected);
        assert.equal(isOddOrEven([]), expected);
    });

    it('Should return even if argument length is even', () => {
        let expected = 'even';
        let actual = isOddOrEven('ab');

        assert.equal(actual, expected);
    });

    it('Should return odd if argument length is odd', () => {
        let expected = 'odd';
        let actual = isOddOrEven('abc');

        assert.equal(actual, expected);
    });
});