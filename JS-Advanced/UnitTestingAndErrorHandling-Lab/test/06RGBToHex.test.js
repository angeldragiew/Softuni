let rgbToHexColor = require('../06RGBToHex.js');
let assert = require('chai').assert;

describe('Tests for rgbToHexColor', () => {
    it('Should pass when all color inputs are valid', () => {
        let [red, green, blue] = [255, 158, 170];
        let expected = '#FF9EAA';
        let actual = rgbToHexColor(red, green, blue);

        assert.equal(actual, expected);
    });
    it('Should return #000000 for (0, 0, 0)', () => {
        let [red, green, blue] = [0, 0, 0];
        let expected = '#000000';
        let actual = rgbToHexColor(red, green, blue);

        assert.equal(actual, expected);
    });

    it('Should return #0C0D0E for (12, 13, 14)', () => {
        let [red, green, blue] = [12, 13, 14];
        let expected = '#0C0D0E';
        let actual = rgbToHexColor(red, green, blue);

        assert.equal(actual, expected);
    });

    it('Should return #FFFFFF for (255, 255, 255)', () => {
        let [red, green, blue] = [255, 255, 255];
        let expected = '#FFFFFF';
        let actual = rgbToHexColor(red, green, blue);

        assert.equal(actual, expected);
    });


    it('Should return undefined when red color is out of range', () => {
        let expected = undefined;
        assert.equal(rgbToHexColor(-1, 45, 12), expected);
        assert.equal(rgbToHexColor(256, 445, 12), expected);
    });
    it('Should return undefined when green color is out of range', () => {
        let expected = undefined;
        assert.equal(rgbToHexColor(45, -1, 12), expected);
        assert.equal(rgbToHexColor(45, 256, 12), expected);
    });
    it('Should return undefined when blue color is out of range', () => {
        let expected = undefined;
        assert.equal(rgbToHexColor(45, 45, -1), expected);
        assert.equal(rgbToHexColor(45, 54, 256), expected);
    });

    it('Should return undefined when a color is not in correct type', () => {
        let expected = undefined;

        assert.equal(rgbToHexColor(3.14, 45, 12), expected);
        assert.equal(rgbToHexColor(23, 3.14, 12), expected);
        assert.equal(rgbToHexColor(21, 45, 3.14), expected);
    });

    it('should return undefined for ("5", [3], {8:9})', function () {
        assert.equal(rgbToHexColor("5", [3], { 8: 9 }), undefined);
    });

    it('Should fail when not enough parameters', () => {
        let expected = undefined;
        assert.equal(rgbToHexColor(), expected);
    });
});