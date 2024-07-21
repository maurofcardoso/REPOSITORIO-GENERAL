import { useUsuarios } from './hooks/useUsuarios';
import './styles/usuarios.css';

export const Usuarios = async () => {
    let view = `
        <div class="header">
            <h1>Usuarios</h1>
            <div class="tools"> 
                <button class="btn" id="btnNewUsuario"> Nuevo Usuario </button>
            </div>           
        </div> 
        <div class="table" id="table">
            <div class="table-header">ID</div>
            <div class="table-header">Nombre</div>
            <div class="table-header">Apellido</div>
            <div class="table-header">Email</div>
            <div class="table-header">Rol</div>
            <div class="table-header">Área</div>
        </div>       
    `;     

    return useUsuarios(view);
} 