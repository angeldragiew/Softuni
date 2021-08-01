import { render } from "../../node_modules/lit-html/lit-html.js";
import authService from "../../services/authService.js";
import { navTemplate } from "./navTemplate.js";


async function getView(context){
    let navInfo = {
        isLoggedUser:authService.isLoggedIn(),
        currentPage: context.path
    }
    render(navTemplate(navInfo), document.getElementById('navbar'));
}

export default{
    getView
}