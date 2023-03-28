import { CreateOrdenComponent, CreateListProductOrden, PageOrden } from '../Components/OrdenComponents.js';

export const IndexRenderInfoOrden = async (posInfo, posProducts, ordenCompra)  => {
    const informacionGeneral = document.getElementById(posInfo);
    informacionGeneral.innerHTML = "";
    const info = CreateOrdenComponent (ordenCompra);
    informacionGeneral.innerHTML = (info);
    const products = document.getElementById (posProducts);
    products.innerHTML = "";
    ordenCompra.responseCompleto.listCarritos.forEach (x => {
        products.innerHTML += (CreateListProductOrden (x));
    })
}

export const IndexPageOrden = () => {
    const page = document.getElementById ('center');
    page.innerHTML = PageOrden();
}