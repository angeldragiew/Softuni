function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let tdElements = document.querySelectorAll('.container tbody tr td');
      let searchField = document.getElementById('searchField');
      let searched = searchField.value;

      for (const el of tdElements) {
         let parent = el.parentElement;
         if (parent.classList.contains('select')) {
            parent.classList.remove('select')
         }
      }

      for (const el of tdElements) {
         if (el.textContent.includes(searched)) {
            let parent = el.parentElement;
            parent.classList.add('select')
         }
      }
      searchField.value = '';
   }
}