function addItem() {
    let itemsElement = document.getElementById('items');
    let newItemTextElement = document.getElementById('newItemText');

    let newLiItem = document.createElement('LI');
    newLiItem.textContent = newItemTextElement.value;
    itemsElement.appendChild(newLiItem);
    newItemTextElement.value = '';
}