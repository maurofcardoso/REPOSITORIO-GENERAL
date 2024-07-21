import { getStorage } from "../../../helpers/storage";
import { login } from "../../../services";

export const useLogin = async (view) => {

	//Segurizo las paginas. SI ya esta logueado mandarlo al home
	const token = getStorage("tickets_token");
	if(!!token) return navigateTo("/");

    const divElement = document.createElement('div');
	divElement.classList = 'login';
	divElement.innerHTML = view;

	const btnLogin = divElement.querySelector('#btnLogin');
	btnLogin.addEventListener('click', async () => {
		
		const password = divElement.querySelector('#password').value;
		const user = divElement.querySelector('#user').value;

		await login(user, password);	
	});

	return divElement;
}