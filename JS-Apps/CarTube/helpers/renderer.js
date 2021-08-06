import { render } from "../node_modules/lit-html/lit-html.js";

let rootElement = document.querySelector('#site-content');
export function renderMain(template) {
    render(template, rootElement);
}