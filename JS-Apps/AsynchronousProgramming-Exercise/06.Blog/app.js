function attachEvents() {
    (async () => {
        let postsRequest = await fetch('http://localhost:3030/jsonstore/blog/posts');
        let posts = await postsRequest.json();

        let loadPostsButton = document.getElementById('btnLoadPosts');
        loadPostsButton.addEventListener('click', () => {
            let postsSelectElement = document.getElementById('posts');
            for (const post in posts) {
                let optionEl = document.createElement('option');
                optionEl.value = posts[post].id;
                optionEl.textContent = posts[post].title;
                postsSelectElement.append(optionEl);
            }
        });

        let commentRequest = await fetch('http://localhost:3030/jsonstore/blog/comments');
        let comments = await commentRequest.json();

        let viewPostButton = document.getElementById('btnViewPost');
        viewPostButton.addEventListener('click', () => {
            let postTitleElement = document.getElementById('post-title');
            let postsSelectElement = document.getElementById('posts');

            let currPostId = postsSelectElement.value;

            postTitleElement.textContent = posts[currPostId].title;

            let postBodyElement = document.getElementById('post-body');
            postBodyElement.textContent = posts[currPostId].body;

            let commentSection = document.getElementById('post-comments');
            while (commentSection.firstChild) {
                commentSection.removeChild(commentSection.lastChild);
              }
            
            let commentArray = Object.values(comments);

            for (const comment of commentArray) {
                if (comment.postId === currPostId) {
                    let liEl = document.createElement('li');
                    liEl.textContent = comment.text;
                    commentSection.appendChild(liEl);
                }
            }
        });


    })();
}

attachEvents();