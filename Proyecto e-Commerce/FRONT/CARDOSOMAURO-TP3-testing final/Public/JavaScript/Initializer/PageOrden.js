import { IndexRenderInfoOrden, IndexPageOrden } from '../Containers/Orden.js';
import { CreateOrden } from '../Services/FetchOrdenCompra.js';

IndexPageOrden();

const CarryOrden = async () => {
    const orden = await CreateOrden (1);
    if (orden) {
        localStorage.setItem ("active", "false");
    }
    IndexRenderInfoOrden ('subDiv1', 'listOrden', orden);
}

CarryOrden();