import { renderMain } from "../helpers/renderer.js";
import { html } from "../node_modules/lit-html/lit-html.js";
import listingService from "../services/listingService.js";

let ownerButtons = (listing) => html`
        <div class="listings-buttons">
            <a href="/edit/${listing._id}" class="button-list">Edit</a>
            <a href="/delete/${listing._id}" class="button-list">Delete</a>
        </div>
`;

let detailsTemplate = (listing, userId) => html`
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src="${listing.imageUrl}">
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${listing.brand}</li>
            <li><span>Model:</span>${listing.model}</li>
            <li><span>Year:</span>${listing.year}</li>
            <li><span>Price:</span>${listing.price}$</li>
        </ul>

        <p class="description-para">${listing.description}</p>
        ${userId === listing._ownerId ? ownerButtons(listing) : ''}
    </div>
</section>
`;

export async function detailsView(ctx) {
    try {
        let listing = await listingService.getListing(ctx.params.id);
        renderMain(detailsTemplate(listing, ctx.userId));
    } catch (err) {
        window.alert(err);
    }
}
