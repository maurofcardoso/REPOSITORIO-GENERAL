import { useMisTickets } from './hooks/useMisTickets';
import './styles/mistickets.css';
import { getStorage } from "../../helpers/storage";

export const MisTickets = async () => {
    const user = getStorage("tickets_user");

    if(user.rol.rolId == 1 || user.rol.rolId == 3)
  	{
        var btnTicketsJS = `<button class="btn secundary" id="btnTickets"> Tickets del Area </button>`
    }
    else
    {
        var btnTicketsJS = ``
    }
    
    console.log(btnTicketsJS)

    let view = `
        <div class="header">
            <h1>Mis Tickets</h1>
            <div class="tools"> 
                <button class="btn" id="btnNewTicket"> Nuevo Ticket </button>
                ${btnTicketsJS}
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

    return useMisTickets(view);
} 