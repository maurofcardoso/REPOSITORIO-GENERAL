import { ModifyProduct, DeleteCarrito } from '../Services/FetchCarrito.js';
import { IndexRenderCarrito, IndexInfoCompra } from '../Containers/Carrito.js';

export const modify = async (event) => {
    const product = await ModifyProduct ( event.currentTarget.form.id, event.currentTarget.form.inputCarrito.value);
    IndexInfoCompra ("subDiv1");
    IndexRenderCarrito ("listCarrito");
}

export const deleteProduct = (event) => {
    const productId = event.currentTarget.form.id;
    console.log (productId);
    DeleteCarrito (productId);
    location.reload();
}