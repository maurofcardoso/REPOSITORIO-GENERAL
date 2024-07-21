import { Message } from "../../components";
import { getWithToken } from "../../helpers/fetch";

const VITE_API_TICKET_BASE = import.meta.env.VITE_API_TICKET_BASE;

export const getTicketsByUser = async (idUser) => {
  try {
    let todos = await getWithToken(VITE_API_TICKET_BASE, "tickets");
    const misTickets = await todos.filter(
      (ticket) => ticket.user.userId === idUser
    );
    const ticketsTodo = misTickets.filter(
      (ticket) => ticket.ticketStatus.description === "Pendiente"
    );
    const ticketsDoing = misTickets.filter(
      (ticket) => ticket.ticketStatus.description === "En curso"
    );
    const ticketsDone = misTickets.filter(
      (ticket) => ticket.ticketStatus.description === "Finalizado"
    );

    return {
      ticketsTodo,
      ticketsDoing,
      ticketsDone,
    };

  } catch (e) {
    return {
      ticketsTodo: [],
      ticketsDoing: [],
      ticketsDone: [],
    };
  }


};
