import { render } from "../../node_modules/lit-html/lit-html.js";
import furnitureService from "../../services/furnitureService.js";
import { furnitureDetailsTemplate } from "./furnitureDetailsTemplate.js";


async function getView(context,next) {
    let furniture = await furnitureService.get(context.params.id);
    render(furnitureDetailsTemplate(furniture), document.getElementById('root'));
    next();
}

export default {
    getView
}
