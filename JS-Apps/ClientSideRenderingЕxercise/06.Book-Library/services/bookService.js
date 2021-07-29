import formService from "../services/formService.js";
import { allBookRowsTemplate } from "../templates/bookRowTemplate.js";
import { render } from "../../node_modules/lit-html/lit-html.js";
import bookService from "../services/formService.js";

async function loadBooks() {
    let moviesRequest = await fetch('http://localhost:3030/jsonstore/collections/books');
    let moviesResult = await moviesRequest.json();
    return moviesResult;
}

async function renderBooks() {
    let moviesInfo = await loadBooks();
    let moviesEntries = Object.entries(moviesInfo);
    render(allBookRowsTemplate(moviesEntries, editBook, deleteMovie), document.getElementById('booksDiv'));
}

async function editBook(e) {
    bookService.renderEditForm(e, submitEdit);
}

async function submitEdit(e) {
    e.preventDefault();
    let form = e.target.parentNode;

    let data = new FormData(form);
    let author = data.get('author');
    let title = data.get('title');

    let updatedBook = {
        author,
        title
    }

    let updateRequest = await fetch(`http://localhost:3030/jsonstore/collections/books/${localStorage.getItem('edit-book-id')}`, {
        method: 'put',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(updatedBook)
    })
    form.reset();
    formService.renderAddForm();
    let updateResult = await updateRequest.json();
    await renderBooks();
}


async function deleteMovie(e) {
    let parent = e.target.parentNode.parentNode;
    let id = parent.getAttribute('book-id');

    let deleteRequest = await fetch(`http://localhost:3030/jsonstore/collections/books/${id}`, {
        method: 'Delete',
    })
    parent.remove();
    await renderBooks();
}


async function addBook(e) {
    e.preventDefault();

    let form = e.target.parentNode;

    let data = new FormData(form);
    let author = data.get('author');
    let title = data.get('title');

    let newBook = {
        author,
        title
    }
    if (author === '' || title === '') {
        alert('empty fields!!!');
        return;
    }

    let createBookRequest = await fetch('http://localhost:3030/jsonstore/collections/books', {
        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(newBook)
    })
    await renderBooks();
    form.reset();
}

export default {
    loadBooks,
    editBook,
    deleteMovie,
    addBook,
    renderBooks
}