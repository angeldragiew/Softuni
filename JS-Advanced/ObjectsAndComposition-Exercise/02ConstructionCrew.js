function solve(worker) {

    if (worker.dizziness === true) {
        worker.levelOfHydrated += 0.1 * worker.experience * worker.weight;
        worker.dizziness = false;
    }
    return worker;
}


let worker = {
    weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false
};



console.log(solve(worker));
