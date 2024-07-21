import { useHome } from './hooks/useHome';
import './styles/home.css';

export const Home = async () => {
    let view = `
    <h1>Home</h1>
    <section class="homeStats">
        <div class="ticketStats1">
            <h2 class="statNumber" id="statNumber1">0</h2>
            <h3 class="statDescription">Tickets con Prioridad Alta</h3>
        </div>
        <div class="ticketStats2">
            <h2 class="statNumber" id="statNumber2">0</h2>
            <h3 class="statDescription">Tickets Pendientes</h3>
        </div>
        <div class="ticketStats3">
            <h2 class="statNumber" id="statNumber3">0</h2>
            <h3 class="statDescription">Tickets en Curso</h3>
        </div>
        <div class="ticketStats4">
            <h2 class="statNumber" id="statNumber4">0</h2>
            <h3 class="statDescription">Tickets Finalizados</h3>
        </div>
    </section>
    `;     

    return useHome(view);
}