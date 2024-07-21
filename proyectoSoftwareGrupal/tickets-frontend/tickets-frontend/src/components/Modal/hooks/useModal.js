export const useModal = async (view, children) => {
	const divElement = document.createElement('div');
	divElement.classList.add('modal');	
	divElement.innerHTML = view;

    const childrenModal = divElement.querySelector("#childrenModal"); 
    childrenModal.appendChild(children);

	return divElement;
};
