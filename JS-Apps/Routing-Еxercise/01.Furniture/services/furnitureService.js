import { jsonRequester } from "../helpers/jsonRequester.js";


async function getAll() {
    let result = await jsonRequester('http://localhost:3030/data/catalog');
    return result;
}

async function get(id) {
    let result = await jsonRequester(`http://localhost:3030/data/catalog/${id}`);
    return result;
}

async function create(item) {
    let result = await jsonRequester(`http://localhost:3030/data/catalog`, 'post', item,true);
}

async function update(item, id) {
    let result = await jsonRequester(`http://localhost:3030/data/catalog/${id}`, 'put', item, true);
    return result;
}

async function deleteFurniture(context, next) {
    let id = context.params.id;
    try {
        let result = jsonRequester(`http://localhost:3030/data/catalog/${id}`, 'delete', undefined, true);

    } catch (err) {
        console.log(err);
    }

    context.page.redirect('/dashboard');
}

export default {
    getAll,
    get,
    create,
    update,
    deleteFurniture
}