function search() {
   let searchText = document.getElementById('searchText').value;

   let items = Array.from(document.querySelectorAll('#towns li'));

   let matchedItems = 0;
   for (const item of items) {
      if(item.textContent.includes(searchText)){
         matchedItems++;
         item.style.fontWeight ='bold';
         item.style.textDecoration  ='underline';
      }
   }
   let resultElement = document.getElementById('result');
   resultElement.textContent=`${matchedItems} matches found`
}
