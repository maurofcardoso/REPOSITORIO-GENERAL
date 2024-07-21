import { getWithToken } from "../../helpers/fetch";

const VITE_API_AUTH_BASE = import.meta.env.VITE_API_AUTH_BASE;

export const getUserData = async (id) => {
    try {
        const result = await getWithToken(VITE_API_AUTH_BASE, `Users/${id}`);
        return result;
    } catch (error) {
        return "Error al obtener la informacion";
    }
}