import { getTicketsByArea } from "../../../services/tickets/getTicketsByArea";
import { getStorage } from "../../../helpers/storage";
import { getTicketsByUser } from "../../../services/tickets/getTicketsByUser";

export const useHome = async (view) => {

	const user = getStorage("tickets_user");
    const divElement = document.createElement('div');
	divElement.classList = 'home';
	divElement.innerHTML = view;

	//Se vetifica si el usuario es un Administrador o Agente
	if(user.rol.rolId == 1 || user.rol.rolId == 3)
  	{
		//El usuario es Administrador ni Agente, por lo que se muestran TODOS los tickets del area
		var tickets = await getTicketsByArea(user);	
	}
	else
	{
		//El usuario NO es Administrador ni Agente, por lo que se muestran SOLO sus tickets creados
		var tickets = await getTicketsByUser(user.userId);
	}
	debugger;
	divElement.querySelector("#statNumber2").innerText = tickets.ticketsTodo.length;
	divElement.querySelector("#statNumber3").innerText = tickets.ticketsDoing.length;
	divElement.querySelector("#statNumber4").innerText = tickets.ticketsDone.length;
	let ticketsToCheck = tickets.ticketsTodo;
	ticketsToCheck = ticketsToCheck.concat(tickets.ticketsDoing)
	let count=0;
	if(ticketsToCheck.length !== 0){
		for(let i=0; i<ticketsToCheck.length; i++){
			count;
			if(ticketsToCheck[i].ticketPriority.description === "Alta")
				count++
		}
	}
	divElement.querySelector("#statNumber1").innerText = count;
	return divElement;
}