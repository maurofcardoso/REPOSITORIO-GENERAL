import { GetOrdenByDate } from '../Services/FetchOrdenCompra.js';
import { IndexPageBalnance, IndexBalanceDiario } from '../Containers/Balance.js';

IndexPageBalnance();

const _button = document.getElementById ('formBusqueda');    

const OrdenDetail = async (event) => {
    event.preventDefault();
    const from = event.currentTarget[0].value;
    const to = event.currentTarget[1].value;
    const orden = await GetOrdenByDate (from, to);
    localStorage.setItem ("from", from);
    localStorage.setItem ("to", to);
    IndexBalanceDiario ("infoBalance", "infoBalanceProducts", orden, from, to);
}

_button.addEventListener ('submit', OrdenDetail);




