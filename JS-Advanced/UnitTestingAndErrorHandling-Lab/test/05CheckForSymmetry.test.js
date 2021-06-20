let isSymmetric = require('../05CheckForSymmetry.js');
const assert = require('chai').assert;

describe('Tests for isSymmetric', () => {
    it('Should return true when array is symetric', () => {
        let input = [1, 2, 1];
        let actual = isSymmetric(input);
        let expected = true;
        assert.equal(actual, expected);
    });

    it('Should return false when the input is not an array', () => {
        assert.equal(isSymmetric(0), false);
        assert.equal(isSymmetric(true), false);
        assert.equal(isSymmetric(NaN), false);
        assert.equal(isSymmetric('text'), false);
        assert.equal(isSymmetric({}), false);
    });

    it('Should return false when array is not symetric', () => {
        let input = [1, 2, 3];
        let expected = false;
        let actual = isSymmetric(input);

        assert.equal(actual, expected);
    });
    it('Should return false when input is of type [1,2,\'1\']', () => {
        let input = [1, 2, '1'];
        let expected = false;
        let actual = isSymmetric(input);

        assert.equal(actual, expected);
    });
});