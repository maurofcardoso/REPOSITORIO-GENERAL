import { navigateTo } from "../../../router/router";
import { addUsuario } from "../../../services/organization/addUsuario.js";

export const useNewUsuario = async (view) => {
  const divElement = document.createElement("div");
  divElement.classList = "newUsuario";
  divElement.innerHTML = view;

  const btnAddTicket = divElement.querySelector("#btnAddUsuario");

  if (btnAddTicket) {
    btnAddTicket.addEventListener("click", async () => {
      const usernameUsuario = divElement.querySelector("#usernameUsuario");
      const nameUsuario = divElement.querySelector("#nameUsuario");
      const apellidoUsuario = divElement.querySelector("#apellidoUsuario");
      const telefonoUsuario = divElement.querySelector("#telefonoUsuario");
      const dniUsuario = divElement.querySelector("#dniUsuario");
      const emailUsuario = divElement.querySelector("#emailUsuario");
      const rolUsuario = divElement.querySelector("#rolUsuario");

      if(usernameUsuario.value != "" && nameUsuario.value != "" && apellidoUsuario.value != "" && telefonoUsuario.value != "" 
        && dniUsuario.value != "" && emailUsuario.value != "" && rolUsuario.value != "")
      {
        const request = {
            userName: usernameUsuario.value,
            firstName: nameUsuario.value,
            lastName: apellidoUsuario.value,
            phone: telefonoUsuario.value,
            dni: dniUsuario.value,
            email: emailUsuario.value,
            rolId: parseInt(rolUsuario.value)
        };
        console.log(request)
  
        await addUsuario(request);
        navigateTo("/usuarios");
      }
      else
      {
        alertify.error('ERROR TODOS los campos son obligatorios');
      }      
    });
  }
  return divElement;
};
