function solve(input) {
    const townsPopulationRegistry = {

    };
    for (const el of input) {
        let splittedInfo = el.split(' <-> ');
        let townName = splittedInfo[0];
        let townPopulation = Number(splittedInfo[1]);

        if (townsPopulationRegistry.hasOwnProperty(townName)) {
            townsPopulationRegistry[townName] += townPopulation;
        } else {
            townsPopulationRegistry[townName] = townPopulation;
        }
    }

    for (const [key, value] of Object.entries(townsPopulationRegistry)) {
        console.log(`${key} : ${value}`);
    }
}


solve(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']
);