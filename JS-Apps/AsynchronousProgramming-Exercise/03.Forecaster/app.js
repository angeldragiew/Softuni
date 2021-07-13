function attachEvents() {
    let forecastElement = document.getElementById('forecast');
    let locationInput = document.getElementById('location');

    let submitButton = document.getElementById('submit');

    submitButton.addEventListener('click', () => {
        forecastElement.style.display = 'block';

        let currentForecastDiv = document.getElementById('current');
        Array.from(currentForecastDiv.querySelectorAll('div')).forEach((el, i) => {
            if (i !== 0) {
                el.remove();
            }
        });

        let upcomingForecastDiv = document.getElementById('upcoming');
        Array.from(upcomingForecastDiv.querySelectorAll('div')).forEach((el, i) => {
            if (i !== 0) {
                el.remove();
            }
        });
        fetch('http://localhost:3030/jsonstore/forecaster/locations')
            .then(res => res.json())
            .then(locations => {
                let loc = locations.find(l => l.name === locationInput.value);
                let code = loc.code;
                return fetch(`http://localhost:3030/jsonstore/forecaster/today/${code}`)
                    .then(res => res.json())
                    .then(todayInfo => ({ code, todayInfo }))
            })
            .then(({ todayInfo, code }) => {
                createCurrentCondition(todayInfo.forecast.condition, todayInfo.forecast.high, todayInfo.forecast.low, todayInfo.name);
                return fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${code}`)
            })
            .then(res => res.json())
            .then(upcomingForecast => {
                createUpcomingForecast(upcomingForecast.forecast);
            })
            .catch(err => {
                let errorDiv = document.createElement('div');
                errorDiv.textContent = 'Error';
                currentForecastDiv.appendChild(errorDiv)
            });
    });

    function createUpcomingForecast(upcomingForecast) {
        let forecastInfoDiv = document.createElement('div');
        forecastInfoDiv.classList.add('forecast-info');
        for (const curr of upcomingForecast) {
            let upcomingSpan = document.createElement('span');
            upcomingSpan.classList.add('upcoming');

            let symbolSpan = document.createElement('span');
            symbolSpan.classList.add('symbol');
            symbolSpan.textContent = defineSymbol(curr.condition);
            upcomingSpan.appendChild(symbolSpan);

            let tempSpan = document.createElement('span');
            tempSpan.classList.add('forecast-data');
            tempSpan.textContent = `${curr.low}°/${curr.high}°`;
            upcomingSpan.appendChild(tempSpan);

            let conditionNameSpan = document.createElement('span');
            tempSpan.classList.add('forecast-data');
            conditionNameSpan.textContent = curr.condition;
            upcomingSpan.appendChild(conditionNameSpan);

            forecastInfoDiv.appendChild(upcomingSpan);
        }
        document.getElementById('upcoming').appendChild(forecastInfoDiv);
    }
    function createCurrentCondition(condition, high, low, name) {
        let divForecasts = document.createElement('div');
        divForecasts.classList.add('forecasts');

        let conditionSymbolSpan = document.createElement('span');
        conditionSymbolSpan.textContent = defineSymbol(condition);
        conditionSymbolSpan.classList.add('condition', 'symbol');
        divForecasts.appendChild(conditionSymbolSpan);

        let conditionSpan = document.createElement('span');
        conditionSpan.classList.add('condition');

        let nameSpan = document.createElement('span');
        nameSpan.classList.add('forecast-data');
        nameSpan.textContent = name;
        conditionSpan.appendChild(nameSpan);

        let tempSpan = document.createElement('span');
        tempSpan.classList.add('forecast-data');
        tempSpan.textContent = `${low}°/${high}°`;
        conditionSpan.appendChild(tempSpan);

        let conditionNameSpan = document.createElement('span');
        conditionNameSpan.classList.add('forecast-data');
        conditionNameSpan.textContent = condition;
        conditionSpan.appendChild(conditionNameSpan);


        divForecasts.appendChild(conditionSpan);

        document.getElementById('current').appendChild(divForecasts);
    }

    function defineSymbol(condition) {
        let code = '';
        switch (condition) {
            case 'Sunny':
                code = '☀';
                break;
            case 'Partly sunny':
                code = '⛅';
                break;
            case 'Overcast':
                code = '☁';
                break;
            case 'Rain':
                code = '☂';
                break;
        }
        return code;
    }

}

attachEvents();