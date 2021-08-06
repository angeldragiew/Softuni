import { html } from "../node_modules/lit-html/lit-html.js";

let guestUserButtons = () => html`
<div id="guest">
    <a href="/login">Login</a>
    <a href="/register">Register</a>
</div>
`;

let loggedUserButtons = (username) => html`
    <div id="profile">
        <a>Welcome ${username}</a>
        <a href="/myListings">My Listings</a>
        <a href="/createListing">Create Listing</a>
        <a href="/logout">Logout</a>
    </div>
`;

export let navTemplate = (isUserLogged, username) => html`
<nav>
    <a class="active" href="/home">Home</a>
    <a href="/allListings">All Listings</a>
    <a href="/byYear">By Year</a>
    <!-- Guest users -->
    ${isUserLogged ? loggedUserButtons(username) : guestUserButtons()}
    <!-- Logged users -->
</nav>
`;