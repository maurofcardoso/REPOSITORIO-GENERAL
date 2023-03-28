import { PageContacto } from "../Components/ContactoComponents.js";

export const IndexPageContacto = async () => {
    const page = document.getElementById ('center');
    page.innerHTML = PageContacto ();
}