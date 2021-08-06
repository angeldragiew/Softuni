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

let allListingsTemplate = (listings) => html`
<section id="car-listings">
    <h1>Car Listings</h1>
    <div class="listings">

        <!-- Display all records -->
        ${listings.length > 0 ? listings.map(l => listingTemplate(l)) : html` <p class="no-cars">No cars in database.
        </p>`}
        <!-- Display if there are no records -->
    </div>
</section>
`;

export async function allListingView() {
    try {
        let listings = await listingService.getAll();
        renderMain(allListingsTemplate(listings));
    } catch (err) {
        window.alert(err);
    }
}
