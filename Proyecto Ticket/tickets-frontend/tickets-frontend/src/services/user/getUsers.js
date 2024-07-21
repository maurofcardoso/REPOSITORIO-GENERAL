import { Message } from "../../components";
import { getWithToken } from "../../helpers/fetch";

const VITE_API_AUTH_BASE = import.meta.env.VITE_API_AUTH_BASE;

export const getUsers = async () => {
    try {
        const users = await getWithToken(VITE_API_AUTH_BASE, "Users");
        return {
            users
        }

    } catch (error) {
        Message("Error al obtener los usuarios", "warn");
    }
 
}