function solve() {
   let buttonsElements = document.querySelectorAll('.add-product');
   let textAreaElement = document.querySelector('textarea');
   let buttonCheckoutElement = document.querySelector('.checkout');

   let totalPrice = 0;
   let productBasket = [];

   for (const button of buttonsElements) {
      button.addEventListener('click', (e) => {
         let product = e.currentTarget.parentElement.parentElement;
         productName = product.querySelector('.product-title').textContent;
         productPrice = Number(product.querySelector('.product-line-price').textContent);

         if (!productBasket.includes(productName)) {
            productBasket.push(productName);
         }
         totalPrice += productPrice;

         let addedInfo = `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
         textAreaElement.textContent += addedInfo;
      });
   }
   buttonCheckoutElement.addEventListener('click', (e) => {
      textAreaElement.textContent += `You bought ${productBasket.join(', ')} for ${totalPrice.toFixed(2)}.`;
      e.currentTarget.setAttribute("disabled", "true");
      for (const button of buttonsElements) {
         button.setAttribute("disabled", "true");
      }
   });
}