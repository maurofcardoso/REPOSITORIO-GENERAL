import { PageQuienesSomos, CreateQuienesSomosComponent } from "../Components/QuienesSomosComponents.js";

export const IndexPageQuienesSomos = async () => {
    const page = document.getElementById ('center');
    page.innerHTML = PageQuienesSomos ();
}

export const IndexRenderQuienesSomos = async (pos1)  => {
    const _infoQuienesSomos = document.getElementById(pos1);
    _infoQuienesSomos.innerHTML = "";
    _infoQuienesSomos.innerHTML = CreateQuienesSomosComponent ();
}