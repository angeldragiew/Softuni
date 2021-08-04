function solve(input) {
    let juicesStore = new Map();
    let bottlesStore = new Map();

    for (const juiceInfo of input) {
        let [juiceName, juiceQuantity] = juiceInfo.split(' => ');

        if (juicesStore.has(juiceName) === false) {
            juicesStore.set(juiceName, 0);
        }
        let newQuantity = juicesStore.get(juiceName) + Number(juiceQuantity);
        juicesStore.set(juiceName, newQuantity)
        if (juicesStore.get(juiceName) >= 1000) {
            let currQuntity = juicesStore.get(juiceName);
            let bottles = Math.floor(currQuntity / 1000);
            let leftQuantity = currQuntity % 1000;

            juicesStore.set(juiceName, leftQuantity);

            if (bottlesStore.has(juiceName) === false) {
                bottlesStore.set(juiceName, 0);
            }
            let newBottles = bottlesStore.get(juiceName) + bottles;
            bottlesStore.set(juiceName, newBottles);
        }
    }

    let result = [];
    for (const [key, value] of bottlesStore) {
        result.push(`${key} => ${value}`);
    }
    return result.join('\n');
}

console.log(solve(
    ['Kiwi => 234',
        'Pear => 2345',
        'Watermelon => 3456',
        'Kiwi => 4567',
        'Pear => 5678',
        'Watermelon => 6789']

));