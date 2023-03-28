import { GetUrlBase } from "./URL.js";

const urlProduct = `${GetUrlBase()}/productos`;

const urlProducts = (name, sort) => {
    if(name === '' && sort !== ''){
        return `${urlProduct}?sort=${sort}`;
    }
    if(name !== '' && sort !== ""){
        return `${urlProduct}?name=${name}&sort=${sort}`;
    }
    if(name !== '' && sort === ''){
        return `${urlProduct}?name=${name}`;
    }
    if(name === '' && sort === ''){
        return `${urlProduct}`;
    }
}

export const GetProducts = async (name, sort) => {
    const response = await fetch (urlProducts(name, sort), {method: 'POST'});
    const productsList = await response.json();
    return productsList;
}