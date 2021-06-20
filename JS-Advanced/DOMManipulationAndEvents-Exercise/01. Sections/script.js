function create(words) {
   let contentElement = document.getElementById('content');
   for (const word of words) {
      let divElement = document.createElement('div');

      let paragraph = document.createElement('p');
      paragraph.textContent = word;
      paragraph.setAttribute('style', 'display:none');

      divElement.appendChild(paragraph);
      contentElement.appendChild(divElement);
   }

   contentElement.addEventListener('click', (e) => {
      if (e.target.matches('#content div')) {
         e.target.children[0].setAttribute('style', 'display:block');
      }
   });
}