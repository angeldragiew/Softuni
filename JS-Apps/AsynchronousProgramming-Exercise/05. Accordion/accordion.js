function solution() {
    (async () => {
        let articleRequest = await fetch('http://localhost:3030/jsonstore/advanced/articles/list');
        let articles = await articleRequest.json();

        for (const article of articles) {
            let articleInfoRequest = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${article._id}`);
            let articleInfo = await articleInfoRequest.json();

            createArticle(articleInfo.title, articleInfo.content);
            
        }
    })();

    function createArticle(title, content) {
        let articleDiv = document.createElement('div');
        articleDiv.classList.add('accordion');

        let headDiv = document.createElement('div');
        headDiv.classList.add('head');

        let spanElement = document.createElement('span');
        spanElement.textContent = title;
        headDiv.appendChild(spanElement);

        let buttonElement = document.createElement('button');
        buttonElement.classList.add('button');
        buttonElement.textContent = 'More';

        buttonElement.addEventListener('click', (e) => {
            let parent = e.target.parentNode.parentNode;
            let hidd = parent.querySelector('.extra');

            if (hidd.style.display === 'none') {
                hidd.style.display = 'block';
                parent.querySelector('button').textContent='Hide';
            } else {
                hidd.style.display = 'none';
                parent.querySelector('button').textContent='More';
            }
        });
        headDiv.appendChild(buttonElement);

        let extraDiv = document.createElement('div');
        extraDiv.classList.add('extra');
        extraDiv.style.display='none';
        let pElement = document.createElement('p');
        pElement.textContent = content;
        extraDiv.appendChild(pElement);

        articleDiv.appendChild(headDiv);
        articleDiv.appendChild(extraDiv);

        document.getElementById('main').appendChild(articleDiv);
    }
}

solution();