window.addEventListener('load', solution);

function solution() {
  let submitButton = document.getElementById('submitBTN');
  let editButton = document.getElementById('editBTN');
  let continueButton = document.getElementById('continueBTN');

  submitButton.addEventListener('click', () => {
    let fnameElement = document.getElementById('fname');
    let emailElement = document.getElementById('email');
    let phoneElement = document.getElementById('phone');
    let addressElement = document.getElementById('address');
    let codeElement = document.getElementById('code');

    if (fnameElement.value !== '' && emailElement.value !== '') {
      let infoPreviewElement = document.getElementById('infoPreview');

      let fnameLi = document.createElement('li');
      fnameLi.textContent = 'Full Name: ' + fnameElement.value;
      infoPreviewElement.appendChild(fnameLi);

      let emailLi = document.createElement('li');
      emailLi.textContent = 'Email: ' + emailElement.value;
      infoPreviewElement.appendChild(emailLi);

      let phoneLi = document.createElement('li');
      phoneLi.textContent = 'Phone Number: ' + phoneElement.value;
      infoPreviewElement.appendChild(phoneLi);

      let addressLi = document.createElement('li');
      addressLi.textContent = 'Address: ' + addressElement.value;
      infoPreviewElement.appendChild(addressLi);

      let codeLi = document.createElement('li');
      codeLi.textContent = 'Postal Code: ' + codeElement.value;
      infoPreviewElement.appendChild(codeLi);

      submitButton.disabled = true;
      fnameElement.value = '';
      emailElement.value = '';
      phoneElement.value = '';
      addressElement.value = '';
      codeElement.value = '';

      editButton.disabled = false;
      continueButton.disabled = false;
    }
  });

  editButton.addEventListener('click', () => {
    let liElements = document.querySelectorAll('#infoPreview li');

    let fnameElement = document.getElementById('fname');
    let emailElement = document.getElementById('email');
    let phoneElement = document.getElementById('phone');
    let addressElement = document.getElementById('address');
    let codeElement = document.getElementById('code');

    fnameElement.value = liElements[0].textContent.split(': ').slice(1);
    liElements[0].remove();

    emailElement.value = liElements[1].textContent.split(': ').slice(1);
    liElements[1].remove();

    phoneElement.value = liElements[2].textContent.split(': ').slice(1);
    liElements[2].remove();

    addressElement.value = liElements[3].textContent.split(': ').slice(1);
    liElements[3].remove();

    codeElement.value = liElements[4].textContent.split(': ').slice(1);
    liElements[4].remove();

    submitButton.disabled = false;
    editButton.disabled = true;
    continueButton.disabled = true;
  });

  continueButton.addEventListener('click', () => {
    let divBlockElement = document.getElementById('block');
    divBlockElement.innerHTML = '';

    let h3Element = document.createElement('h3');
    h3Element.textContent = 'Thank you for your reservation!';
    divBlockElement.appendChild(h3Element);
  });

}
