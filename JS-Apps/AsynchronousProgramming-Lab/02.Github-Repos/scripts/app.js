function loadRepos() {
	let username = document.getElementById('username').value;

	let url = `https://api.github.com/users/${username}/repos`;

	fetch(url)
		.then(res => res.json())
		.then(repos => {
			repos.forEach(repo => {
				let liElement = document.createElement('li');
				let aElement = document.createElement('a');
				aElement.href = repo.html_url;
				aElement.textContent = repo.full_name;
				liElement.appendChild(aElement);
				document.getElementById('repos').appendChild(liElement);
			});
		})
}