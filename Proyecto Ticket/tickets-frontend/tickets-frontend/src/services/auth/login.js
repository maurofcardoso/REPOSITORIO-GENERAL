import { Message } from "../../components";
import { fetchWithoutToken } from "../../helpers/fetch";
import { setStorage } from "../../helpers/storage";
import { navigateTo } from "../../router/router";
const VITE_API_AUTH_BASE = import.meta.env.VITE_API_AUTH_BASE;

export const login = async (userName, password) => {
  try {
    const data = await fetchWithoutToken(
      VITE_API_AUTH_BASE,
      `Users/login`,
      "POST",
      {
        userName,
        password,
      }
    );

    if (!!data && !!data.token) {
      const { userId, firstName, lastName, rol, areaId, email, token } = data;
      const { rolId, title } = rol;

      const user = {
        userId,
        firstName,
        lastName,
        areaId,
        email,
        rol: {
          rolId,
          title,
        },
      };

      setStorage("tickets_user", user);
      setStorage("tickets_token", token);
      navigateTo("/");
    }

    return data;
  } catch (e) {
    Message("Usuario o contraseña erroneos", "warn");
  }
};
