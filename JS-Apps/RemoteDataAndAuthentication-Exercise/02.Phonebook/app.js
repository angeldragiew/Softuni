function attachEvents() {
    let phonebookElement = document.getElementById('phonebook');
    let btnLoad = document.getElementById('btnLoad');
    let baseUrl = 'http://localhost:3030/jsonstore/phonebook';
    let btnCreate = document.getElementById('btnCreate');

    btnLoad.addEventListener('click', loadContacts);
    btnCreate.addEventListener('click', createContact);

    async function createContact() {
        let personInput = document.getElementById('person');
        let phoneInput = document.getElementById('phone');

        let person = personInput.value;
        let phone = phoneInput.value;

        personInput.value = '';
        phoneInput.value = '';

        let data = {
            person,
            phone,
        }

        let createRequest = await fetch(baseUrl, {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(data)
        });

        let createResult = await createRequest.json();
        console.log(createResult);
    }

    async function loadContacts() {
        while (phonebookElement.firstChild) {
            phonebookElement.lastChild.remove()
        }
        let contactsRequest = await fetch(baseUrl);
        let contacts = await contactsRequest.json();

        Object.values(contacts).forEach(c => {
            let deleteButton = createEl('button', 'Delete');
            deleteButton.addEventListener('click', deleteContact);
            let liElement = createEl('li', `${c.person}: ${c.phone}`, { 'contact-id': `${c._id}` }, deleteButton);
            phonebookElement.appendChild(liElement);
        })
    }

    async function deleteContact(e) {
        let currentContact = e.target.parentNode;
        let deleteId = currentContact.getAttribute('contact-id');

        let deleteRequest = await fetch(baseUrl + '/' + deleteId, { method: 'delete' });
        let deleteResult = await deleteRequest.json();
        console.log(deleteResult);

        currentContact.remove();
    }


    function createEl(type = '', content = '', attributesObj = {}, ...nestedElements) {
        let result = document.createElement(type);

        if (content === 0 || content) {
            result.textContent = content;
        }

        if (attributesObj) {
            for (const key in attributesObj) {
                if (key === 'class') {
                    if (Array.isArray(attributesObj[key])) {
                        result.classList.add(...attributesObj[key]);
                    } else {
                        result.classList.add(attributesObj[key]);
                    }
                } else {
                    result.setAttribute(key, attributesObj[key]);
                }
            }
        }

        if (nestedElements) {
            nestedElements.forEach(x => result.appendChild(x));
        }
        return result;
    }
}


attachEvents();