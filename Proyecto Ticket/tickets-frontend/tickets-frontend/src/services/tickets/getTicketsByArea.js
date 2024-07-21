import { Message } from "../../components";
import { getWithToken } from "../../helpers/fetch";

const VITE_API_TICKET_BASE = import.meta.env.VITE_API_TICKET_BASE;

export const getTicketsByArea = async (userJwt) => {
 
  try {

    let todos = await getWithToken(VITE_API_TICKET_BASE, "tickets");

    todos = todos.filter((ticket) => ticket.user.userId != userJwt.userId);
    const ticketsTodo = todos.filter(
      (ticket) => ticket.ticketStatus.description === "Pendiente"
    );
    const ticketsDoing = todos.filter(
      (ticket) => ticket.ticketStatus.description === "En curso"
    );
    const ticketsDone = todos.filter(
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
