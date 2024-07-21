import { Message } from "../../components";
import { getWithToken } from "../../helpers/fetch";

const VITE_API_TICKET_BASE = import.meta.env.VITE_API_TICKET_BASE;

export const getTicketCategories = async () => {

    try {
        const ticketCategories = await getWithToken(VITE_API_TICKET_BASE, "TicketCategory");
        return {
            ticketCategories
        }

    } catch (error) {
        Message("Error al obtener los tickets", "warn");
    }
 
}