import page from "./node_modules/page/page.mjs";
import authService from "./services/authService.js";
import furnitureService from "./services/furnitureService.js";
import createView from "./views/create/createView.js";
import dashBoardView from "./views/dashboard/dashBoardView.js";
import furnitureDetailsView from "./views/details/furnitureDetailsView.js";
import editView from "./views/edit/editView.js";
import loginView from "./views/login/loginView.js";
import myFurnitureView from "./views/myFurniture/myFurnitureView.js";
import navBarView from "./views/navbar/navBarView.js";
import registerView from "./views/register/registerView.js";

page('/dashboard', dashBoardView.getView, navBarView.getView);
page('/my-furniture', myFurnitureView.getView, navBarView.getView);
page('/create', createView.getView, navBarView.getView);
page('/furnitureDetails/:id', furnitureDetailsView.getView, navBarView.getView);
page('/login', loginView.getView, navBarView.getView);
page('/register', registerView.getView, navBarView.getView);
page('/logout', authService.logout, navBarView.getView);
page('/edit/:id', editView.getView, navBarView.getView);
page('/delete/:id',furnitureService.deleteFurniture, navBarView.getView);

page('/index.html', '/dashboard');
page('/01.Furniture/index.html', '/dashboard');

page('/', '/dashboard');

page.start();