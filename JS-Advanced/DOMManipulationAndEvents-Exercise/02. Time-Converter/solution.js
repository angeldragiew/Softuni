function attachEventsListeners() {
    let daysBtnEl = document.getElementById('daysBtn');
    let daysInputEl = document.getElementById('days');

    let hoursBtnEl = document.getElementById('hoursBtn');
    let hoursInputEl = document.getElementById('hours');

    let minutesBtnEl = document.getElementById('minutesBtn');
    let minutesInputEl = document.getElementById('minutes');

    let secondsBtnEl = document.getElementById('secondsBtn');
    let secondsInputEl = document.getElementById('seconds');

    daysBtnEl.addEventListener('click', () => {
        let days = Number(daysInputEl.value);
        hoursInputEl.value = days * 24;
        minutesInputEl.value = days * 1440;
        secondsInputEl.value = days * 86400;
    });

    hoursBtnEl.addEventListener('click', () => {
        let hours = Number(hoursInputEl.value);
        daysInputEl.value = hours / 24;
        minutesInputEl.value = hours * 60;
        secondsInputEl.value = hours * 3600;
    });

    minutesBtnEl.addEventListener('click', () => {
        let minutes = Number(minutesInputEl.value);
        daysInputEl.value = minutes / 1440;
        hoursInputEl.value = minutes / 60;
        secondsInputEl.value = minutes * 60;
    });

    secondsBtnEl.addEventListener('click', () => {
        let seconds = Number(secondsInputEl.value);
        daysInputEl.value = seconds / 86400;
        hoursInputEl.value = seconds / 3600;
        minutesInputEl.value = seconds / 60;
    });
}