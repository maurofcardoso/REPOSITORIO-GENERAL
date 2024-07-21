import { Message } from "../../components";
import { fetchWithToken } from "../../helpers/fetch";
const VITE_API_AUTH_BASE = import.meta.env.VITE_API_AUTH_BASE;

export const addUsuario = async (info) => {
  try {
   await fetchWithToken(VITE_API_AUTH_BASE, "Users", "POST", info)

  } catch (error) {
    Message("Error al crear el usuario", "warn");
  }
};
