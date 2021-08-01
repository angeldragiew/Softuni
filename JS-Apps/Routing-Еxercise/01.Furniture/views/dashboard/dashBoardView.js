import { render } from "../../node_modules/lit-html/lit-html.js";
import { dashboardTemplate } from "./dashboardTemplate.js";
import furnitureService from "../../services/furnitureService.js";

async function getView(context, next) {
    let allFurnitures = await furnitureService.getAll();
    render(dashboardTemplate(allFurnitures), document.getElementById('root'));
    next();
}

export default {
    getView
}
