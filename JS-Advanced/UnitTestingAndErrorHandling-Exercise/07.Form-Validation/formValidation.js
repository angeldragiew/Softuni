function validate() {
    let companyCheckBoxElement = document.getElementById('company');
    let companyInfoElement = document.getElementById('companyInfo');
    let validElement = document.getElementById('valid');

    let submitButton = document.getElementById('submit');

    let isCompanyNumber = false;

    let usernameRegex = /^[a-zA-Z0-9]{3,20}$/;
    let passRegex = /^[\w+_]{5,15}$/;
    let emailRegex = /^(.*)@(.*)\.(.*)$/;

    submitButton.addEventListener('click', (e) => {
        e.preventDefault();
        let isValid = true;
        let usernameInputElement = document.getElementById('username');
        let emailInputElement = document.getElementById('email');
        let passwordInputElement = document.getElementById('password');
        let confirmPasswordInputElement = document.getElementById('confirm-password');

        let isValidUsername = usernameRegex.test(usernameInputElement.value);
        setBorder(usernameInputElement, isValidUsername);

        let isValidEmail = emailRegex.test(emailInputElement.value);
        setBorder(emailInputElement, isValidEmail);

        let areValidPasswords =
            passRegex.test(passwordInputElement.value) &&
            passRegex.test(confirmPasswordInputElement.value) &&
            passwordInputElement.value === confirmPasswordInputElement.value;


        setBorder(passwordInputElement, areValidPasswords);
        setBorder(confirmPasswordInputElement, areValidPasswords);

        if (isCompanyNumber) {
            let companyNumberInputElement = document.getElementById('companyNumber');
            let companyNumber = Number(companyNumberInputElement.value);
            let isCompanyNumberValid = companyNumber >= 1000 && companyNumber <= 9999;
            isValid = isCompanyNumberValid;
            setBorder(companyNumberInputElement,isCompanyNumberValid);
        }

        if (isValidUsername && isValidEmail && areValidPasswords && isValid) {
            validElement.setAttribute('style', 'display: block')
        } else {
            validElement.setAttribute('style', 'display: none')
        }
    });

    companyCheckBoxElement.addEventListener('change', () => {
        if (companyInfoElement.style.display === 'block') {
            companyInfoElement.setAttribute('style', 'display: none');
            isCompanyNumber = false;
        } else {
            companyInfoElement.setAttribute('style', 'display: block');
            isCompanyNumber = true;
        }
    });

    function setBorder(element, bool) {
        if (bool) {
            element.setAttribute('style', 'border: none');
        } else {
            element.setAttribute('style', 'border-color: red');
        }
    }
}
