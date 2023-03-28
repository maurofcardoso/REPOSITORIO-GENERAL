export const ErrorCarritoVacio = () => {
    const error =
    `
    <div class="window-notice" id="window-notice">
        <div class="content">
            <div>El carrito esta vacio!!</div>
            <br>
            <div class="content-text"><a href="http://localhost:3000/Products">ACEPTAR</a></div>
        </div>
    </div>
    `
    return error;
}

export const ErrorGenerarOrden = () => {
    const error =
    `
    <div class="window-notice" id="window-notice">
        <div class="content">
            <div>No se pudo generar la orden!!</div>
            <br>
            <div class="content-text"><a href="http://localhost:3000/Carrito">ACEPTAR</a></div>
        </div>
    </div>
    `
    return error;
}

export const AgregadoCorrectamente = () => {
    const error =
    `
    <div class="window-notice" id="window-notice">
        <div class="content">
            <div>El producto se agrego correctamente!!</div>
            <br>
            <div class="content-text"><a href="http://localhost:3000/Products">SEGUIR</a></div>
        </div>
    </div>
    `
    return error;
}

export const ProductoExiste = () => {
    const error =
    `
    <div class="window-notice" id="window-notice">
        <div class="content">
            <div>El producto ya existe en el carrito!!</div>
            <br>
            <div class="content-text"><a href="http://localhost:3000/Carrito">SEGUIR</a></div>
        </div>
    </div>
    `
    return error;
}

export const ErrorDePeticion = () => {
    const error =
    `
    <div class="window-notice" id="window-notice">
        <div class="content">
            <div>Existe un error en la peticion!!</div>
            <br>
            <div class="content-text"><a href="http://localhost:3000/Carrito">SEGUIR</a></div>
        </div>
    </div>
    `
    return error;
}

export const ProductoNoExiste = () => {
    const error =
    `
    <div class="window-notice" id="window-notice">
        <div class="content">
            <div>El producto no existe en el carrito!!</div>
            <br>
            <div class="content-text"><a href="http://localhost:3000/Carrito">SEGUIR</a></div>
        </div>
    </div>
    `
    return error;
}

export const ContenerLetras = () => {
    const error =
    `
    <div class="window-notice" id="window-notice">
        <div class="content">
            <div>El producto solo puede contener letras!!</div>
            <br>
            <div class="content-text"><a href="http://localhost:3000/Products">SEGUIR</a></div>
        </div>
    </div>
    `
    return error;
}

export const SinCoincidencias = () => {
    const error =
    `
    <div class="window-notice" id="window-notice">
        <div class="content">
            <div>No hay coincidencias con la busqueda!!</div>
            <br>
            <div class="content-text"><a href="http://localhost:3000/Products">SEGUIR</a></div>
        </div>
    </div>
    `
    return error;
}