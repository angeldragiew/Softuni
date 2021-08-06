
import { jsonRequester } from "../helpers/jsonRequester.js";
import * as api from "../services/api.js";

async function getAll() {
    let result = await jsonRequester(api.allListing);
    return result;
}

async function getListing(id) {
    let result = await jsonRequester(api.listing(id));
    return result;
}

async function getUserListings(userId) {
    let result = await jsonRequester(api.userListings(userId));
    return result;
}

async function createListing(newListing) {
    let result = await jsonRequester(api.createListing, 'post', newListing, true);
    return result;
}

async function updateListing(id, updatedListing) {
    let result = await jsonRequester(api.updateListing(id), 'put', updatedListing, true);
    return result;
}

async function deleteListing(ctx) {
    let id = ctx.params.id;
    try {
        let result = await jsonRequester(api.deleteListing(id), 'delete', undefined, true);
        ctx.page.redirect('/allListings');
    } catch (err) {
        window.alert(err);
    }
}

async function getListingByYear(year) {
    let result = await jsonRequester(api.listingByYear(year));
    return result;
}

export default {
    getAll,
    getListing,
    createListing,
    updateListing,
    deleteListing,
    getUserListings,
    getListingByYear
}