import { formatDate } from '../../helpers/date';
import { useCard } from './hooks/useCard';
import './styles/card.css';

export const Card = (card) => {
	let view = `
        <h3>${card.ticketBody.title}</h3>
        <span>${card.idTicket} - ${formatDate(card.ticketLogs[0].dateAction)} - ${card.user.firstName} ${card.user.lastName}</span>
        <div class="tag">${card.ticketCategory.name}</div>   
        <p>${card.ticketBody.description}</p>    
        <div class=${`"priority ${card.ticketPriority.description.toLocaleLowerCase()}"`}> ${card.ticketPriority.description}</div>
    `;
    
	return useCard(view, card);
};
