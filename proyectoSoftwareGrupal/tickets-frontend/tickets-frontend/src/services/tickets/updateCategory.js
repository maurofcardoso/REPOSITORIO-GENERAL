import { fetchWithToken } from "../../helpers/fetch";
const VITE_API_TICKET_BASE = import.meta.env.VITE_API_TICKET_BASE;

export const updateCategory = (id, category) => {
  try {
    fetchWithToken(VITE_API_TICKET_BASE, `tickets/${id}`, "PUT", {
        CategoryId: category,
    });
  } catch (error) {
    Message("Error modificar la categoría del ticket", "warn");
  }
};