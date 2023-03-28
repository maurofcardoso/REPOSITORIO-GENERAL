import { PageBalance, CreateComponentInfo, CreateBalanceComponent, CreateComponentVenta, CreateListBalanceOrden } from "../Components/BalanceDiario.js";
import { GetOrdenByDate } from "../Services/FetchOrdenCompra.js";

export const IndexPageBalnance = async () => {
    const page = document.getElementById ('center');
    page.innerHTML = PageBalance();
}

export const IndexBalanceDiario = async (posInfo, posProducts, ordenCompra, from, to) => {
    const elem = document.getElementById ("subDiv1");
    elem.innerHTML = "";
    const informacionGeneral = document.getElementById(posInfo);
    informacionGeneral.innerHTML = "";
    const info = CreateComponentInfo (ordenCompra, from, to);
    informacionGeneral.innerHTML = info;
    const products = document.getElementById (posProducts);
    products.innerHTML = "";
    let cont = 0;
    ordenCompra.listOrdenResponseCompleto.forEach (x => {
        products.innerHTML += CreateComponentVenta (cont, x.total, x);
        cont = cont + 1;
    })
    InfoEventCarry();
}

const detailVenta = async (event) => {
    event.preventDefault();
    const orden = await GetOrdenByDate (localStorage.getItem ("from"), localStorage.getItem ("to"));
    const list = document.getElementById ("infoBalanceProducts");
    list.innerHTML = "";
    IndexRenderInfoBalance ("infoBalance", "infoVentaBalance", orden.listOrdenResponseCompleto[event.target.id]);
}

const InfoEventCarry = () => {
    const _infoVenta = document.querySelectorAll ('.ventaBalance');
    if (_infoVenta) {
        _infoVenta.forEach (x => {
            x.addEventListener ('click', detailVenta);
        })
    }
}

const IndexRenderInfoBalance = async (posInfo, posProducts, ordenCompra)  => {
    const informacionGeneral = document.getElementById(posInfo);
    informacionGeneral.innerHTML = "";
    const info = CreateBalanceComponent (ordenCompra);
    informacionGeneral.innerHTML = (info);
    const products = document.getElementById (posProducts);
    products.innerHTML = "";
    ordenCompra.responseCompleto.listCarritos.forEach (x => {
        products.innerHTML += (CreateListBalanceOrden (x));
    })
    VolverEventCarry();
}

const VolverEventCarry = () => {
    const _volver = document.querySelectorAll (".buttonVolver");
    if (_volver) {
        _volver.forEach (x => {
            x.addEventListener ('click', Volver);
        })
    }
}

const Volver = async (event) => {
    event.preventDefault();
    const orden = await GetOrdenByDate (localStorage.getItem ("from"), localStorage.getItem ("to"));
    const _infoVentaBalance = document.getElementById ("infoVentaBalance");
    _infoVentaBalance.innerHTML = "";
    IndexBalanceDiario ("infoBalance", "infoBalanceProducts", orden, localStorage.getItem ("from"), localStorage.getItem ("to"));
}