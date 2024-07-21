import { getTicketById } from "../../services/tickets/getTicketById";
import { getTicketCategories } from "../../services/tickets/getTicketCategories"
import { useViewTicket } from "./hooks/useViewTicket";
import downloadIcon from "../../../public/download.svg";
import { getStorage } from "../../helpers/storage";

import "./styles/viewTicket.css";
import { Comment } from "../../components";
import { formatDate } from "../../helpers/date";

export const ViewTicket = async (params) => {
	const userStorage = getStorage("tickets_user");
	if(userStorage.rol.rolId=== 2) 
	{
		var StateSelect = "disabled";
		var CategorySelect = "disabled";
	}

	const ticket = await getTicketById(params.id);
	console.log(ticket)
  	const userNameFull = `${ticket.user.firstName} ${ticket.user.lastName}`;
	
  const states = [
	"Pendiente",
	"En curso",
	"Finalizado"
  ]
  const categories = await getTicketCategories();
  const categoryNames = [];
  for(let i=0; i< Object.keys(categories.ticketCategories).length; i++){
	if(!categoryNames.includes(categories.ticketCategories[i].name))
		categoryNames.push(categories.ticketCategories[i].name)
  } 


  let view = `
		<h1>Ticket ${ticket.ticketBody.title} </h1>
		<div class="${`header ${ticket.ticketPriority.description.toLocaleLowerCase()}`}"> 					
			<span><strong>${userNameFull}</strong></span>		
			<div class="date"> ${formatDate(ticket.ticketLogs[0].dateAction)} </div>

			<select id="slCategory" class="slCategory" ${CategorySelect}> 
				${categoryNames.map((category, i) => 
					category === ticket.ticketCategory.name
						? `<option value=${i+1} selected>${category}</option>`
						: `<option value=${i+1} >${category}</option>`			
					).join('')}							
			</select>
			<select id="slStatus" ${StateSelect}> 
				${states.map((state, i) => 
					state === ticket.ticketStatus.description 
						? `<option value=${i+1} selected>${state}</option>`
						: `<option value=${i+1} >${state}</option>`			
					).join('')}							
			</select>
			<div class="tag" 
				id=${ticket.ticketPriority.description.toLocaleLowerCase()}> 
				${ticket.ticketPriority.description}
			</div>
			<div class="tag" 
				title="${ticket.ticketCategory.description}"> 
				${ticket.ticketCategory.name}
			</div>			
		</div>
		<div class="body">
			<h2>Detalle</h2>
			<p class="description"> ${ticket.ticketBody.description} </p>
			${!!ticket.ticketBody.file && `<button class="attach" id="btnAttach"> <img src="${downloadIcon}" alt="download file" title="descargar archivo adjunto" /> </button>`}			
		</div>
		<div class="footer" id="footer">
			<div class="comments" id="comments">
				<h2>Comentarios</h2>					
			</div>	
		</div>
	`;

  return useViewTicket(view, ticket);
};
