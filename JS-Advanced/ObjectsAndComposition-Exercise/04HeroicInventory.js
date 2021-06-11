function solve(input) {
    let result = [];

    for (const el of input) {
        let [name, level, itemList] = el.split(' / ');

        items = itemList ? itemList.split(', ') : [];
        let currHero = {
            name: name,
            level: Number(level),
            items: items
        };

        result.push(currHero);
    }
    return JSON.stringify(result);
}

console.log(solve(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
));