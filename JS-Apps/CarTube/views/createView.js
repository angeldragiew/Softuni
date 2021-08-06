import { renderMain } from "../helpers/renderer.js";
import { html } from "../node_modules/lit-html/lit-html.js";
import listingService from "../services/listingService.js";


let createTemplate = (createHandler) => html`
<section id="create-listing">
    <div class="container">
        <form @submit=${createHandler} id="create-form">
            <h1>Create Car Listing</h1>
            <p>Please fill in this form to create an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand">

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model">

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description">

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year">

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl">

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price">

            <hr>
            <input type="submit" class="registerbtn" value="Create Listing">
        </form>
    </div>
</section>
`;

export function createView(ctx) {
    async function createHandler(e) {
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

        let newListing = {
            brand,
            model,
            description,
            year,
            imageUrl,
            price          
        }

        try {
            let result = await listingService.createListing(newListing);
            ctx.page.redirect('/allListings');
        } catch (err) {
            window.alert(err);
        }
    }

    renderMain(createTemplate(createHandler));
}