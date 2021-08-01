import { html } from "../../node_modules/lit-html/lit-html.js";
import authService from "../../services/authService.js";

export let furnitureDetailsTemplate = (furniture) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Furniture Details</h1>
    </div>
</div>
<div class="row space-top">
    <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img src="${furniture.img.replace('.', '')}" />
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <p>Make: <span>${furniture.make}</span></p>
        <p>Model: <span>${furniture.model}</span></p>
        <p>Year: <span>${furniture.year}</span></p>
        <p>Description: <span>${furniture.description}</span></p>
        <p>Price: <span>${furniture.price}</span></p>
        <p>Material: <span>${furniture.material}</span></p>
            ${furniture._ownerId === authService.getUserId()
                 ? html`  <div><a href="/edit/${furniture._id}" class="btn btn-info">Edit</a>
            <a href="/delete/${furniture._id}" class="btn btn-red">Delete</a></div>`
            :''}   
    </div>
</div>
`;