import { useNewUsuario } from './hooks/useNewUsuario';
import './styles/newUsuario.css';

export const NewUsuario = async() => {
    let view = `
        <h1> Nuevo Usuario </h1>  
        <section class="newUsuario">   
            <input type="input" id="usernameUsuario" placeholder = "Nombre de usuario">
            <input type="input" id="nameUsuario" placeholder = "Nombre">
            <input type="input" id="apellidoUsuario" placeholder = "Apellido">
            <input type="input" id="telefonoUsuario" placeholder = "Teléfono">
            <input type="input" id="dniUsuario" placeholder = "DNI">
            <input type="input" id="emailUsuario" placeholder = "E-Mail">
            <input type="number" id="rolUsuario" placeholder = "Rol">
            <button id="btnAddUsuario">Crear</button>
        </section>    
    `;  
    
    return useNewUsuario(view);    
}