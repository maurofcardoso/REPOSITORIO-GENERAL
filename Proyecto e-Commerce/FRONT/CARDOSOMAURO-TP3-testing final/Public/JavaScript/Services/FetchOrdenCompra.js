import { GetUrlBase } from "../Services/URL.js";
import { ErrorGenerarOrden } from "../Components/ErrorComponents.js";

const URLOrden =  `${GetUrlBase()}/orden`;

export const CreateOrden = async (clientId) => {
    const list = await fetch (`${URLOrden}/${clientId}`, {
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
    })
    .then((response) => {
        if (response.status === 201) {
            return response;
        }
        if (response.status === 400) {
            const _error = document.getElementById ("subDiv1");
            _error.innerHTML = ErrorGenerarOrden();
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

export const GetOrdenByDate = async (from, to) => {
    const list = await fetch (`${URLOrden}?from=${from}&to=${to}`, {
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        }
    })
    .then((response) => {
        if (response.status === 200) {
            return response;
        }
        if (response.status === 404) {
            const _error = document.getElementById ("subDiv1");
            _error.innerHTML = ErrorGenerarOrden();
        }
    })
    .catch((error) => {
        return error;
    })
    if (list !== undefined) {
        const listOrden = await list.json();
        return (listOrden);
    }
}