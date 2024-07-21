import { Message } from "../../components";
import { getWithToken } from "../../helpers/fetch";

const VITE_API_TICKET_BASE = import.meta.env.VITE_API_TICKET_BASE;

export const getAreas = async () => {
    try {        
        const areas = await getWithToken(VITE_API_TICKET_BASE, `Area`);
        return areas;

    } catch (error) {
        Message("Error al obtener el ticket", "warn");        
    }  
}