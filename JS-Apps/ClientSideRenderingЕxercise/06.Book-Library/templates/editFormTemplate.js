import { html } from "../../node_modules/lit-html/lit-html.js";

export let editFormTemplate = (title, author, eventListener) => html`
<form id="edit-form">
    <input type="hidden" name="id">
    <h3>Edit book</h3>
    <label>TITLE</label>
    <input type="text" name="title" value=${title} placeholder="Title...">
    <label>AUTHOR</label>
    <input type="text" name="author" value=${author} placeholder="Author...">
    <input @click=${eventListener} type="submit" value="Save">
</form>`