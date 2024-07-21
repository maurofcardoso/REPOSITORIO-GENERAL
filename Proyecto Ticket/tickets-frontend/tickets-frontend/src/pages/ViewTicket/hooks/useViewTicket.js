import { AddComment, Comment, Modal } from "../../../components";
import { navigateTo } from "../../../router/router";
import { addComment, updateState } from "../../../services";
import { updateCategory } from "../../../services/tickets/updateCategory"

export const useViewTicket = async (view, ticket) => {
  const divElement = document.createElement("div");
  divElement.classList = "viewTicket";
  divElement.innerHTML = view;

  const slStatus = divElement.querySelector("#slStatus");
  slStatus.addEventListener("change", async (event) => {
    const value = event.target.value;
    divElement.appendChild(await Modal(await AddComment(ticket)));
    updateState(ticket.idTicket, value);
  });

  const slCategory = divElement.querySelector("#slCategory");
  slCategory.addEventListener("change", async (event) => {
    const value = event.target.value;
    divElement.appendChild(await Modal(await AddComment(ticket)));
    updateCategory(ticket.idTicket, value);
  });

  const btnAttach = divElement.querySelector("#btnAttach");

  if (btnAttach) {
    btnAttach.addEventListener("click", async () => {
      window.open(ticket.ticketBody.file, "_blank");
    });
  } 

  const comments = divElement.querySelector("#comments");

  for (let index = 0; index < ticket.ticketComments.length; index++) {
    const orderTickets =  ticket.ticketComments.sort((a,b) => a.idComment < b.idComment ? 1 : -1)
    const comment = orderTickets[index];
    comments.appendChild(await Comment(comment));    
  }

  const footer = divElement.querySelector("#footer");
  footer.prepend(await AddComment(ticket));

  return divElement;
};
