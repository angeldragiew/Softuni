import { html } from "../../node_modules/lit-html/lit-html.js";

export let addFormTemplate = (eventListener) => html`
<form id="add-form">
    <h3>Add book</h3>
    <label>TITLE</label>
    <input type="text" name="title" placeholder="Title...">
    <label>AUTHOR</label>
    <input type="text" name="author" placeholder="Author...">
    <input @click=${eventListener} type="submit" value="Submit">
</form>
`;