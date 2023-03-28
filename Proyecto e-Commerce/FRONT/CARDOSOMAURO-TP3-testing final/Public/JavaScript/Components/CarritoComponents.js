export const CarritoInfoCliente = (totalProducts, total) => {
    const info = 
    `
    <div class="infoClient">
        <h1>CARDOSO MAURO</h1>
        <div class="totales">
            <h3>Cantidad total de productos:  ${totalProducts} u.</h3>
            <br>
            <h2>Total de la compra:  $  ${total}</h2>
        </div>
        <div id="comprar">
            <a id="buttonOrden" href="http://localhost:3000/OrdenCompra" class="btn-flotante">COMPRAR</a>
        </div>
    </div>
    `
    return info;
}

export const CreateCarritoComponent = (products) => {
    const carritoElement = 
    `
    <div class="carrito">
        <div class="titulo"><h1>${products.nombre}</h1></div>
        <div class="infoFoto">
            <div class="cuerpo">
                <img id="${products.productoId}" src="${products.image}" alt="${products.descripcion}" title="${products.nombre}">
            </div>
            <div class="pie">
                <h2>PRECIO: $ ${products.precio}</h2>
                <h2>CANTIDAD: ${products.cantidad}</h2>
                <h3>NOMBRE: ${products.nombre}</h3>
                <h3>DESCRIPCION: ${products.descripcion}</h3>
                <h3>MARCA: ${products.marca}</h3>
                <h3>CODIGO: ${products.codigo}</h3>
            </div>
        </div>
        <div>
            <form id="${products.productoId}" class='carritoForm'>
                <input value="${products.cantidad}" type="number" id="inputCarrito" class="inputCarrito" name="inputCarrito" min="1">
                <button id='deleteButton' class="deleteButton" type='button'><i class="fas fa-shopping-cart"></i></button>
            </form>
        </div>
    </div>
    `
    return carritoElement;
}

export const PageCarrito = () => {
    const carritoElement = 
    `
    <div id="CarritoComplet">
        <div id="subDiv1">
        </div>
        <div id="subDiv2">
            <div id="listCarrito"></div>
        </div>
    </div>
    `
    return carritoElement;
}