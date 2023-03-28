import { PageProducts, CreateProductInfo, CreateProductCard } from "../Components/ProductsComponents.js";
import { GetProducts } from "../Services/FetchProduct.js";
import { ButtonAddCarrito, infoProductEventCarga } from '../Services/ProductEvents.js';

const RenderProducts = (pos, product) => {
    let _pos = document.getElementById (pos);
    _pos.innerHTML = (CreateProductInfo (product));
}

export const IndexRenderProducts = async (pos, name, sort)  => {
    document.getElementById(pos).innerHTML = "";
    const products = await GetProducts(name, sort);
    await products.forEach(x => {
        RenderProducts(pos, x);
        const _buttonAddCarrito = document.getElementById ('addButton');
        _buttonAddCarrito.addEventListener ('click', ButtonAddCarrito);
    });
}

export const IndexRenderProductCard = async (pos, name, sort) => {
    document.getElementById(pos).innerHTML = "";
    const products = await GetProducts(name, sort);
    let _pos = document.getElementById (pos);
    products.forEach(x => {
        _pos.innerHTML += CreateProductCard(x);
    });
    infoProductEventCarga();
}

export const IndexPageProduct = async () => {
    const page = document.getElementById ('center');
    page.innerHTML = PageProducts();
}