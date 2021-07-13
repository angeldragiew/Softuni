function lockedProfile() {
    (async () => {
        let profilesRequest = await fetch('http://localhost:3030/jsonstore/advanced/profiles');
        let profiles = await profilesRequest.json();
        let index = 1;
        for (const profile in profiles) {

            let profileDiv = document.createElement('div');
            profileDiv.classList.add('profile');

            let imgEl = document.createElement('img');
            imgEl.src = './iconProfile2.png';
            imgEl.classList.add('userIcon');
            profileDiv.appendChild(imgEl);

            let lockLabel = document.createElement('label');
            lockLabel.textContent = 'Lock';
            profileDiv.appendChild(lockLabel);

            let lockInput = document.createElement('input');
            lockInput.type = 'radio';
            lockInput.name = `user${index}Locked`;
            lockInput.value = 'lock';
            lockInput.checked = true;
            profileDiv.appendChild(lockInput);

            let unlockLabel = document.createElement('label');
            unlockLabel.textContent = 'Unlock';
            profileDiv.appendChild(unlockLabel);

            let unlockInput = document.createElement('input');
            unlockInput.type = 'radio';
            unlockInput.name = `user${index}Locked`;
            unlockInput.value = 'unlock';
            profileDiv.appendChild(unlockInput);

            let hrElement = document.createElement('hr');
            profileDiv.appendChild(hrElement);

            let usernameLabel = document.createElement('label');
            usernameLabel.textContent = 'Username';
            profileDiv.appendChild(usernameLabel);

            let usernameInput = document.createElement('input');
            usernameInput.type = 'text';
            usernameInput.name = `user${index}Username`;
            usernameInput.value = profiles[profile].username;
            usernameInput.disabled = true;
            usernameInput.readOnly = true;
            profileDiv.appendChild(usernameInput);

            let hiddenFieldsDiv = document.createElement('div');
            hiddenFieldsDiv.style.display='none';
            // hiddenFieldsDiv.id=`user${index}HiddenFields`;

            let secondHrElement = document.createElement('hr');
            hiddenFieldsDiv.appendChild(secondHrElement);

            let emailLabel = document.createElement('label');
            emailLabel.textContent = 'Email:';
            hiddenFieldsDiv.appendChild(emailLabel);

            let emailInput = document.createElement('input');
            emailInput.type = 'email';
            emailInput.name = `user${index}Email`;
            emailInput.value = profiles[profile].email;
            emailInput.disabled = true;
            emailInput.readOnly = true;
            hiddenFieldsDiv.appendChild(emailInput);

            let ageLabel = document.createElement('label');
            ageLabel.textContent = 'Age:';
            hiddenFieldsDiv.appendChild(ageLabel);

            //<input type="email" name="user1Age" value="" disabled readonly />
            let ageInput = document.createElement('input');
            ageInput.type = 'email';
            ageInput.name = `user${index}Age`;
            ageInput.value = profiles[profile].age;
            ageInput.disabled = true;
            ageInput.readOnly = true;
            hiddenFieldsDiv.appendChild(ageInput);

            profileDiv.appendChild(hiddenFieldsDiv);

            let showMoreBtn = document.createElement('button');
            showMoreBtn.textContent='Show more';
            showMoreBtn.addEventListener('click', (e) => {
                let parent = e.target.parentNode;
                if(parent.querySelector('input[value=unlock]:checked')){
                    let hiddenFields = parent.querySelector('div');

                    if(hiddenFields.style.display ==='none'){
                        hiddenFields.style.display='block';
                        parent.querySelector('button').textContent='Hide it';
                    }else{
                        hiddenFields.style.display='none';
                        parent.querySelector('button').textContent='Show more';
                    }
                }
            })

            profileDiv.appendChild(showMoreBtn);
            document.getElementById('main').appendChild(profileDiv);
            index++;
        }
    })();
}