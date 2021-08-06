import { html,render } from "../node_modules/lit-html/lit-html.js";
import { renderMain } from "../helpers/renderer.js";
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

let listingsTemplate = (listings) => html`
${listings.length > 0 ? listings.map(l => listingTemplate(l)) : html`<p class="no-cars"> No results.</p>`}
`;

let searchTemplate = (searchHandler) => html`
<section id="search-cars">
    <h1>Filter by year</h1>

    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year">
        <button @click=${searchHandler} class="button-list">Search</button>
    </div>

    <h2>Results:</h2>
    <div class="listings">

        <!-- Display all records -->
        <!-- Display if there are no matches -->
    </div>
</section>
`;

export function searchView() {
    async function searchHandler(e) {
        e.preventDefault();
        let searchedValue = document.getElementById('search-input').value;
        if (searchedValue.trim() !== '') {
            let listings = await listingService.getListingByYear(Number(searchedValue));
            render(listingsTemplate(listings), document.querySelector('.listings'))
        }
    }
    renderMain(searchTemplate(searchHandler));
}