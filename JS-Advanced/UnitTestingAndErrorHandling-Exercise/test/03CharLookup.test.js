const lookupChar = require('../03CharLookup.js');
const assert = require('chai').assert;

describe('Tests for lookupChar', () => {
    it('Should return undefined when first argument is not a string', () => {
        let expected = undefined;

        assert.equal(lookupChar(1, 1), expected);
        assert.equal(lookupChar(false, 1), expected);
        assert.equal(lookupChar(null, 1), expected);
        assert.equal(lookupChar([], 1), expected);
        assert.equal(lookupChar({}, 1), expected);
    });

    it('Should return undefined when second argument is not an integer', () => {
        let expected = undefined;

        assert.equal(lookupChar('Angel', 3.14), expected);
        assert.equal(lookupChar('Angel', NaN), expected);
        assert.equal(lookupChar('Angel', null), expected);
        assert.equal(lookupChar('Angel', [1, 2, 3]), expected);
        assert.equal(lookupChar('Angel', {}), expected);
        assert.equal(lookupChar('Angel', false), expected);
    });

    it('Should return Incorrect index when index argument is less than zero', () => {
        let expected = 'Incorrect index';

        assert.equal(lookupChar('Angel', -5), expected);
    });

    it('Should return Incorrect index when index argument is more than or equal to string argument length', () => {
        let expected = 'Incorrect index';

        assert.equal(lookupChar('Angel', 5), expected);
        assert.equal(lookupChar('Angel', 10), expected);
    });

    it('Should return char at given index if both of arguments are valid', () => {
        let string = 'Angel';
        let index = 0;
        let expected = 'A';
        let actual = lookupChar(string, index);

        assert.equal(actual, expected);
        assert.equal(lookupChar('Petar', 4), 'r');
    });
});