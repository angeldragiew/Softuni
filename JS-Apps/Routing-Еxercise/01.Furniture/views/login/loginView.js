import { render } from "../../node_modules/lit-html/lit-html.js";
import authService from "../../services/authService.js";
import { loginTemplate } from "./loginTemplate.js";


async function getView(context, next) {
    let loginHandler = login.bind(null, context);
    render(loginTemplate(loginHandler), document.getElementById('root'));
    next();
}

async function login(context, e) {
    e.preventDefault();
    let data = new FormData(e.target);
    let email =  data.get('email');
    let password =  data.get('password');

    let user = {
        email,
        password
    }
    try{
        let result = await authService.login(user);
        context.page.redirect('/dashboard')
    }catch(err){
        alert(err);
    }
}

export default {
    getView
}