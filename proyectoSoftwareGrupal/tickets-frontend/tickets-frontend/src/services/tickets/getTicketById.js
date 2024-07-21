import { Message } from "../../components";
import { getWithToken } from "../../helpers/fetch";

const VITE_API_TICKET_BASE = import.meta.env.VITE_API_TICKET_BASE;

export const getTicketById = async (id) => {
    try {        
        const ticket = await getWithToken(VITE_API_TICKET_BASE, `tickets/${id}`);
        return ticket;

    } catch (error) {
        Message("Error al obtener el ticket", "warn");        
    }  
}