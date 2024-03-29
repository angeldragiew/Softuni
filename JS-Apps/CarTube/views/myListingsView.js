import { renderMain } from "../helpers/renderer.js";
import { html } from "../node_modules/lit-html/lit-html.js";
import listingService from "../services/listingService.js";

let listingTemplate = (listing) => html`
<div class="listing">
    <div class="preview">
        <img src="${listing.imageUrl}">
    </div>
    <h2>${listing.brand} ${listing.model}</h2>
    <div class="info">
        <div class="data-info">
            <h3>Year: ${listing.year}</h3>
            <h3>Price: ${listing.price} $</h3>
        </div>
        <div class="data-buttons">
            <a href="/details/${listing._id}" class="button-carDetails">Details</a>
        </div>
    </div>
</div>
`;

let myListingsTemplate = (listings) => html`
<section id="my-listings">
    <h1>My car listings</h1>
    <div class="listings">
        <!-- Display all records -->
        ${listings.length > 0 ? listings.map(l => listingTemplate(l)) : html`<p class="no-cars"> You haven't listed any
            cars yet.</p>`}
        <!-- Display if there are no records -->
    </div>
</section>
`;

export async function myListingsView(ctx) {
    try {
        let listings = await listingService.getUserListings(ctx.userId);
        renderMain(myListingsTemplate(listings));
    } catch (err) {
        window.alert(err);
    }
}