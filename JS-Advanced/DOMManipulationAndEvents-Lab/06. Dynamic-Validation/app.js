function validate() {
    let reg = /([a-z]+)@([a-z]+)\.([a-z]+)/gm;
    let emailInputElement = document.getElementById('email');

    emailInputElement.addEventListener('change', (e) => {
        if (reg.test(e.target.value)) {
            e.target.className = '';
        } else {
            e.target.className = 'error';
        }
    });
}