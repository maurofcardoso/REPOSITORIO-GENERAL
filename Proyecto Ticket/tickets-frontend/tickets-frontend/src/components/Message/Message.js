import './styles/message.css';

let timer;

export const Message = (value, type) => {
	const divElement = document.createElement('div');
	divElement.id = 'message';
	divElement.innerHTML = `<div class="${type}"> ${value} </div>`;
	document.getElementById('app').appendChild(divElement);
	timer = setInterval(closeMessage, 2000);
};

const closeMessage = () => {
	let div = document.querySelector('#message');
	if (!!div) div.remove();
	clearInterval(timer);
};
