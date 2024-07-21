import "./styles/publicLayout.css";

export const PublicLayout = async (children) => {
  const divElement = document.createElement("div");
  divElement.id = "publicLayout";
  divElement.appendChild(await children());

  return divElement;
};
