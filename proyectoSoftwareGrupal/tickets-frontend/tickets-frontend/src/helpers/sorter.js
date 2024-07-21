import Sortable from "sortablejs";

export const sorterList = (element, onAdd) => {

  const status = {
    todo: 1,
    doing: 2,
    done: 3,            
  };

  Sortable.create(element, {
    group: { name: "tickets" },
    animation: 150,
    easing: "cubic-bezier(0.895, 0.03, 0.685, 0.22)",
    draggable: ".card",
    chosenClass: "chosen",
    onAdd: (e) => {
      onAdd(e.item.id, status[e.to.id]);
    },
  });
};
