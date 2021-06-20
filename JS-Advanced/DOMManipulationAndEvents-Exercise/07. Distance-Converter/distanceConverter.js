function attachEventsListeners() {
    let convertBtn = document.getElementById('convert');
    let inputUnitsElement = document.getElementById('inputUnits');
    let outputUnitsElement = document.getElementById('outputUnits');

    let inputDistanceElement = document.getElementById('inputDistance');
    let outputDistanceElement = document.getElementById('outputDistance');

    convertBtn.addEventListener('click', () => {
        let meters = convertValueFromUnitToMeters(inputUnitsElement.value, inputDistanceElement.value);
        let newUnitValue = convertValueFromMetersToUnit(outputUnitsElement.value, meters);

        outputDistanceElement.value = newUnitValue;
    });


    function convertValueFromUnitToMeters(unit, unitValue) {
        let meters = 0;
        switch (unit) {
            case 'km':
                meters = unitValue * 1000;
                break;
            case 'm':
                meters = unitValue * 1;
                break;
            case 'cm':
                meters = unitValue * 0.01;
                break;
            case 'mm':
                meters = unitValue * 0.001;
                break;
            case 'mi':
                meters = unitValue * 1609.34;
                break;
            case 'yrd':
                meters = unitValue * 0.9144;
                break;
            case 'ft':
                meters = unitValue * 0.3048;
                break;
            case 'in':
                meters = unitValue * 0.0254;
                break;
        }
        return meters;
    }

    function convertValueFromMetersToUnit(unit, meters) {
        let unitValue = 0;
        switch (unit) {
            case 'km':
                unitValue = meters / 1000;
                break;
            case 'm':
                unitValue = meters / 1;
                break;
            case 'cm':
                unitValue = meters / 0.01;
                break;
            case 'mm':
                unitValue = meters / 0.001;
                break;
            case 'mi':
                unitValue = meters / 1609.34;
                break;
            case 'yrd':
                unitValue = meters / 0.9144;
                break;
            case 'ft':
                unitValue = meters / 0.3048;
                break;
            case 'in':
                unitValue = meters / 0.0254;
                break;
        }
        return unitValue;
    }
}