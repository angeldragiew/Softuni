import { render } from "../node_modules/lit-html/lit-html.js"
import { navTemplate } from "../views/nav.js"

let navRootElement = document.querySelector('header');

export function navMiddleWare(ctx, next) {
    render(navTemplate(ctx.isLoggedIn, ctx.username), navRootElement);
    next();
}