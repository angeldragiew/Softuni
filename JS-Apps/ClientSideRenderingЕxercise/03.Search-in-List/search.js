import {render} from '../node_modules/lit-html/lit-html.js';
import {towns} from './towns.js';
import {allTownsTemplate} from './templates/townTemplates.js';

let townsDiv = document.getElementById('towns');
render(allTownsTemplate(towns), townsDiv);

let searchBtn = document.getElementById('searchBtn');
searchBtn.addEventListener('click', search);

function search() {
   let allLiElements = townsDiv.querySelectorAll('ul li');
   let searchText = document.getElementById('searchText').value;

   allLiElements.forEach(li => {
      li.classList.remove('active');
   });

   let resultDiv = document.getElementById('result');
   let matches = 0;
   allLiElements.forEach(li => {
      if(li.textContent.toLowerCase().includes(searchText.toLowerCase())){
         li.classList.add('active');
         matches++;
      }
   });

   resultDiv.textContent=` ${matches} matches found`;
}
