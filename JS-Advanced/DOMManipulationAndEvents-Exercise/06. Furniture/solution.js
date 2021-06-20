function solve() {
  let textareaElements = document.querySelectorAll('textarea');
  let btnsElements = document.querySelectorAll('button');

  btnsElements[0].addEventListener('click', (e) => {
    let input = textareaElements[0].value;
    let parsedInput = JSON.parse(input);

    for (let i = 0; i < parsedInput.length; i++) {
      let obj = parsedInput[i];

      let imgTd = document.createElement('td');
      let imgElement = document.createElement('img');
      imgElement.setAttribute('src', obj.img)
      imgTd.appendChild(imgElement);

      let nameTd = document.createElement('td');
      let namePElement = document.createElement('p');
      namePElement.textContent = obj.name;
      nameTd.appendChild(namePElement);

      let priceTd = document.createElement('td');
      let pricePElement = document.createElement('p');
      pricePElement.textContent = obj.price;
      priceTd.appendChild(pricePElement);

      let decFactorTd = document.createElement('td');
      let decFactorPElement = document.createElement('p');
      decFactorPElement.textContent = obj.decFactor;
      decFactorTd.appendChild(decFactorPElement);

      let inputTd = document.createElement('td');
      let inputElement = document.createElement('input');
      inputElement.setAttribute('type', 'checkbox')
      // inputElement.setAttribute('disabled', 'true');
      inputTd.appendChild(inputElement);

      let trElement = document.createElement('tr');

      trElement.appendChild(imgTd);
      trElement.appendChild(nameTd);
      trElement.appendChild(priceTd);
      trElement.appendChild(decFactorTd);
      trElement.appendChild(inputTd);
      document.querySelector('tbody').appendChild(trElement);
    }
  });


  btnsElements[1].addEventListener('click', (e) => {
    let checkboxes = document.querySelectorAll('input[type=checkbox]');
    let boughtFurniture = [];
    let totalPrice = 0;
    let averageDecFactor = 0;
    let index = 0;

    for (const cb of checkboxes) {
      if (cb.checked) {
        let tr = cb.parentElement.parentElement;
        let furnitureName = tr.querySelector('td:nth-child(2) p').textContent;
        let furniturePrice = Number(tr.querySelector('td:nth-child(3) p').textContent);
        let decFacotr = Number(tr.querySelector('td:nth-child(4) p').textContent);
        averageDecFactor += decFacotr;
        index++;

        totalPrice += furniturePrice;
        boughtFurniture.push(furnitureName);
      }
    };

    textareaElements[1].textContent += `Bought furniture: ${boughtFurniture.join(', ')}\n`;
    textareaElements[1].textContent += `Total price: ${totalPrice.toFixed(2)}\n`;
    textareaElements[1].textContent += `Average decoration factor: ${averageDecFactor / index}`;
  });

}