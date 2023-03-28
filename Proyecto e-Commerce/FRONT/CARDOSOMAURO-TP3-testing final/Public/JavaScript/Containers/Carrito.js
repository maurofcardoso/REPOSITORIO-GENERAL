import { CreateCarritoComponent, PageCarrito, CarritoInfoCliente } from '../Components/CarritoComponents.js';
import { GetCarrito } from '../Services/FetchCarrito.js';
import { modify, deleteProduct } from '../Services/CarritoEvents.js';
import { ErrorCarritoVacio } from '../Components/ErrorComponents.js';

export const IndexRenderCarrito = async (pos)  => {
    const carrito = await GetCarrito (1);
    const _listCarrito = document.getElementById(pos);
    _listCarrito.innerHTML = "";
    carrito.listCarritoProductoResponse.forEach(x => {
        _listCarrito.innerHTML += (CreateCarritoComponent (x));
    });
    const _modify = document.getElementsByClassName ("inputCarrito"); 
    const _delete = document.getElementsByClassName ('deleteButton');
    if (_modify.length !== 0) {
        for (let x of _modify) {
            x.addEventListener ('click', modify);
        }
        for (let x of _delete) {
            x.addEventListener ('click', deleteProduct);
        }
    }
    if (carrito.listCarritoProductoResponse.length === 0) {
        _listCarrito.innerHTML = ErrorCarritoVacio();
    }
}

export const IndexPageCarrito = async () => {
    const page = document.getElementById ('center');
    page.innerHTML = PageCarrito();
}

export const IndexInfoCompra = async (pos) => {
    const carrito = await GetCarrito (1);
    const _info = document.getElementById(pos);
    _info.innerHTML = "";
    let totalProductos = carrito.listCarritoProductoResponse.length;
    let totalCompra = 0;
    carrito.listCarritoProductoResponse.forEach(x => {
        totalCompra += x.cantidad * x.precio;
    });
    _info.innerHTML = CarritoInfoCliente (totalProductos, totalCompra);
}