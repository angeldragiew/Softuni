import { render } from "../node_modules/lit-html/lit-html.js";
import { allOptionsTemplate } from "./templates/optionsTemplate.js";

let submitBtn = document.getElementById('submitBtn');
let itemTextElement = document.getElementById('itemText');
let menuElement = document.getElementById('menu');

let options = [];
submitBtn.addEventListener('click', addItem);
loadAllOptions();

async function addItem(e) {
    e.preventDefault();
    let text = itemTextElement.value;

    try {
        let addNewValueRequest = await fetch('http://localhost:3030/jsonstore/advanced/dropdown', {
            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify({ text })
        });
        if(addNewValueRequest.ok){
            let addNewValueResult = await addNewValueRequest.json();
            options.push(addNewValueResult);
            render(allOptionsTemplate(options), menuElement);
            itemTextElement.value = "";
        }
    }
    catch (err) {
        alert(err);
    }
}

async function loadAllOptions() {
    try {
        let optionsRequest = await fetch('http://localhost:3030/jsonstore/advanced/dropdown');
        let optionsResult = await optionsRequest.json();
        options = Object.values(optionsResult);
        render(allOptionsTemplate(options), menuElement);
    } catch (err) {
        alert(err);
    }
}