import { fetchWithToken } from "../../helpers/fetch";
const VITE_API_TICKET_BASE = import.meta.env.VITE_API_TICKET_BASE;

export const addComment = async (id, comment) => {
  try {
    await fetchWithToken(VITE_API_TICKET_BASE, "TicketComment", "POST", {
      idTicket: id,
      comment: comment,
      file:""
    });
  } catch (error) {
    Message("Error modificar el estado del ticket", "warn");
  }
};
