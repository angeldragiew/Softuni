async function loadStudents() {
    let url = 'http://localhost:3030/jsonstore/collections/students';
    let studentsRequest = await fetch(url);
    let students = await studentsRequest.json();

    Object.values(students).forEach(s => {
        let trElement = createEl('tr', undefined, {},
            createEl('td', s.firstName),
            createEl('td', s.lastName),
            createEl('td', s.facultyNumber),
            createEl('td', s.grade)
        );
        document.querySelector('#results tbody').appendChild(trElement);
    });

}
loadStudents();

let submitBtn = document.getElementById('submit');
submitBtn.addEventListener('click', addStudent);

async function addStudent(e) {
    e.preventDefault();
    let formElement = document.getElementById('form');

    let data = new FormData(formElement);
    let firstName = data.get('firstName');
    let lastName = data.get('lastName');
    let facultyNumber = data.get('facultyNumber');
    let grade = data.get('grade');

    if (firstName !== '' && lastName !== '' && facultyNumber !== '' && grade !== '') {
        formElement.reset();
        let student = {
            firstName,
            lastName,
            facultyNumber,
            grade
        }
        let url = 'http://localhost:3030/jsonstore/collections/students';
        let createRequest = await fetch(url, {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(student),
        });
        let createResult = await createRequest.json();

        let trElement = createEl('tr', undefined, {},
            createEl('td', createResult.firstName),
            createEl('td', createResult.lastName),
            createEl('td', createResult.facultyNumber),
            createEl('td', createResult.grade)
        );
        document.querySelector('#results tbody').appendChild(trElement);
    }

}

function createEl(type = '', content = '', attributesObj = {}, ...nestedElements) {
    let result = document.createElement(type);

    if (content === 0 || content) {
        result.textContent = content;
    }

    if (attributesObj) {
        for (const key in attributesObj) {
            if (key === 'class') {
                if (Array.isArray(attributesObj[key])) {
                    result.classList.add(...attributesObj[key]);
                } else {
                    result.classList.add(attributesObj[key]);
                }
            } else {
                result.setAttribute(key, attributesObj[key]);
            }
        }
    }

    if (nestedElements) {
        nestedElements.forEach(x => result.appendChild(x));
    }
    return result;
}