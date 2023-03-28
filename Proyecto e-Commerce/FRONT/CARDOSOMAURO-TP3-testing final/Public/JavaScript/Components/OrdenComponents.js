export const CreateOrdenComponent = (ordenCompra) => {
    const ordenComponent = 
    `
    <div class="ordenCompra">
        <h1>${ordenCompra.responseCompleto.lastname} ${ordenCompra.responseCompleto.name}</h1>
        <h2>Orden de compra </h2>
        <h2>Fecha: ${ordenCompra.fecha}</h2>
        <h2>Total: $ ${ordenCompra.total}</h2>
        <h2>DNI: ${ordenCompra.responseCompleto.dni}</h2>
        <h2>Cel.: ${ordenCompra.responseCompleto.phoneNumber}</h2>
        <h2>Direccion: ${ordenCompra.responseCompleto.address}</h2>
    </div>
    `
    return ordenComponent;
}

export const CreateListProductOrden = (products) => {
    const listProductElement = 
    `
    <div id="productInfo" class="product">
        <div id="cuerpoInfo">
            <div class="imgInfo">
                <div class="cuerpo">
                    <img id="${products.productoId}" src="${products.image}" alt="${products.descripcion}" title="${products.nombre}">
                </div>
            </div>
            <div class="info">
                <div class="detailProduct" id="${products.productoId}">
                        <div class="pie">
                            <h3>NOMBRE: ${products.nombre}</h3>
                            <h3>DESCRIPCION: ${products.descripcion}</h3>
                            <h3>MARCA: ${products.marca}</h3>
                            <h3>CODIGO: ${products.codigo}</h3>
                            <br>
                            <h3>CANTIDAD: ${products.cantidad}</h3>
                            <h2>PRECIO: $ ${products.precio}</h2>
                            <h2>TOTAL: $ ${products.precio*products.cantidad}</h2>
                        </div>
                </div>
            </div>
        </div>
    </div>
    `
    return listProductElement;
}

export const PageOrden = () => {
    const ordenElement = 
    `
        <div id="ordenComplet">
            <div id="subDiv1">
            </div>
            <div id="subDiv2">
            </div>
            <div id="subDiv3">
                <div id="listOrden"></div>
            </div>
        </div>
    `
    return ordenElement;
}