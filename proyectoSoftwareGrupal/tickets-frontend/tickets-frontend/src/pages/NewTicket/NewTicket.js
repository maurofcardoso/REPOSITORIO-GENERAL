import { useNewTicket } from './hooks/useNewTicket';
import './styles/newTicket.css';

export const NewTicket = async() => {
    let view = `
        <h1> Nuevo Ticket </h1>  
        <section class="newTicket">   
            <select id="sl-prioridad">
            <option value= "1">Baja</option>
            <option value= "2">Media</option>
            <option value= "3">Alta</option>
            </select>  
            <select id="sl-cateogria">
            <option value= "1">Ventas</option>
            <option value= "2">Compras</option>
            <option value= "3">Reparacion Hardware</option>
            </select>   
            <input type="input" name= "titulo" id="title" placeholder = "Titulo del Ticket">
            <textarea name="descripcion" cols="40" rows="5" id="descripcion" placeholder = "Descripcion del ticket"></textarea>
            <input type="url" name="adjunto" id="adjunto" placeholder = "Ruta del adjunto" >
            <button id="btnAddTicket">Crear</button>
        </section>    
    `;  
    
    return useNewTicket(view);    
} 