import { navigateTo } from "../../../router/router";
import { addComment } from "../../../services";

export const useAddComment = async (view, ticket) => {

	const divElement = document.createElement('div');
	divElement.classList.add('newComment');		
	divElement.innerHTML = view;
	
    const btnAddComment = divElement.querySelector("#btnAddComment");
    btnAddComment.addEventListener("click", async () => {
      const taComment = divElement.querySelector("#taComment");   

      if(taComment.value == "")
      {
        alertify.error("ERROR el campo de comentario NO puede estar vacio")
      }
      else
      {
        var a = await addComment(ticket.idTicket, taComment.value);
        navigateTo("/tickets/" + ticket.idTicket);
      }
    });

	return divElement;
};
