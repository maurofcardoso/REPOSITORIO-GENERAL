import { useCategorias } from './hooks/useCategorias';
import './styles/categorias.css';

export const Categorias = async () => {
    let view = `
        <div class="header">
            <h1>Categorias</h1>
            <div class="tools"> 
                <button class="btn" id="btnNewCategoria"> Nueva Categoria </button>
            </div>           
        </div> 
        <div class="table" id="table">
            <div class="table-header">ID</div>
            <div class="table-header">Nombre</div>
            <div class="table-header">Descripcion</div>           
        </div>   
    `;     

    return useCategorias(view);
} 