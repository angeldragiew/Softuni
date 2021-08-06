import { renderMain } from "../helpers/renderer.js";
import { html } from "../node_modules/lit-html/lit-html.js";
import authService from "../services/authService.js";


let loginTemplate = (loginHandler) => html`
<section id="login">
    <div class="container">
        <form @submit=${loginHandler} id="login-form" action="#" method="post">
            <h1>Login</h1>
            <p>Please enter your credentials.</p>
            <hr>

            <p>Username</p>
            <input placeholder="Enter Username" name="username" type="text">

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn" value="Login">
        </form>
        <div class="signin">
            <p>Dont have an account?
                <a href="/register">Sign up</a>.
            </p>
        </div>
    </div>
</section>
`;

export function loginView(ctx) {
    async function loginHandler(e) {
        e.preventDefault();
        let data = new FormData(e.target);
        let username = data.get('username');
        let password = data.get('password');

        if (username.trim() === '' || password.trim() === '') {
            window.alert('There cannot be empty fields!');
            return;
        }

        let user = {
            username,
            password
        }

        try{
           let result = await authService.login(user);
            ctx.page.redirect('/allListings');
        }catch(err){
            window.alert(err);
        }
    }


    renderMain(loginTemplate(loginHandler));
}