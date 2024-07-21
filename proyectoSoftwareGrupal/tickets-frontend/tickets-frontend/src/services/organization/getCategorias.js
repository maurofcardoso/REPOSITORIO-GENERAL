import { Message } from "../../components";
import { getWithToken } from "../../helpers/fetch";

const VITE_API_TICKET_BASE = import.meta.env.VITE_API_TICKET_BASE;

export const getCategorias = async () => {
    try {        
        const categorias = await getWithToken(VITE_API_TICKET_BASE, `TicketCategory`);
        return categorias;

    } catch (error) {
        Message("Error al obtener las categorias", "warn");        
    }  
}