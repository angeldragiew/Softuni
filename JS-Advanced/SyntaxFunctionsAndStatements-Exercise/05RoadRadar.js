function solve(currSpeed, area) {
    let speedLimit = 0;

    switch (area) {
        case 'motorway':
            speedLimit = 130;
            break;
        case 'interstate':
            speedLimit = 90;
            break;
        case 'city':
            speedLimit = 50;
            break;
        case 'residential':
            speedLimit = 20;
            break;
    }

    if (currSpeed <= speedLimit) {
        return `Driving ${currSpeed} km/h in a ${speedLimit} zone`
    } else {
        let exceeding = currSpeed - speedLimit;

        let status = 'speeding';
        if (exceeding > 20) {
            status = exceeding <= 40 ? 'excessive speeding' : 'reckless driving';
        }
        return `The speed is ${exceeding} km/h faster than the allowed speed of ${speedLimit} - ${status}`
    }
}

console.log(solve(40, 'city'));
console.log(solve(21, 'residential'));
console.log(solve(120, 'interstate'));
console.log(solve(200, 'motorway'));