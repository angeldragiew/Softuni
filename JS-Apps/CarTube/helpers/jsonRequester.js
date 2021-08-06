import authService from "../services/authService.js";

export async function jsonRequester(url, method, body, authorizedRequest, skipResult) {
    if (method === undefined) {
        method = 'get';
    }

    let headers = {};

    if (method.toLowerCase() === 'post' ||
        method.toLowerCase() === 'put' ||
        method.toLowerCase() === 'patch') {
        headers['Content-type'] = 'application/json';
    }

    if (authorizedRequest) {
        headers['X-Authorization'] = authService.getAccessToken();
    }

    let options = {
        method,
        headers
    }

    if (body !== undefined) {
        options.body = JSON.stringify(body);
    }

    let request = await fetch(url, options);
    if (!request.ok) {
        let message = await request.text();
        throw new Error(`${message}`);
    }

    let result = undefined;
    if (!skipResult) {
        result = await request.json();
    }
    return result;
}