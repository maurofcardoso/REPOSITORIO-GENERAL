import { useAddComment } from './hooks/useAddComment';
import './styles/addcomment.css';

export const AddComment = async (card, ticket) => {
	let view = `
        <h2>Nuevo comentario</h2>	
        <textarea name="Text1" cols="40" rows="5" id="taComment"></textarea>
        <button id="btnAddComment">Enviar</button>
    `;
	return useAddComment(view, card);
};