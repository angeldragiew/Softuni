import authService from "../services/authService.js";

export function authMiddleware(ctx, next) {
    let data = authService.getData();
    if (data.accessToken) {
        ctx.isLoggedIn = true;
        ctx.userId = data.userId;
        ctx.username = data.username;///promeneno
        ctx.accessToken = data.accessToken;
    }
    next();
}