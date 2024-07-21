import { getStorage } from "../../../helpers/storage";
import { navigateTo } from "../../../router/router";
import { getAreas } from "../../../services";
import { getUsers } from "../../../services/user/getUsers";

export const useUsuarios = async (view) => {
  const user = getStorage("tickets_user");

  //Se verifica si el usuario es Administrador
  if (user.rol.rolId == 1) {
    const areas = await getAreas();
    const users = await getUsers();
    const divElement = document.createElement("div");
    divElement.classList = "usuarios";
    divElement.innerHTML = view;
    const table = divElement.querySelector("#table");

    users.users.forEach((user) => {
      const id = document.createElement("div");
      id.classList = "table-item";
      id.innerHTML = user.userId;
      table.appendChild(id);

      const nombre = document.createElement("div");
      nombre.classList = "table-item";
      nombre.innerHTML = user.firstName;
      table.appendChild(nombre);

      const apellido = document.createElement("div");
      apellido.classList = "table-item";
      apellido.innerHTML = user.lastName;
      table.appendChild(apellido);

      const email = document.createElement("div");
      email.classList = "table-item";
      email.innerHTML = user.email;
      table.appendChild(email);

      const rol = document.createElement("div");
      rol.classList = "table-item";
      rol.innerHTML = user.rol.title;
      table.appendChild(rol);

      let nameArea;
      for(let i=0; i<areas.length; i++){
        if(areas[i].idArea == user.areaId)
            nameArea = areas[i].nameArea;
      }

      const area = document.createElement("div");
      area.classList = "table-item";
      area.innerHTML = nameArea;
      table.appendChild(area);
    });

    const btnNewUsuario = divElement.querySelector("#btnNewUsuario");
    if (btnNewUsuario) {
        btnNewUsuario.addEventListener("click", async () => {
        navigateTo("/newusuario");
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
