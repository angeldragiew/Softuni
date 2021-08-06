export const baseUrl = `http://localhost:3030`;

export const login = `${baseUrl}/users/login`;

export const register = `${baseUrl}/users/register`;

export const logout = `${baseUrl}/users/logout`;

export const allListing = `${baseUrl}/data/cars?sortBy=_createdOn%20desc`;

export const listing = (id) => `${baseUrl}/data/cars/${id}`;

export const createListing = `${baseUrl}/data/cars`;

export const updateListing = (id) => `${baseUrl}/data/cars/${id}`;

export const deleteListing = (id) => `${baseUrl}/data/cars/${id}`;

export const listingByYear = (year) => `${baseUrl}/data/cars?where=year%3D${year}`;

export const userListings = (userId) => `${baseUrl}/data/cars?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`;


