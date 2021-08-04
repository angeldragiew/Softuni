class Contact {
    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this._online = false;
    }

    render(id) {
        let parent = document.getElementById(id);
        let articleElement = document.createElement('article');

        let titleDivElement = document.createElement('div');
        titleDivElement.classList.add('title');
        titleDivElement.textContent = `${this.firstName} ${this.lastName}`;

        let buttonElement = document.createElement('button');
        buttonElement.textContent = '\u2139';

        let infoDivElement = document.createElement('div');
        infoDivElement.classList.add('info');
        infoDivElement.setAttribute('style', 'display:none');

        let phoneSpanElement = document.createElement('span');
        phoneSpanElement.textContent = `\u260E ${this.phone}`;
        let emailSpanElement = document.createElement('span');
        emailSpanElement.textContent = `\u2709 ${this.email}`;
        infoDivElement.appendChild(phoneSpanElement);
        infoDivElement.appendChild(emailSpanElement);

        buttonElement.addEventListener('click', () => {
            if (infoDivElement.style.display === 'none') {
                infoDivElement.style.display = 'block';
            } else {
                infoDivElement.style.display = 'none';
            }
        });
        titleDivElement.appendChild(buttonElement);

        articleElement.appendChild(titleDivElement);
        articleElement.appendChild(infoDivElement);

        parent.appendChild(articleElement);
    }

    set online(value) {
        let titleDivElements = Array.from(document.getElementsByClassName('title'));
        let titleDivElement = titleDivElements.find(e => e.textContent.includes(`${this.firstName} ${this.lastName}`));
        if (value === true) {
            titleDivElement.classList.add('online');
        } else {
            titleDivElement.classList.remove('online');
        }
        this._online = value;
    }
    get online() {
        return this._online;
    }
}

let contacts = [
    new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
    new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
    new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
];
contacts.forEach(c => c.render('main'));

// After 1 second, change the online status to true
setTimeout(() => contacts[1].online = true, 2000);
