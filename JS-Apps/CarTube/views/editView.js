import { renderMain } from "../helpers/renderer.js";
import { html } from "../node_modules/lit-html/lit-html.js";
import listingService from "../services/listingService.js";


let editTemplate = (editHandler, listing) => html`
<section id="edit-listing">
    <div class="container">

        <form @submit=${editHandler} id="edit-form">
            <h1>Edit Car Listing</h1>
            <p>Please fill in this form to edit an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand" value=${listing.brand}>

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model" value=${listing.model}>

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description" value=${listing.description}>

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year" value=${listing.year}>

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl" value=${listing.imageUrl}>

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price" value=${listing.price}>

            <hr>
            <input type="submit" class="registerbtn" value="Edit Listing">
        </form>
    </div>
</section>
`;

export async function editView(ctx) {
    async function editHandler(e) {
        e.preventDefault();
        let data = new FormData(e.target);

        let brand = data.get('brand');
        let model = data.get('model');
        let description = data.get('description');
        let year = data.get('year');
        let imageUrl = data.get('imageUrl');
        let price = data.get('price');

        if (brand.trim() === '' ||
            model.trim() === '' ||
            description.trim() === '' ||
            year.trim() === '' ||
            imageUrl.trim() === '' ||
            price.trim() === '') {
            window.alert('There cannot be empty fields!');
            return;
        }
        year = Number(year);
        price = Number(price);

        if (year < 0 || price < 0) {
            window.alert('The values of year and price must be positive numbers!');
            return;
        }

        let updatedListing = {
            brand,
            model,
            description,
            year,
            imageUrl,
            price
        }

        try {
            let result = await listingService.updateListing(ctx.params.id, updatedListing);
            ctx.page.redirect(`/details/${ctx.params.id}`)
        } catch (err) {
            window.alert(err);
        }
    }

    let listing = await listingService.getListing(ctx.params.id);
    renderMain(editTemplate(editHandler, listing));
}