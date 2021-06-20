function lockedProfile() {
    let buttonsElements = document.querySelectorAll('button');
    document.querySelector('input[name=nameOfradio]')

    for (let i = 0; i < buttonsElements.length; i++) {
        const button = buttonsElements[i];
        button.addEventListener('click', (e) => {
            let parent = e.currentTarget.parentElement;
            let radioBtnValue = parent.querySelector(`input[type=radio]:checked`).value;

            let id = `user${i + 1}HiddenFields`;
            let hiddenEls = document.getElementById(id);
            if (radioBtnValue === 'unlock') {
                if (button.textContent == 'Show more') {
                    hiddenEls.setAttribute('style', 'display:block');
                    button.textContent = 'Hide it';
                } else {
                    hiddenEls.setAttribute('style', 'display:none');
                    button.textContent = 'Show more';
                }
            }
        });
    }
}