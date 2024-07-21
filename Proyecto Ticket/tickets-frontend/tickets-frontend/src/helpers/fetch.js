import { Unauthorized } from "../Errors/Unauthorized";
import { getStorage } from "./storage";

export const fetchWithoutToken = async (
  api,
  endpoint,
  method,
  request = null
) => {
  try {
    let init = {
      method: method,
      headers: {
        "Content-Type": "application/json",
      },
    };

    if (!!request) init.body = JSON.stringify(request);

    const response = await fetch(`${api}/${endpoint}`, init);

    if (!response.ok) {
      const data = await response.json();

      if (!!data.title && !!data.status) {
        const { title, status } = data;
        if (status === 401) {
          throw new Unauthorized(401, title);
        }
      } else
        throw new Error(`Error no especificado, consulte al administrador.`);
    }
    const data = await response.json();
    return data;
  } catch (error) {
    throw new Error(error);
  }
};

export const getWithoutToken = async (api, endpoint) => {
  try {
    const response = await fetch(`${api}/${endpoint}`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    });

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }
    const data = await response.json();
    return data;
  } catch (error) {
    throw new Error(error);
  }
};

export const fetchWithToken = async (api, endpoint, method, request = null) => {
  try {
    const token = getStorage("tickets_token");

    let init = {
      method: method,
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    };

    if (!!request) init.body = JSON.stringify(request);

    const response = await fetch(`${api}/${endpoint}`, init);

    if (!response.ok) {
      const data = await response.json();

      if (!!data.title && !!data.status) {
        const { title, status } = data;
        if (status === 401) {
          throw new Unauthorized(401, title);
        }
      } else
        throw new Error(`Error no especificado, consulte al administrador.`);
    }
    const data = await response.json();
    return data;
  } catch (error) {
    throw new Error(error);
  }
};

export const getWithToken = async (api, endpoint) => {
  try {
    const token = getStorage("tickets_token");

    const response = await fetch(`${api}/${endpoint}`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });

    if (!response.ok && !response.status === 404) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }
    const data = await response.json();
    return data;
  } catch (error) {
    throw new Error(error);
  }
};
