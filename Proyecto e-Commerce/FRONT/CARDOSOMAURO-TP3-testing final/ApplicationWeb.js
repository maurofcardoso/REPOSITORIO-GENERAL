const express = require ('express');
const path = require ('path');
const ApplicationWeb = express();
const port = process.env.port || 3000;
const router = express.Router();

ApplicationWeb.get ('/Products', (req, res) => {
    res.sendFile (path.join (__dirname + '/Public/Views/Products.html'));
});
ApplicationWeb.get ('/Carrito', (req, res) => {
    res.sendFile (path.join (__dirname + '/Public/Views/Carrito.html'));
});
ApplicationWeb.get ('/OrdenCompra', (req, res) => {
    res.sendFile (path.join (__dirname + '/Public/Views/OrdenCompra.html'));
});
ApplicationWeb.get ('/BalanceDiario', (req, res) => {
    res.sendFile (path.join (__dirname + '/Public/Views/BalanceDiario.html'));
});
ApplicationWeb.get ('/QuienesSomos', (req, res) => {
    res.sendFile (path.join (__dirname + '/Public/Views/QuienesSomos.html'));
});
ApplicationWeb.get ('/Contacto', (req, res) => {
    res.sendFile (path.join (__dirname + '/Public/Views/Contacto.html'));
});
ApplicationWeb.use (express.static (__dirname + '/Public'));
ApplicationWeb.use ('/', router);

ApplicationWeb.listen (port, ()=> console.log(`ApplicationWeb listening at http://localhost:${port}/Products`));