import { render } from "../../node_modules/lit-html/lit-html.js";
import furnitureService from "../../services/furnitureService.js";
import { createTemplate, createFormFields } from "./createTemplate.js";

let fields = {
    make: false,
    model: false,
    year: false,
    description: false,
    price: false,
    img: false
};


async function getView(context, next) {
    let createHandler = create.bind(null, context);
    render(createTemplate(createHandler, fields), document.getElementById('root'));

    next();
}

export default {
    getView
}

async function create(context, e) {
    e.preventDefault();

    let data = new FormData(e.target);
    let make = data.get('make');
    let model = data.get('model');
    let year = Number(data.get('year'));
    let description = data.get('description');
    let price = Number(data.get('price'));
    let img = data.get('img');
    let material = data.get('material');
    let _id = context.params.id;

    let isValid = fieldValidator(make, model, year, description, price, img);

    if (isValid === false) {
        render(createFormFields(fields), document.getElementById('formCreate'));
        return;
    }

    let newFurniture = {
        make,
        model,
        year,
        description,
        price,
        img,
        material,
        _id
    }

    try {
        let result = await furnitureService.create(newFurniture);
        context.page.redirect('/dashboard')
    } catch (err) {
        alert(err);
    }
}

function fieldValidator(make, model, year, description, price, img) {
    let isValid = true;

    if (make.length < 4) {
        fields.make = false;
        isValid = false;
    } else {
        fields.make = true;
    }

    if (model.length < 4) {
        fields.model = false;
        isValid = false;
    } else {
        fields.model = true;
    }

    if (description.length < 10) {
        fields.description = false;
        isValid = false;
    } else {
        fields.description = true;
    }
    if (year < 1950 || year > 2050) {
        fields.year = false;
        isValid = false;
    } else {
        fields.year = true;
    }

    if (price < 0) {
        fields.price = false;
        isValid = false;
    } else {
        fields.price = true;
    }

    if (img === '') {
        fields.img = false;
        isValid = false;
    } else {
        fields.img = true;
    }

    return isValid;
}


