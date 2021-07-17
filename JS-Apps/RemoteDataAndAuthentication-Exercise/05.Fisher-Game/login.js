let registerForm = document.getElementById('register-form');
registerForm.addEventListener('submit', register);

let loginForm = document.getElementById('login-form');
loginForm.addEventListener('submit', login);

async function register(e) {
    e.preventDefault();

    let form = e.target;
    let data = new FormData(form);

    let email = data.get('email');
    let password = data.get('password');
    let rePass = data.get('rePass');

    if (email === '' || password === '' || rePass === '') {
        alert("Empty fields!");
        return;
    }
    if (password !== rePass) {
        alert("Pass do not match!");
        return;
    }

    let newUser = {
        email,
        password
    }
    try {
        let registerRequest = await fetch('http://localhost:3030/users/register', {
            headers: { 'Content-type': 'application/json' },
            method: 'POST',
            body: JSON.stringify(newUser)
        })

        let registerResult = await registerRequest.json();
        console.log(registerResult);
        localStorage.setItem('token', registerResult.accessToken);
        localStorage.setItem('user-id', registerResult._id);
    } catch (err) {
        console.log('Error');
    }
    location.assign('./index.html');
}

async function login(e) {
    e.preventDefault();

    let form = e.target;
    let data = new FormData(form);

    let email = data.get('email');
    let password = data.get('password');

    if (email === '' || password === '') {
        alert("Empty fields!");
        return;
    }

    let user = {
        email,
        password
    }
    try {
        let loginRequest = await fetch('http://localhost:3030/users/login', {
            headers: { 'Content-type': 'application/json' },
            method: 'POST',
            body: JSON.stringify(user)
        })

        let loginResult = await loginRequest.json();
        console.log(loginResult);
        localStorage.setItem('token', loginResult.accessToken);
        localStorage.setItem('user-id', loginResult._id);
    } catch (err) {
        console.log('Error');
    }
    location.assign('./index.html');

}