import { html } from "../../node_modules/lit-html/lit-html.js";

export let loadButtonTemplate = (id, textContent, eventListener) =>
    html`<button @click=${eventListener} id=${id}>${textContent}</button>`;