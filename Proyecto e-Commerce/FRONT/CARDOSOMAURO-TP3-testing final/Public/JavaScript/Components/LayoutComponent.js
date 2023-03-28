export const header = () => {
    const compHeader = 
    `
    <header id="header">
        <div class="logotipo">
            <img class="logoImg" src="../Images/Logo.jpg">
            <h1 class="logoText">SUPER MAURITO</h1>
        </div>	   
        <div id='searchProducts'>
            <form id='searchForm'>
                <input id='searchProduct' placeholder='¿Que compras hoy?...' type='text'>
            </form>
            <div>
                <input id="checkOut" type="checkbox" class="checkInput" id="checkOne" checked>
                <label for="checkOne" class="checkLabel">Ordenar por precio</label>
            </div>
        </div> 
        <div class="logotipo">
            <img class="logoImg" src="../Images/usuario.jpg">
            <h3>cardoso mauro</h3>
        </div>           
    </header>
    `
    return compHeader;
}

export const navMenu = () => {
    const menu = 
    `
    <ul class="menu">
        <li class="item">|</li>
        <li class="item"><a href="http://localhost:3000/Products">PRODUCTOS</a></li>
        <li class="item">|</li>
        <li class="item"><a href="http://localhost:3000/BalanceDiario">BALANCE DIARIO</a>
        <li class="item">|</li>
        <li class="item"><a href="http://localhost:3000/QuienesSomos">QUIENES SOMOS</a>
        <li class="item">|</li>
        <li class="item"><a href="http://localhost:3000/Contacto">CONTACTO</a>
        <li class="item">|</li>
        <li class="item"><a href="http://localhost:3000/Carrito"><i id="carritoLogo" class="fas fa-shopping-cart"></i></a>
        <li class="item">|</li>
    </ul>
    `
    return menu;
}

export const Layout = () => {
    const Layout = 
    `
    <div id="info">
        <span>¡El mejor servicio!</span>
        <div>1</div>
        <h3>"Selecciona"</h3>
        <div>2</div>
        <h3>"Compra"</h3>
        <div>3</div>
        <h3>"Retira"</h3>
    </div>
    <div id="search"></div>
    <div id="menu"></div>
    <div id="main">
    </div>
    `
    return Layout;
}

export const divMain = () => {
    const div =
    `
    <div id="bannerIzq"></div>
    <div id="center"></div>
    <div id="bannerDer"></div>
    `
    return div;
}

export const BannerIzq = () => {
    const banner = 
    `
    <div class="bannerIzq">
        <img class="medioPago" src="../Images/mediosPago.jpg">
        <h1>
            AHORRA MAS!!!
        </h1>
        <img class="cajera" src="../Images/cajera.jpeg">
    </div>
    `
    return banner;
}

export const BannerDer = () => {
    const banner = 
    `
    <section class="banDer">
        <div class="informacion">
            <h2>Horarios de atencion</h2>
            <p>Lunes a viernes de 8hs a 21hs.</p>
            <p>Sabados hasta las 19hs.</p>
        </div>
        <div id="marcas">
            <img id="marcasImg"></img>
        </div>
        <div class="informacion">
            <h2>Atencion al cliente</h2>
            <h4>0800 - 888 - 1414</h4>
        </div>
    </section>
    `
    return banner;
}