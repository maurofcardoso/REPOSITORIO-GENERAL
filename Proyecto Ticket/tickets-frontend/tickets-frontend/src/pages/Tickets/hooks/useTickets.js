import { getTicketsByArea } from "../../../services/tickets/getTicketsByArea";
import { sorterList } from "../../../helpers/sorter";
import { updateState } from "../../../services";
import { Card } from "../../../components";
import { getStorage } from "../../../helpers/storage";
import { navigateTo } from "../../../router/router";

export const useTickets = async (view) => {
  const user = getStorage("tickets_user");
  const divElement = document.createElement("div");
  

  //Se verifica si el usuario es Administrador o Agente
  if(user.rol.rolId == 1 || user.rol.rolId == 3)
  {
    //Si es Administrador o Agente se muestran todos los tickets del area
    const tickets = await getTicketsByArea(user);

    divElement.classList = "tickets";
    divElement.innerHTML = view;
    
    const todo = divElement.querySelector("#todo");
    const doing = divElement.querySelector("#doing");
    const done = divElement.querySelector("#done");

    tickets.ticketsTodo?.forEach((card) => {
      todo.appendChild(Card(card));
    });

    tickets.ticketsDoing?.forEach((card) => {
      doing.appendChild(Card(card));
    });

    tickets.ticketsDone?.forEach((card) => {
      done.appendChild(Card(card));
    });

    sorterList(todo, updateState);
    sorterList(doing, updateState);
    sorterList(done, updateState);  
    
    const btnNewTicket = divElement.querySelector("#btnNewTicket");
    if (btnNewTicket) {
      btnNewTicket.addEventListener("click", async () => {
        navigateTo("/newticket");
      })
    }

    const btnMisTickets = divElement.querySelector("#btnMisTickets");
    if (btnMisTickets) {
      btnMisTickets.addEventListener("click", async () => {
        navigateTo("/mistickets");
      })
    }

    return divElement;
  }
  

  //Si NO es Administrador ni Agente NO se muestran todos los tickets del area
  divElement.classList = "tickets";
  divElement.innerHTML = view;
  divElement.innerHTML += "<label class='error'> Para obtener el listado de tickets del area debe ser un Agente o Administrador </label>";
  
  const btnNewTicket = divElement.querySelector("#btnNewTicket");
    if (btnNewTicket) {
      btnNewTicket.addEventListener("click", async () => {
        navigateTo("/newticket");
      })
    }

    const btnMisTickets = divElement.querySelector("#btnMisTickets");
    if (btnMisTickets) {
      btnMisTickets.addEventListener("click", async () => {
        navigateTo("/mistickets");
      })
    }

  return divElement;






  
};
