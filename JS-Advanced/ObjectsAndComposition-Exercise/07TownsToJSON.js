function solve(input) {
    let titles = serializeRow(input[0]);

    let rows = input
        .slice(1)
        .map(row => serializeRow(row).reduce((acc, el, i) => {
            acc[titles[i]] = el;
            return acc;
        }, {}));


    function serializeRow(row) {
        return row
            .split(/\s*\|\s*/gmi)
            .filter(x => x !== '')
            .map(x => isNaN(x) ? x : Number(Number(x).toFixed(2)));
    }

    return JSON.stringify(rows);
}


console.log(solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
));