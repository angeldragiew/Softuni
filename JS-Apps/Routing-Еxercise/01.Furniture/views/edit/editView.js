import { render } from "../../node_modules/lit-html/lit-html.js";
import furnitureService from "../../services/furnitureService.js";
import { editTemplate } from "./editTemplate.js";

async function getView(context, next) {
    let editHandler = edit.bind(null, context);
    let furniture = await furnitureService.get(context.params.id);

    render(editTemplate(furniture, editHandler), document.getElementById('root'));
    next();
}

async function edit(context, e) {
    e.preventDefault();
    let data = new FormData(e.target);

    let make = data.get('make');
    let model = data.get('model');
    let year = data.get('year');
    let description = data.get('description');
    let price = data.get('price');
    let img = data.get('img');
    let material = data.get('material');
    let _id = context.params.id;

    let furniture = {
        make,
        model,
        year,
        description,
        price,
        img,
        material,
        _id
    }

    let result = await furnitureService.update(furniture, _id);
    context.page.redirect(`/furnitureDetails/${context.params.id}`);
}

export default {
    getView
}