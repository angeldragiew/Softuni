import { jsonRequester } from "../helpers/jsonRequester.js";
import * as api from "../services/api.js";

function saveData(userId, email, accessToken) {
    localStorage.setItem('userId', userId);
    localStorage.setItem('email', email);
    localStorage.setItem('accessToken', accessToken);
}

function deleteData() {
    localStorage.removeItem('userId');
    localStorage.removeItem('email');
    localStorage.removeItem('accessToken');
}

export function getData() {
    let userId = getUserId();
    let username = getUsername();
    let accessToken = getAccessToken();//////////////////

    return {
        userId,
        username,
        accessToken,
    }
}

function getAccessToken() {
    return localStorage.getItem('accessToken');
}

function getUsername() {
    return localStorage.getItem('username');
}

function getUserId() {
    return localStorage.getItem('userId');
}

function isLoggedIn() {
    return localStorage.getItem('accessToken') !== null;
}

async function login(user) {
    let result = await jsonRequester(api.login, 'Post', user);
    localStorage.setItem('accessToken', result.accessToken);
    localStorage.setItem('username', result.username);
    localStorage.setItem('userId', result._id);
    return result;
}

async function register(newUser) {
    let result = await jsonRequester(api.register, 'Post', newUser);
    console.log(result);
    localStorage.setItem('accessToken', result.accessToken);
    localStorage.setItem('username', result.username);
    localStorage.setItem('userId', result._id);
    return result;
}

async function logout(context) {
    try {
        let result = await jsonRequester(api.logout, 'get', undefined, true, true);
        localStorage.clear();
        context.page.redirect('/home');
    } catch (err) {
        console.log(err);
    }
}

export default {
    getAccessToken,
    getUserId,
    getUsername,
    isLoggedIn,
    login,
    register,
    logout,
    saveData,
    deleteData,
    getData
}