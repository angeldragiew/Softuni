function deleteByEmail() {

    let emails = Array.from(document.querySelectorAll('tbody td:nth-child(2)'));

    let emailElement = document.querySelector('input');
    let searchedEmail = emailElement.value;


    let resultElement = document.getElementById('result');
    let match = emails.find(x => x.textContent === searchedEmail);
    if (match !== undefined) {
        match.parentElement.remove();
        resultElement.textContent = 'Deleted';
    } else {
        resultElement.textContent = 'Not found.';
    }

    emailElement.textContent = '';
}