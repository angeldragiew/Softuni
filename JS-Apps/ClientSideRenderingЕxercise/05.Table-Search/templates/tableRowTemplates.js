import { html } from "../../node_modules/lit-html/lit-html.js";
import { ifDefined } from '../../node_modules/lit-html/directives/if-defined.js';

export let rowTemplate = (rowInfo) => html`
<tr class="${ifDefined(rowInfo.class)}">
    <td>${rowInfo.firstName} ${rowInfo.lastName}</td>
    <td>${rowInfo.email}</td>
    <td>${rowInfo.course}</td>
</tr>
`;

export let allRowsTemplate = (allRows) => allRows.map(row => rowTemplate(row));