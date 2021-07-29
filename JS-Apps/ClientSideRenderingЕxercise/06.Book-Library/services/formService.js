import { render } from "../../node_modules/lit-html/lit-html.js";
import { editFormTemplate } from "../templates/editFormTemplate.js";
import { addFormTemplate } from "../templates/addFormTemplate.js"
import bookService from "./bookService.js";

function renderEditForm(e, eventListener) {
    let parent = e.target.parentNode.parentNode;
    let title = parent.querySelectorAll('td')[0].textContent;
    let author = parent.querySelectorAll('td')[1].textContent;
    localStorage.setItem('edit-book-id', parent.getAttribute('book-id'));

    render(editFormTemplate(title, author, eventListener), document.getElementById('formsDiv'));
}

function renderAddForm() {
    render(addFormTemplate(bookService.addBook), document.getElementById('formsDiv'));
}


export default {
    renderEditForm,
    renderAddForm
}