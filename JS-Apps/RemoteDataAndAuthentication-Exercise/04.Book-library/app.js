let baseUrl = 'http://localhost:3030/jsonstore/collections/books';
let loadBooksButton = document.getElementById('loadBooks');
let submitSaveButton = document.getElementById('submitSaveButton')

loadBooksButton.addEventListener('click', loadBooks);
submitSaveButton.addEventListener('click', handleFormButton);

async function loadBooks() {
    try {
        let booksRequest = await fetch(baseUrl);
        let books = await booksRequest.json();

        let tableBodyElement = document.querySelector('table tbody');
        while (tableBodyElement.lastChild) {
            tableBodyElement.firstChild.remove();
        }

        for (const key in books) {
            let trElement = createHtmlBook(books[key].author, books[key].title, key);
            tableBodyElement.appendChild(trElement);
        }
    } catch (err) {
        console.error(err);
    }
}

function createHtmlBook(author, title, id) {
    let editButton = createEl('button', 'Edit');
    editButton.addEventListener('click', editBook);
    let deleteButton = createEl('button', 'Delete');
    deleteButton.addEventListener('click', deleteBook);
    let trElement = createEl('tr', undefined, { 'book-id': id },
        createEl('td', author),
        createEl('td', title),
        createEl('td', undefined, {},
            editButton,
            deleteButton
        )
    );
    return trElement;
}

async function handleFormButton(e) {
    e.preventDefault();
    let formElement = document.querySelector('form');
    let data = new FormData(formElement);

    let author = data.get('author');
    let title = data.get('title');

    if (author !== '' && title !== '') {
        formElement.reset();
        if (submitSaveButton.textContent === 'Submit') {
            let createBookRequest = await fetch(baseUrl, {
                method: 'POST',
                headers: { 'Content-type': 'application/json' },
                body: JSON.stringify({
                    author,
                    title,
                })
            });
            let createBookResult = await createBookRequest.json();
            console.log(createBookResult);
            let trElement = createHtmlBook(createBookResult.author, createBookResult.title, createBookResult._id);
            let tableBodyElement = document.querySelector('table tbody');
            tableBodyElement.appendChild(trElement);
        } else {
            let updateID = e.target.getAttribute('update-id');
            let updateBookRequest = await fetch(baseUrl + '/' + updateID, {
                method: 'PUT',
                headers: { 'Content-type': 'application/json' },
                body: JSON.stringify({
                    author,
                    title,
                })
            });

            let updateBookResult = await updateBookRequest.json();
            console.log(updateBookResult);
            let trElement = createHtmlBook(updateBookResult.author, updateBookResult.title, updateBookResult._id);
            let oldTrElement = document.querySelector(`tr[book-id='${updateID}']`);
            oldTrElement.replaceWith(trElement);

            submitSaveButton.textContent = 'Submit';
            let h3FormElement = document.querySelector('form h3');
            h3FormElement.textContent = 'FORM';
        }
    }
}

function editBook(e) {
    let parent = e.target.parentNode.parentNode;
    let updateId = parent.getAttribute('book-id');

    submitSaveButton.textContent = 'Save';
    submitSaveButton.setAttribute('update-id', updateId)

    let h3FormElement = document.querySelector('form h3');
    h3FormElement.textContent = 'Edit FORM';

    let parentTds = parent.querySelectorAll('td');
    let author = parentTds[0].textContent;
    let title = parentTds[1].textContent;

    let formInputs = document.querySelectorAll('form input');
    formInputs[0].value = title;
    formInputs[1].value = author;
}

async function deleteBook(e) {
    let parent = e.target.parentNode.parentNode;
    let deleteID = parent.getAttribute('book-id');
    try {
        await fetch(baseUrl + '/' + deleteID, {
            method: 'delete'
        });
        parent.remove();
    } catch (err) {
        console.error(err);
    }
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