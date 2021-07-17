let loadButton = document.querySelector('main aside .load');
loadButton.addEventListener('click', loadCatches);

let addButton = document.querySelector('#addForm .add');
addButton.disabled = localStorage.getItem('token') === null;
addButton.addEventListener('click', createCatch);

let loginLogout = document.querySelector('#guest a');
loginLogout.textContent = localStorage.getItem('token') === null ? 'Login' : 'Logout';
loginLogout.href = localStorage.getItem('token') === null ? "login.html" : '';
loginLogout.addEventListener('click', () => {
    if (loginLogout.textContent === 'Logout') {
        localStorage.clear();
    }
})

async function deleteCatch(e) {
    let currCatch = e.target.parentNode;
    let id = currCatch.getAttribute('catch-id');

    try {
        let deleteRequest = await fetch(`http://localhost:3030/data/catches/${id}`, {
            method: 'DELETE',
            headers: {
                'X-Authorization': localStorage.getItem('token')
            },
        });

        currCatch.remove();

    } catch (err) {
        console.error(err);
    }
}

async function updateCatch(e) {
    let currCatch = e.target.parentNode;
    let id = currCatch.getAttribute('catch-id');

    let angler = currCatch.querySelector('.angler').value;
    let weight = currCatch.querySelector('.weight').value;
    let species = currCatch.querySelector('.species').value;
    let location = currCatch.querySelector('.location').value;
    let bait = currCatch.querySelector('.bait').value;
    let captureTime = currCatch.querySelector('.captureTime').value;

    let updatedCatch = {
        angler,
        weight: Number(weight),
        species,
        location,
        bait,
        captureTime: Number(captureTime)
    }
    try {
        let updateRequest = await fetch(`http://localhost:3030/data/catches/${id}`, {
            method: 'PUT',
            headers: {
                'Content-type': 'application/json',
                'X-Authorization': localStorage.getItem('token')
            },
            body: JSON.stringify(updatedCatch)
        });
        let updateResult = await updateRequest.json();
    } catch (err) {
        console.error(err);
    }
}

async function createCatch() {
    let angler = document.querySelector('#addForm .angler').value;
    let weight = document.querySelector('#addForm .weight').value;
    let species = document.querySelector('#addForm .species').value;
    let location = document.querySelector('#addForm .location').value;
    let bait = document.querySelector('#addForm .bait').value;
    let captureTime = document.querySelector('#addForm .captureTime').value;

    let currCatch = {
        angler,
        weight: Number(weight),
        species,
        location,
        bait,
        captureTime: Number(captureTime)
    }
    try {
        let createCatchRequest = await fetch('http://localhost:3030/data/catches ', {
            method: 'POST',
            headers: {
                'Content-type': 'application/json',
                'X-Authorization': localStorage.getItem('token')
            },
            body: JSON.stringify(currCatch)
        })
        let createCatchResult = await createCatchRequest.json();
        console.log(createCatchResult);
        let catchesDiv = document.getElementById('catches');
        let catchDiv = createHtmlCatch(createCatchResult);
        catchesDiv.appendChild(catchDiv);
    } catch (err) {
        console.error(err);
    }
    document.querySelectorAll('#addForm input').forEach(i => i.value = '');
}

async function loadCatches() {
    let catchesDiv = document.getElementById('catches');
    while (catchesDiv.lastChild) {
        catchesDiv.firstChild.remove();
    }

    let catchesRequest = await fetch('http://localhost:3030/data/catches');
    let catchesResult = await catchesRequest.json();

    catchesResult.forEach(c => {
        let catchDiv = createHtmlCatch(c);
        catchesDiv.appendChild(catchDiv);
    })
}

function createHtmlCatch(c) {
    let catchDiv = createEl('div', undefined, { class: 'catch' });

    ////
    let anglerLabel = createEl('label', 'Angler');
    catchDiv.appendChild(anglerLabel);

    let anglerInput = document.createElement('input');
    anglerInput.type = 'text';
    anglerInput.classList.add('angler');
    anglerInput.value = c.angler;
    catchDiv.appendChild(anglerInput);

    catchDiv.appendChild(createEl('hr'));
    /////
    let weightLabel = createEl('label', 'Weight');
    catchDiv.appendChild(weightLabel);

    let weightInput = document.createElement('input');
    weightInput.type = 'text';
    weightInput.classList.add('weight');
    weightInput.value = c.weight;
    catchDiv.appendChild(weightInput);

    catchDiv.appendChild(createEl('hr'));
    /////
    let speciesLabel = createEl('label', 'Species');
    catchDiv.appendChild(speciesLabel);

    let speciesInput = document.createElement('input');
    speciesInput.type = 'text';
    speciesInput.classList.add('species');
    speciesInput.value = c.species;
    catchDiv.appendChild(speciesInput);

    catchDiv.appendChild(createEl('hr'));
    ////
    let locationLabel = createEl('label', 'Location');
    catchDiv.appendChild(locationLabel);

    let locationInput = document.createElement('input');
    locationInput.type = 'text';
    locationInput.classList.add('location');
    locationInput.value = c.location;
    catchDiv.appendChild(locationInput);

    catchDiv.appendChild(createEl('hr'));
    ////
    let baitLabel = createEl('label', 'Bait');
    catchDiv.appendChild(baitLabel);

    let baitInput = document.createElement('input');
    baitInput.type = 'text';
    baitInput.classList.add('bait');
    baitInput.value = c.bait;
    catchDiv.appendChild(baitInput);

    catchDiv.appendChild(createEl('hr'));
    ////
    let captureTimeLabel = createEl('label', 'CaptureTime');
    catchDiv.appendChild(captureTimeLabel);

    let captureTimeInput = document.createElement('input');
    captureTimeInput.type = 'text';
    captureTimeInput.classList.add('captureTime');
    captureTimeInput.value = c.captureTime;
    catchDiv.appendChild(captureTimeInput);

    catchDiv.appendChild(createEl('hr'));


    let updateButton = createEl('button', 'Update', { class: 'update' });
    updateButton.addEventListener('click', updateCatch);
    updateButton.disabled = localStorage.getItem('user-id') !== c._ownerId;
    catchDiv.appendChild(updateButton);
    let deleteButton = createEl('button', 'Delete', { class: 'delete' });
    deleteButton.addEventListener('click', deleteCatch);
    deleteButton.disabled = localStorage.getItem('user-id') !== c._ownerId;
    catchDiv.appendChild(deleteButton);
    catchDiv.setAttribute('catch-id', c._id);
    catchDiv.setAttribute('owner-id', c._ownerId);
    return catchDiv;
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
