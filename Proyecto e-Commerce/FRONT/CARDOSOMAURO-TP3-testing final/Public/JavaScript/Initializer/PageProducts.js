import { IndexPageProduct, IndexRenderProductCard } from "../Containers/Products.js";
import { Validation, CheckSearch } from "../Services/ProductEvents.js";

await IndexPageProduct();

await IndexRenderProductCard ('listProduct', '', '');

const _form = document.getElementById ('searchForm');

const _checkOut = document.getElementById ('checkOut');

_checkOut.addEventListener ("click", CheckSearch);

_form.addEventListener ('keydown', Validation);