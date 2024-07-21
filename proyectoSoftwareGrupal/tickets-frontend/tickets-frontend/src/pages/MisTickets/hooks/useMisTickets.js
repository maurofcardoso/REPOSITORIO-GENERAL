import { Card } from "../../../components";
import { getStorage } from "../../../helpers/storage";
import { navigateTo } from "../../../router/router";
import { getTicketsByUser } from "../../../services/tickets/getTicketsByUser";

export const useMisTickets = async (view) => {
  const user = getStorage("tickets_user");
  const tickets = await getTicketsByUser(user.userId);
  
  const divElement = document.createElement("div");
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

  const btnNewTicket = divElement.querySelector("#btnNewTicket");
  if (btnNewTicket) {
    btnNewTicket.addEventListener("click", async () => {
      navigateTo("/newticket");
    })
  }

  const btnTickets = divElement.querySelector("#btnTickets");
  if (btnTickets) {
    btnTickets.addEventListener("click", async () => {
      if(user.rol.rolId == 1 || user.rol.rolId == 3)
  	  {
        navigateTo("/tickets");
      }
      else
      {
        alertify.error('ERROR, para acceder a todos los tickets del area debe ser Administrador o Agente');
      }
    })
  }

  return divElement;
};
