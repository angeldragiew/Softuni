import { authMiddleware } from "./middlewares/authMiddleWare.js";
import { navMiddleWare } from "./middlewares/navMiddleware.js";
import page from "./node_modules/page/page.mjs";
import authService from "./services/authService.js";
import listingService from "./services/listingService.js";
import { allListingView } from "./views/allListingsView.js";
import { createView } from "./views/createView.js";
import { detailsView } from "./views/detailsView.js";
import { editView } from "./views/editView.js";
import { homeView } from "./views/homeView.js";
import { loginView } from "./views/loginView.js";
import { myListingsView } from "./views/myListingsView.js";
import { registeView } from "./views/registerView.js";
import { searchView } from "./views/searchView.js";

page(authMiddleware);
page(navMiddleWare);

page('/index.html', '/home');
page('/', '/home');
page('/home', homeView);
page('/login', loginView);
page('/register', registeView);
page('/logout', authService.logout);
page('/allListings', allListingView);
page('/details/:id', detailsView);
page('/edit/:id', editView);
page('/delete/:id', listingService.deleteListing);
page('/createListing', createView);
page('/myListings', myListingsView);
page('/byYear', searchView);

page.start();