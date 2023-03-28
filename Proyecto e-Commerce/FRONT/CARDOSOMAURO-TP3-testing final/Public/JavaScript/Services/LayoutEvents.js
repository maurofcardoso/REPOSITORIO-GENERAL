import { GetProducts } from "./FetchProduct.js";
import { AddProduct } from "./FetchCarrito.js";
import { CreateProductCard } from "../Components/ProductsComponents.js";
import { IndexRenderProducts } from "../Containers/Products.js";
import { SinCoincidencias, ContenerLetras } from "../Components/ErrorComponents.js";

const expresionRegular = /^[a-zA-ZÀ-ÿ\s]{1,40}$/;
let palabra = '';

export const Validation = async (event) => {
    const _checkOut = document.getElementById ('checkOut');
    const _listProduct = document.getElementById('listProduct');
    if ( event.keyCode !== 8 && event.keyCode !== 13 && event.pointerId !== 1) {
        if (expresionRegular.test(event.key)) {
            _listProduct.innerHTML = "";
            palabra += `${event.key}`;
            const products = await GetProducts (palabra, _checkOut.checked);
            if (products != null) {
                products.forEach (x => {
                    _listProduct.innerHTML += (CreateProductCard (x));
                });
                infoProductEventCarga();
            }
        }else{
            if (!expresionRegular.test(event.key)){
                _listProduct.innerHTML = "";
                _listProduct.innerHTML = ContenerLetras();
            }
        }
    }else {
        if (event.keyCode === 8) {
            const value = palabra;
            palabra = value.slice  (0, -1);
            const products = await GetProducts (palabra, _checkOut.checked);
            _listProduct.innerHTML = "";
            products.forEach (x => {
                _listProduct.innerHTML += (CreateProductCard (x));
            });
            infoProductEventCarga();
        }else {
            event.preventDefault();
            if (expresionRegular.test(palabra)) {
                _listProduct.innerHTML = "";
                const products = await GetProducts (palabra, _checkOut.checked);
                if (products != null) {
                    products.forEach (x => {
                        _listProduct.innerHTML += (CreateProductCard (x));
                    });
                    infoProductEventCarga();
                }else {
                    _listProduct.innerHTML = SinCoincidencias();
                }
            }else{
                if (!expresionRegular.test(event.key)){
                    _listProduct.innerHTML = "";
                    _listProduct.innerHTML = ContenerLetras();
                }
            }
        }
    }
}

export const InfoProductEvent = async (event) => {
    event.preventDefault();
    IndexRenderProducts ('listProduct', event.currentTarget.childNodes[1].id, '');
}

export const infoProductEventCarga = () => {
    const _infoProduct = document.querySelectorAll ('#listProduct a');
    if (_infoProduct) {
        _infoProduct.forEach (x => {
            x.addEventListener ('click', InfoProductEvent);
        })
    }
}

export const ButtonAddCarrito = async (event) => {
    const _product = document.getElementsByClassName ('detailProduct');
    const _input = document.getElementById ('inputCarrito');
    const product = await AddProduct ( _product[0].id, _input.value);
    if (product) {
        const _listProduct = document.getElementById ('listProduct');
        _listProduct.innerHTML = "";
        window.location.href = "http://localhost:3000/Products";
        localStorage.setItem ("active", "true");
    }
}

export const CheckSearch = async (event) => {
    const _checkOut = document.getElementById ('checkOut');
    const _listProduct = document.getElementById('listProduct');
    const products = await GetProducts (palabra, _checkOut.checked);
    _listProduct.innerHTML = "";
    if (products === null){
        _listProduct.innerHTML = SinCoincidencias();
    }else {
        products.forEach (x => {
            _listProduct.innerHTML += (CreateProductCard (x));
        });
        infoProductEventCarga();
    }
}