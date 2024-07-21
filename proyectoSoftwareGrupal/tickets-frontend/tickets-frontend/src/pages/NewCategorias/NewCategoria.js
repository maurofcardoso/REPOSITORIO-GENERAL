import { useNewCategoria } from './hooks/useNewCategoria';
import './styles/newCategoria.css';

export const NewCategoria = async() => {
    let view = `
        <h1> Nueva Categoria </h1>  
        <section class="newCategoria">
        
            <input type="input" id="nombreCategoria" placeholder = "Nombre de la Categoria">
            
            <select id="sl-areaDestino">
                <option value= "2">CompraVenta</option>
                <option value= "3">Soporte</option>
            </select>  

            <textarea name="descripcion" cols="40" rows="5" id="descripcion" placeholder = "Descripcion de la categoria"></textarea>
            
            <button id="btnAddCategoria">Crear</button>
        </section>    
    `;  
    
    return useNewCategoria(view);    
} 