import { navigateTo } from "../../../router/router";
import { addArea } from "../../../services/organization/addArea";

export const useNewArea = async (view) => {
  const divElement = document.createElement("div");
  divElement.classList = "newArea";
  divElement.innerHTML = view;

  const btnAddTicket = divElement.querySelector("#btnAddArea");

  if (btnAddTicket) {
    btnAddTicket.addEventListener("click", async () => {
      const nameArea = divElement.querySelector("#nameArea");
      const descripcion = divElement.querySelector("#descripcion");

      if(nameArea.value != "" && descripcion.value != "")
      {
        const request = {
          nameArea: nameArea.value,
          description: descripcion.value,
        };
  
        await addArea(request);
        navigateTo("/areas");
      }
      else
      {
        alertify.error('ERROR TODOS los campos son obligatorios');
      }      
    });
  }
  return divElement;
};
