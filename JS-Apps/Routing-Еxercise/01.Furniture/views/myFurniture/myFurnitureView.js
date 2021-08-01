import { render } from "../../node_modules/lit-html/lit-html.js";
import authService from "../../services/authService.js";
import furnitureService from "../../services/furnitureService.js";
import { allMyfurnitureTemplate } from "./myFurnitureTemplate.js";

async function getView(context, next) {
    let allFurnitures = await furnitureService.getAll();
    allFurnitures = allFurnitures.filter(f=>f._ownerId===authService.getUserId());
    render(allMyfurnitureTemplate(allFurnitures), document.getElementById('root'));
    next();
}

export default {
    getView
}
