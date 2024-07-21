import { navigateTo } from "../../../router/router";
import { addTicket } from "../../../services/tickets/addTicket";

export const useNewTicket = async (view) => {
  const divElement = document.createElement("div");
  divElement.classList = "newTicket";
  divElement.innerHTML = view;

  const btnAddTicket = divElement.querySelector("#btnAddTicket");

  if (btnAddTicket) {
    btnAddTicket.addEventListener("click", async () => {
      const slprioridad = divElement.querySelector("#sl-prioridad");
      const slcateogria = divElement.querySelector("#sl-cateogria");
      const title = divElement.querySelector("#title");
      const descripcion = divElement.querySelector("#descripcion");
      const adjunt = divElement.querySelector("#adjunto");

      if(slprioridad.value != "" && slcateogria.value != "" && title.value != "" && descripcion.value != "")
      {
        const request = {
          PriorityId: slprioridad.value,
          CategoryId: slcateogria.value,
          title: title.value,
          description: descripcion.value,
          fileAdjunt: adjunt.value,
        };
  
        await addTicket(request);
        navigateTo("/MisTickets");
      }
      else
      {
        alertify.error('ERROR TODOS los campos son obligatorios');
      }
    });
  }
  return divElement;
};
