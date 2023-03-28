export const PageBalance = () => {
    const balanceElement = 
    `
    <div id="BalanceComplet">
        <div id="subDiv1">
            <form id="formBusqueda">
                <h1>INGRESE SU BUSQUEDA</h1>
                <div class="busqueda">
                    <label for="bday">DESDE: </label>
                    <input type="date" id="bday" name="bday" required pattern="\d{4}-\d{2}-\d{2}"/>
                    <label for="bday">HASTA: </label>
                    <input type="date" id="bday" name="bday" required pattern="\d{4}-\d{2}-\d{2}"/>
                </div>
                <div>
                    <button id='buttonBuscarOrden' name="" type='submit'><span><i class='fa fa-search'></i></span></button>
                </div>
            </form>
        </div>
        <div id="subDiv2">
            <div id="listBalance">
                <div id="infoBalance"></div>
                <div id="infoBalanceProducts"></div>
                <div id="infoVentaBalance"></div>
            </div>
        </div>
    </div>
    `
    return balanceElement;
}

export const CreateBalanceComponent = (ordenCompra) => {
    const listProductElement =  
        `
        <div class="ordenBalance">
            <h1>${ordenCompra.responseCompleto.lastname} ${ordenCompra.responseCompleto.name}</h1>
            <h2>Orden de compra </h2>
            <h2>Fecha de compra: ${ordenCompra.fecha}</h2>
            <h2>Total de la compra: $ ${ordenCompra.total}</h2>
            <h2>DNI: ${ordenCompra.responseCompleto.dni}</h2>
            <h2>Cel.: ${ordenCompra.responseCompleto.phoneNumber}</h2>
            <h2>Direccion: ${ordenCompra.responseCompleto.address}</h2>
            <div id="buttonVolver">
                <button class='buttonVolver' type='button'>volver</button>
            </div>
        </div>
        `
    return listProductElement;
}

export const CreateComponentInfo = (ordenCompra, from, to) => {
    const elem = 
    `
    <div>
        <h1>BALANCE TOTAL DESDE ${from} HASTA ${to}</h1>
        <br>
        <div id="infoh2">
            <h2> CANTIDAD DE VENTAS: ${ordenCompra.cantidadVentas}</h2>
            <h2> RECAUDACION TOTAL: $ ${ordenCompra.recaudationDay}</h2>
        </div>
    </div>
    `
    return elem;
}

export const CreateComponentVenta = (cont, total, ordenCompra) => {
    const elem =
    `
    <div class="ventaBalance" id="${cont}">
        <h2 id="${cont}">${ordenCompra.responseCompleto.lastname} ${ordenCompra.responseCompleto.name}</h2>
        <br>
        <h3 id="${cont}">DNI: ${ordenCompra.responseCompleto.dni}</h3>
        <h3 id="${cont}">Cel.: ${ordenCompra.responseCompleto.phoneNumber}</h3>
        <h3 id="${cont}">Direccion: ${ordenCompra.responseCompleto.address}</h3>
        <h3 id="${cont}">Total de la compra: $ ${total}</h3>
    </div>
    `
    return elem;
}

export const CreateListBalanceOrden = (products) => {
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
                    <div id="contenidoPie">
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