import { getStorage } from "../../../helpers/storage";
import { navigateTo } from "../../../router/router";
import { getCategorias } from "../../../services/organization/getCategorias";

export const useCategorias = async (view) => {
  const user = getStorage("tickets_user");

  //Se verifica si el usuario es Administrador
  if (user.rol.rolId == 1) {
    const categorias = await getCategorias();

    const divElement = document.createElement("div");
    divElement.classList = "categorias";
    divElement.innerHTML = view;

    const table = divElement.querySelector("#table");

    categorias.forEach((area) => {
      const id = document.createElement("div");
      id.classList = "table-item";
      id.innerHTML = area.idTicketCategory;
      table.appendChild(id);

      const nombre = document.createElement("div");
      nombre.classList = "table-item";
      nombre.innerHTML = area.name;
      table.appendChild(nombre);

      const description = document.createElement("div");
      description.classList = "table-item";
      description.innerHTML = area.description;
      table.appendChild(description);
  
    });    

    const btnNewCategoria = divElement.querySelector("#btnNewCategoria");
    if (btnNewCategoria) {
      btnNewCategoria.addEventListener("click", async () => {
        navigateTo("/newcategoria");
      });
    }

    return divElement;
  }

  //Si NO es Administrador
  divElement.innerHTML = view;
  divElement.innerHTML +=
    "<label class='error'> Para obtener el listado de Categorias debe ser un Administrador </label>";

  return divElement;
};
