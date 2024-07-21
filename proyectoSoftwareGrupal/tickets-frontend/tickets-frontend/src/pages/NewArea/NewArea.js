import { useNewArea } from './hooks/useNewArea';
import './styles/newArea.css';

export const NewArea = async() => {
    let view = `
        <h1> Nueva Area </h1>  
        <section class="newArea">   
            <input type="input" id="nameArea" placeholder = "Nombre del Area">
            <textarea name="descripcion" cols="40" rows="5" id="descripcion" placeholder = "Descripcion del area"></textarea>
            <button id="btnAddArea">Crear</button>
        </section>    
    `;  
    
    return useNewArea(view);    
} 