import { renderMain } from "../helpers/renderer.js";
import { html } from "../node_modules/lit-html/lit-html.js";
import authService from "../services/authService.js";


let registerTemplate = (registerHandler) => html`
<section id="register">
    <div class="container">
        <form @submit=${registerHandler} id="register-form">
            <h1>Register</h1>
            <p>Please fill in this form to create an account.</p>
            <hr>

            <p>Username</p>
            <input type="text" placeholder="Enter Username" name="username" required>

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password" required>

            <p>Repeat Password</p>
            <input type="password" placeholder="Repeat Password" name="repeatPass" required>
            <hr>

            <input type="submit" class="registerbtn" value="Register">
        </form>
        <div class="signin">
            <p>Already have an account?
                <a href="/login">Sign in</a>.
            </p>
        </div>
    </div>
</section>
`;

export function registeView(ctx) {
    async function registerHandler(e) {
        e.preventDefault();
        let data = new FormData(e.target);

        let username = data.get('username');
        let password = data.get('password');
        let repeatPass = data.get('repeatPass');

        if (username.trim() === '' ||
            password.trim() === '' ||
            repeatPass.trim() === '') {
            window.alert('There cannot be empty fields!');
            return;
        }

        if (password !== repeatPass) {
            window.alert('Pass and repeat pass must match!');
            return;
        }

        let newUser = {
            username,
            password
        }

        try {
            let result = await authService.register(newUser);
            ctx.page.redirect('/allMemes');
        } catch (err) {
            window.alert(err);
        }
    }

    renderMain(registerTemplate(registerHandler));
}