class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = Number(budgetMoney);
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {
        for (const product of products) {
            let [name, quantity, price] = product.split(' ');
            price = Number(price);
            quantity = Number(quantity);
            if (price <= this.budgetMoney) {
                if (!this.stockProducts.hasOwnProperty(name)) {
                    this.stockProducts[name] = 0;/////////////////////////
                }
                this.stockProducts[name] += quantity;
                this.budgetMoney -= price;
                this.history.push(`Successfully loaded ${quantity} ${name}`)
            } else {
                this.history.push(`There was not enough money to load ${quantity} ${name}`)
            }
        }
        return this.history.join('\n');
    }

    addToMenu(meal, neededProducts, productPrice) {
        productPrice = Number(productPrice);

        if (!this.menu.hasOwnProperty(meal)) {
            this.menu[meal] = {};
            this.menu[meal].products = neededProducts;
            this.menu[meal].price = productPrice;

            let mealsInMenu = Object.keys(this.menu);
            if (mealsInMenu.length === 1) {
                return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
            }
            return `Great idea! Now with the ${meal} we have ${mealsInMenu.length} meals in the menu, other ideas?`;
        } else {
            return `The ${meal} is already in the our menu, try something different.`;
        }
    }

    showTheMenu() {
        let menuLenght = Object.keys(this.menu).length;
        if (menuLenght === 0) {
            return "Our menu is not ready yet, please come later...";
        }
        let result = [];
        for (const key in this.menu) {
            result.push(`${key} - $ ${this.menu[key].price}`);
        }
        return result.join('\n');
    }

    makeTheOrder(meal) {
        if (!this.menu.hasOwnProperty(meal)) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }
        let neededProducts = this.menu[meal].products;
        let canMakeIt = true;
        for (const currProduct of neededProducts) {
            let [currProductName, currProductQuantity] = currProduct.split(' ');
            currProductQuantity = Number(currProductQuantity);

            if (!this.stockProducts.hasOwnProperty(currProductName)) {
                canMakeIt = false;
                break;
            } else {
                if (this.stockProducts[currProductName] < currProductQuantity) {
                    canMakeIt = false;
                    break;
                }
            }
        }
        if (canMakeIt === false) {
            return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
        } else {
            for (const currProduct of neededProducts) {
                let [currProductName, currProductQuantity] = currProduct.split(' ');
                currProductQuantity = Number(currProductQuantity);
                this.stockProducts[currProductName] -= currProductQuantity;
            }
            this.budgetMoney += this.menu[meal].price;
            return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`
        }
    }
}

let kitchen = new Restaurant(1000);
kitchen.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1']);
kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
console.log(kitchen.makeTheOrder('frozenYogurt'));
