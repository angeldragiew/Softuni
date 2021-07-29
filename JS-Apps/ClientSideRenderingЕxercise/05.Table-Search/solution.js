import { render } from "../node_modules/lit-html/lit-html.js";
import { allRowsTemplate } from "./templates/tableRowTemplates.js";

function solve() {
   let rootElement = document.querySelector('.container tbody');
   let rows = [];
   loadRows();

   document.querySelector('#searchBtn').addEventListener('click', search);
   let searchFieldElement = document.getElementById('searchField');

   function search() {
      rows.forEach(row => {
         if (row.firstName.toLowerCase().includes(searchFieldElement.value.toLowerCase()) ||
            row.lastName.toLowerCase().includes(searchFieldElement.value.toLowerCase()) ||
            row.email.toLowerCase().includes(searchFieldElement.value.toLowerCase()) ||
            row.course.toLowerCase().includes(searchFieldElement.value.toLowerCase())) {
            row.class = 'select';
         } else {
            row.class = undefined;
         }
      })
      render(allRowsTemplate(rows), rootElement);
   }

   async function loadRows() {
      let rowsRequest = await fetch('http://localhost:3030/jsonstore/advanced/table');
      let rowsResult = await rowsRequest.json();

      rows = Object.values(rowsResult);
      rows.map(row => row.class = undefined);
      render(allRowsTemplate(rows), rootElement);
   }
}

solve();