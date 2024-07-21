import { useAreas } from './hooks/useAreas';
import './styles/areas.css';

export const Areas = async () => {
    let view = `
        <div class="header">
            <h1>Areas</h1>
            <div class="tools"> 
                <button class="btn" id="btnNewArea"> Nueva Area </button>
            </div>           
        </div> 
        <div class="table" id="table">
            <div class="table-header">ID</div>
            <div class="table-header">Nombre</div>
            <div class="table-header">Descripcion</div>
        </div>       
    `;     

    return useAreas(view);
} 