import { GetUrlBase } from "../Services/URL.js";
import { ProductoExiste, ProductoNoExiste, ErrorDePeticion } from "../Components/ErrorComponents.js";

const URLCarrito =  `${GetUrlBase()}/carrito`;

export const AddProduct = async (productId, amount) => {
    const list = await fetch(URLCarrito, {
        method: 'PATCH',
        headers: {
            "Content-Type": "application/json",
            "Content-Type": "application/json" 
        },
        body: JSON.stringify({
            "clientId": 1,
            "productId": parseInt(productId),
            "amount": parseInt(amount)
        })
    })
    .then((response) => {
        if (response.status === 200) {
            return response;
        }
        if (response.status === 404) {
            const _listProducts = document.getElementById ("listProduct");
            _listProducts.innerHTML = ProductoExiste();
        }
    })
    .catch((error) => {
        return error;
    })
    if (list !== undefined) {
        const listProduct = await list.json();
        return (listProduct);
    }
};

export const ModifyProduct = async (productId, amount) => {
    const list = await fetch(URLCarrito, {
        method: 'PUT',
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            "clientId": parseInt ('1'),
            "productId": parseInt(productId),
            "amount": parseInt(amount)
        })
    })
    .then((response) => {
        if (response.status === 200) {
            return response;
        }
        if (response.status === 400) {
            const _listProducts = document.getElementById ("listProduct");
            _listProducts.innerHTML = ProductoNoExiste();
        }
    })
    .catch((error) => {
        return error;
    })
    if (list !== undefined) {
        const listProduct = await list.json();
        return (listProduct);
    }
};

export const DeleteCarrito = async (productId) => {
    const list = await fetch(`${URLCarrito}/${1}/${productId}`, {
        method: 'DELETE',
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            "clientId": 1,
            "productId": parseInt(productId)
        })
    })
    .then((response) => {
        if (response.status === 200) {
            return response;
        }
        if (response.status === 404) {
            const _listProducts = document.getElementById ("listProduct");
            _listProducts.innerHTML = ProductoNoExiste();
        }
        if (response.status === 400) {
            const _listProducts = document.getElementById ("listProduct");
            _listProducts.innerHTML = ErrorDePeticion();
        }
    })
    .catch((error) => {
        return error;
    })
    if (list !== undefined) {
        const listProduct = await list.json();
        return (listProduct);
    }
}

export const GetCarrito = async (clientId) => {
    const list = await fetch (`${URLCarrito}/${clientId}`, {
        method: 'GET',
        headers: {
            "Content-Type": "application/json",
            'Content-Type': 'application/json' 
        },
    })
    .then((response) => {
        if (response.status === 200) {
            return response;
        }
        if (response.status === 404) {
            const _listProducts = document.getElementById ("listProduct");
            _listProducts.innerHTML = ProductoExiste();
        }
    })
    .catch((error) => {
        return error;
    })
    if (list !== undefined) {
        const listProduct = await list.json();
        return (listProduct);
    }
}