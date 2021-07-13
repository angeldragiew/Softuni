function getInfo() {
    let busesElement = document.getElementById('buses');
    let stopNameElement = document.getElementById('stopName');

    while (busesElement.firstChild) {
        busesElement.removeChild(busesElement.lastChild);
    }
    let stopId = document.getElementById('stopId').value;

    fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopId}`)
        .then(res => res.json())
        .then(stopInfo => {
            stopNameElement.textContent = stopInfo.name;
            document.getElementById('stopId').value = '';
            for (const bus in stopInfo.buses) {
                let liElement = document.createElement('li');
                liElement.textContent = `Bus ${bus} arrives in ${stopInfo.buses[bus]} minutes`;
                busesElement.appendChild(liElement);
            }
        }).catch(err => {
            stopNameElement.textContent = 'Error';
        })
}