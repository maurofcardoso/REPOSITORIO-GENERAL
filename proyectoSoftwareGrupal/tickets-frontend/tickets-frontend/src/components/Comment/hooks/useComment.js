import { getUserData } from "../../../services";

export const useComment = async (view, comment) => {
	const divElement = document.createElement('div');
	divElement.classList.add('comment');	
	divElement.innerHTML = view;

    const dataUser = await getUserData(comment.idUser);

    const cite = divElement.querySelector("#cite"); 
    cite.innerHTML = dataUser.firstName + " " + dataUser.lastName;

	return divElement;
};
