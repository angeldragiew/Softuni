import { render } from '../node_modules/lit-html/lit-html.js';
import { cats } from './catSeeder.js';
import { catsTemplate } from './templates/catsTemplate.js';

let allCatsSection = document.getElementById('allCats');
let catsTemplateResult = catsTemplate(cats, statusCodeToggle);

render(catsTemplateResult, allCatsSection);


function statusCodeToggle(e) {
    let button = e.target;
    let parent = e.target.parentNode;
    let statusDiv = parent.querySelector('.status');


    if (button.textContent === 'Hide status code') {
        button.textContent = 'Show status code'
        statusDiv.setAttribute('style', 'display:none');
    } else {
        button.textContent = 'Hide status code';
        statusDiv.setAttribute('style', 'display:block');
    }
}