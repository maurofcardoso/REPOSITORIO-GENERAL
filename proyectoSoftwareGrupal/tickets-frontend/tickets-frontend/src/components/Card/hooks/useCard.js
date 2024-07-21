import { navigateTo } from "../../../router/router";


export const useCard = (view, card) => {

	const divElement = document.createElement('div');
	divElement.classList.add('card');
	divElement.id = card.idTicket;
	divElement.setAttribute("data-id", card.idTicket);
	divElement.classList.add(card.ticketPriority.description.toLocaleLowerCase());
	divElement.innerHTML = view;
	
	divElement.addEventListener('click', () => {
		navigateTo(`/tickets/${card.idTicket}`);
	});

	return divElement;
};
