const PaymentPackage = require('../12PaymentPackage');
let assert = require('chai').assert;
let expect = require('chai').expect;

describe('PaymentPackage', () => {
    describe('constructor', () => {
        it('Should set parameters', () => {
            let paymentPackage = new PaymentPackage('Angel', 200);
            assert.property(paymentPackage, 'name');
            assert.property(paymentPackage, 'value');
            assert.property(paymentPackage, 'VAT');
            assert.property(paymentPackage, 'active');
            expect(paymentPackage).to.have.property("name", 'Angel');
            expect(paymentPackage).to.have.property("value", 200);
            expect(paymentPackage).to.have.property("VAT", 20);
            expect(paymentPackage).to.have.property("active", true);
        });
        it("should have toString method", function () {
            let paymentPackage = new PaymentPackage('Angel', 200);
            expect(paymentPackage).to.respondTo("toString");
        });
    });

    describe('name tests', () => {
        it('Constructor Should set and return name correctly when it is valid', () => {
            let paymentPackage = new PaymentPackage('Angel', 200);
            assert.strictEqual(paymentPackage.name, 'Angel');
        });
        it('Should set and return name correctly when it is valid', () => {
            let paymentPackage = new PaymentPackage('Angel', 200);
            paymentPackage.name = 'Ivan';
            assert.strictEqual(paymentPackage.name, 'Ivan');
        });

        it('Should throw when name is not string', () => {
            let paymentPackage = new PaymentPackage('Angel', 200);
            assert.throw(() => paymentPackage.name = null, 'Name must be a non-empty string');
            assert.throw(() => paymentPackage.name = 1, 'Name must be a non-empty string');
            assert.throw(() => paymentPackage.name = false, 'Name must be a non-empty string');
            assert.throw(() => paymentPackage.name = {}, 'Name must be a non-empty string');
            assert.throw(() => paymentPackage.name = [], 'Name must be a non-empty string');
            assert.throw(() => paymentPackage.name = undefined, 'Name must be a non-empty string');
            assert.throw(() => paymentPackage.name = NaN, 'Name must be a non-empty string');
            assert.throw(() => paymentPackage.name = '', 'Name must be a non-empty string');
        });

        // it('Should throw when name is empty string', () => {
        //     let paymentPackage = new PaymentPackage('Angel', 200);
        //     assert.throw(() => paymentPackage.name = '', 'Name must be a non-empty string');
        // });
    });

    describe('value tests', () => {
        it('Constructor Should set and return value correctly when it is valid', () => {
            let paymentPackage = new PaymentPackage('Angel', 200);
            assert.strictEqual(paymentPackage.value, 200);
        });

        it('Should set and return value correctly when it is valid', () => {
            let paymentPackage = new PaymentPackage('Angel', 200);
            paymentPackage.value = 0;
            assert.strictEqual(paymentPackage.value, 0);
        });

        it('Should throw when value is not number', () => {
            let paymentPackage = new PaymentPackage('Angel', 200);
            assert.throw(() => paymentPackage.value = null, 'Value must be a non-negative number');
            assert.throw(() => paymentPackage.value = '1', 'Value must be a non-negative number');
            assert.throw(() => paymentPackage.value = false, 'Value must be a non-negative number');
            assert.throw(() => paymentPackage.value = [], 'Value must be a non-negative number');
            assert.throw(() => paymentPackage.value = {}, 'Value must be a non-negative number');
            assert.throw(() => paymentPackage.value = undefined, 'Value must be a non-negative number');
            assert.throw(() => paymentPackage.value = null, 'Value must be a non-negative number');
             assert.throw(() => paymentPackage.value = -21, 'Value must be a non-negative number');
            assert.throw(() => paymentPackage.value = -211, 'Value must be a non-negative number');
        });

        // it('Should throw when value is less than 0', () => {
        //     let paymentPackage = new PaymentPackage('Angel', 200);
        //     assert.throw(() => paymentPackage.value = -21, 'Value must be a non-negative number');
        //     assert.throw(() => paymentPackage.value = -211, 'Value must be a non-negative number');
        // });
    });

    describe('VAT tests', () => {
        it('Constructor should set default value to VAT', () => {
            let paymentPackage = new PaymentPackage('Angel', 200);
            assert.strictEqual(paymentPackage.VAT, 20);
        });

        it('Should set and return VAT correctly when it is valid', () => {
            let paymentPackage = new PaymentPackage('Angel', 200);
            paymentPackage.VAT = 0;
            assert.strictEqual(paymentPackage.VAT, 0);
        });

        it('Should throw when VAT is not number', () => {
            let paymentPackage = new PaymentPackage('Angel', 200);
            assert.throw(() => paymentPackage.VAT = null, 'VAT must be a non-negative number');
            assert.throw(() => paymentPackage.VAT = '1', 'VAT must be a non-negative number');
            assert.throw(() => paymentPackage.VAT = false, 'VAT must be a non-negative number');
            assert.throw(() => paymentPackage.VAT = undefined, 'VAT must be a non-negative number');
            assert.throw(() => paymentPackage.VAT = {}, 'VAT must be a non-negative number');
            assert.throw(() => paymentPackage.VAT = [], 'VAT must be a non-negative number');
            assert.throw(() => paymentPackage.VAT = null, 'VAT must be a non-negative number');
            assert.throw(() => paymentPackage.VAT = -21, 'VAT must be a non-negative number');
            assert.throw(() => paymentPackage.VAT = -211, 'VAT must be a non-negative number');
        });

        // it('Should throw when VAT is less than 0', () => {
        //     let paymentPackage = new PaymentPackage('Angel', 200);
        //     assert.throw(() => paymentPackage.VAT = -21, 'VAT must be a non-negative number');
        //     assert.throw(() => paymentPackage.VAT = -211, 'VAT must be a non-negative number');
        // });
    });

    describe('active tests', () => {
        it('Constructor should set default value to active', () => {
            let paymentPackage = new PaymentPackage('Angel', 200);
            assert.strictEqual(paymentPackage.active, true);
        });

        it('Should set and return active correctly when it is valid', () => {
            let paymentPackage = new PaymentPackage('Angel', 200);
            paymentPackage.active = false;
            assert.strictEqual(paymentPackage.active, false);
        });

        it('Should throw when active is not bool', () => {
            let paymentPackage = new PaymentPackage('Angel', 200);
            assert.throw(() => paymentPackage.active = null, 'Active status must be a boolean');
            assert.throw(() => paymentPackage.active = '1', 'Active status must be a boolean');
            assert.throw(() => paymentPackage.active = 123, 'Active status must be a boolean');
            assert.throw(() => paymentPackage.active = [], 'Active status must be a boolean');
            assert.throw(() => paymentPackage.active = {}, 'Active status must be a boolean');
            assert.throw(() => paymentPackage.active = null, 'Active status must be a boolean');
            assert.throw(() => paymentPackage.active = undefined, 'Active status must be a boolean');
        });
    });

    describe('toString', () => {
        it('Should return correct string', () => {
            let paymentPackage = new PaymentPackage('Angel', 200);
            paymentPackage.active = false;
            let expected = [
                `Package: ${paymentPackage.name}` + (paymentPackage.active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${paymentPackage.value}`,
                `- Value (VAT ${paymentPackage.VAT}%): ${paymentPackage.value * (1 + paymentPackage.VAT / 100)}`
            ].join('\n');
            let actual = paymentPackage.toString();
            assert.strictEqual(actual, expected);
        });

        it('Should return correct string', () => {
            let paymentPackage = new PaymentPackage('Angel', 200);
            let expected = [
                `Package: ${paymentPackage.name}` + (paymentPackage.active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${paymentPackage.value}`,
                `- Value (VAT ${paymentPackage.VAT}%): ${paymentPackage.value * (1 + paymentPackage.VAT / 100)}`
            ].join('\n');
            let actual = paymentPackage.toString();
            assert.strictEqual(actual, expected);
        });

    });
});
