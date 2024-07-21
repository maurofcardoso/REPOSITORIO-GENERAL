import { UserProfile } from "../../../components";
import { getStorage } from "../../../helpers/storage";
import { navigateTo } from "../../../router/router";

export const useAuthLayout = async (view, children) => {

	//Segurizo las paginas. SI No esta logueado mandarlo al login
	const token = getStorage("tickets_token");
	if(!token) return navigateTo("/login");

    const divElement = document.createElement('div');
	divElement.classList = 'authLayout';
	divElement.innerHTML = view;

	const main = divElement.querySelector('#children');
	main.appendChild(await children());

	const header = divElement.querySelector('#header');
	header.appendChild(UserProfile());

    const nav = divElement.querySelectorAll('.navbar button');
    nav.forEach((el) => {
		el.addEventListener('click', (e) => {
			const { textContent } = e.target;
			navigateTo(`/${textContent.trim()}`);
		});
	});

    return divElement;
}