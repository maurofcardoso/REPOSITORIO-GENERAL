import { navigateTo } from "../../../router/router";
import { addCategoria } from "../../../services/organization/addCategoria";

export const useNewCategoria = async (view) => {
  const divElement = document.createElement("div");
  divElement.classList = "newCategoria";
  divElement.innerHTML = view;

  const btnAddTicket = divElement.querySelector("#btnAddCategoria");

  if (btnAddTicket) {
    btnAddTicket.addEventListener("click", async () => {
      const slareaDestino = divElement.querySelector("#sl-areaDestino");
      
      const nombreCategoria = divElement.querySelector("#nombreCategoria");
      const descripcion = divElement.querySelector("#descripcion");

      if(slareaDestino.value != "" && nombreCategoria.value != "" && descripcion.value != "")
      {
        const request = {
          name: nombreCategoria.value,
          description: descripcion.value,
          reqApproval: false,
          minApprovers: 0,
          idAreadestino: slareaDestino.value
        };
  
        await addCategoria(request);
        navigateTo("/Categorias");
      }
      else
      {
        alertify.error('ERROR TODOS los campos son obligatorios');
      }
    });
  }
  return divElement;
};
