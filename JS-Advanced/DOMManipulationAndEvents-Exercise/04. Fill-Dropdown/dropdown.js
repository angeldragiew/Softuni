function addItem() {
    let menuElement = document.getElementById('menu');
    let newItemTextElement = document.getElementById('newItemText');
    let newItemValueElement = document.getElementById('newItemValue');

    let option = document.createElement('option');
    option.textContent=newItemTextElement.value;
    option.value=newItemValueElement.value;

    menuElement.appendChild(option);

    newItemTextElement.value='';
    newItemValueElement.value='';
}