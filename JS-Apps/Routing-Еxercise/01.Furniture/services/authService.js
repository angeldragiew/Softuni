import { jsonRequester } from "../helpers/jsonRequester.js";


let baseUrl = 'http://localhost:3030/users/';
function getAuthToken() {
    return localStorage.getItem('authToken');
}

function getUsername() {
    return localStorage.getItem('username');
}

function getUserId() {
    return localStorage.getItem('userID');
}

function isLoggedIn() {
    return localStorage.getItem('authToken') !== null;
}

async function login(user) {
    let result = await jsonRequester(`${baseUrl}login`, 'Post', user);
    localStorage.setItem('authToken', result.accessToken);
    localStorage.setItem('username', result.email);
    localStorage.setItem('userID', result._id);
    return result;
}

async function register(newUser) {
    let result = await jsonRequester(`${baseUrl}register`, 'Post', newUser);
    localStorage.setItem('authToken', result.accessToken);
    localStorage.setItem('username', result.email);
    localStorage.setItem('userID', result._id);
    return result;
}

async function logout(context, next) {
    let result = await jsonRequester(`${baseUrl}logout`, 'get', undefined, true, true);
    localStorage.clear();
    context.page.redirect('/dashboard');
    next();
}

export default {
    getAuthToken,
    getUserId,
    getUsername,
    isLoggedIn,
    login,
    register,
    logout
}