import { render } from "../../node_modules/lit-html/lit-html.js";
import authService from "../../services/authService.js";
import { registerTemplate } from "./registerTemplate.js";

async function getView(context, next) {
    let registerHandler = register.bind(null, context);
    render(registerTemplate(registerHandler), document.getElementById('root'));
    next();
}

async function register(context, e) {
    e.preventDefault();
    let data = new FormData(e.target);
    let email = data.get('email');
    let password = data.get('password');
    let rePass = data.get('rePass');

    if (password !== rePass) {
        alert('Passwords must match!');
        return;
    }

    let newUser = {
        email,
        password
    }
    try {
        let result = await authService.register(newUser);
        context.page.redirect('/dashboard')
    } catch (err) {
        alert(err);
    }
}

export default {
    getView
}