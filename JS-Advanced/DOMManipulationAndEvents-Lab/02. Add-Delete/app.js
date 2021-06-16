function addItem() {
    let itemsElement = document.getElementById('items');
    let newItemTextElement = document.getElementById('newItemText');

    let newLiElement = document.createElement('LI');
    newLiElement.textContent = newItemTextElement.value;

    let deleteElement = document.createElement('A');
    deleteElement.textContent = '[Delete]';
    deleteElement.setAttribute('href', '#')
    deleteElement.addEventListener('click', () => {
        deleteElement.parentElement.remove();
    });

    newLiElement.appendChild(deleteElement);
    itemsElement.appendChild(newLiElement);
}