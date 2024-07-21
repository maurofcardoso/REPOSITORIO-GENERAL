import './styles/NotFound.css';

export const NotFound = () => {
	let view = `
		<h1>404</h1>
		<h2>NOT FOUND</h2>	
	`;

	const divElement = document.createElement("div");
	divElement.classList = "notfound";
	divElement.innerHTML = view;

	return divElement;
};


