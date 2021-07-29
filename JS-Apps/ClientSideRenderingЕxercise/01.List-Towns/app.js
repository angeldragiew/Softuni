import { html, render } from '../node_modules/lit-html/lit-html.js'
import townTemplate from './templates/townTemplate.js';

let townsInput = document.getElementById('towns');
let rootElement = document.getElementById('root');
let btnLoadTowns = document.getElementById('btnLoadTowns');

btnLoadTowns.addEventListener('click', loadTowns);

function loadTowns(e) {
    e.preventDefault();
    let towns = townsInput.value.split(', ');
    let townTemplateResult = townTemplate(towns);
    render(townTemplateResult, rootElement);
}
