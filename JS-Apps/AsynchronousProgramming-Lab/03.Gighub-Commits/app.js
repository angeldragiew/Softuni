function loadCommits() {
    let username = document.getElementById('username').value;
    let repo = document.getElementById('repo').value;

    fetch(`https://api.github.com/repos/${username}/${repo}/commits`)
        .then(res => {
            if (res.ok) {
                return res.json()
            } else {
                throw new Error(res.status);
            }
        }
        )
        .then(commits => {
            commits.forEach(commit => {
                let liElement = document.createElement('li');
                liElement.textContent = `${commit.commit.author.name}: ${commit.commit.message}`;
                document.getElementById('commits').appendChild(liElement);
            });
        })
        .catch(err => {
            let liElement = document.createElement('li');
            liElement.textContent = `Error: ${err.message} (Not Found)`;
            document.getElementById('commits').appendChild(liElement);
        })

}