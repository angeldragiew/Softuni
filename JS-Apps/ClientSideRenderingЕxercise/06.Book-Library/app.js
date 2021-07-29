import { render } from "../node_modules/lit-html/lit-html.js";
import bookService from "./services/bookService.js";
import formService from "./services/formService.js";
import { loadButtonTemplate } from "./templates/loadButtonTemplate.js";
import { allBookRowsTemplate } from "./templates/bookRowTemplate.js"


render(loadButtonTemplate('loadBooks', 'LOAD ALL BOOKS', bookService.renderBooks), document.getElementById('buttonDiv'));

// async function loadMoviesEvent() {
//     let moviesInfo = await bookService.loadBooks();
//     let moviesEntries = Object.entries(moviesInfo);
//     render(allBookRowsTemplate(moviesEntries, bookService.editBook, bookService.deleteMovie), document.getElementById('booksDiv'));
// }

formService.renderAddForm();