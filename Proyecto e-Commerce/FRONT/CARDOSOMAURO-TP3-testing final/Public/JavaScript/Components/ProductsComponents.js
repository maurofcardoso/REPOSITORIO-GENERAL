export const CreateProductInfo = (products) => {
    const productElement = 
    `
    <div id="productInfo" class="product">
        <div id="tituloInfo" class="titulo">
            <h1>${products.nombre}</h1>
        </div>
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
                            <h2>PRECIO: $ ${products.precio}</h2>
                        </div>
                </div>
                <div class="buttons">
                    <form id='carrito'>
                        <label for="inputCarrito">Elija cantidad</label>
                        <input type="number" value="1" id="inputCarrito" name="inputCarrito" min="1">
                        <br>
                        <br>
                        <button id='addButton' type='button'><i class="fas fa-shopping-cart"></i></button>
                    </form>
                </div>
            </div>
        </div>
    </div>
    `
    return productElement;
}

export const CreateProductCard = (products) => {
    const productCardElement =
    `
    <a>
        <div class="product" id="${products.nombre}">
            <div class="titulo"><h1>${products.nombre}</h1></div>
            <div class="cuerpo">
                <img id="${products.productoId}" src="${products.image}" alt="${products.descripcion}" title="${products.nombre}">
            </div>
            <div class="pie">
            </div>
        </div>
    </a>
    `
    return productCardElement;
}

export const PageProducts = () => {
    const productElement = 
    `
    <div id="listProduct"></div>
    `
    return productElement;
}