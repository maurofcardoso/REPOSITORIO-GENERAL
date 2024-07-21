import { useTickets } from './hooks/useTickets';
import './styles/tickets.css';

export const Tickets = async () => {
    let view = `
        <div class="header">
            <h1>Tickets del Area</h1>
            <div class="tools"> 
                <button class="btn" id="btnNewTicket"> Nuevo Ticket </button>
                <button class="btn secundary" id="btnMisTickets"> Mis Tickets </button>
            </div>           
        </div> 
        <section class="misTickets">            
            <div class="ticketStatus" id="todo">
                <h2 class="title"> Pendientes </h2>
            </div>
            <div class="ticketStatus" id="doing">
                <h2 class="title"> En curso </h2>           
            </div>
            <div class="ticketStatus" id="done">
                <h2 class="title"> Finalizado </h2> 
            </div>   
        </section>    
    `;     

    return useTickets(view);
} 