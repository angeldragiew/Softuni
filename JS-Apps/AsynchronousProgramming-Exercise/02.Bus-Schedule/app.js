function solve() {
    let departButton = document.getElementById('depart');
    let arriveButton = document.getElementById('arrive');
    let infoElement = document.querySelector('#info .info');

    let arrivingStop = '';

    let baseUrl = 'http://localhost:3030/jsonstore/bus/schedule/';
    let nextStop = 'depot';
    function depart() {
        fetch(baseUrl + nextStop)
            .then(res => res.json())
            .then(stopInfo => {
                infoElement.textContent = `Next stop ${stopInfo.name}`;
                arrivingStop = stopInfo.name;
                nextStop = stopInfo.next;
                departButton.disabled = true;
                arriveButton.disabled = false;
            })
            .catch(err=>{
                infoElement.textContent='Error';
                departButton.disabled = true;
                arriveButton.disabled = true;
            });
    }

    function arrive() {
        infoElement.textContent = `Arriving at ${arrivingStop}`;
        departButton.disabled = false;
        arriveButton.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();