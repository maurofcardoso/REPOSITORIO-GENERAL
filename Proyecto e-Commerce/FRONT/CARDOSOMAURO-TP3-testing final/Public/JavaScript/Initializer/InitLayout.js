import { LayoutIndex } from "../Containers/LayoutContainer.js";
import { GetProducts } from "../Services/FetchProduct.js";

LayoutIndex ();

const initImage = async () => {
    const products = await GetProducts ("", "");
    if (products){
        var pos = Math.floor((Math.random()*products.length));
        const productImg = document.getElementById ("marcasImg");
        productImg.src = products[pos].image;
    }
}

setInterval( async () => {
    initImage ()
}, 1000);

