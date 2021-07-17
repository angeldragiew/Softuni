function attachEvents() {
    let submitButton = document.getElementById('submit');
    let refreshButton = document.getElementById('refresh');
    let messagesArea = document.getElementById('messages');
    let baseUrl = 'http://localhost:3030/jsonstore/messenger';

    submitButton.addEventListener('click', () => {
        let authorInput = document.getElementsByName('author')[0];
        let contentInput = document.getElementsByName('content')[0];
        let author = authorInput.value;
        let content = contentInput.value;

        authorInput.value = '';
        contentInput.value = '';

        fetch(baseUrl, {
            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify({
                author,
                content
            })
        })
            .then(res => res.json())
            .then(res => {
                console.log(res);
            })
            .catch(err => {
                console.log('Error');
            })

    });

    refreshButton.addEventListener('click', () => {
        messagesArea.value = '';
        fetch(baseUrl)
            .then(res => res.json())
            .then(messages => {
                Object.values(messages).forEach(m => {
                    messagesArea.value += `${m.author}: ${m.content}\n`;
                })
            }).catch(err => {
                console.log('Error');
            })
    });
}

attachEvents();