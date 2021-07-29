import { html } from "../../node_modules/lit-html/lit-html.js";

export let bookRowTemplate = (book, editEventListener, deleteEventListener) => html`
<tr book-id=${book[0]}>
    <td>${book[1].title}</td>
    <td>${book[1].author}</td>
    <td>
        <button @click=${editEventListener}>Edit</button>
        <button @click=${deleteEventListener}>Delete</button>
    </td>
</tr>
`;

export let allBookRowsTemplate = (books, editEventListener, deleteEventListener) => html`
<table>
    <thead>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody>
        ${books.map(b => bookRowTemplate(b, editEventListener, deleteEventListener))}
    </tbody>
</table>

`;