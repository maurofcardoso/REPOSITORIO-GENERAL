import { formatDate } from "../../../helpers/date";
import { getStorage } from "../../../helpers/storage";
import { navigateTo } from "../../../router/router";
import { getAreas } from "../../../services/organization/getAreas";

export const useAreas = async (view) => {
  const user = getStorage("tickets_user");

  //Se verifica si el usuario es Administrador
  if (user.rol.rolId == 1) {
    const areas = await getAreas();

    const divElement = document.createElement("div");
    divElement.classList = "areas";
    divElement.innerHTML = view;
    const table = divElement.querySelector("#table");

    areas.forEach((area) => {
      const id = document.createElement("div");
      id.classList = "table-item";
      id.innerHTML = area.idArea;
      table.appendChild(id);

      const nombre = document.createElement("div");
      nombre.classList = "table-item";
      nombre.innerHTML = area.nameArea;
      table.appendChild(nombre);

      const description = document.createElement("div");
      description.classList = "table-item";
      description.innerHTML = area.description;
      table.appendChild(description);
    });

    const btnNewArea = divElement.querySelector("#btnNewArea");
    if (btnNewArea) {
      btnNewArea.addEventListener("click", async () => {
        navigateTo("/newarea");
      });
    }

    return divElement;
  }

  //Si NO es Administrador
  divElement.innerHTML = view;
  divElement.innerHTML +=
    "<label class='error'> Para obtener el listado de Areas debe ser un Administrador </label>";

  return divElement;
};
