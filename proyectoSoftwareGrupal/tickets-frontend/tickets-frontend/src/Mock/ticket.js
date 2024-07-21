export const ticket = {
  idTicket: 4,
  idUser: 4,
  ticketComments: [],
  ticketLogs: [],
  dateCreated:"17/11/2022",  
  ticketStatus: {
    idTicketStatus: 1,
    description: "Pendiente",
  },
  ticketPriority: {
    idPriority: 1,
    description: "Baja",
  },
  ticketBody: {
    idTicketBody: 5,
    title: "Titulo del ticket",
    description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eu dapibus mi, at tincidunt justo. Maecenas ornare enim at felis consequat, nec convallis velit congue. Maecenas ac ligula vitae justo tempus tincidunt ut vitae ex. Nulla volutpat eros erat, cursus mattis turpis iaculis vel. Nam pretium eros eu efficitur consequat. Sed dictum ex ut condimentum sodales. Suspendisse non nisl dui. Nullam aliquam bibendum porta. Duis ornare magna ut ipsum consectetur dictum et eget ligula. Cras eget lacus ultricies, mollis ante a, efficitur ligula. In condimentum vulputate libero et suscipit. Nulla imperdiet tincidunt quam ut consectetur. Nunc vitae neque a risus posuere viverra. Vestibulum auctor ornare varius. Phasellus cursus tellus et justo pharetra posuere. Duis dictum justo ac nisl.",
    file: "url",
  },
  ticketCount: {
    idTicketCount: 5,
    countOpen: 0,
    countApproved: 0,
    countDisapproved: 0,
  },
  ticketCategory: {
    idTicketCategory: 3,
    name: "Reparacion Hardware",
    description:
      "Categoria responsable de gestionar las reparaciones de Hardware",
    reqApproval: true,
    minApprovers: 1,
    idAreadestino: 3,
    active: true,
  },
};
