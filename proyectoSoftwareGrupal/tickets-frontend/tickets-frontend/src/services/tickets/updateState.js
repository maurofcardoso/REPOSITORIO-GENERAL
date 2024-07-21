import { fetchWithToken } from "../../helpers/fetch";
const VITE_API_TICKET_BASE = import.meta.env.VITE_API_TICKET_BASE;

export const updateState = (id, state) => {
  try {
    fetchWithToken(VITE_API_TICKET_BASE, "tickets", "PUT", {
      idTicket: id,
      StatusId: state,
    });
  } catch (error) {
    Message("Error modificar el estado del ticket", "warn");
  }
};
