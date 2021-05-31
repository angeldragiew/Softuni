function solve(names) {
    names.sort(((a, b) => a.localeCompare(b)));

    let i = 1;
    for (let name of names) {
        console.log(`${i++}.${name}`);
    }
}

solve(["John", "Bob", "Christina", "Ema"])